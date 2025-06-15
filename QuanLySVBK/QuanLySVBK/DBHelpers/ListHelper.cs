using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows;

namespace QuanLySVBK.DBHelpers
{
    public static class ListHelper
    {
        // --- GIẢNG VIÊN ---
        public const string GetAllGiangVien = "SELECT * FROM giangvien";

        public const string InsertGiangVien = @"
            INSERT INTO giangvien (MaGV, HoTen, GioiTinh, NgaySinh, QueQuan, CanCuocCongDan, SoDienThoai, MaVien)
            VALUES (@MaGV, @HoTen, @GioiTinh, @NgaySinh, @QueQuan, @CCCD, @SoDT, @MaVien)";

        public const string DeleteGiangVienByMaGV = "DELETE FROM giangvien WHERE MaGV = @MaGV";

        public static string SearchGiangVienByKeyWord() => @"
            SELECT * FROM giangvien
            WHERE 
                (@MaGV IS NULL OR LOWER(MaGV) LIKE @MaGV)
                AND (@HoTen IS NULL OR LOWER(HoTen) LIKE @HoTen)
                AND (@GioiTinh IS NULL OR LOWER(GioiTinh) LIKE @GioiTinh)
                AND (@QueQuan IS NULL OR LOWER(QueQuan) LIKE @QueQuan)
                AND (@CCCD IS NULL OR LOWER(CanCuocCongDan) LIKE @CCCD)
                AND (@SoDT IS NULL OR LOWER(SoDienThoai) LIKE @SoDT)
                AND (@MaVien IS NULL OR LOWER(MaVien) LIKE @MaVien)";

        public static string GetUpsertGiangVienQuery() => @"
            IF EXISTS (SELECT 1 FROM giangvien WHERE MaGV = @MaGV)
                UPDATE giangvien
                SET HoTen = @HoTen, GioiTinh = @GioiTinh, NgaySinh = @NgaySinh, QueQuan = @QueQuan, CanCuocCongDan = @CCCD, SoDienThoai = @SoDT, MaVien = @MaVien
                WHERE MaGV = @MaGV
            ELSE
                INSERT INTO giangvien (MaGV, HoTen, GioiTinh, NgaySinh, QueQuan, CanCuocCongDan, SoDienThoai, MaVien)
                VALUES (@MaGV, @HoTen, @GioiTinh, @NgaySinh, @QueQuan, @CCCD, @SoDT, @MaVien)";

        // --- SINH VIÊN ---
        public const string GetAllSinhVien = "SELECT * FROM sinhvien";

        public const string InsertSinhVien = @"
            INSERT INTO sinhvien (MaSV, HoTen, GioiTinh, NgaySinh, QueQuan, CanCuocCongDan, SoDienThoai, MaNganh)
            VALUES (@MaSV, @HoTen, @GioiTinh, @NgaySinh, @QueQuan, @CCCD, @SoDT, @MaNganh)";

        public const string DeleteSinhVienByMaSV = "DELETE FROM sinhvien WHERE MaSV = @MaSV";

        public static string SearchSinhVienByKeyWord() => @"
            SELECT * FROM sinhvien
            WHERE 
                (@MaSV IS NULL OR LOWER(MaSV) LIKE @MaSV)
                AND (@HoTen IS NULL OR LOWER(HoTen) LIKE @HoTen)
                AND (@GioiTinh IS NULL OR LOWER(GioiTinh) LIKE @GioiTinh)
                AND (@QueQuan IS NULL OR LOWER(QueQuan) LIKE @QueQuan)
                AND (@CCCD IS NULL OR LOWER(CanCuocCongDan) LIKE @CCCD)
                AND (@SoDT IS NULL OR LOWER(SoDienThoai) LIKE @SoDT)
                AND (@MaNganh IS NULL OR LOWER(MaNganh) LIKE @MaNganh)";

        public static string GetUpsertSinhVienQuery() => @"
            IF EXISTS (SELECT 1 FROM sinhvien WHERE MaSV = @MaSV)
                UPDATE sinhvien
                SET HoTen = @HoTen, GioiTinh = @GioiTinh, NgaySinh = @NgaySinh, QueQuan = @QueQuan, CanCuocCongDan = @CCCD, SoDienThoai = @SoDT, MaNganh = @MaNganh
                WHERE MaSV = @MaSV
            ELSE
                INSERT INTO sinhvien (MaSV, HoTen, GioiTinh, NgaySinh, QueQuan, CanCuocCongDan, SoDienThoai, MaNganh)
                VALUES (@MaSV, @HoTen, @GioiTinh, @NgaySinh, @QueQuan, @CCCD, @SoDT, @MaNganh)";

        // --- HỌC PHẦN ---
        public const string GetAllHocPhan = "SELECT * FROM hocphan";

        public const string InsertHocPhan = @"
            INSERT INTO hocphan (MaHP, TenHP, MaVien, SoTinChi)
            VALUES (@MaHP, @TenHP, @MaVien, @SoTC)";

        public const string DeleteHocPhanByMaHP = "DELETE FROM hocphan WHERE MaHP = @MaHP";

