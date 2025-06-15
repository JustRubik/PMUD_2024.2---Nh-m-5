using Microsoft.Data.SqlClient;
using QuanLySVBK.DBHelpers;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace QuanLySVBK
{
    public partial class XuLyGPA : UserControl
    {
        public ObservableCollection<KetQuaMonHoc> DanhSachKetQua { get; set; } = [];

        public XuLyGPA()
        {
            InitializeComponent();
            dgKetQua.ItemsSource = DanhSachKetQua;
            CboKiHoc.ItemsSource = TemplateList.TermID;
        }

        private void BtnXuLy_Click(object sender, RoutedEventArgs e)
        {
            string mssv = TxtMaSinhVien.Text.Trim();
            string? kiHoc = CboKiHoc.SelectedItem?.ToString();

            // Kiểm tra đầu vào
            if (string.IsNullOrEmpty(mssv) || string.IsNullOrEmpty(kiHoc))
            {
                MessageBox.Show("Vui lòng nhập MSSV và chọn kì học.", "Thiếu thông tin", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            DanhSachKetQua.Clear();

            try
            {
                using SqlConnection conn = new(App_Config.connectionString);
                conn.Open();

                // Truy vấn lấy thông tin môn học, điểm giữa kì, cuối kì từ bảng diem + thông tin từ bảng hocphan
                string query = @"
                    SELECT 
                        d.MaHP AS MaMonHoc,
                        d.MaLop,
                        hp.TenHP AS TenMonHoc,
                        hp.SoTinChi,
                        ISNULL(d.DiemGiuaKi, 0) AS DiemGiuaKi,
                        ISNULL(d.DiemCuoiKi, 0) AS DiemCuoiKi
                    FROM diem d
                    JOIN hocphan hp ON d.MaHP = hp.MaHP
                    WHERE d.MaSV = @MaSV AND d.MaKi = @MaKi";

                using SqlCommand cmd = new(query, conn);
                cmd.Parameters.AddWithValue("@MaSV", mssv);
                cmd.Parameters.AddWithValue("@MaKi", kiHoc);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    double diemGK = Convert.ToDouble(reader["DiemGiuaKi"]);
                    double diemCK = Convert.ToDouble(reader["DiemCuoiKi"]);
                    double diemTong = Math.Round(0.4 * diemGK + 0.6 * diemCK, 2);

                    DanhSachKetQua.Add(new KetQuaMonHoc
                    {
                        MaSV = mssv,
                        MaKi = kiHoc,
                        MaMonHoc = reader["MaMonHoc"].ToString(),
                        MaLop = reader["MaLop"].ToString(),
                        TenMonHoc = reader["TenMonHoc"].ToString(),
                        SoTinChi = Convert.ToInt32(reader["SoTinChi"]),
                        Diem = diemTong
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi truy vấn dữ liệu: " + ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void BtnInDanhSach_Click(object sender, RoutedEventArgs e)
        {
            if (DanhSachKetQua.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để in.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            MessageBox.Show("In danh sách GPA thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
