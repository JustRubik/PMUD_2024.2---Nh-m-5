using Microsoft.Data.SqlClient;
using QuanLySVBK.DBHelpers;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace QuanLySVBK
{
    public partial class DanhMucHocPhan : UserControl
    {
        private readonly string _role;
        public ObservableCollection<HocPhan> DanhSachHocPhan { get; set; } = [];

        public DanhMucHocPhan(string role)
        {
            InitializeComponent();
            dgHocPhan.ItemsSource = DanhSachHocPhan;

            CboMaVien.ItemsSource = TemplateList.MaViens;

            LoadHocPhanTuCSDL();
            _role = role;
            ApDungPhanQuyen();
        }

        private void LoadHocPhanTuCSDL()
        {
            DanhSachHocPhan.Clear();
            try
            {
                using SqlConnection conn = new(App_Config.connectionString);
                conn.Open();
                using SqlCommand cmd = new(ListHelper.GetAllHocPhan, conn);
                using SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DanhSachHocPhan.Add(new HocPhan
                    {
                        MaHP = reader["MaHP"]?.ToString(),
                        TenHP = reader["TenHP"]?.ToString(),
                        MaVien = reader["MaVien"]?.ToString(),
                        SoTinChi = reader["SoTinChi"] is int soTC ? soTC : 0
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải học phần: " + ex.Message);
            }
        }

        private bool ThongTinHocPhanHopLe(out string? errorMsg)
        {
            if (!ValidationHelper.KiemTraTrong(TxtMaHP.Text, "Mã học phần không được để trống.", out errorMsg) ||
                !ValidationHelper.KiemTraTrong(TxtTenHP.Text, "Tên học phần không được để trống.", out errorMsg) ||
                !ValidationHelper.KiemTraTrong(TxtSoTinChi.Text, "Vui lòng nhập số tín chỉ", out errorMsg) ||
                !ValidationHelper.KiemTraTrong(CboMaVien.Text, "Mã viện không được để trống.", out errorMsg))
            {
                return false;
            }

            errorMsg = null;
            return true;
        }

        private void BtnThemMoi_Click(object sender, RoutedEventArgs e)
        {
            if (!ThongTinHocPhanHopLe(out string? errorMsg))
            {
                MessageBox.Show(errorMsg, "Thiếu thông tin", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!int.TryParse(TxtSoTinChi.Text, out int soTC))
            {
                MessageBox.Show("Số tín chỉ phải là số nguyên.");
                return;
            }

            try
            {
                using SqlConnection conn = new(App_Config.connectionString);
                conn.Open();
                using SqlCommand cmd = new(ListHelper.InsertHocPhan, conn);
                cmd.Parameters.AddWithValue("@MaHP", TxtMaHP.Text);
                cmd.Parameters.AddWithValue("@TenHP", TxtTenHP.Text);
                cmd.Parameters.AddWithValue("@MaVien", CboMaVien.Text);
                cmd.Parameters.AddWithValue("@SoTC", soTC);
                cmd.ExecuteNonQuery();

                LoadHocPhanTuCSDL();
                MessageBox.Show("Đã thêm học phần.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm học phần: " + ex.Message);
            }
        }

        private void BtnXoa_Click(object sender, RoutedEventArgs e)
        {
            if (_role == "student" || _role == "lecturer")
            {
                MessageBox.Show("Bạn không có quyền xóa học phần.");
                return;
            }

            if (dgHocPhan.SelectedItem is HocPhan hp)
            {
                try
                {
                    using SqlConnection conn = new(App_Config.connectionString);
                    conn.Open();
                    using SqlCommand cmd = new(ListHelper.DeleteHocPhanByMaHP, conn);
                    cmd.Parameters.AddWithValue("@MaHP", hp.MaHP);
                    cmd.ExecuteNonQuery();

                    LoadHocPhanTuCSDL();
                    MessageBox.Show("Đã xóa học phần.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Hãy chọn một học phần để xóa.");
            }
        }

        private void BtnCapNhat_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using SqlConnection conn = new(App_Config.connectionString);
                conn.Open();

                string query = ListHelper.GetUpsertHocPhanQuery();

                foreach (var item in dgHocPhan.Items)
                {
                    if (item is not DataRowView && item != CollectionView.NewItemPlaceholder)
                    {
                        if (item is HocPhan hp)
                        {
                            using SqlCommand cmd = new(query, conn);
                            cmd.Parameters.AddWithValue("@MaHP", hp.MaHP);
                            cmd.Parameters.AddWithValue("@TenHP", hp.TenHP);
                            cmd.Parameters.AddWithValue("@MaVien", hp.MaVien);
                            cmd.Parameters.AddWithValue("@SoTC", hp.SoTinChi);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi cập nhật: " + ex.Message);
            }
        }

        private void BtnTimKiem_Click(object sender, RoutedEventArgs e)
        {
            string maHP = TxtMaHP.Text.Trim().ToLower();
            string tenHP = TxtTenHP.Text.Trim().ToLower();
            string maVien = CboMaVien.Text.Trim().ToLower();
            string soTinChi = TxtSoTinChi.Text.Trim();

            if (string.IsNullOrWhiteSpace(maHP) && 
                string.IsNullOrWhiteSpace(tenHP) && 
                string.IsNullOrWhiteSpace(maVien) &&
                string.IsNullOrWhiteSpace(soTinChi))
            {
                MessageBox.Show("Vui lòng nhập ít nhất một từ khóa tìm kiếm.");
                return;
            }

            DanhSachHocPhan.Clear();
            try
            {
                using SqlConnection conn = new(App_Config.connectionString);
                conn.Open();
                using SqlCommand cmd = new(ListHelper.SearchHocPhanByKeyWord(), conn);
                cmd.Parameters.AddWithValue("@MaHP", string.IsNullOrWhiteSpace(maHP) ? DBNull.Value : $"%{maHP}%");
                cmd.Parameters.AddWithValue("@TenHP", string.IsNullOrWhiteSpace(tenHP) ? DBNull.Value : $"%{tenHP}%");
                cmd.Parameters.AddWithValue("@MaVien", string.IsNullOrWhiteSpace(maVien) ? DBNull.Value : $"%{maVien}%");
                
                if (string.IsNullOrWhiteSpace(soTinChi))
                    cmd.Parameters.AddWithValue("@SoTC", DBNull.Value);
                else if (int.TryParse(soTinChi, out int soTC))
                    cmd.Parameters.AddWithValue("@SoTC", soTC);
                else
                {
                    MessageBox.Show("Số tín chỉ phải là số nguyên.");
                    return;
                }

                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DanhSachHocPhan.Add(new HocPhan
                    {
                        MaHP = reader["MaHP"]?.ToString(),
                        TenHP = reader["TenHP"]?.ToString(),
                        MaVien = reader["MaVien"]?.ToString(),
                        SoTinChi = reader["SoTinChi"] is int stc ? stc : 0
                    });
                }

                if (DanhSachHocPhan.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy học phần phù hợp.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message);
            }
        }

        private void BtnInDS_Click(object sender, RoutedEventArgs e)
        {
            LoadHocPhanTuCSDL();
        }

        private void ApDungPhanQuyen()
        {
            if (_role == "student" || _role == "lecturer")
            {
                BtnThemMoi.IsEnabled = false;
                BtnXoa.IsEnabled = false;
                BtnCapNhat.IsEnabled = false;
                BtnThemMoi.Visibility = Visibility.Collapsed;
                BtnXoa.Visibility = Visibility.Collapsed;
                BtnCapNhat.Visibility = Visibility.Collapsed;
            }
        }
    }
}
