using System.Windows;

namespace QuanLySVBK
{
    public partial class MainWindow : Window
    {
        public bool isLoggingOut;
        private readonly LoginWindow loginWindow;

        public MainWindow(string username, string role, LoginWindow loginWindow)
        {
            InitializeComponent();
            Title = $"Xin chào {username}";
            this.loginWindow = loginWindow;

        }

        private void Account_Click(object sender, RoutedEventArgs e)
        {
            SubMenuPopup_Account.IsOpen = !SubMenuPopup_Account.IsOpen;
        }

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

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            isLoggingOut = true;
            loginWindow.Show();     // Hiện lại LoginWindow đã bị ẩn
            Application.Current.MainWindow = loginWindow;
            Close();                // Đóng MainWindow (có thể dùng Hide() nếu muốn ẩn thay vì đóng)
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            if (!isLoggingOut) 
            {
                if(Application.Current.MainWindow == this)
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
}
