using Microsoft.Data.SqlClient;
using QuanLySVBK.DBHelpers;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace QuanLySVBK
{
    public partial class CapNhatDiem : UserControl
    {
        public ObservableCollection<DiemModel> DanhSachDiem { get; set; } = [];
        public CapNhatDiem()
        {
            InitializeComponent();
            DanhSachDiem = [];
            dgKetQua.ItemsSource = DanhSachDiem;

            CboKiHoc.ItemsSource = TemplateList.TermID;
        }

        private void BtnTimKiem_Click(object sender, RoutedEventArgs e)
        {
            string mssv = TxtMSSV.Text.Trim();

            if (string.IsNullOrWhiteSpace(mssv))
            {
                MessageBox.Show("Vui lòng nhập MSSV để tìm kiếm.", "Thiếu thông tin", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            DanhSachDiem.Clear();

            string query = @"
                SELECT 
                    d.MaHP, 
                    hp.TenHP, 
                    hp.SoTinChi, 
                    d.DiemGiuaKi, 
                    d.DiemCuoiKi
                FROM diem d
                INNER JOIN hocphan hp ON d.MaHP = hp.MaHP
                WHERE d.MaSV = @MaSV
            ";

            try
            {
                using SqlConnection conn = new(App_Config.connectionString);
                using SqlCommand cmd = new(query, conn);
                cmd.Parameters.AddWithValue("@MaSV", mssv);

                conn.Open();
                using SqlDataReader reader = cmd.ExecuteReader();

                if (!reader.HasRows)
                {
                    MessageBox.Show("Không tìm thấy kết quả nào cho MSSV này.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                MessageBox.Show("Tìm thấy sinh viên");
                while (reader.Read())
                {
                    DiemModel diem = new()
                    {
                        MaMonHoc = reader["MaHP"].ToString(),
                        TenMonHoc = reader["TenHP"].ToString(),
                        SoTinChi = Convert.ToInt32(reader["SoTinChi"]),
                        DiemGK = reader["DiemGiuaKi"] != DBNull.Value ? Convert.ToSingle(reader["DiemGiuaKi"]) : 0,
                        DiemCK = reader["DiemCuoiKi"] != DBNull.Value ? Convert.ToSingle(reader["DiemCuoiKi"]) : 0,
                    };
                    DanhSachDiem.Add(diem);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi truy vấn dữ liệu:\n{ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }



        private void BtnThem_Click(object sender, RoutedEventArgs e)
        {
            string mssv = TxtMSSV.Text.Trim();
            string maHP = TxtMaHP.Text.Trim();
            string maLop = TxtMaLopHocPhan.Text.Trim();
            string? kiHoc = CboKiHoc.SelectedItem?.ToString();
            string strDiemGK = TxtDiemGK.Text.Trim();
            string strDiemCK = TxtDiemCK.Text.Trim();

            if (string.IsNullOrWhiteSpace(mssv) ||
                string.IsNullOrWhiteSpace(maHP) ||
                string.IsNullOrWhiteSpace(maLop) ||
                string.IsNullOrWhiteSpace(kiHoc) ||
                string.IsNullOrWhiteSpace(strDiemGK) ||
                string.IsNullOrWhiteSpace(strDiemCK))
            {
                MessageBox.Show("Vui lòng điền đầy đủ tất cả các trường.", "Thiếu thông tin", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!float.TryParse(strDiemGK, out float diemGK) || !float.TryParse(strDiemCK, out float diemCK))
            {
                MessageBox.Show("Điểm phải là số hợp lệ.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                using SqlConnection conn = new(App_Config.connectionString);
                conn.Open();

                if (!IsExists(conn, "sinhvien", "MaSV", mssv) ||
                    !IsExists(conn, "hocphan", "MaHP", maHP) ||
                    !IsExists(conn, "lophocphan", "MaLop", maLop))
                {
                    MessageBox.Show("Một trong các mã (SV, HP, Lớp) không tồn tại.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Kiểm tra tồn tại bản ghi trùng cả 4 khóa chính
                string fullDupQuery = @"
            SELECT COUNT(*) FROM diem 
            WHERE MaSV = @MaSV AND MaHP = @MaHP AND MaKi = @MaKi AND MaLop = @MaLop";

                using SqlCommand fullDupCmd = new(fullDupQuery, conn);
                fullDupCmd.Parameters.AddWithValue("@MaSV", mssv);
                fullDupCmd.Parameters.AddWithValue("@MaHP", maHP);
                fullDupCmd.Parameters.AddWithValue("@MaKi", kiHoc);
                fullDupCmd.Parameters.AddWithValue("@MaLop", maLop);

                int fullDup = (int)fullDupCmd.ExecuteScalar();

                if (fullDup > 0)
                {
                    MessageBox.Show("Dữ liệu đã tồn tại cho sinh viên, học phần, kỳ học và lớp học phần này.", "Trùng dữ liệu", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Kiểm tra tồn tại bản ghi trùng MaSV, MaHP, MaKi (cập nhật)
                string partialQuery = @"
            SELECT COUNT(*) FROM diem 
            WHERE MaSV = @MaSV AND MaHP = @MaHP AND MaKi = @MaKi";

                using SqlCommand partialCmd = new(partialQuery, conn);
                partialCmd.Parameters.AddWithValue("@MaSV", mssv);
                partialCmd.Parameters.AddWithValue("@MaHP", maHP);
                partialCmd.Parameters.AddWithValue("@MaKi", kiHoc);

                int partialExists = (int)partialCmd.ExecuteScalar();

                if (partialExists > 0)
                {
                    // Cập nhật điểm và mã lớp mới
                    string updateQuery = @"
                UPDATE diem
                SET DiemGiuaKi = @DiemGK,
                    DiemCuoiKi = @DiemCK,
                    MaLop = @MaLop
                WHERE MaSV = @MaSV AND MaHP = @MaHP AND MaKi = @MaKi";

                    using SqlCommand updateCmd = new(updateQuery, conn);
                    updateCmd.Parameters.AddWithValue("@DiemGK", diemGK);
                    updateCmd.Parameters.AddWithValue("@DiemCK", diemCK);
                    updateCmd.Parameters.AddWithValue("@MaLop", maLop);
                    updateCmd.Parameters.AddWithValue("@MaSV", mssv);
                    updateCmd.Parameters.AddWithValue("@MaHP", maHP);
                    updateCmd.Parameters.AddWithValue("@MaKi", kiHoc);

                    updateCmd.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật điểm thành công (với lớp học phần mới).", "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    // Thêm mới bản ghi
                    string insertQuery = @"
                INSERT INTO diem (MaSV, MaHP, MaKi, MaLop, DiemGiuaKi, DiemCuoiKi)
                VALUES (@MaSV, @MaHP, @MaKi, @MaLop, @DiemGK, @DiemCK)";

                    using SqlCommand insertCmd = new(insertQuery, conn);
                    insertCmd.Parameters.AddWithValue("@MaSV", mssv);
                    insertCmd.Parameters.AddWithValue("@MaHP", maHP);
                    insertCmd.Parameters.AddWithValue("@MaKi", kiHoc);
                    insertCmd.Parameters.AddWithValue("@MaLop", maLop);
                    insertCmd.Parameters.AddWithValue("@DiemGK", diemGK);
                    insertCmd.Parameters.AddWithValue("@DiemCK", diemCK);

                    insertCmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm điểm mới thành công.", "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
                }

                BtnTimKiem_Click(null!, null!); // Làm mới danh sách
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xử lý dữ liệu: " + ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnXoa_Click(object sender, RoutedEventArgs e)
        {
            if (dgKetQua.SelectedItem is DiemModel selected)
            {
                // Xác nhận trước khi xóa
                var result = MessageBox.Show("Bạn có chắc chắn muốn xóa điểm này?", "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result != MessageBoxResult.Yes)
                    return;

                try
                {
                    using SqlConnection conn = new(App_Config.connectionString);
                    conn.Open();

                    string deleteQuery = @"
                DELETE FROM diem
                WHERE MaSV = @MaSV AND MaHP = @MaHP AND MaKi = @MaKi";

                    using SqlCommand cmd = new(deleteQuery, conn);
                    cmd.Parameters.AddWithValue("@MaSV", TxtMSSV.Text.Trim()); // hoặc selected.MaSV nếu có
                    cmd.Parameters.AddWithValue("@MaHP", selected.MaMonHoc);
                    cmd.Parameters.AddWithValue("@MaKi", CboKiHoc.SelectedItem?.ToString());

                    int affectedRows = cmd.ExecuteNonQuery();

                    if (affectedRows > 0)
                    {
                        DanhSachDiem.Remove(selected);
                        MessageBox.Show("Xóa điểm thành công.", "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy bản ghi để xóa.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa dữ liệu: " + ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }


        private void BtnCapNhat_Click(object sender, RoutedEventArgs e)
        {
            string mssv = TxtMSSV.Text.Trim();
            string maHP = TxtMaHP.Text.Trim();
            string maLop = TxtMaLopHocPhan.Text.Trim();
            string? kiHoc = CboKiHoc.SelectedItem?.ToString();
            string strDiemGK = TxtDiemGK.Text.Trim();
            string strDiemCK = TxtDiemCK.Text.Trim();

            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrWhiteSpace(mssv) ||
                string.IsNullOrWhiteSpace(maHP) ||
                string.IsNullOrWhiteSpace(maLop) ||
                string.IsNullOrWhiteSpace(kiHoc) ||
                string.IsNullOrWhiteSpace(strDiemGK) ||
                string.IsNullOrWhiteSpace(strDiemCK))
            {
                MessageBox.Show("Vui lòng điền đầy đủ tất cả các trường.", "Thiếu thông tin", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!float.TryParse(strDiemGK, out float diemGK) || !float.TryParse(strDiemCK, out float diemCK))
            {
                MessageBox.Show("Điểm phải là số hợp lệ.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                using SqlConnection conn = new(App_Config.connectionString);
                conn.Open();

                // Kiểm tra bản ghi tồn tại
                string checkQuery = "SELECT COUNT(*) FROM diem WHERE MaSV = @MaSV AND MaHP = @MaHP AND MaKi = @MaKi";
                using SqlCommand checkCmd = new(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@MaSV", mssv);
                checkCmd.Parameters.AddWithValue("@MaHP", maHP);
                checkCmd.Parameters.AddWithValue("@MaKi", kiHoc);

                int count = (int)checkCmd.ExecuteScalar();

                if (count == 0)
                {
                    MessageBox.Show("Không tìm thấy bản ghi điểm để cập nhật.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // 1. Xóa dòng khỏi datagrid (nếu có chọn)
                if (dgKetQua.SelectedItem is DiemModel selected)
                {
                    DanhSachDiem.Remove(selected);
                }

                // 2. Cập nhật điểm
                string updateQuery = @"
            UPDATE diem
            SET DiemGiuaKi = @DiemGK,
                DiemCuoiKi = @DiemCK,
                MaLop = @MaLop
            WHERE MaSV = @MaSV AND MaHP = @MaHP AND MaKi = @MaKi";

                using SqlCommand updateCmd = new(updateQuery, conn);
                updateCmd.Parameters.AddWithValue("@DiemGK", diemGK);
                updateCmd.Parameters.AddWithValue("@DiemCK", diemCK);
                updateCmd.Parameters.AddWithValue("@MaLop", maLop);
                updateCmd.Parameters.AddWithValue("@MaSV", mssv);
                updateCmd.Parameters.AddWithValue("@MaHP", maHP);
                updateCmd.Parameters.AddWithValue("@MaKi", kiHoc);

                updateCmd.ExecuteNonQuery();

                MessageBox.Show("Cập nhật điểm thành công.", "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);

                // Làm mới danh sách nếu cần
                BtnTimKiem_Click(null!, null!);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật dữ liệu: " + ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private static bool IsExists(SqlConnection conn, string table, string column, string value)
        {
            string query = $"SELECT COUNT(*) FROM {table} WHERE {column} = @Value";
            using SqlCommand cmd = new(query, conn);
            cmd.Parameters.AddWithValue("@Value", value);
            return (int)cmd.ExecuteScalar() > 0;
        }

        public static bool CheckCapNhatDiem(string maSV, string maHP, string maLop, string maKi, float diemGK, float diemCK, out string message)
        {
            message = string.Empty;

            try
            {
                using SqlConnection conn = new(App_Config.connectionString);
                conn.Open();

                // Kiểm tra xem dòng dữ liệu có tồn tại chưa
                string checkQuery = "SELECT COUNT(*) FROM diem WHERE MaSV = @MaSV AND MaHP = @MaHP AND MaKi = @MaKi";
                using SqlCommand checkCmd = new(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@MaSV", maSV);
                checkCmd.Parameters.AddWithValue("@MaHP", maHP);
                checkCmd.Parameters.AddWithValue("@MaKi", maKi);

                int count = (int)checkCmd.ExecuteScalar();
                if (count == 0)
                {
                    message = "Không tìm thấy dữ liệu để cập nhật. Vui lòng kiểm tra lại MSSV, Mã học phần và Kỳ học.";
                    return false;
                }

                // Cập nhật điểm
                string updateQuery = @"
                    UPDATE diem
                    SET DiemGiuaKi = @DiemGK,
                        DiemCuoiKi = @DiemCK,
                        MaLop = @MaLop
                    WHERE MaSV = @MaSV AND MaHP = @MaHP AND MaKi = @MaKi";

                using SqlCommand updateCmd = new(updateQuery, conn);
                updateCmd.Parameters.AddWithValue("@DiemGK", diemGK);
                updateCmd.Parameters.AddWithValue("@DiemCK", diemCK);
                updateCmd.Parameters.AddWithValue("@MaLop", maLop);
                updateCmd.Parameters.AddWithValue("@MaSV", maSV);
                updateCmd.Parameters.AddWithValue("@MaHP", maHP);
                updateCmd.Parameters.AddWithValue("@MaKi", maKi);

                int rowsAffected = updateCmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    message = "Cập nhật điểm thành công.";
                    return true;
                }
                else
                {
                    message = "Không có dữ liệu nào được cập nhật.";
                    return false;
                }
            }
            catch (Exception ex)
            {
                message = "Lỗi khi cập nhật dữ liệu: " + ex.Message;
                return false;
            }
        }

    }

    public class DiemModel
    {
        public string? MaMonHoc { get; set; }
        public string? TenMonHoc { get; set; }
        public int SoTinChi { get; set; }
        public float DiemGK { get; set; }
        public float DiemCK { get; set; }
        public float DiemTK { get; set; }
    }
}
