using Microsoft.Data.SqlClient;
using QuanLySVBK.DBHelpers;
using System;
using System.Windows;
using System.Windows.Controls;

namespace QuanLySVBK.Accounts
{
    public partial class ThongTinGiangVienControl : UserControl
    {
        private readonly string? _maGV;

        public ThongTinGiangVienControl(string? maGV)
        {
            InitializeComponent();
            _maGV = maGV;
            LoadThongTin();
        }

        private void LoadThongTin()
        {
            if (string.IsNullOrWhiteSpace(_maGV)) return;

            using SqlConnection conn = new(App_Config.connectionString);
            conn.Open();

            string query = @"
                SELECT HoTen, GioiTinh, NgaySinh, QueQuan, CanCuocCongDan, SoDienThoai, MaVien
                FROM giangvien
                WHERE MaGV = @MaGV";

            using SqlCommand cmd = new(query, conn);
            cmd.Parameters.AddWithValue("@MaGV", _maGV);

            using SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                TxtHoTen.Text = reader["HoTen"].ToString();
                TxtMaGV.Text = _maGV;
                TxtGioiTinh.Text = reader["GioiTinh"].ToString();
                TxtNgaySinh.Text = Convert.ToDateTime(reader["NgaySinh"]).ToString("dd/MM/yyyy");
                TxtQueQuan.Text = reader["QueQuan"].ToString();
                TxtCCCD.Text = reader["CanCuocCongDan"].ToString();
                TxtSDT.Text = reader["SoDienThoai"].ToString();
                TxtMaVien.Text = reader["MaVien"].ToString();
            }
        }
    }
}
