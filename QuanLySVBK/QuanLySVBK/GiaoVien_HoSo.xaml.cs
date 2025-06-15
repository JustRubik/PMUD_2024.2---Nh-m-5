using System.Windows;
using System.Windows.Controls;

namespace QuanLySVBK
{
    public partial class GiaoVien_HoSo : UserControl
    {
        public GiaoVien_HoSo()
        {
            InitializeComponent();
            Loaded += GiaoVien_HoSo_Loaded;
        }

        private void GiaoVien_HoSo_Loaded(object sender, RoutedEventArgs e)
        {
            // Load dữ liệu từ CSDL (ví dụ)
            LoadDataFromDatabase();
        }

        private void LoadDataFromDatabase()
        {
            // Giả lập dữ liệu từ CSDL
            TxtHoTen.Text = "Trương Hồ Phương Nga";
            TxtNgaySinh.Text = "9/12/1982";
            TxtGioiTinh.Text = "Nữ";
            TxtQueQuan.Text = "Cần Thơ";
            TxtVien.Text = "Viện Công nghệ Sinh học và Công nghệ Thực phẩm";
            TxtEmail.Text = "DucPhongDang@sis.hust.edu.vn";
            TxtSoDienThoai.Text = "00397643191";
            TxtCCCD.Text = "01082946685";
        }

        private void ToggleEditMode(bool isEditMode)
        {
            // Chuyển đổi giữa chế độ xem và chỉnh sửa
            TxtHoTen.Style = isEditMode ? (Style)Resources["EditableTextBoxStyle"] : (Style)Resources["ReadOnlyTextBoxStyle"];
            TxtNgaySinh.Style = isEditMode ? (Style)Resources["EditableTextBoxStyle"] : (Style)Resources["ReadOnlyTextBoxStyle"];
            TxtGioiTinh.Style = isEditMode ? (Style)Resources["EditableTextBoxStyle"] : (Style)Resources["ReadOnlyTextBoxStyle"];
            TxtQueQuan.Style = isEditMode ? (Style)Resources["EditableTextBoxStyle"] : (Style)Resources["ReadOnlyTextBoxStyle"];
            TxtVien.Style = isEditMode ? (Style)Resources["EditableTextBoxStyle"] : (Style)Resources["ReadOnlyTextBoxStyle"];
            TxtEmail.Style = isEditMode ? (Style)Resources["EditableTextBoxStyle"] : (Style)Resources["ReadOnlyTextBoxStyle"];
            TxtSoDienThoai.Style = isEditMode ? (Style)Resources["EditableTextBoxStyle"] : (Style)Resources["ReadOnlyTextBoxStyle"];
            TxtCCCD.Style = isEditMode ? (Style)Resources["EditableTextBoxStyle"] : (Style)Resources["ReadOnlyTextBoxStyle"];

            BtnChinhSua.Visibility = isEditMode ? Visibility.Collapsed : Visibility.Visible;
            BtnHuy.Visibility = isEditMode ? Visibility.Visible : Visibility.Collapsed;
            BtnLuu.Visibility = isEditMode ? Visibility.Visible : Visibility.Collapsed;
        }

        private void BtnChinhSua_Click(object sender, RoutedEventArgs e)
        {
            ToggleEditMode(true);
        }

        private void BtnHuy_Click(object sender, RoutedEventArgs e)
        {
            ToggleEditMode(false);
            LoadDataFromDatabase(); // Khôi phục dữ liệu gốc
        }

        private void BtnLuu_Click(object sender, RoutedEventArgs e)
        {
            // Lưu dữ liệu vào CSDL
            try
            {
                // TODO: Thêm code lưu vào CSDL ở đây
                MessageBox.Show("Cập nhật thông tin thành công!");
                ToggleEditMode(false);
            }
            catch
            {
                MessageBox.Show("Lỗi khi cập nhật dữ liệu!");
            }
        }
    }
}