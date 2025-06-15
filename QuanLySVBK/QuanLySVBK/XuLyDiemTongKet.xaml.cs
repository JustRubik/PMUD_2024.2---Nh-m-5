using Microsoft.Data.SqlClient;
using QuanLySVBK.DBHelpers;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace QuanLySVBK
{
    public partial class XuLyDiemTongKet : UserControl
    {
        // Danh sách kết quả dùng để hiển thị trên DataGrid
        public ObservableCollection<KetQuaMonHoc> DanhSachKetQua { get; set; } = [];

        public XuLyDiemTongKet()
        {
            InitializeComponent();
            dgKetQua.ItemsSource = DanhSachKetQua;

            CboKiHoc.ItemsSource = TemplateList.TermID;
        }

        private void BtnXuLy_Click(object sender, RoutedEventArgs e)
        {
            // Lấy dữ liệu từ các input
            string? mssv = TxtMaSinhVien.Text.Trim();
            string? maHP = TxtMaHP.Text.Trim();
            string? maNganh = TxtMaNganh.Text.Trim();
            string? maLopHocPhan = TxtMaLopHocPhan.Text.Trim();
            string? kiHoc = CboKiHoc.SelectedItem?.ToString() ?? "";

            if (string.IsNullOrWhiteSpace(mssv))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ MSSV.", "Thiếu thông tin", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // TODO: Gọi hàm truy vấn cơ sở dữ liệu từ MSSV, MaHP, MaLop, MaKi để lấy điểm

            
        }

        private void BtnInDanhSach_Click(object sender, RoutedEventArgs e)
        {
            string? maLop = TxtMaLopHocPhan.Text.Trim();
            string? maSV = TxtMaSinhVien.Text.Trim();
            string? maHP = TxtMaHP.Text.Trim();
            string? maNganh = TxtMaNganh.Text.Trim();
            string? kiHoc = CboKiHoc.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(maLop))
            {
                MessageBox.Show("Vui lòng nhập Mã lớp học phần.", "Thiếu thông tin", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            DanhSachKetQua.Clear();

            try
            {
                using (SqlConnection conn = new(App_Config.connectionString))
                {
                    conn.Open();

                    // Xây dựng câu truy vấn động
                    string query = @"
                        SELECT 
                            sv.MaSV,
                            hp.MaHP,
                            hp.TenHP,
                            hp.SoTinChi,
                            d.DiemGiuaKi,
                            d.DiemCuoiKi,
                            lh.MaKi
                        FROM lophocphan lh
                        JOIN diem d ON lh.MaLop = d.MaLop AND lh.MaHP = d.MaHP AND lh.MaKi = d.MaKi
                        JOIN sinhvien sv ON d.MaSV = sv.MaSV
                        JOIN hocphan hp ON lh.MaHP = hp.MaHP
                        WHERE lh.MaLop = @MaLop
                    ";

                    // Thêm các điều kiện nếu có
                    if (!string.IsNullOrWhiteSpace(maSV))
                        query += " AND sv.MaSV = @MaSV";
                    if (!string.IsNullOrWhiteSpace(maHP))
                        query += " AND hp.MaHP = @MaHP";
                    if (!string.IsNullOrWhiteSpace(maNganh))
                        query += " AND sv.MaNganh = @MaNganh";
                    if (!string.IsNullOrWhiteSpace(kiHoc))
                        query += " AND lh.MaKi = @MaKi";

                    using SqlCommand cmd = new(query, conn);
                    cmd.Parameters.AddWithValue("@MaLop", maLop);

                    if (!string.IsNullOrWhiteSpace(maSV))
                        cmd.Parameters.AddWithValue("@MaSV", maSV);
                    if (!string.IsNullOrWhiteSpace(maHP))
                        cmd.Parameters.AddWithValue("@MaHP", maHP);
                    if (!string.IsNullOrWhiteSpace(maNganh))
                        cmd.Parameters.AddWithValue("@MaNganh", maNganh);
                    if (!string.IsNullOrWhiteSpace(kiHoc))
                        cmd.Parameters.AddWithValue("@MaKi", kiHoc);

                    using SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string? msv = reader["MaSV"].ToString();
                        string? mahp = reader["MaHP"].ToString();
                        string? tenhp = reader["TenHP"].ToString();
                        int sotinchi = Convert.ToInt32(reader["SoTinChi"]);
                        double diemGK = reader["DiemGiuaKi"] != DBNull.Value ? Convert.ToDouble(reader["DiemGiuaKi"]) : 0;
                        double diemCK = reader["DiemCuoiKi"] != DBNull.Value ? Convert.ToDouble(reader["DiemCuoiKi"]) : 0;
                        double diemTK = Math.Round(0.4 * diemGK + 0.6 * diemCK, 2);

                        DanhSachKetQua.Add(new KetQuaMonHoc
                        {
                            MaSV = msv,
                            MaMonHoc = mahp,
                            TenMonHoc = tenhp,
                            SoTinChi = sotinchi,
                            Diem = diemTK
                        });
                    }
                }

                if (DanhSachKetQua.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy kết quả phù hợp với điều kiện lọc.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy dữ liệu: " + ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


    }
}
