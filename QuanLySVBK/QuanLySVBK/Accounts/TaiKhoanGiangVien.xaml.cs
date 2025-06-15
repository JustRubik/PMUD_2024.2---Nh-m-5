using System.Windows;
using System.Windows.Controls;

namespace QuanLySVBK.Accounts
{
    public partial class TaiKhoanGiangVien : UserControl
    {
        public bool isLoggingOut;
        private readonly string? _id;
        private readonly string? _name;
        private readonly string? _role = "lecturer";

        public TaiKhoanGiangVien(string? name, string id)
        {
            InitializeComponent();
            TxtHoTen.Text = $"{name}";
            TxtMaGV.Text = $"{id}";
            _id = id;
            _name = name;
        }

        private void BtnLecturerInfo_Click(object sender, RoutedEventArgs e)
        {
            MainContentArea.Content = new ThongTinGiangVienControl(_id);

        }

        private void BtnClassList_Click(object sender, RoutedEventArgs e)
        {
            MainContentArea.Content = new DanhSachLopDayControl(_id); // _id là mã giảng viên đã truyền từ constructor
        }


        private void BtnChangePassword_Click(object sender, RoutedEventArgs e)
        {
            MainContentArea.Content = new DoiMatKhauControl(_id, _role);
        }

        public void SetUserInfo(string hoTen, string maGV)
        {
            TxtHoTen.Text = $"USER: {hoTen}";
            TxtMaGV.Text = $"ID: {maGV}";
        }
    }
}
