using System.Windows;

namespace LoginDemo
{
    public partial class MainWindow : Window
    {
        public MainWindow(string username)
        {
            InitializeComponent();
            Title = $"Xin chào {username}";
        }

        /*
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new()
            {
                Owner = this
            };
            Hide();

            bool? result = loginWindow.ShowDialog();

            if (result == true)
            {
                ShowDialog(); // hiện lại cửa sổ chính
            }
            else
            {
                Close(); // đóng cửa sổ chính nếu đăng nhập không thành công    
            }
        }*/

        private void HandleGPA_Click(object sender, RoutedEventArgs e)
        {
            MainContentControl.Content = new XuLyGPA();
        }
       

        private void HandleCPA_Click(object sender, RoutedEventArgs e)
        {
            MainContentControl.Content = new XuLyCPA();
        }

        private void HandleFinalGrade_Click(object sender, RoutedEventArgs e)
        {
            //MainContentControl.Content = new XuLyDiemCK();
        }

        private void UpdateScoreMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MainContentControl.Content = new CapNhatDiem();
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            MainContentControl.Content = new HelpWindow();
        }

        private void DanhMucGiangVien_Click(object sender, RoutedEventArgs e)
        {
            MainContentControl.Content = new DanhMucGiangVien();
        }

        private void DanhMucSinhVien_Click(object sender, RoutedEventArgs e)
        {
            MainContentControl.Content = new DanhMucSinhVien();
        }

        private void DanhMucHocPhan_Click(object sender, RoutedEventArgs e)
        {
            MainContentControl.Content = new DanhMucHocPhan();
        }

        private void DanhMucNganhDaoTao_Click(object sender, RoutedEventArgs e)
        {
            MainContentControl.Content = new DanhMucNganhDaoTao();
        }

        private void DanhMucLopHocPhan_Click(object sender, RoutedEventArgs e)
        {
            MainContentControl.Content = new DanhMucLopHocPhan();
        }

        private void DanhMucKhoaVien_Click(object sender, RoutedEventArgs e)
        {
            MainContentControl.Content = new DanhMucKhoaVien();
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);
        }
    }
}