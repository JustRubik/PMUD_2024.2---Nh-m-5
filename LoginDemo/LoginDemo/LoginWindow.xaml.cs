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

        private bool CheckLogin(string username, string password, string tableName)
        {
            string connectionString = "Server=admin-pc\\sqlexpress;Database=QuanLyDiemSVBK;Trusted_Connection=True;TrustServerCertificate=True;";

            using (SqlConnection conn = new (connectionString))
            {
                conn.Open();

                string query = $"SELECT password FROM {tableName} WHERE username = @username";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    object result = cmd.ExecuteScalar();

                    return (result != null && result.ToString() == password);
                }
            }
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameBox.Text.Trim();
            string password = PasswordBox.Password;

            try
            {
                if (AdminRadio.IsChecked == true)
                {
                    if (CheckLogin(username, password, "Admin"))
                    {
                        MessageBox.Show("Đăng nhập thành công!");
                        DialogResult = true;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Sai tài khoản hoặc mật khẩu.");
                    }
                }
                else if (StudentRadio.IsChecked == true)
                {
                    if (CheckLogin(username, password, "Student"))
                    {
                        MessageBox.Show("Đăng nhập thành công!");
                        DialogResult = true;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Sai tài khoản hoặc mật khẩu.");
                    }
                }
                else if (TeacherRadio.IsChecked == true)
                {
                    if (CheckLogin(username, password, "Teacher"))
                    {
                        MessageBox.Show("Đăng nhập thành công!");
                        DialogResult = true;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Sai tài khoản hoặc mật khẩu.");
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn loại tài khoản.");
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
