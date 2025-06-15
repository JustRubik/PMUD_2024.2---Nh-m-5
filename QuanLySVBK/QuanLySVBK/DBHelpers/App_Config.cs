namespace QuanLySVBK.DBHelpers
{
    public static class App_Config
    {
        // Dùng kết nối tới file MDF gắn trực tiếp
        public const string connectionString =
            "Server=admin-pc\\sqlexpress;" +
            "Database=D:\\GITHUB\\PMUD_2024.2\\QUANLYSVBK\\QLDSVBK_DATASINHVIEN.MDF;" +
            "Trusted_Connection=True;" +
            "TrustServerCertificate=True;";
    }
}
