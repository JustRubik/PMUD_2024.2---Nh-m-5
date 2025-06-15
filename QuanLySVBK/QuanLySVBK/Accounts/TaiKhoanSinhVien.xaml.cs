using System.Windows;
using System.Windows.Controls;

namespace QuanLySVBK.Accounts
{
    public partial class TaiKhoanSinhVien : UserControl
    {

        public bool isLoggingOut;
        private readonly string? _id;
        private readonly string? _name;
        private readonly string? _role = "student";
        public TaiKhoanSinhVien(string? name, string id)
        {
            InitializeComponent();
            TxtHoTen.Text = $"{name}";
            TxtMSSV.Text = $"{id}";
            _id = id;
            _name = name;
        }

        private void BtnStudentInfo_Click(object sender, RoutedEventArgs e)
        {
            MainContentArea.Content = new ThongTinSinhVienControl(_id);
        }


        private void BtnGradeLookup_Click(object sender, RoutedEventArgs e)
        {
            MainContentArea.Content = new TraCuuKetQuaControl(_id);
        }


        private void BtnSubjectLookup_Click(object sender, RoutedEventArgs e)
        {
            MainContentArea.Content = new TraCuuMonHocControl();
        }


        private void BtnChangePassword_Click(object sender, RoutedEventArgs e)
        {
            MainContentArea.Content = new DoiMatKhauControl(_id, _role); // _id là mã sinh viên
        }

        public void SetUserInfo(string hoTen, string mssv)
        {
            TxtHoTen.Text = $"USER: {hoTen}";
            TxtMSSV.Text = $"ID: {mssv}";
        }
    }
}
