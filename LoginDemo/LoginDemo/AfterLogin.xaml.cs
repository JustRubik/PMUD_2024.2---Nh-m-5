using System.Windows;

namespace LoginDemo
{
    public partial class AfterLogin : Window
    {
        public AfterLogin(string username)
        {
            InitializeComponent();
            Title = $"Xin chào {username}";
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
            // TODO : Bổ sung giao diện xử lý điểm CK
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
            var result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result != MessageBoxResult.Yes)
            {
                e.Cancel = true;
            }
            base.OnClosing(e);
        }


    }
}