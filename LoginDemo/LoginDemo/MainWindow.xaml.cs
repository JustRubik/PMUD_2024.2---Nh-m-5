using System.Windows;

namespace LoginDemo
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Owner = this;
            this.Hide();

            bool? result = loginWindow.ShowDialog();

            if (result == true)
            {
                ShowDialog(); // hiện lại cửa sổ chính
            }
            else
            {
                Close(); // đóng cửa sổ chính nếu đăng nhập không thành công    
            }
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

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);
        }
    }
}