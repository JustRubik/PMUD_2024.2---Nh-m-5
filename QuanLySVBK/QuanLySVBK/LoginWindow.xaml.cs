using System.Windows;
using QuanLySVBK.DBHelpers;

namespace QuanLySVBK
{
    public partial class LoginWindow : Window
    {
        //private readonly string connectionString = "Server=admin-pc\\sqlexpress;Database=QuanLyDiemSVBK;Trusted_Connection=True;TrustServerCertificate=True;";

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void OpenMainWindow(string username, string id, string role)
        {
            MainWindow afterLogin = new(username, id, role, this);
            Application.Current.MainWindow = afterLogin;
            afterLogin.Show();
            Hide();
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

                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ tài khoản và mật khẩu.");
                    return;
                }

                if (tableName == null)
                {
                    MessageBox.Show("Vui lòng chọn loại tài khoản.");
                    return;
                }

                string? role = tableName switch
                {
                    "Admin" => "admin",
                    "taikhoan_sinhvien" => "student",
                    "taikhoan_giangvien" => "lecturer",
                    _ => null
                };

                if (role == null)
                {
                    MessageBox.Show("Role không hợp lệ.");
                    return;
                }

                // Kiểm tra đăng nhập
                string? id = LoginHelper.TryLogin(username, password, tableName);

                if (id != null)
                {
                    MessageBox.Show("Đăng nhập thành công!");
                    OpenMainWindow(username, id, role);
                }
                else
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi:\n{ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ForgotPassword_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            new ForgotPasswordWindow().ShowDialog();
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            if (Application.Current.MainWindow == this)
            {
                MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result != MessageBoxResult.Yes)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
