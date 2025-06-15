using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Windows;

namespace QuanLySVBK.DBHelpers
{
    public static class LoginHelper
    {

        // Trả về ID nếu đăng nhập đúng, ngược lại trả về null
        public static string? TryLogin(string usernameOrId, string password, string tableName)
        {
            string? query = tableName switch
            {
                "Admin" => "SELECT Username, Password FROM Admin WHERE Username = @user",
                "taikhoan_sinhvien" =>
                    int.TryParse(usernameOrId, out _) ?
                    "SELECT MaSV, Password FROM taikhoan_sinhvien WHERE MaSV = @user" :
                    "SELECT MaSV, Password FROM taikhoan_sinhvien WHERE Username = @user",

                "taikhoan_giangvien" =>
                    int.TryParse(usernameOrId, out _) ?
                    "SELECT MaGV, Password FROM taikhoan_giangvien WHERE MaGV = @user" :
                    "SELECT MaGV, Password FROM taikhoan_giangvien WHERE Username = @user",

                _ => null
            };


            if (query == null)
                return null;

            try
            {
                using SqlConnection conn = new(App_Config.connectionString);
                using SqlCommand cmd = new(query, conn);
                cmd.Parameters.AddWithValue("@user", usernameOrId);
                conn.Open();

                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string id = reader[0]?.ToString() ?? "";
                    string storedPassword = reader[1]?.ToString() ?? "";

                    if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(storedPassword))
                        return null;

                    return storedPassword == password ? id : null;
                }
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi truy vấn đăng nhập: " + ex.Message);
                return null;
            }
        }
    }
}
