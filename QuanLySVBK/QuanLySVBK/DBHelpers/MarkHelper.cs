using Microsoft.Data.SqlClient;

namespace QuanLySVBK.DBHelpers
{
    public static class MarkHelper
    {
        public const string KetNoiCacBang = @"SELECT
            sv.MaSV,
            sv.HoTen,
            d.MaHP,
            hp.TenHP,
            hp.SoTinChi,
            d.MaLop,
            d.MaKi,
            ROUND(ISNULL(d.DiemGiuaKi, 0) * 0.4 + ISNULL(d.DiemCuoiKi, 0) * 0.6, 2) AS Diem
        FROM diem d
        JOIN sinhvien sv ON d.MaSV = sv.MaSV
        JOIN hocphan hp ON d.MaHP = hp.MaHP
        JOIN lophocphan lhp ON d.MaLop = lhp.MaLop
        WHERE d.MaSV = @MaSV AND d.MaKi <= @MaKi
        ";
    }


    public class KetQuaMonHoc
    {
        public string? MaSV { get; set; }           // = MaSinhVien
        public string? HoTen { get; set; }
        public string? MaNganh { get; set; }
        public string? MaMonHoc { get; set; }
        public string? TenMonHoc { get; set; }
        public string? MaLop { get; set; }
        public string? MaKi { get; set; }
        public int SoTinChi { get; set; }
        public double Diem { get; set; }
    }


}
