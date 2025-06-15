using Microsoft.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using QuanLySVBK.DBHelpers;

namespace QuanLySVBK.Accounts
{
    public partial class DoiMatKhauControl : UserControl
    {
        private readonly string? _id;
        private readonly string? _role;

        public DoiMatKhauControl(string? id, string? role)
        {
            InitializeComponent();
            _id = id;
            _role = role;
        }

        private void BtnDoiMatKhau_Click(object sender, RoutedEventArgs e)
        {
            string mkCu = TxtMatKhauCu.Password.Trim();
            string mkMoi = TxtMatKhauMoi.Password.Trim();
            string mkNhapLai = TxtNhapLaiMatKhauMoi.Password.Trim();

            if (string.IsNullOrEmpty(mkCu) || string.IsNullOrEmpty(mkMoi) || string.IsNullOrEmpty(mkNhapLai))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thiếu thông tin", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (mkMoi != mkNhapLai)
            {
                MessageBox.Show("Mật khẩu mới không khớp.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string tableName, idColumn;
            if (_role == "student")
            {
                tableName = "taikhoan_sinhvien";
                idColumn = "MaSV";
            }
            else if (_role == "lecturer")
            {
                tableName = "taikhoan_giangvien";
                idColumn = "MaGV";
            }
            else
            {
                MessageBox.Show("Không xác định vai trò người dùng.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            using SqlConnection conn = new(App_Config.connectionString);
            conn.Open();

            string queryCheck = $"SELECT Password FROM {tableName} WHERE {idColumn} = @ID";
            using SqlCommand cmd = new(queryCheck, conn);
            cmd.Parameters.AddWithValue("@ID", _id);

            if (cmd.ExecuteScalar() is not string mkHienTai || mkCu != mkHienTai)
            {
                MessageBox.Show("Mật khẩu hiện tại không đúng.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string queryUpdate = $"UPDATE {tableName} SET Password = @Password WHERE {idColumn} = @ID";
            using SqlCommand cmdUpdate = new(queryUpdate, conn);
            cmdUpdate.Parameters.AddWithValue("@Password", mkMoi);
            cmdUpdate.Parameters.AddWithValue("@ID", _id);
            int rows = cmdUpdate.ExecuteNonQuery();

            if (rows > 0)
            {
                MessageBox.Show("Đổi mật khẩu thành công!", "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
                TxtMatKhauCu.Clear();
                TxtMatKhauMoi.Clear();
                TxtNhapLaiMatKhauMoi.Clear();
            }
            else
            {
                MessageBox.Show("Đổi mật khẩu thất bại.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
