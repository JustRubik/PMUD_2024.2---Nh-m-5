using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QuanLySVBK.DBHelpers
{
    public static class ListHelper
    {
        // --- TRUY VẤN DỮ LIỆU GIẢNG VIÊN
        public const string GetAllGiangVien = "SELECT * FROM giangvien";

        public const string InsertGiangVien = @"
            INSERT INTO giangvien (MaGV, HoTen, GioiTinh, NgaySinh, QueQuan, CanCuocCongDan, SoDienThoai, MaVien)
            VALUES (@MaGV, @HoTen, @GioiTinh, @NgaySinh, @QueQuan, @CCCD, @SoDT, @MaVien)";

        public const string DeleteGiangVienByMaGV = "DELETE FROM giangvien WHERE MaGV = @MaGV";

        public const string SearchGiangVienByHoTen = @"
                    SELECT * FROM giangvien
                    WHERE LOWER(HoTen) LIKE @keyword
                       OR LOWER(MaGV) LIKE @keyword
                       OR LOWER(MaVien) LIKE @keyword";
        public static string GetUpsertGiangVienQuery()
        {
            return @"
                IF EXISTS (SELECT 1 FROM giangvien WHERE MaGV = @MaGV)
                    UPDATE giangvien
                    SET HoTen = @HoTen, GioiTinh = @GioiTinh, NgaySinh = @NgaySinh, QueQuan = @QueQuan, CanCuocCongDan = @CCCD, SoDienThoai = @SoDT, MaVien = @MaVien
                    WHERE MaGV = @MaGV
                ELSE
                    INSERT INTO giangvien (MaGV, HoTen, GioiTinh, NgaySinh, QueQuan, CanCuocCongDan, SoDienThoai, MaVien)
                    VALUES (@MaGV, @HoTen, @GioiTinh, @NgaySinh, @QueQuan, @CCCD, @SoDT, @MaVien)";
        }

        // --- TRUY VẤN DỮ LIỆU SINH VIÊN ---
        public const string GetAllSinhVien = "SELECT * FROM sinhvien";

        public const string InsertSinhVien = @"
            INSERT INTO sinhvien (MaSV, HoTen, GioiTinh, NgaySinh, QueQuan, CanCuocCongDan, SoDienThoai, MaNganh)
            VALUES (@MaSV, @HoTen, @GioiTinh, @NgaySinh, @QueQuan, @CCCD, @SoDT, @MaNganh)";

        public const string DeleteSinhVienByMaSV = "DELETE FROM sinhvien WHERE MaSV = @MaSV";

        public const string SearchSinhVienByHoTen = @"
                SELECT * FROM sinhvien
                WHERE LOWER(MaSV) LIKE @keyword
                   OR LOWER(MaSV) LIKE @keyword
                   OR LOWER(MaNganh) LIKE @keyword
                   OR LOWER(MaSV) LIKE @keyword
                   OR LOWER(QueQuan) LIKE @keyword
                   OR LOWER(CanCuocCongDan) LIKE @keyword
                   OR LOWER(SoDienThoai) LIKE @keyword
                   OR LOWER(MaNganh) LIKE @keyword";
        public static string GetUpsertSinhVienQuery()
        {
            return @"
                IF EXISTS (SELECT 1 FROM sinhvien WHERE MaSV = @MaSV)
                    UPDATE sinhvien
                    SET HoTen = @HoTen, GioiTinh = @GioiTinh, NgaySinh = @NgaySinh, QueQuan = @QueQuan, CanCuocCongDan = @CCCD, SoDienThoai = @SoDT, MaNganh = @MaNganh
                    WHERE MaSV = @MaSV
                ELSE
                    INSERT INTO sinhvien (MaSV, HoTen, GioiTinh, NgaySinh, QueQuan, CanCuocCongDan, SoDienThoai, MaNganh)
                    VALUES (@MaSV, @HoTen, @GioiTinh, @NgaySinh, @QueQuan, @CCCD, @SoDT, @MaNganh)";
        }
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

    public static class TemplateList
    {
        public static readonly string[] Cities =
        [
        "Hà Nội", "TP.HCM", "Đà Nẵng", "Hải Phòng", "Cần Thơ",
        "An Giang", "Bà Rịa - Vũng Tàu", "Bắc Giang", "Bắc Kạn", "Bạc Liêu",
        "Bắc Ninh", "Bến Tre", "Bình Định", "Bình Dương", "Bình Phước",
        "Bình Thuận", "Cà Mau", "Cao Bằng", "Đắk Lắk", "Đắk Nông",
        "Điện Biên", "Đồng Nai", "Đồng Tháp", "Gia Lai", "Hà Giang",
        "Hà Nam", "Hà Tĩnh", "Hải Dương", "Hậu Giang", "Hòa Bình",
        "Hưng Yên", "Khánh Hòa", "Kiên Giang", "Kon Tum", "Lai Châu",
        "Lâm Đồng", "Lạng Sơn", "Lào Cai", "Long An", "Nam Định",
        "Nghệ An", "Ninh Bình", "Ninh Thuận", "Phú Thọ", "Phú Yên",
        "Quảng Bình", "Quảng Nam", "Quảng Ngãi", "Quảng Ninh", "Quảng Trị",
        "Sóc Trăng", "Sơn La", "Tây Ninh", "Thái Bình", "Thái Nguyên",
        "Thanh Hóa", "Thừa Thiên Huế", "Tiền Giang", "Trà Vinh", "Tuyên Quang",
        "Vĩnh Long", "Vĩnh Phúc", "Yên Bái", "Khác"
        ];

        public static readonly string[] MaViens = [.. new string[]
        {
            "FAMI", "SET", "SEE", "SME", "SOFL", "SOICT", "KHÁC"
        }.OrderBy(c => c == "KHÁC" ? 1 : 0).ThenBy(c=>c)];

        public static readonly string[] MaNganhs = [.. new string[]
        {
            "ET2", "ME1", "ET1", "MI2", "ME2", "FL2", "MI1", "EE1", "EE2", "FL1", "IT1", "IT2", "KHÁC"
        }.OrderBy(c => c == "KHÁC" ? 1 : 0).ThenBy(c=>c)];
    }
}
