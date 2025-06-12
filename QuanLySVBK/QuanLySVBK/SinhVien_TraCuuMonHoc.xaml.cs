using System.Windows;
using System.Windows.Controls;
using System.Data;

namespace QuanLySVBK
{
    public partial class SinhVien_TraCuuMonHoc : UserControl
    {
        public SinhVien_TraCuuMonHoc()
        {
            InitializeComponent();
            Loaded += SinhVien_TraCuuMonHoc_Loaded;
        }

        private void SinhVien_TraCuuMonHoc_Loaded(object sender, RoutedEventArgs e)
        {
            // Load dữ liệu mẫu
            LoadSampleData();
        }

        private void LoadSampleData()
        {
            // Tạo DataTable mẫu
            DataTable dt = new DataTable();
            dt.Columns.Add("MaHocPhan");
            dt.Columns.Add("TenHocPhan");
            dt.Columns.Add("SoTinChi");
            dt.Columns.Add("KhoaVien");

            // Thêm dữ liệu mẫu
            dt.Rows.Add("IT001", "Lập trình hướng đối tượng", 4, "Công nghệ thông tin");
            dt.Rows.Add("MA002", "Toán cao cấp", 3, "Toán-Tin");
            dt.Rows.Add("PH003", "Vật lý đại cương", 3, "Vật lý kỹ thuật");

            dgKetQua.ItemsSource = dt.DefaultView;
        }

        private void btnTimKiem_Click(object sender, RoutedEventArgs e)
        {
            // Xử lý tìm kiếm ở đây
            MessageBox.Show("Chức năng tìm kiếm sẽ được triển khai sau!");
        }
    }
}