using System.Windows;
using System.Windows.Controls;

namespace QuanLySVBK
{
    public partial class GiaoVien_DoiMatKhau : UserControl
    {
        public GiaoVien_DoiMatKhau()
        {
            InitializeComponent();
        }

        private void TogglePasswordVisibility(PasswordBox passwordBox, TextBox textBox, Button button)
        {
            if (passwordBox.Visibility == Visibility.Visible)
            {
                // Hiển thị mật khẩu dạng text
                textBox.Text = passwordBox.Password;
                passwordBox.Visibility = Visibility.Collapsed;
                textBox.Visibility = Visibility.Visible;
                button.Content = "Ẩn";
            }
            else
            {
                // Ẩn mật khẩu, trở về dạng password
                passwordBox.Password = textBox.Text;
                textBox.Visibility = Visibility.Collapsed;
                passwordBox.Visibility = Visibility.Visible;
                button.Content = "Hiện";
            }
        }

        private void btnHienCu_Click(object sender, RoutedEventArgs e)
        {
            TogglePasswordVisibility(txtMatKhauCu, txtMatKhauCuVisible, btnHienCu);
        }

        private void btnHienMoi_Click(object sender, RoutedEventArgs e)
        {
            TogglePasswordVisibility(txtMatKhauMoi, txtMatKhauMoiVisible, btnHienMoi);
        }

        private void btnHienLai_Click(object sender, RoutedEventArgs e)
        {
            TogglePasswordVisibility(txtNhapLai, txtNhapLaiVisible, btnHienLai);
        }
    }
}