        public static string GetUpsertHocPhanQuery() => @"
            IF EXISTS (SELECT 1 FROM hocphan WHERE MaHP = @MaHP)
                UPDATE hocphan
                SET TenHP = @TenHP, SoTinChi = @SoTC, MaVien = @MaVien
                WHERE MaHP = @MaHP
            ELSE
                INSERT INTO hocphan(MaHP, TenHP, MaVien, SoTinChi) 
                VALUES(@MaHP, @TenHP, @MaVien, @SoTC)";

        public static string SearchHocPhanByKeyWord() => @"
            SELECT * FROM hocphan
            WHERE (@MaHP IS NULL OR LOWER(MaHP) LIKE @MaHP)
                AND (@TenHP IS NULL OR LOWER(TenHP) LIKE @TenHP)
                AND (@MaVien IS NULL OR LOWER(MaVien) LIKE @MaVien)
                AND (@SoTC IS NULL OR SoTinChi = @SoTC)";

        // --- VIỆN ---
        public const string GetAllVien = "SELECT * FROM vien";

        public const string InsertVien = @"
            INSERT INTO vien (MaVien, TenVien, VienTruong, Website, DiaChiVanPhong)
            VALUES (@MaVien, @TenVien, @VienTruong, @Website, @DiaChi)";

        public const string DeleteVien = "DELETE FROM vien WHERE MaVien = @MaVien";

        public const string FindVienTheoTen = "SELECT * FROM vien WHERE TenVien LIKE @TenVien";

        public const string UpdateVien = @"
            UPDATE vien
            SET TenVien = @TenVien, VienTruong = @VienTruong, Website = @Website, DiaChiVanPhong = @DiaChiVanPhong
            WHERE MaVien = @MaVien";


        public const string SearchVienByKeyword = @"
            SELECT * FROM vien
            WHERE (@MaVien IS NULL OR MaVien LIKE @MaVien)
                AND (@TenVien IS NULL OR TenVien LIKE @TenVien)
                AND (@VienTruong IS NULL OR VienTruong LIKE @VienTruong)
                AND (@Website IS NULL OR Website LIKE @Website)
                AND (@DiaChiVanPhong IS NULL OR DiaChiVanPhong LIKE @DiaChiVanPhong)";

        // --- LỚP HỌC PHẦN ---
        public const string GetAllLopHocPhan = "SELECT * FROM lophocphan";

        public const string InsertLopHocPhan = @"
            INSERT INTO lophocphan (MaLop, MaHP, MaVien, MaKi, MaGV)
            VALUES (@MaLop, @MaHP, @MaVien, @MaKi, @MaGVHP)";

        public const string DeleteLopHocPhanByMaLop = "DELETE FROM lophocphan WHERE MaLop = @MaLop";

        public static string GetUpsertLopHocPhanQuery() => @"
            IF EXISTS (SELECT 1 FROM lophocphan WHERE MaLop = @MaLop)
                UPDATE lophocphan
                SET MaHP = @MaHP, MaVien = @MaVien, MaKi = @MaKi, MaGV = @MaGVHP
                WHERE MaLop = @MaLop
            ELSE
                INSERT INTO lophocphan (MaLop, MaHP, MaVien, MaKi, MaGV)
                VALUES (@MaLop, @MaHP, @MaVien, @MaKi, @MaGVHP)";

        public static string SearchLopHocPhanByKeyWord() => @"
            SELECT * FROM lophocphan
            WHERE (@MaLop IS NULL OR LOWER(MaLop) LIKE @MaLop)
                AND (@MaHP IS NULL OR LOWER(MaHP) LIKE @MaHP)
                AND (@MaVien IS NULL OR LOWER(MaVien) LIKE @MaVien)
                AND (@MaKi IS NULL OR LOWER(MaKi) LIKE @MaKi)
                AND (@MaGVHP IS NULL OR LOWER(MaGV) LIKE @MaGVHP)";
    }

    public static class ValidationHelper
    {
        public static bool KiemTraTrong(string value, string message, out string? errorMessage)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                errorMessage = message;
                return false;
            }
            errorMessage = null;
            return true;
        }
    }

    // --- MODELS ---
    public class GiangVien
    {
        public string? MaGV { get; set; }
        public string? HoTen { get; set; }
        public string? GioiTinh { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string? QueQuan { get; set; }
        public string? CanCuocCongDan { get; set; }
        public string? SoDienThoai { get; set; }
        public string? MaVien { get; set; }
    }

    public class SinhVien
    {
        public string? MaSV { get; set; }
        public string? HoTen { get; set; }
        public string? GioiTinh { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string? QueQuan { get; set; }
        public string? CanCuocCongDan { get; set; }
        public string? SoDienThoai { get; set; }
        public string? MaNganh { get; set; }
    }

    public class HocPhan
    {
        public string? MaHP { get; set; }
        public string? TenHP { get; set; }
        public string? MaVien { get; set; }
        public int SoTinChi { get; set; }
    }

    public class Vien
    {
        public string? MaVien { get; set; }
        public string? TenVien { get; set; }
        public string? VienTruong { get; set; }
        public string? Website { get; set; }
        public string? DiaChiVanPhong { get; set; }
    }

    public class LopHocPhan
    {
        public string? MaLop { get; set; }
        public string? MaHP { get; set; }
        public string? TenHP { get; set; }
        public string? MaKi { get; set; }
        public string? MaVien { get; set; }
        public string? MaGVHP { get; set; }
    }

}
