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

namespace QuanLySVBK
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

        private void BtnHienCu_Click(object sender, RoutedEventArgs e)
        {
            TogglePasswordVisibility(TxtMatKhauCu, TxtMatKhauCuVisible, BtnHienCu);
        }

        private void BtnHienMoi_Click(object sender, RoutedEventArgs e)
        {
            TogglePasswordVisibility(TxtMatKhauMoi, TxtMatKhauMoiVisible, BtnHienMoi);
        }

        private void BtnHienLai_Click(object sender, RoutedEventArgs e)
        {
            TogglePasswordVisibility(TxtNhapLai, TxtNhapLaiVisible, BtnHienLai);
        }
    }
}
