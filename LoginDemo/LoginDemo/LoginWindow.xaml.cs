using System.Windows;
using Microsoft.Data.SqlClient;

namespace LoginDemo
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void OpenAfterLogin(string username)
        {
            var afterLogin = new AfterLogin(username);
            afterLogin.Show();
            this.Close();
        }

        private static bool CheckLogin(string username, string password, string tableName)
        {
            string connectionString = "Server=admin-pc\\sqlexpress;Database=QuanLyDiemSVBK;Trusted_Connection=True;TrustServerCertificate=True;";

            using (SqlConnection conn = new(connectionString))
            {
                conn.Open();

                string query = $"SELECT Password FROM {tableName} WHERE Username = @username";

                using (SqlCommand cmd = new(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    object result = cmd.ExecuteScalar();

                    return result is string storedPassword && storedPassword == password;
                }
            }
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameBox.Text.Trim();
            string password = PasswordBox.Password;

            try
            {
                string? tableName = null;

                if (AdminRadio.IsChecked == true) tableName = "Admin";
                else if (StudentRadio.IsChecked == true) tableName = "taikhoan_sinhvien";
                else if (TeacherRadio.IsChecked == true) tableName = "taikhoan_giangvien";
                else
                {
                    MessageBox.Show("Vui lòng chọn loại tài khoản.");
                    return;
                }

                if (CheckLogin(username, password, tableName))
                {
                    MessageBox.Show("Đăng nhập thành công!");
                    OpenAfterLogin(username);
                }
                else
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($":\n{ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

        }


        private void ForgotPassword_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            new ForgotPasswordWindow().ShowDialog();
        }
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);
        }
    }
}
