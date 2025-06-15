using Microsoft.Data.SqlClient;
using QuanLySVBK.DBHelpers;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace QuanLySVBK
{
    public partial class DanhMucNganhDaoTao : UserControl
    {
        private readonly string? _role;
        public ObservableCollection<NganhModel> DanhSachNganh { get; set; } = [];
        private readonly string _connectionString = App_Config.connectionString;

        public DanhMucNganhDaoTao(string? role)
        {
            InitializeComponent();
            LoadComboBoxVien();
            LoadDanhSachNganh();
            _role = role;
            ApDungPhanQuyen();
        }

        private void LoadComboBoxVien()
        {
            using SqlConnection conn = new(_connectionString);
            conn.Open();
            string query = "SELECT MaVien FROM vien";

            using SqlCommand cmd = new(query, conn);
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                CboMaVien.Items.Add(reader["MaVien"].ToString());
            }
        }

        private void LoadDanhSachNganh()
        {
            DanhSachNganh.Clear();

            using SqlConnection conn = new(_connectionString);
            conn.Open();

            string query = @"
                SELECT n.MaNganh, n.TenNganh, n.MaVien, v.TenVien
                FROM nganhdaotao n
                JOIN vien v ON n.MaVien = v.MaVien";

            using SqlCommand cmd = new(query, conn);
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                DanhSachNganh.Add(new NganhModel
                {
                    MaNganh = reader["MaNganh"].ToString(),
                    TenNganh = reader["TenNganh"].ToString(),
                    MaVien = reader["MaVien"].ToString(),
                    TenVien = reader["TenVien"].ToString()
                });
            }

            dgNganhDaoTao.ItemsSource = DanhSachNganh;
        }

        private void BtnTimKiem_Click(object sender, RoutedEventArgs e)
        {
            string? maNganh = TxtMaNganh.Text.Trim();
            string? tenNganh = TxtTenNganh.Text.Trim();
            string? maVien = CboMaVien.SelectedItem?.ToString();

            var danhSachLoc = DanhSachNganh.Where(nganh =>
                (string.IsNullOrEmpty(maNganh) || (!string.IsNullOrEmpty(nganh.MaNganh) && nganh.MaNganh.Contains(maNganh, StringComparison.OrdinalIgnoreCase))) &&
                (string.IsNullOrEmpty(tenNganh) || (!string.IsNullOrEmpty(nganh.TenNganh) && nganh.TenNganh.Contains(tenNganh, StringComparison.OrdinalIgnoreCase))) &&
                (string.IsNullOrEmpty(maVien) || string.Equals(nganh.MaVien, maVien, StringComparison.OrdinalIgnoreCase))
            ).ToList();



            dgNganhDaoTao.ItemsSource = danhSachLoc;

            if (danhSachLoc.Count == 0)
            {
                MessageBox.Show("Không tìm thấy ngành phù hợp.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            if (string.IsNullOrEmpty(maNganh) && string.IsNullOrEmpty(tenNganh) && string.IsNullOrEmpty(maVien))
            {
                dgNganhDaoTao.ItemsSource = DanhSachNganh;
                return;
            }

        }


        private void BtnThemMoi_Click(object sender, RoutedEventArgs e)
        {
            string maNganh = TxtMaNganh.Text.Trim();
            string tenNganh = TxtTenNganh.Text.Trim();
            string maVien = CboMaVien.Text;

            if (string.IsNullOrEmpty(maNganh) || string.IsNullOrEmpty(tenNganh) || string.IsNullOrEmpty(maVien))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thiếu thông tin", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            using SqlConnection conn = new(_connectionString);
            conn.Open();

            string checkQuery = "SELECT COUNT(*) FROM nganhdaotao WHERE MaNganh = @MaNganh";
            using SqlCommand checkCmd = new(checkQuery, conn);
            checkCmd.Parameters.AddWithValue("@MaNganh", maNganh);
            int count = (int)checkCmd.ExecuteScalar();
            if (count > 0)
            {
                MessageBox.Show("Mã ngành đã tồn tại.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string insertQuery = "INSERT INTO nganhdaotao (MaNganh, TenNganh, MaVien) VALUES (@MaNganh, @TenNganh, @MaVien)";
            using SqlCommand cmd = new(insertQuery, conn);
            cmd.Parameters.AddWithValue("@MaNganh", maNganh);
            cmd.Parameters.AddWithValue("@TenNganh", tenNganh);
            cmd.Parameters.AddWithValue("@MaVien", maVien);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Thêm ngành thành công!", "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
            LoadDanhSachNganh();
        }

        private void BtnXoa_Click(object sender, RoutedEventArgs e)
        {
            string maNganh = TxtMaNganh.Text.Trim();

            if (string.IsNullOrEmpty(maNganh))
            {
                MessageBox.Show("Vui lòng nhập Mã ngành cần xóa.", "Thiếu thông tin", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (MessageBox.Show($"Bạn có chắc chắn muốn xóa ngành '{maNganh}' không?", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                return;

            using SqlConnection conn = new(_connectionString);
            conn.Open();

            string deleteQuery = "DELETE FROM nganhdaotao WHERE MaNganh = @MaNganh";
            using SqlCommand cmd = new(deleteQuery, conn);
            cmd.Parameters.AddWithValue("@MaNganh", maNganh);
            int affected = cmd.ExecuteNonQuery();

            if (affected > 0)
            {
                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadDanhSachNganh();
            }
            else
            {
                MessageBox.Show("Không tìm thấy mã ngành cần xóa.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnCapNhat_Click(object sender, RoutedEventArgs e)
        {
            string maNganh = TxtMaNganh.Text.Trim();
            string tenNganh = TxtTenNganh.Text.Trim();
            string maVien = CboMaVien.Text;

            if (string.IsNullOrEmpty(maNganh) || string.IsNullOrEmpty(tenNganh) || string.IsNullOrEmpty(maVien))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thiếu thông tin", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            using SqlConnection conn = new(_connectionString);
            conn.Open();

            string updateQuery = "UPDATE nganhdaotao SET TenNganh = @TenNganh, MaVien = @MaVien WHERE MaNganh = @MaNganh";
            using SqlCommand cmd = new(updateQuery, conn);
            cmd.Parameters.AddWithValue("@TenNganh", tenNganh);
            cmd.Parameters.AddWithValue("@MaVien", maVien);
            cmd.Parameters.AddWithValue("@MaNganh", maNganh);
            int affected = cmd.ExecuteNonQuery();

            if (affected > 0)
            {
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadDanhSachNganh();
            }
            else
            {
                MessageBox.Show("Không tìm thấy ngành cần cập nhật.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnInDS_Click(object sender, RoutedEventArgs e)
        {
            LoadDanhSachNganh();
        }

        private void ApDungPhanQuyen()
        {
            if (_role is "student" or "lecturer")
            {
                BtnThemMoi.Visibility = Visibility.Collapsed;
                BtnXoa.Visibility = Visibility.Collapsed;
                BtnCapNhat.Visibility = Visibility.Collapsed;
                BtnThemMoi.IsEnabled = false;
                BtnXoa.IsEnabled = false;
                BtnCapNhat.IsEnabled = false;
            }
        }

        public class NganhModel
        {
            public string? MaNganh { get; set; }
            public string? TenNganh { get; set; }
            public string? MaVien { get; set; }
            public string? TenVien { get; set; }
        }

        private void BtnTimKiem_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void BtnThemMoi_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void BtnXoa_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void BtnCapNhat_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void BtnInDS_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
