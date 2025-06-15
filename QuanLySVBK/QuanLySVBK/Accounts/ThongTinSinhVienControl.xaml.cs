using Microsoft.Data.SqlClient;
using QuanLySVBK.DBHelpers;
using System;
using System.Windows;
using System.Windows.Controls;

namespace QuanLySVBK.Accounts
{
    public partial class ThongTinSinhVienControl : UserControl
    {
        private readonly string? _maSV;

        public ThongTinSinhVienControl(string? maSV)
        {
            InitializeComponent();
            _maSV = maSV;
            LoadThongTinSinhVien();
        }

        private void LoadThongTinSinhVien()
        {
            try
            {
                using SqlConnection conn = new(App_Config.connectionString);
                conn.Open();

                string query = @"
                    SELECT HoTen, MaSV, GioiTinh, NgaySinh, QueQuan, CanCuocCongDan, SoDienThoai, MaNganh, GPA, CPA
                    FROM sinhvien
                    WHERE MaSV = @MaSV";

                using SqlCommand cmd = new(query, conn);
                cmd.Parameters.AddWithValue("@MaSV", _maSV);

                using SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    TxtHoTen.Text = reader["HoTen"]?.ToString();
                    TxtMaSV.Text = reader["MaSV"]?.ToString();
                    TxtGioiTinh.Text = reader["GioiTinh"]?.ToString();
                    TxtNgaySinh.Text = Convert.ToDateTime(reader["NgaySinh"]).ToString("dd/MM/yyyy");
                    TxtQueQuan.Text = reader["QueQuan"]?.ToString();
                    TxtCCCD.Text = reader["CanCuocCongDan"]?.ToString();
                    TxtSDT.Text = reader["SoDienThoai"]?.ToString();
                    TxtMaNganh.Text = reader["MaNganh"]?.ToString();
                    TxtGPA.Text = reader["GPA"]?.ToString();
                    TxtCPA.Text = reader["CPA"]?.ToString();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sinh viên.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
