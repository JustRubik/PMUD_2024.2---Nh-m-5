using Microsoft.Data.SqlClient;
using QuanLySVBK.DBHelpers;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using static QuanLySVBK.DBHelpers.ListHelper;

namespace QuanLySVBK
{
    public partial class DanhMucLopHocPhan : UserControl
    {
        private readonly string _role;
        private const string connectionString = App_Config.connectionString;

        public ObservableCollection<LopHocPhan> DanhSachLopHocPhan { get; set; } = [];

        public DanhMucLopHocPhan(string role)
        {
            InitializeComponent();
            _role = role;
            dgLopHocPhan.ItemsSource = DanhSachLopHocPhan;
            CboMaKi.ItemsSource = TemplateList.TermID;
            CboMaVien.ItemsSource = TemplateList.MaViens;

            LoadLopHocPhanTuCSDL();
            ApDungPhanQuyen();
        }

        private void LoadLopHocPhanTuCSDL()
        {
            DanhSachLopHocPhan.Clear();

            try
            {
                using SqlConnection conn = new(App_Config.connectionString);
                conn.Open();

                string query = "SELECT * FROM lophocphan";

                using SqlCommand cmd = new(query, conn);
                using SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string? maHP = reader["MaHP"]?.ToString();
                    string? tenHP = "";

                    // Gọi hàm lấy TênHP tương ứng
                    var hocPhan = GetHocPhanTheoMaHP(maHP);
                    if (hocPhan != null)
                        tenHP = hocPhan.TenHP;

                    DanhSachLopHocPhan.Add(new LopHocPhan
                    {
                        MaLop = reader["MaLop"]?.ToString(),
                        MaHP = maHP,
                        TenHP = tenHP,
                        MaKi = reader["MaKi"]?.ToString(),
                        MaVien = reader["MaVien"]?.ToString(),
                        MaGVHP = reader["MaGV"]?.ToString()
                    });
                }

                dgLopHocPhan.ItemsSource = DanhSachLopHocPhan;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải lớp học phần: " + ex.Message);
            }
        }

