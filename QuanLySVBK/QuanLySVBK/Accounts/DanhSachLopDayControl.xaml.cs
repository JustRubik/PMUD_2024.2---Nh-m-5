using Microsoft.Data.SqlClient;
using QuanLySVBK.DBHelpers;
using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace QuanLySVBK.Accounts
{
    public partial class DanhSachLopDayControl : UserControl
    {
        public ObservableCollection<LopDayModel> DanhSachLopDay { get; set; } = [];
        private readonly string? _maGV;

        public DanhSachLopDayControl(string? maGV)
        {
            InitializeComponent();
            _maGV = maGV;
            LoadDanhSachLopDay();
        }

        private void LoadDanhSachLopDay()
        {
            DanhSachLopDay.Clear();

            using SqlConnection conn = new(App_Config.connectionString);
            conn.Open();

            string query = "SELECT MaLop, MaHP, MaVien, MaKi FROM lophocphan WHERE MaGV = @MaGV";
            using SqlCommand cmd = new(query, conn);
            cmd.Parameters.AddWithValue("@MaGV", _maGV);

            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                DanhSachLopDay.Add(new LopDayModel
                {
                    MaLop = reader["MaLop"].ToString(),
                    MaHP = reader["MaHP"].ToString(),
                    MaVien = reader["MaVien"].ToString(),
                    MaKi = reader["MaKi"].ToString()
                });
            }

            dgLopDay.ItemsSource = DanhSachLopDay;
        }

        public class LopDayModel
        {
            public string? MaLop { get; set; }
            public string? MaHP { get; set; }
            public string? MaVien { get; set; }
            public string? MaKi { get; set; }
        }
    }
}
