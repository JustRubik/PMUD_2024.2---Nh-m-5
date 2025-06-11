using System.Windows;
using System.Windows.Controls;

namespace LoginDemo
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
            txtHoTen.Text = "Trương Hồ Phương Nga";
            txtNgaySinh.Text = "9/12/1982";
            txtGioiTinh.Text = "Nữ";
            txtQueQuan.Text = "Cần Thơ";
            txtVien.Text = "Viện Công nghệ Sinh học và Công nghệ Thực phẩm";
            txtEmail.Text = "DucPhongDang@sis.hust.edu.vn";
            txtSoDienThoai.Text = "00397643191";
            txtCCCD.Text = "01082946685";
        }

        private void ToggleEditMode(bool isEditMode)
        {
            // Chuyển đổi giữa chế độ xem và chỉnh sửa
            txtHoTen.Style = isEditMode ? (Style)Resources["EditableTextBoxStyle"] : (Style)Resources["ReadOnlyTextBoxStyle"];
            txtNgaySinh.Style = isEditMode ? (Style)Resources["EditableTextBoxStyle"] : (Style)Resources["ReadOnlyTextBoxStyle"];
            txtGioiTinh.Style = isEditMode ? (Style)Resources["EditableTextBoxStyle"] : (Style)Resources["ReadOnlyTextBoxStyle"];
            txtQueQuan.Style = isEditMode ? (Style)Resources["EditableTextBoxStyle"] : (Style)Resources["ReadOnlyTextBoxStyle"];
            txtVien.Style = isEditMode ? (Style)Resources["EditableTextBoxStyle"] : (Style)Resources["ReadOnlyTextBoxStyle"];
            txtEmail.Style = isEditMode ? (Style)Resources["EditableTextBoxStyle"] : (Style)Resources["ReadOnlyTextBoxStyle"];
            txtSoDienThoai.Style = isEditMode ? (Style)Resources["EditableTextBoxStyle"] : (Style)Resources["ReadOnlyTextBoxStyle"];
            txtCCCD.Style = isEditMode ? (Style)Resources["EditableTextBoxStyle"] : (Style)Resources["ReadOnlyTextBoxStyle"];

            btnChinhSua.Visibility = isEditMode ? Visibility.Collapsed : Visibility.Visible;
            btnHuy.Visibility = isEditMode ? Visibility.Visible : Visibility.Collapsed;
            btnLuu.Visibility = isEditMode ? Visibility.Visible : Visibility.Collapsed;
        }

        private void btnChinhSua_Click(object sender, RoutedEventArgs e)
        {
            ToggleEditMode(true);
        }

        private void btnHuy_Click(object sender, RoutedEventArgs e)
        {
            ToggleEditMode(false);
            LoadDataFromDatabase(); // Khôi phục dữ liệu gốc
        }

        private void btnLuu_Click(object sender, RoutedEventArgs e)
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