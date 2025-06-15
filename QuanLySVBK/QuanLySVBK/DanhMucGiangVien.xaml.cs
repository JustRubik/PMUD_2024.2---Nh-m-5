using Microsoft.Data.SqlClient;
using QuanLySVBK.DBHelpers;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using static QuanLySVBK.DBHelpers.ListHelper;

namespace QuanLySVBK
{
    public partial class DanhMucGiangVien : UserControl
    {
        private readonly string _role;

        public ObservableCollection<GiangVien> DanhSachGiangVien { get; set; } = [];

        public DanhMucGiangVien(string role)
        {
            InitializeComponent();
            dgGiangVien.ItemsSource = DanhSachGiangVien;

            CboQueQuan.ItemsSource = TemplateList.Cities;

            TxtMaVien.ItemsSource = TemplateList.MaViens;

            LoadGiangVienTuCSDL();
            _role = role;
            ApDungPhanQuyen();
        }

        private void LoadGiangVienTuCSDL()
        {
            DanhSachGiangVien.Clear();
            try
            {
                using SqlConnection conn = new(App_Config.connectionString);
                conn.Open();
                using SqlCommand cmd = new(ListHelper.GetAllGiangVien, conn);
                using SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    GiangVien gv = new()
                    {
                        MaGV = reader["MaGV"].ToString(),
                        HoTen = reader["HoTen"].ToString(),
                        GioiTinh = reader["GioiTinh"].ToString(),
                        NgaySinh = reader["NgaySinh"] == DBNull.Value ? null : reader.GetDateTime(reader.GetOrdinal("NgaySinh")),
                        QueQuan = reader["QueQuan"]?.ToString(),
                        CanCuocCongDan = reader["CanCuocCongDan"]?.ToString(),
                        SoDienThoai = reader["SoDienThoai"]?.ToString(),
                        MaVien = reader["MaVien"]?.ToString()
                    };
                    DanhSachGiangVien.Add(gv);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        private bool ThongTinGiangVienHopLe(out string? errorMsg)
        {
            if (!ValidationHelper.KiemTraTrong(TxtGiangVien.Text, "Mã giảng viên không được để trống.", out errorMsg) ||
                !ValidationHelper.KiemTraTrong(TxtHoTen.Text, "Họ tên không được để trống.", out errorMsg) ||
                (RbNam.IsChecked == false && RbNu.IsChecked == false && (errorMsg = "Vui lòng chọn giới tính.") != null) ||
                (DpNgaySinh.SelectedDate == null && (errorMsg = "Ngày sinh không được để trống.") != null) ||
                !ValidationHelper.KiemTraTrong(CboQueQuan.Text, "Vui lòng chọn quê quán.", out errorMsg) ||
                !ValidationHelper.KiemTraTrong(TxtCCCD.Text, "Căn cước công dân không được để trống.", out errorMsg) ||
                !ValidationHelper.KiemTraTrong(TxtSoDienThoai.Text, "Số điện thoại không được để trống.", out errorMsg) ||
                !ValidationHelper.KiemTraTrong(TxtMaVien.Text, "Mã viện không được để trống.", out errorMsg))
            {
                return false;
            }

            errorMsg = null;
            return true;
        }



        private void BtnThemMoi_Click(object sender, RoutedEventArgs e)
        {

            if (!ThongTinGiangVienHopLe(out string? errorMsg))
            {
                MessageBox.Show(errorMsg, "Thiếu thông tin", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }


            GiangVien gv = new()
            {
                MaGV = TxtGiangVien.Text,
                HoTen = TxtHoTen.Text,
                GioiTinh = RbNam.IsChecked == true ? "Nam" : "Nữ",
                NgaySinh = DpNgaySinh.SelectedDate,
                QueQuan = CboQueQuan.Text,
                CanCuocCongDan = TxtCCCD.Text,
                SoDienThoai = TxtSoDienThoai.Text,
                MaVien = TxtMaVien.Text
            };

            try
            {
                using SqlConnection conn = new(App_Config.connectionString);
                conn.Open();
                using SqlCommand cmd = new(ListHelper.InsertGiangVien, conn);
                cmd.Parameters.AddWithValue("@MaGV", gv.MaGV);
                cmd.Parameters.AddWithValue("@HoTen", gv.HoTen);
                cmd.Parameters.AddWithValue("@GioiTinh", gv.GioiTinh);
                cmd.Parameters.AddWithValue("@NgaySinh", gv.NgaySinh ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@QueQuan", gv.QueQuan ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@CCCD", gv.CanCuocCongDan ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@SoDT", gv.SoDienThoai ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@MaVien", gv.MaVien ?? (object)DBNull.Value);
                cmd.ExecuteNonQuery();

                LoadGiangVienTuCSDL();
                MessageBox.Show("Đã thêm giảng viên vào CSDL.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm mới: " + ex.Message);
            }
        }


        private void BtnXoa_Click(object sender, RoutedEventArgs e)
        {
            if (_role == "student" || _role == "lecturer")
            {
                MessageBox.Show("Bạn không có quyền xóa giảng viên.");
                return;
            }

            if (dgGiangVien.SelectedItem is GiangVien gv)
            {
                try
                {
                    using SqlConnection conn = new(App_Config.connectionString);
                    conn.Open();
                    using SqlCommand cmd = new(ListHelper.DeleteGiangVienByMaGV, conn);
                    cmd.Parameters.AddWithValue("@MaGV", gv.MaGV);
                    cmd.ExecuteNonQuery();

                    LoadGiangVienTuCSDL();
                    MessageBox.Show("Đã xóa giảng viên.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Hãy chọn một giảng viên để xóa.");
            }
        }

        private void BtnLuu_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using SqlConnection conn = new(App_Config.connectionString);
                conn.Open();

                string query = ListHelper.GetUpsertGiangVienQuery();

                foreach (var item in dgGiangVien.Items)
                {
                    if (item is not DataRowView && item != CollectionView.NewItemPlaceholder)
                    {
                        if (item is GiangVien gv)
                        {
                            using SqlCommand cmd = new(query, conn);

                            cmd.Parameters.AddWithValue("@MaGV", gv.MaGV);
                            cmd.Parameters.AddWithValue("@HoTen", gv.HoTen);
                            cmd.Parameters.AddWithValue("@GioiTinh", gv.GioiTinh);
                            cmd.Parameters.AddWithValue("@NgaySinh", gv.NgaySinh ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@QueQuan", gv.QueQuan ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@CCCD", gv.CanCuocCongDan ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@SoDT", gv.SoDienThoai ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@MaVien", gv.MaVien ?? (object)DBNull.Value);

                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                MessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi lưu: " + ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnTimKiem_Click(object sender, RoutedEventArgs e)
        {
            string maGV = TxtGiangVien.Text.Trim().ToLower();
            string hoTen = TxtHoTen.Text.Trim().ToLower();
            string gioiTinh = RbNam.IsChecked == true ? "nam" :
                              RbNu.IsChecked == true ? "nữ" : "";
            string queQuan = CboQueQuan.Text.Trim().ToLower();
            string cccd = TxtCCCD.Text.Trim().ToLower();
            string soDienThoai = TxtSoDienThoai.Text.Trim().ToLower();
            string maVien = TxtMaVien.Text.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(maGV) &&
                string.IsNullOrWhiteSpace(hoTen) &&
                string.IsNullOrWhiteSpace(gioiTinh) &&
                string.IsNullOrWhiteSpace(queQuan) &&
                string.IsNullOrWhiteSpace(cccd) &&
                string.IsNullOrWhiteSpace(soDienThoai) &&
                string.IsNullOrWhiteSpace(maVien))
            {
                MessageBox.Show("Vui lòng nhập ít nhất một từ khóa để tìm kiếm.");
                return;
            }

            DanhSachGiangVien.Clear();

            try
            {
                using SqlConnection conn = new(App_Config.connectionString);
                conn.Open();

                using SqlCommand cmd = new(SearchGiangVienByKeyWord(), conn);
                cmd.Parameters.AddWithValue("@MaGV", string.IsNullOrWhiteSpace(maGV) ? DBNull.Value : $"%{maGV}%");
                cmd.Parameters.AddWithValue("@HoTen", string.IsNullOrWhiteSpace(hoTen) ? DBNull.Value : $"%{hoTen}%");
                cmd.Parameters.AddWithValue("@GioiTinh", string.IsNullOrWhiteSpace(gioiTinh) ? DBNull.Value : $"%{gioiTinh}%");
                cmd.Parameters.AddWithValue("@QueQuan", string.IsNullOrWhiteSpace(queQuan) ? DBNull.Value : $"%{queQuan}%");
                cmd.Parameters.AddWithValue("@CCCD", string.IsNullOrWhiteSpace(cccd) ? DBNull.Value : $"%{cccd}%");
                cmd.Parameters.AddWithValue("@SoDT", string.IsNullOrWhiteSpace(soDienThoai) ? DBNull.Value : $"%{soDienThoai}%");
                cmd.Parameters.AddWithValue("@MaVien", string.IsNullOrWhiteSpace(maVien) ? DBNull.Value : $"%{maVien}%");

                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DanhSachGiangVien.Add(new GiangVien
                    {
                        MaGV = reader["MaGV"]?.ToString(),
                        HoTen = reader["HoTen"]?.ToString(),
                        GioiTinh = reader["GioiTinh"]?.ToString(),
                        NgaySinh = reader["NgaySinh"] == DBNull.Value ? null : reader.GetDateTime(reader.GetOrdinal("NgaySinh")),
                        QueQuan = reader["QueQuan"]?.ToString(),
                        CanCuocCongDan = reader["CanCuocCongDan"]?.ToString(),
                        SoDienThoai = reader["SoDienThoai"]?.ToString(),
                        MaVien = reader["MaVien"]?.ToString()
                    });
                }

                if (DanhSachGiangVien.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy giảng viên phù hợp.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message);
            }
        }





        private void BtnInDS_Click(object sender, RoutedEventArgs e)
        {
            LoadGiangVienTuCSDL();
        }

        private void ApDungPhanQuyen()
        {
            if (_role is "student" or "lecturer")
            {
                BtnThemMoi.Visibility = Visibility.Collapsed;
                BtnXoa.Visibility = Visibility.Collapsed;
                BtnLuu.Visibility = Visibility.Collapsed;
                BtnThemMoi.IsEnabled = false;
                BtnXoa.IsEnabled = false;
                BtnLuu.IsEnabled = false;
            }
        }
    }
}
