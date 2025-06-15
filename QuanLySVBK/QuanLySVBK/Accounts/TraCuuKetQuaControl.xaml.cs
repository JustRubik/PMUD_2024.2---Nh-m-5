using Microsoft.Data.SqlClient;
using QuanLySVBK.DBHelpers;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows.Controls;

namespace QuanLySVBK.Accounts
{
    public partial class TraCuuKetQuaControl : UserControl
    {
        private readonly string? _maSV;

        public ObservableCollection<KetQuaMonHoc> DanhSachKetQua { get; set; } = [];

        public TraCuuKetQuaControl(string? maSV)
        {
            InitializeComponent();
            _maSV = maSV;
            LoadKetQua();
        }

        private void LoadKetQua()
        {
            if (string.IsNullOrWhiteSpace(_maSV)) return;

            DanhSachKetQua.Clear();

            using SqlConnection conn = new(App_Config.connectionString);
            conn.Open();

            string query = @"
                SELECT 
                    d.MaHP, hp.TenHP, hp.SoTinChi, d.MaLop, d.MaKi,
                    d.DiemGiuaKi, d.DiemCuoiKi
                FROM diem d
                JOIN hocphan hp ON d.MaHP = hp.MaHP
                WHERE d.MaSV = @MaSV";

            using SqlCommand cmd = new(query, conn);
            cmd.Parameters.AddWithValue("@MaSV", _maSV);

            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                float gk = reader["DiemGiuaKi"] is DBNull ? 0 : Convert.ToSingle(reader["DiemGiuaKi"]);
                float ck = reader["DiemCuoiKi"] is DBNull ? 0 : Convert.ToSingle(reader["DiemCuoiKi"]);
                float tongKet = (float)Math.Round(gk * 0.4 + ck * 0.6, 2);
                string diemChu = GetDiemChu(tongKet);

                DanhSachKetQua.Add(new KetQuaMonHoc
                {
                    MaHP = reader["MaHP"].ToString(),
                    TenHP = reader["TenHP"].ToString(),
                    SoTinChi = Convert.ToInt32(reader["SoTinChi"]),
                    MaLop = reader["MaLop"].ToString(),
                    MaKi = reader["MaKi"].ToString(),
                    DiemGiuaKi = gk,
                    DiemCuoiKi = ck,
                    DiemTongKet = tongKet,
                    DiemChu = diemChu
                });
            }

            dgKetQua.ItemsSource = DanhSachKetQua;
        }

        private static string GetDiemChu(float diem)
        {
            if (diem >= 8.5) return "A";
            if (diem >= 7.0) return "B";
            if (diem >= 5.5) return "C";
            if (diem >= 4.0) return "D";
            return "F";
        }

        public class KetQuaMonHoc
        {
            public string? MaHP { get; set; }
            public string? TenHP { get; set; }
            public int SoTinChi { get; set; }
            public string? MaLop { get; set; }
            public string? MaKi { get; set; }
            public float DiemGiuaKi { get; set; }
            public float DiemCuoiKi { get; set; }
            public float DiemTongKet { get; set; }
            public string? DiemChu { get; set; }
        }
    }
}
