using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LoginDemo
{
    /// <summary>
    /// Interaction logic for SinhVien_DoiMatKhau.xaml
    /// </summary>
    public partial class SinhVien_DoiMatKhau : UserControl
    {
        public SinhVien_DoiMatKhau()
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
