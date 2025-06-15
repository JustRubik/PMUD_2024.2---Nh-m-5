using Microsoft.Data.SqlClient;
using System.Windows;

namespace QuanLySVBK.DBHelpers
{
    public static class UserHelper
    {

        public static string GetFullName(string username, string id, string role)
        {
            string? query = role switch
            {
                "student" => @"
                    SELECT sinhvien.HoTen
                    FROM sinhvien
                    JOIN taikhoan_sinhvien ON sinhvien.MaSV = taikhoan_sinhvien.MaSV
                    WHERE taikhoan_sinhvien.Username = @username OR taikhoan_sinhvien.MaSV = @id;",

                "lecturer" => @"
                    SELECT giangvien.HoTen
                    FROM giangvien
                    JOIN taikhoan_giangvien ON giangvien.MaGV = taikhoan_giangvien.MaGV
                    WHERE taikhoan_giangvien.Username = @username OR taikhoan_giangvien.MaGV = @id;",

                _ => null
            };

            if (query == null) return username;

            try
            {
                using SqlConnection conn = new(App_Config.connectionString);
                conn.Open();
                using SqlCommand cmd = new(query, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@id", id);

                using SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return reader["HoTen"] as string ?? username;
                }
            }
            catch
            {
                return username;
            }

            return username;
        }
    }
}