        private bool ThongTinLopHocPhanHopLe(out string? errorMsg)
        {
            errorMsg = null;

            if (string.IsNullOrWhiteSpace(TxtMaLop.Text))
            {
                errorMsg = "Vui lòng nhập mã lớp.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(TxtMaHP.Text))
            {
                errorMsg = "Vui lòng nhập mã học phần.";
                return false;
            }

            if (CboMaKi.SelectedValue == null)
            {
                errorMsg = "Vui lòng chọn kì học.";
                return false;
            }

            if (CboMaVien.SelectedValue == null)
            {
                errorMsg = "Vui lòng chọn mã viện.";
                return false;
            }

            return true;
        }

        private void BtnThemMoi_Click(object sender, RoutedEventArgs e)
        {
            if (!ThongTinLopHocPhanHopLe(out string? errorMsg))
            {
                MessageBox.Show(errorMsg, "Thiếu thông tin", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var lhp = new
            {
                MaLop = TxtMaLop.Text.Trim(),
                MaHP = TxtMaHP.Text.Trim(),
                MaKi = CboMaKi.SelectedValue?.ToString(),
                MaVien = CboMaVien.SelectedValue?.ToString(),
                MaGV = TxtMaGVHP.Text.Trim()
            };

            try
            {
                using SqlConnection conn = new(App_Config.connectionString);
                conn.Open();
                using SqlCommand cmd = new(ListHelper.InsertLopHocPhan, conn);
                cmd.Parameters.AddWithValue("@MaLop", lhp.MaLop);
                cmd.Parameters.AddWithValue("@MaHP", lhp.MaHP);
                cmd.Parameters.AddWithValue("@MaKi", lhp.MaKi ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@MaVien", lhp.MaVien ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@MaGVHP", lhp.MaGV ?? (object)DBNull.Value);
                cmd.ExecuteNonQuery();

                LoadLopHocPhanTuCSDL();
                MessageBox.Show("Đã thêm lớp học phần vào CSDL.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm mới lớp học phần: " + ex.Message);
            }
        }


        private void BtnXoa_Click(object sender, RoutedEventArgs e)
        {
            if (_role == "student" || _role == "lecturer")
            {
                MessageBox.Show("Bạn không có quyền xóa lớp học phần.");
                return;
            }

            if (dgLopHocPhan.SelectedItem is LopHocPhan lop)
            {
                try
                {
                    using SqlConnection conn = new(connectionString);
                    conn.Open();
                    using SqlCommand cmd = new(DeleteLopHocPhanByMaLop, conn);
                    cmd.Parameters.AddWithValue("@MaLop", lop.MaLop);
                    cmd.ExecuteNonQuery();

                    LoadLopHocPhanTuCSDL();
                    MessageBox.Show("Đã xóa lớp học phần.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Hãy chọn một lớp để xóa.");
            }
        }

        private void BtnCapNhat_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using SqlConnection conn = new(App_Config.connectionString);
                conn.Open();

                string query = ListHelper.GetUpsertLopHocPhanQuery();

                foreach (var item in dgLopHocPhan.Items)
                {
                    if (item is not DataRowView && item != CollectionView.NewItemPlaceholder)
                    {
                        if (item is LopHocPhan lhp)
                        {
                            using SqlCommand cmd = new(query, conn);

                            cmd.Parameters.AddWithValue("@MaLop", lhp.MaLop);
                            cmd.Parameters.AddWithValue("@MaHP", lhp.MaHP);
                            cmd.Parameters.AddWithValue("@MaKi", lhp.MaKi ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@MaVien", lhp.MaVien ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@MaGVHP", lhp.MaGVHP ?? (object)DBNull.Value);

                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                MessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi lưu: " + ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnTimKiem_Click(object sender, RoutedEventArgs e)
        {
            string maLop = TxtMaLop.Text.Trim().ToLower();
            string maHP = TxtMaHP.Text.Trim().ToLower();
            string maKi = CboMaKi.Text.Trim().ToLower();
            string maVien = CboMaVien.Text.Trim().ToLower();
            string maGV = TxtMaGVHP.Text.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(maLop) &&
                string.IsNullOrWhiteSpace(maHP) &&
                string.IsNullOrWhiteSpace(maKi) &&
                string.IsNullOrWhiteSpace(maVien) &&
                string.IsNullOrWhiteSpace(maGV))
            {
                MessageBox.Show("Vui lòng nhập ít nhất một từ khóa để tìm kiếm.");
                return;
            }

            DanhSachLopHocPhan.Clear();

            try
            {
                using SqlConnection conn = new(connectionString);
                conn.Open();

                using SqlCommand cmd = new(SearchLopHocPhanByKeyWord(), conn);
                cmd.Parameters.AddWithValue("@MaLop", string.IsNullOrWhiteSpace(maLop) ? DBNull.Value : $"%{maLop}%");
                cmd.Parameters.AddWithValue("@MaHP", string.IsNullOrWhiteSpace(maHP) ? DBNull.Value : $"%{maHP}%");
                cmd.Parameters.AddWithValue("@MaKi", string.IsNullOrWhiteSpace(maKi) ? DBNull.Value : $"%{maKi}%");
                cmd.Parameters.AddWithValue("@MaVien", string.IsNullOrWhiteSpace(maVien) ? DBNull.Value : $"%{maVien}%");
                cmd.Parameters.AddWithValue("@MaGVHP", string.IsNullOrWhiteSpace(maGV) ? DBNull.Value : $"%{maGV}%");

                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string? maHPFromReader = reader["MaHP"]?.ToString();
                    string? tenHP = "";
                    var hocPhan = GetHocPhanTheoMaHP(maHPFromReader);
                    if (hocPhan != null)
                        tenHP = hocPhan.TenHP;

                    DanhSachLopHocPhan.Add(new LopHocPhan
                    {
                        MaLop = reader["MaLop"]?.ToString(),
                        MaHP = maHPFromReader,
                        TenHP = tenHP,
                        MaKi = reader["MaKi"]?.ToString(),
                        MaVien = reader["MaVien"]?.ToString(),
                        MaGVHP = reader["MaGV"]?.ToString()
                    });
                }

                if (DanhSachLopHocPhan.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy lớp học phần nào phù hợp.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message);
            }
        }


        private void BtnInDS_Click(object sender, RoutedEventArgs e)
        {
            LoadLopHocPhanTuCSDL();
        }

        private void ApDungPhanQuyen()
        {
            if (_role == "student" || _role == "lecturer")
            {
                BtnThemMoi.IsEnabled = false;
                BtnXoa.IsEnabled = false;
                BtnCapNhat.IsEnabled = false;
                BtnThemMoi.Visibility = Visibility.Collapsed;
                BtnXoa.Visibility = Visibility.Collapsed;
                BtnCapNhat.Visibility = Visibility.Collapsed;
            }
        }

        // --- Kết nối với bảng khác ---
        private static HocPhan? GetHocPhanTheoMaHP(string? maHP)
        {
            try
            {
                using SqlConnection conn = new(App_Config.connectionString);
                conn.Open();

                string query = "SELECT * FROM hocphan WHERE MaHP = @MaHP";

                using SqlCommand cmd = new(query, conn);
                cmd.Parameters.AddWithValue("@MaHP", maHP);

                using SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new HocPhan
                    {
                        MaHP = reader["MaHP"]?.ToString(),
                        TenHP = reader["TenHP"]?.ToString(),
                        MaVien = reader["MaVien"]?.ToString(),
                        SoTinChi = reader["SoTinChi"] == DBNull.Value ? 0 : Convert.ToInt32(reader["SoTinChi"])
                    };
                }
                else
                {
                    return null; // Không tìm thấy học phần
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi truy vấn học phần: " + ex.Message);
                return null;
            }
        }
    }
}
