using System.Configuration;
using System.Data;
using System.Globalization;
using System.Windows;

namespace QuanLySVBK
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("vi-VN");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("vi-VN");
            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            // Dọn dẹp tài nguyên hoặc lưu trạng thái ở đây
            base.OnExit(e);
        }

    }

}