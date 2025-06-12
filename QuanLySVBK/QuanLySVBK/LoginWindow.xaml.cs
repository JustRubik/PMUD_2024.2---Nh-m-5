using Microsoft.Data.SqlClient;
using System.Windows;

namespace QuanLySVBK
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();

        }

        private void OpenMainWindow(string username, string role)
        {
            MainWindow afterLogin = new(username, role, this);
            Application.Current.MainWindow = afterLogin;
            afterLogin.Show();
            Hide();
        }

        // Kiểm tra đăng nhập
        private static bool CheckLogin(string username, string password, string tableName)
        {
            string connectionString = "Server=admin-pc\\sqlexpress;Database=QuanLyDiemSVBK;Trusted_Connection=True;TrustServerCertificate=True;";
            using SqlConnection conn = new(connectionString);
            conn.Open();

            string query = $"SELECT Password FROM {tableName} WHERE Username = @username";
            using SqlCommand cmd = new(query, conn);
            cmd.Parameters.AddWithValue("@username", username);
            object result = cmd.ExecuteScalar();

            return result is string storedPassword && storedPassword == password;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameBox.Text.Trim();
            string password = PasswordBox.Password;

            try
            {
                string? tableName = (AdminRadio.IsChecked == true) ? "Admin"
                                 : (StudentRadio.IsChecked == true) ? "taikhoan_sinhvien"
                                 : (TeacherRadio.IsChecked == true) ? "taikhoan_giangvien"
                                 : null;

                if (tableName == null)
                {
                    MessageBox.Show("Vui lòng chọn loại tài khoản.");
                    return;
                }

                if (CheckLogin(username, password, tableName))
                {
                    MessageBox.Show("Đăng nhập thành công!");
                    string? role = (tableName == "Admin") ? "admin"
                            : (tableName == "taikhoan_sinhvien") ? "student"
                            : (tableName == "taikhoan_giangvien") ? "lecturer"
                            : null;
                    if (role != null)
                    {
                        OpenMainWindow(username, role);
                    }
                }
                else
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($":\n{ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ForgotPassword_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            new ForgotPasswordWindow().ShowDialog();
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            if(Application.Current.MainWindow == this)
            {
                var result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result != MessageBoxResult.Yes)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
