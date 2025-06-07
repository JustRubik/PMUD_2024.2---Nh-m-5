using System.Configuration;
using System.Data;
using System.Windows;

namespace LoginDemo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var loginWindow = new MainWindow();
            loginWindow.Show();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            // Dọn dẹp tài nguyên hoặc lưu trạng thái ở đây
            base.OnExit(e);
        }

    }

}
