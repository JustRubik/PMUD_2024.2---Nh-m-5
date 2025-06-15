using Microsoft.Data.SqlClient;
using QuanLySVBK.DBHelpers;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using static QuanLySVBK.DBHelpers.ListHelper;

namespace QuanLySVBK
{
    public partial class DanhMucKhoaVien : UserControl
    {
        private readonly ObservableCollection<Vien> danhSachVien = [];
        private readonly string _role;

        public DanhMucKhoaVien(string role)
        {
            InitializeComponent();
            dgKhoaVien.ItemsSource = danhSachVien;
            LoadVien();
            _role = role;
            ApDungPhanQuyen();
        }

        private void LoadVien()
        {
            danhSachVien.Clear();

            try
            {
                using SqlConnection conn = new(App_Config.connectionString);
                conn.Open();
                using SqlCommand cmd = new(GetAllVien, conn);
                using SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    danhSachVien.Add(new Vien
                    {
                        MaVien = reader["MaVien"].ToString(),
                        TenVien = reader["TenVien"].ToString(),
                        VienTruong = reader["VienTruong"].ToString(),
                        Website = reader["Website"].ToString(),
                        DiaChiVanPhong = reader["DiaChiVanPhong"].ToString()
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu viện: " + ex.Message);
            }
        }

        private void BtnThemMoi_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtMaVien.Text))
            {
                MessageBox.Show("Vui lòng nhập mã viện!");
                return;
            }

            try
            {
                using SqlConnection conn = new(App_Config.connectionString);
                conn.Open();
                using SqlCommand cmd = new(InsertVien, conn);
                cmd.Parameters.AddWithValue("@MaVien", TxtMaVien.Text.Trim());
                cmd.Parameters.AddWithValue("@TenVien", TxtTenVien.Text.Trim());
                cmd.Parameters.AddWithValue("@VienTruong", TxtVienTruong.Text.Trim());
                cmd.Parameters.AddWithValue("@Website", TxtWebsite.Text.Trim());
                cmd.Parameters.AddWithValue("@DiaChi", TxtDiaChi.Text.Trim());

                cmd.ExecuteNonQuery();
                LoadVien();
                MessageBox.Show("Thêm viện thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm viện: " + ex.Message);
            }
        }

        private void BtnXoa_Click(object sender, RoutedEventArgs e)
        {
            if (_role == "student" || _role == "lecturer")
            {
                MessageBox.Show("Bạn không có quyền xóa viện.");
                return;
            }

            if (dgKhoaVien.SelectedItem is Vien vien)
            {
                if (MessageBox.Show($"Xác nhận xóa viện '{vien.TenVien}'?", "Xác nhận", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    try
                    {
                        using SqlConnection conn = new(App_Config.connectionString);
                        conn.Open();
                        using SqlCommand cmd = new(ListHelper.DeleteVien, conn);
                        cmd.Parameters.AddWithValue("@MaVien", vien.MaVien);
                        cmd.ExecuteNonQuery();

                        LoadVien();
                        MessageBox.Show("Đã xóa viện.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Hãy chọn một viện để xóa.");
            }
        }


        private void BtnCapNhat_Click(object sender, RoutedEventArgs e)
        {
            if (dgKhoaVien.SelectedItem is not Vien)
            {
                return;
            }

            try
            {
                using SqlConnection conn = new(App_Config.connectionString);
                conn.Open();
                using SqlCommand cmd = new(UpdateVien, conn);
                cmd.Parameters.AddWithValue("@MaVien", TxtMaVien.Text.Trim());
                cmd.Parameters.AddWithValue("@TenVien", TxtTenVien.Text.Trim());
                cmd.Parameters.AddWithValue("@VienTruong", TxtVienTruong.Text.Trim());
                cmd.Parameters.AddWithValue("@Website", TxtWebsite.Text.Trim());
                cmd.Parameters.AddWithValue("@DiaChi", TxtDiaChi.Text.Trim());

                cmd.ExecuteNonQuery();
                LoadVien();
                MessageBox.Show("Cập nhật thông tin viện thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật viện: " + ex.Message);
            }
        }

        private void BtnTimKiem_Click(object sender, RoutedEventArgs e)
        {
            string maVien = TxtMaVien.Text.Trim().ToLower();
            string tenVien = TxtTenVien.Text.Trim().ToLower();
            string vienTruong = TxtVienTruong.Text.Trim().ToLower();
            string website = TxtWebsite.Text.Trim().ToLower();
            string diaChi = TxtDiaChi.Text.Trim().ToLower();

            // Nếu tất cả đều rỗng thì không tìm
            if (string.IsNullOrWhiteSpace(maVien) &&
                string.IsNullOrWhiteSpace(tenVien) &&
                string.IsNullOrWhiteSpace(vienTruong) &&
                string.IsNullOrWhiteSpace(website) &&
                string.IsNullOrWhiteSpace(diaChi))
            {
                MessageBox.Show("Vui lòng nhập ít nhất một từ khóa để tìm kiếm.");
                return;
            }

            danhSachVien.Clear();

            try
            {
                using SqlConnection conn = new(App_Config.connectionString);
                conn.Open();

                using SqlCommand cmd = new(ListHelper.SearchVienByKeyword, conn);
                cmd.Parameters.AddWithValue("@MaVien", string.IsNullOrWhiteSpace(maVien) ? DBNull.Value : $"%{maVien}%");
                cmd.Parameters.AddWithValue("@TenVien", string.IsNullOrWhiteSpace(tenVien) ? DBNull.Value : $"%{tenVien}%");
                cmd.Parameters.AddWithValue("@VienTruong", string.IsNullOrWhiteSpace(vienTruong) ? DBNull.Value : $"%{vienTruong}%");
                cmd.Parameters.AddWithValue("@Website", string.IsNullOrWhiteSpace(website) ? DBNull.Value : $"%{website}%");
                cmd.Parameters.AddWithValue("@DiaChiVanPhong", string.IsNullOrWhiteSpace(diaChi) ? DBNull.Value : $"%{diaChi}%");

                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    danhSachVien.Add(new Vien
                    {
                        MaVien = reader["MaVien"]?.ToString(),
                        TenVien = reader["TenVien"]?.ToString(),
                        VienTruong = reader["VienTruong"]?.ToString(),
                        Website = reader["Website"]?.ToString(),
                        DiaChiVanPhong = reader["DiaChiVanPhong"]?.ToString()
                    });
                }

                if (danhSachVien.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy viện nào phù hợp.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message);
            }
        }


        private void DgKhoaVien_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgKhoaVien.SelectedItem is not Vien vien) return;

            TxtMaVien.Text = vien.MaVien;
            TxtTenVien.Text = vien.TenVien;
            TxtVienTruong.Text = vien.VienTruong;
            TxtWebsite.Text = vien.Website;
            TxtDiaChi.Text = vien.DiaChiVanPhong;
        }

        private void BtnInDS_Click(object sender, RoutedEventArgs e)
        {
            LoadVien();
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
