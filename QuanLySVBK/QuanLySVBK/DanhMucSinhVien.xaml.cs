using Microsoft.Data.SqlClient;
using QuanLySVBK.DBHelpers;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using static QuanLySVBK.DBHelpers.ListHelper;

namespace QuanLySVBK
{
    public partial class DanhMucSinhVien : UserControl
    {
        private readonly string _role;
        public ObservableCollection<SinhVien> DanhSachSinhVien { get; set; } = [];

        public DanhMucSinhVien(string role)
        {
            InitializeComponent();
            dgSinhVien.ItemsSource = DanhSachSinhVien;

            CboQueQuan.ItemsSource = TemplateList.Cities;
            TxtMaNganh.ItemsSource = TemplateList.MaNganhs;

            LoadSinhVienTuCSDL();
            _role = role;
            ApDungPhanQuyen();
        }

        private void LoadSinhVienTuCSDL()
        {
            DanhSachSinhVien.Clear();
            try
            {
                using SqlConnection conn = new(App_Config.connectionString);
                conn.Open();
                using SqlCommand cmd = new(ListHelper.GetAllSinhVien, conn);
                using SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    SinhVien sv = new()
                    {
                        MaSV = reader["MaSV"].ToString(),
                        HoTen = reader["HoTen"].ToString(),
                        GioiTinh = reader["GioiTinh"].ToString(),
                        NgaySinh = reader["NgaySinh"] == DBNull.Value ? null : reader.GetDateTime(reader.GetOrdinal("NgaySinh")),
                        QueQuan = reader["QueQuan"]?.ToString(),
                        CanCuocCongDan = reader["CanCuocCongDan"]?.ToString(),
                        SoDienThoai = reader["SoDienThoai"]?.ToString(),
                        MaNganh = reader["MaNganh"]?.ToString()
                    };
                    DanhSachSinhVien.Add(sv);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        private bool ThongTinSinhVienHopLe(out string? errorMsg)
        {
            if (!ValidationHelper.KiemTraTrong(TxtSinhVien.Text, "Mã sinh viên không được để trống.", out errorMsg) ||
                !ValidationHelper.KiemTraTrong(TxtHoTen.Text, "Họ tên không được để trống.", out errorMsg) ||
                (RbNam.IsChecked == false && RbNu.IsChecked == false && (errorMsg = "Vui lòng chọn giới tính.") != null) ||
                (DpNgaySinh.SelectedDate == null && (errorMsg = "Ngày sinh không được để trống.") != null) ||
                !ValidationHelper.KiemTraTrong(CboQueQuan.Text, "Vui lòng chọn quê quán.", out errorMsg) ||
                !ValidationHelper.KiemTraTrong(TxtCCCD.Text, "Căn cước công dân không được để trống.", out errorMsg) ||
                !ValidationHelper.KiemTraTrong(TxtSoDienThoai.Text, "Số điện thoại không được để trống.", out errorMsg) ||
                !ValidationHelper.KiemTraTrong(TxtMaNganh.Text, "Mã ngành không được để trống.", out errorMsg))
            {
                return false;
            }

            errorMsg = null;
            return true;
        }

        private void BtnThemMoi_Click(object sender, RoutedEventArgs e)
        {
            if (!ThongTinSinhVienHopLe(out string? errorMsg))
            {
                MessageBox.Show(errorMsg, "Thiếu thông tin", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            SinhVien sv = new()
            {
                MaSV = TxtSinhVien.Text,
                HoTen = TxtHoTen.Text,
                GioiTinh = RbNam.IsChecked == true ? "Nam" : "Nữ",
                NgaySinh = DpNgaySinh.SelectedDate,
                QueQuan = CboQueQuan.Text,
                CanCuocCongDan = TxtCCCD.Text,
                SoDienThoai = TxtSoDienThoai.Text,
                MaNganh = TxtMaNganh.Text
            };

            try
            {
                using SqlConnection conn = new(App_Config.connectionString);
                conn.Open();
                using SqlCommand cmd = new(ListHelper.InsertSinhVien, conn);
                cmd.Parameters.AddWithValue("@MaSV", sv.MaSV);
                cmd.Parameters.AddWithValue("@HoTen", sv.HoTen);
                cmd.Parameters.AddWithValue("@GioiTinh", sv.GioiTinh);
                cmd.Parameters.AddWithValue("@NgaySinh", sv.NgaySinh ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@QueQuan", sv.QueQuan ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@CCCD", sv.CanCuocCongDan ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@SoDT", sv.SoDienThoai ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@MaNganh", sv.MaNganh ?? (object)DBNull.Value);
                cmd.ExecuteNonQuery();

                LoadSinhVienTuCSDL();
                MessageBox.Show("Đã thêm sinh viên vào CSDL.");
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
                MessageBox.Show("Bạn không có quyền xóa sinh viên.");
                return;
            }

            if (dgSinhVien.SelectedItem is SinhVien sv)
            {
                try
                {
                    using SqlConnection conn = new(App_Config.connectionString);
                    conn.Open();
                    using SqlCommand cmd = new(ListHelper.DeleteSinhVienByMaSV, conn);
                    cmd.Parameters.AddWithValue("@MaSV", sv.MaSV);
                    cmd.ExecuteNonQuery();

                    LoadSinhVienTuCSDL();
                    MessageBox.Show("Đã xóa sinh viên.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Hãy chọn một sinh viên để xóa.");
            }
        }

        private void BtnLuu_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using SqlConnection conn = new(App_Config.connectionString);
                conn.Open();

                string query = ListHelper.GetUpsertSinhVienQuery();

                foreach (var item in dgSinhVien.Items)
                {
                    if (item is not DataRowView && item != CollectionView.NewItemPlaceholder)
                    {
                        if (item is SinhVien sv)
                        {
                            using SqlCommand cmd = new(query, conn);

                            cmd.Parameters.AddWithValue("@MaSV", sv.MaSV);
                            cmd.Parameters.AddWithValue("@HoTen", sv.HoTen);
                            cmd.Parameters.AddWithValue("@GioiTinh", sv.GioiTinh);
                            cmd.Parameters.AddWithValue("@NgaySinh", sv.NgaySinh ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@QueQuan", sv.QueQuan ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@CCCD", sv.CanCuocCongDan ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@SoDT", sv.SoDienThoai ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@MaNganh", sv.MaNganh ?? (object)DBNull.Value);

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
            string maSV = TxtSinhVien.Text.Trim().ToLower();
            string hoTen = TxtHoTen.Text.Trim().ToLower();
            string gioiTinh = RbNam.IsChecked == true ? "nam" :
                              RbNu.IsChecked == true ? "nữ" : "";
            string queQuan = CboQueQuan.Text.Trim().ToLower();
            string cccd = TxtCCCD.Text.Trim().ToLower();
            string soDienThoai = TxtSoDienThoai.Text.Trim().ToLower();
            string maNganh = TxtMaNganh.Text.Trim().ToLower();

            // Nếu tất cả đều rỗng thì không tìm
            if (string.IsNullOrWhiteSpace(maSV) &&
                string.IsNullOrWhiteSpace(hoTen) &&
                string.IsNullOrWhiteSpace(gioiTinh) &&
                string.IsNullOrWhiteSpace(queQuan) &&
                string.IsNullOrWhiteSpace(cccd) &&
                string.IsNullOrWhiteSpace(soDienThoai) &&
                string.IsNullOrWhiteSpace(maNganh))
            {
                MessageBox.Show("Vui lòng nhập ít nhất một từ khóa để tìm kiếm.");
                return;
            }

            DanhSachSinhVien.Clear();

            try
            {
                using SqlConnection conn = new(App_Config.connectionString);
                conn.Open();

                using SqlCommand cmd = new(SearchSinhVienByKeyWord(), conn);
                cmd.Parameters.AddWithValue("@MaSV", string.IsNullOrWhiteSpace(maSV) ? DBNull.Value : $"%{maSV}%");
                cmd.Parameters.AddWithValue("@HoTen", string.IsNullOrWhiteSpace(hoTen) ? DBNull.Value : $"%{hoTen}%");
                cmd.Parameters.AddWithValue("@GioiTinh", string.IsNullOrWhiteSpace(gioiTinh) ? DBNull.Value : $"%{gioiTinh}%");
                cmd.Parameters.AddWithValue("@QueQuan", string.IsNullOrWhiteSpace(queQuan) ? DBNull.Value : $"%{queQuan}%");
                cmd.Parameters.AddWithValue("@CCCD", string.IsNullOrWhiteSpace(cccd) ? DBNull.Value : $"%{cccd}%");
                cmd.Parameters.AddWithValue("@SoDT", string.IsNullOrWhiteSpace(soDienThoai) ? DBNull.Value : $"%{soDienThoai}%");
                cmd.Parameters.AddWithValue("@MaNganh", string.IsNullOrWhiteSpace(maNganh) ? DBNull.Value : $"%{maNganh}%");

                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DanhSachSinhVien.Add(new SinhVien
                    {
                        MaSV = reader["MaSV"]?.ToString(),
                        HoTen = reader["HoTen"]?.ToString(),
                        GioiTinh = reader["GioiTinh"]?.ToString(),
                        NgaySinh = reader["NgaySinh"] == DBNull.Value ? null : reader.GetDateTime(reader.GetOrdinal("NgaySinh")),
                        QueQuan = reader["QueQuan"]?.ToString(),
                        CanCuocCongDan = reader["CanCuocCongDan"]?.ToString(),
                        SoDienThoai = reader["SoDienThoai"]?.ToString(),
                        MaNganh = reader["MaNganh"]?.ToString()
                    });
                }

                if (DanhSachSinhVien.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy sinh viên nào phù hợp.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message);
            }
        }


        private void BtnInDS_Click(object sender, RoutedEventArgs e)
        {
            LoadSinhVienTuCSDL();
        }

        private void ApDungPhanQuyen()
        {
            if (_role == "student" || _role == "lecturer")
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
