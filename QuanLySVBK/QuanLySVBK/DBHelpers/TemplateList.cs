namespace QuanLySVBK.DBHelpers
{
    public static class TemplateList
    {
        public static readonly string[] Cities = [
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
        }.OrderBy(c => c == "KHÁC" ? 1 : 0).ThenBy(c => c)];

        public static readonly string[] MaNganhs = [.. new string[]
        {
            "ET2", "ME1", "ET1", "MI2", "ME2", "FL2", "MI1", "EE1", "EE2", "FL1", "IT1", "IT2", "KHÁC"
        }.OrderBy(c => c == "KHÁC" ? 1 : 0).ThenBy(c => c)];

        public static readonly string[] TermID = [.. new string[]
        {
            "20242", "20241", "20232", "20231", "20222", "20221",
            "20212", "20211", "20202", "20201", "20192", "20191"
        }.OrderByDescending(static c => c)];

    }
}
