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

        private const string connectionString = "Server=admin-pc\\sqlexpress;Database=QuanLyDiemSVBK;Trusted_Connection=True;TrustServerCertificate=True;";
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
                using SqlConnection conn = new(connectionString);
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
                using SqlConnection conn = new(connectionString);
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
                    using SqlConnection conn = new(connectionString);
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
                using SqlConnection conn = new(connectionString);
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
            string keyword_HoTen = TxtHoTen.Text.Trim().ToLower();
            string keyword_MaSV = TxtSinhVien.Text.Trim().ToLower();
            string keyword_SoDT = TxtSoDienThoai.Text.Trim().ToLower();
            string keyword_CCCD = TxtCCCD.Text.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(keyword_HoTen) || string.IsNullOrWhiteSpace(keyword_MaSV) || string.IsNullOrWhiteSpace(keyword_SoDT) || string.IsNullOrWhiteSpace(keyword_SoDT))
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm.\nHọ tên, mã sinh viên, mã ngành.");
                return;
            }

            DanhSachSinhVien.Clear();

            try
            {
                using SqlConnection conn = new(connectionString);
                conn.Open();

                string query = SearchSinhVienByHoTen;

                using SqlCommand cmd = new(query, conn);
                cmd.Parameters.AddWithValue("@keyword_HoTen", "%" + keyword_HoTen + "%");
                cmd.Parameters.AddWithValue("@keyword_MaSV", "%" + keyword_MaSV + "%");
                cmd.Parameters.AddWithValue("@keyword_SoDT", "%" + keyword_SoDT + "%");
                cmd.Parameters.AddWithValue("@keyword_CCCD", "%" + keyword_HoTen + "%");

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

                if (DanhSachSinhVien.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy sinh viên phù hợp.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
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
