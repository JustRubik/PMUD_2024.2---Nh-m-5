using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using QuanLySVBK.DBHelpers;

namespace QuanLySVBK
{
    public partial class MainWindow : Window
    {
        public bool isLoggingOut;
        private readonly LoginWindow loginWindow;
        private readonly string _username;
        private readonly string _role;
        private readonly string _id;

        public MainWindow(string username, string id, string role, LoginWindow loginWindow)
        {
            InitializeComponent();
            this.loginWindow = loginWindow;
            _username = username;
            _id = id;
            _role = role;

            Title = "Đang tải thông tin...";
            Task.Run(() =>
            {
                string name = UserHelper.GetFullName(username, id, role);
                Dispatcher.Invoke(() => Title = $"Xin chào {name}");
            });
        }

        private void Homepage_Click(object sender, RoutedEventArgs e)
        {
            MainContentControl.Content = null;
        }

        private void Account_Click(object sender, RoutedEventArgs e)
        {
            SubMenuPopup_Account.IsOpen = !SubMenuPopup_Account.IsOpen;
        }

        private void HandleGPA_Click(object sender, RoutedEventArgs e)
        {
            if (_role == "student")
                MessageBox.Show("Bạn không có quyền truy cập");
            else
                MainContentControl.Content = new XuLyGPA();
        }

        private void HandleCPA_Click(object sender, RoutedEventArgs e)
        {
            if (_role == "student")
                MessageBox.Show("Bạn không có quyền truy cập");
            else
                MainContentControl.Content = new XuLyCPA();
        }

        private void HandleFinalGrade_Click(object sender, RoutedEventArgs e)
        {
            if (_role == "student")
                MessageBox.Show("Bạn không có quyền truy cập");
            else
                MainContentControl.Content = new XuLyDiemTongKet();
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
            MainContentControl.Content = new DanhMucGiangVien(_role);
        }

        private void DanhMucSinhVien_Click(object sender, RoutedEventArgs e)
        {
            MainContentControl.Content = new DanhMucSinhVien(_role);
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
            loginWindow.Show();
            Application.Current.MainWindow = loginWindow;
            Close();
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            if (!isLoggingOut && Application.Current.MainWindow == this)
            {
                MessageBoxResult result = MessageBox.Show(
                    "Bạn có chắc chắn muốn thoát?",
                    "Xác nhận",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning
                );

                if (result != MessageBoxResult.Yes)
                    e.Cancel = true;
            }
        }
    }
}
