using System.Windows;
using System.Windows.Controls;

namespace QuanLySVBK
{
    public partial class SinhVien_TraCuuKetQuaHocTap : UserControl
    {
        public SinhVien_TraCuuKetQuaHocTap()
        {
            InitializeComponent();
            Loaded += SinhVien_TraCuuKetQuaHocTap_Loaded;
        }

        private void SinhVien_TraCuuKetQuaHocTap_Loaded(object sender, RoutedEventArgs e)
        {
            // Load dữ liệu mẫu
            LoadSampleData();
        }

        private void LoadSampleData()
        {
            // Có thể thêm code tải dữ liệu từ CSDL ở đây
        }

        private void btnTraCuuKi_Click(object sender, RoutedEventArgs e)
        {
            // Xử lý tra cứu theo kì
            MessageBox.Show("Chức năng tra cứu theo kì sẽ được triển khai sau!");
        }

        private void btnTraCuuMonHoc_Click(object sender, RoutedEventArgs e)
        {
            // Xử lý tra cứu theo môn học
            MessageBox.Show("Chức năng tra cứu theo môn học sẽ được triển khai sau!");
        }
    }
}