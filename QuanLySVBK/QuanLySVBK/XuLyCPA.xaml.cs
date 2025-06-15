using Microsoft.Data.SqlClient;
using QuanLySVBK.DBHelpers;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace QuanLySVBK
{
    public partial class XuLyCPA : UserControl
    {
        public ObservableCollection<KetQuaMonHoc> DanhSachKetQua { get; set; } = [];

        public XuLyCPA()
        {
            InitializeComponent();
            dgKetQua.ItemsSource = DanhSachKetQua;
            CboKiHoc.ItemsSource = TemplateList.TermID;
            LoadComboBoxKiHoc();
        }

        private void LoadComboBoxKiHoc()
        {
            try
            {
                using SqlConnection conn = new(App_Config.connectionString);
                conn.Open();

                string query = "SELECT DISTINCT MaKi FROM diem ORDER BY MaKi DESC";
                using SqlCommand cmd = new(query, conn);
                using SqlDataReader reader = cmd.ExecuteReader();

                List<string> danhSachKi = [.. TemplateList.TermID]; // Sao chép từ TermID có sẵn

                while (reader.Read())
                {
                    string? maKi = reader["MaKi"].ToString();
                    if (!string.IsNullOrWhiteSpace(maKi) && !danhSachKi.Contains(maKi))
                        danhSachKi.Add(maKi);
                }

                CboKiHoc.ItemsSource = danhSachKi;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách kì học: {ex.Message}");
            }
        }



        private void BtnXuLy_Click(object sender, RoutedEventArgs e)
        {
            string? maSV = TxtMaSinhVien.Text.Trim();
            string? maKi = CboKiHoc.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(maSV) || string.IsNullOrEmpty(maKi))
            {
                MessageBox.Show("Vui lòng nhập MSSV và chọn kì học.");
                return;
            }

            DanhSachKetQua.Clear();

            try
            {
                using SqlConnection conn = new(App_Config.connectionString);
                conn.Open();

                string query = MarkHelper.KetNoiCacBang;

                using SqlCommand cmd = new(query, conn);
                cmd.Parameters.AddWithValue("@MaSV", maSV);
                cmd.Parameters.AddWithValue("@MaKi", maKi);

                using SqlDataReader reader = cmd.ExecuteReader();

                double tongDiemXTinChi = 0;
                int tongTinChi = 0;

                while (reader.Read())
                {
                    var mon = new KetQuaMonHoc
                    {
                        MaSV = reader["MaSV"].ToString(),
                        HoTen = reader["HoTen"].ToString(),
                        MaMonHoc = reader["MaHP"].ToString(),
                        TenMonHoc = reader["TenHP"].ToString(),
                        MaLop = reader["MaLop"].ToString(),
                        MaKi = reader["MaKi"].ToString(),
                        SoTinChi = Convert.ToInt32(reader["SoTinChi"]),
                        Diem = Convert.ToDouble(reader["Diem"])
                    };

                    DanhSachKetQua.Add(mon);
                    tongDiemXTinChi += mon.Diem * mon.SoTinChi;
                    tongTinChi += mon.SoTinChi;
                }

                if (tongTinChi > 0)
                {
                    double cpa = tongDiemXTinChi / tongTinChi;
                    ChkCPA.Text = $"*CPA tính đến kì này: {cpa:F2}";
                }
                else
                {
                    ChkCPA.Text = "*CPA tính đến kì này: chưa có dữ liệu";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xử lý CPA: {ex.Message}");
            }
        }


        private void BtnInDanhSach_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using SqlConnection conn = new(App_Config.connectionString);
                conn.Open();

                string query = @"
                        SELECT 
                        d.MaSV AS MaSinhVien,
                        d.MaHP AS MaMonHoc,
                        d.MaLop,
                        d.MaKi,
                        h.SoTinChi,
                        ROUND((ISNULL(d.DiemGiuaKi, 0) * 0.4 + ISNULL(d.DiemCuoiKi, 0) * 0.6), 2) AS Diem
                    FROM diem d
                    JOIN hocphan h ON d.MaHP = h.MaHP
                    ORDER BY d.MaSV, d.MaKi
                ";

                using SqlCommand cmd = new(query, conn);
                using SqlDataAdapter adapter = new(cmd);

                DataTable dt = new();
                adapter.Fill(dt);

                dgKetQua.ItemsSource = dt.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi in danh sách: {ex.Message}");
            }
        }
    }
}
