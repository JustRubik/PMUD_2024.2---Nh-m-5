using Microsoft.Data.SqlClient;
using QuanLySVBK.DBHelpers;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows.Controls;

namespace QuanLySVBK.Accounts
{
    public partial class TraCuuMonHocControl : UserControl
    {
        public ObservableCollection<HocPhanModel> DanhSachHocPhan { get; set; } = [];

        public TraCuuMonHocControl()
        {
            InitializeComponent();
            LoadHocPhan();
        }

        private void LoadHocPhan()
        {
            DanhSachHocPhan.Clear();

            using SqlConnection conn = new(App_Config.connectionString);
            conn.Open();

            string query = "SELECT MaHP, TenHP, SoTinChi, MaVien FROM hocphan";

            using SqlCommand cmd = new(query, conn);
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                DanhSachHocPhan.Add(new HocPhanModel
                {
                    MaHP = reader["MaHP"].ToString(),
                    TenHP = reader["TenHP"].ToString(),
                    SoTinChi = Convert.ToInt32(reader["SoTinChi"]),
                    MaVien = reader["MaVien"].ToString()
                });
            }

            dgMonHoc.ItemsSource = DanhSachHocPhan;
        }

        public class HocPhanModel
        {
            public string? MaHP { get; set; }
            public string? TenHP { get; set; }
            public int SoTinChi { get; set; }
            public string? MaVien { get; set; }
        }
    }
}
