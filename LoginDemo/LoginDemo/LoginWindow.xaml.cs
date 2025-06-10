using Microsoft.Data.SqlClient;
using System.Text;
using System.Windows;

namespace LoginDemo
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void OpenMainWindow(string username)
        {
            var afterLogin = new MainWindow(username);
            afterLogin.Show();
            this.Close();
        }

        //Kiểm tra đăng nhập
        private static bool CheckLogin(string username, string password, string tableName)
        {
            string connectionString = "Server=admin-pc\\sqlexpress;Database=QuanLyDiemSVBK;Trusted_Connection=True;TrustServerCertificate=True;";

            using SqlConnection conn = new(connectionString);
            conn.Open();

            string query = $"SELECT Password FROM {tableName} WHERE Username = @username";

            using SqlCommand cmd = new(query, conn);
            cmd.Parameters.AddWithValue("@Username", username);
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
                    OpenMainWindow(username);
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
