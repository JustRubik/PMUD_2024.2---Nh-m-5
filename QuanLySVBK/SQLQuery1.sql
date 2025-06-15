/*USE QuanLyDiemSVBK;
GO

DECLARE @sql NVARCHAR(MAX) = N'';

SELECT @sql += 'DROP TABLE [' + SCHEMA_NAME(schema_id) + '].[' + name + '];'
FROM sys.tables;

EXEC sp_executesql @sql;
*/

CREATE DATABASE QuanLyDiemSVBK
ON
(	NAME = 'qldsvbk_datasinhvien',
	FILENAME = 'D:\GITHUB\PMUD_2024.2\QuanLySVBK\QuanLySVBK\App_Data\qldsvbk_datasinhvien.mdf',
	SIZE =100MB,
	MAXSIZE = 1000MB,
	FILEGROWTH = 50MB)
LOG ON
(	
NAME = 'qldsvbk_log',
	FILENAME = 'D:\GITHUB\PMUD_2024.2\QuanLySVBK\QuanLySVBK\App_Data\qldsvbk_datasinhvien.ldf',
	SIZE =100MB,
	MAXSIZE = 1000MB,
	FILEGROWTH = 50MB)
GO

USE QuanLyDiemSVBK;
GO

CREATE TABLE [Admin](
	MaAD	Varchar(10) primary key,
	Username Varchar(50) NULL,
	Password Varchar(25) NULL
);

CREATE TABLE [vien](
	[MaVien] [nvarchar](25) NOT NULL,
	[VienTruong] [nvarchar](100) NOT NULL,
	[TenVien] [nvarchar](100) NOT NULL,
	[Website] [nvarchar](255) NULL,
	[DiaChiVanPhong] [nvarchar](255) NULL,
 CONSTRAINT [PK_vien_MaVien] PRIMARY KEY CLUSTERED 
(
	[MaVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO 
CREATE TABLE [sinhvien](
	[MaSV] [int] NOT NULL,
	[HoTen] [nvarchar](100) NOT NULL,
	[GioiTinh] [nvarchar](10) NOT NULL,
	[NgaySinh] [date] NULL,
	[QueQuan] [nvarchar](255) NULL,
	[CanCuocCongDan] [nvarchar](20) NULL,
	[SoDienThoai] [nvarchar](15) NULL,
	[MaNganh] [nvarchar](20) NULL,
 CONSTRAINT [PK_sinhvien_MaSV] PRIMARY KEY CLUSTERED 
(
	[MaSV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO 
CREATE TABLE [nganhdaotao](
	[MaNganh] [nvarchar](20) NOT NULL,
	[MaVien] [nvarchar](25) NOT NULL,
	[TenNganh] [nvarchar](225) NOT NULL,
 CONSTRAINT [PK_nganhdaotao_MaNganh] PRIMARY KEY CLUSTERED 
(
	[MaNganh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO 
CREATE TABLE [giangvien](
	[MaGV] [int] NOT NULL,
	[HoTen] [nvarchar](100) NOT NULL,
	[GioiTinh] [nvarchar](10) NOT NULL,
	[NgaySinh] [date] NULL,
	[QueQuan] [nvarchar](255) NULL,
	[CanCuocCongDan] [nvarchar](20) NULL,
	[SoDienThoai] [nvarchar](15) NULL,
	[MaVien] [nvarchar](25) NOT NULL,
 CONSTRAINT [PK_giangvien_MaGV] PRIMARY KEY CLUSTERED 
(
	[MaGV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO 
CREATE TABLE [taikhoan_sinhvien] (
    MaSV INT NOT NULL,
    Username NVARCHAR(50) NULL,
    Password NVARCHAR(50) NULL,
    CONSTRAINT PK_taikhoan_sinhvien PRIMARY KEY (MaSV),
    CONSTRAINT FK_taikhoan_sinhvien_MaSV FOREIGN KEY (MaSV)
        REFERENCES sinhvien(MaSV)
        ON DELETE CASCADE
)
GO
CREATE TABLE [taikhoan_giangvien] (
    MaGV INT NOT NULL,
    Username NVARCHAR(50) NULL,
    Password NVARCHAR(50) NULL,
    CONSTRAINT PK_taikhoan_giangvien PRIMARY KEY (MaGV),
    CONSTRAINT FK_taikhoan_giangvien_MaGV FOREIGN KEY (MaGV)
        REFERENCES giangvien(MaGV)
        ON DELETE CASCADE
)
GO
CREATE TABLE [capgiayto](
	[MaSV] [int] NOT NULL,
	[NgayCap] [date] NOT NULL,
	[LoaiGiayTo] [nvarchar](225) NULL,
	[TrangThai] [nvarchar](225) NOT NULL,
 CONSTRAINT [PK_capgiayto_MaSV] PRIMARY KEY CLUSTERED 
(
	[MaSV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO 
CREATE TABLE [hocphan](
	[MaHP] [nvarchar](20) NOT NULL,
	[TenHP] [nvarchar](100) NOT NULL,
	[SoTinChi] [int] NOT NULL,
	[MaVien] [nvarchar](25) NOT NULL,
 CONSTRAINT [PK_hocphan_MaHP] PRIMARY KEY CLUSTERED 
(
	[MaHP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO 
CREATE TABLE [lophocphan](
	[MaLop] [nvarchar](20) NOT NULL,
	[MaHP] [nvarchar](20) NOT NULL,
	[MaVien] [nvarchar](25) NOT NULL,
	[MaKi] [nvarchar](20) NULL,
	[MaGV] [int] NOT NULL,
 CONSTRAINT [PK_lophocphan_MaLop] PRIMARY KEY CLUSTERED 
(
	[MaLop] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO 
CREATE TABLE [diem](
	[MaHP] [nvarchar](20) NOT NULL,
	[MaSV] [int] NOT NULL,
	[MaLop] [nvarchar](20) NOT NULL,
	[MaKi] [nvarchar](20) NOT NULL,
	[DiemGiuaKi] [real] NULL,
	[DiemCuoiKi] [real] NULL,
 CONSTRAINT [PK_diem_MaHP] PRIMARY KEY CLUSTERED 
(
	[MaHP] ASC,
	[MaSV] ASC,
	[MaKi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
-- sinhvien.MaNganh -> nganhdaotao.MaNganh
ALTER TABLE sinhvien
ADD CONSTRAINT FK_sinhvien_nganh
FOREIGN KEY (MaNganh) REFERENCES nganhdaotao(MaNganh);

-- nganhdaotao.MaVien -> vien.MaVien
ALTER TABLE nganhdaotao
ADD CONSTRAINT FK_nganhdaotao_vien
FOREIGN KEY (MaVien) REFERENCES vien(MaVien);

-- giangvien.MaVien -> vien.MaVien
ALTER TABLE giangvien
ADD CONSTRAINT FK_giangvien_vien
FOREIGN KEY (MaVien) REFERENCES vien(MaVien);

-- hocphan.MaVien -> vien.MaVien
ALTER TABLE hocphan
ADD CONSTRAINT FK_hocphan_vien
FOREIGN KEY (MaVien) REFERENCES vien(MaVien);

-- lophocphan.MaHP -> hocphan.MaHP
ALTER TABLE lophocphan
ADD CONSTRAINT FK_lophocphan_hocphan
FOREIGN KEY (MaHP) REFERENCES hocphan(MaHP);

-- lophocphan.MaGV -> giangvien.MaGV
ALTER TABLE lophocphan
ADD CONSTRAINT FK_lophocphan_giangvien
FOREIGN KEY (MaGV) REFERENCES giangvien(MaGV);

-- lophocphan.MaVien -> vien.MaVien
ALTER TABLE lophocphan
ADD CONSTRAINT FK_lophocphan_vien
FOREIGN KEY (MaVien) REFERENCES vien(MaVien);

-- diem.MaSV -> sinhvien.MaSV
ALTER TABLE diem
ADD CONSTRAINT FK_diem_sinhvien
FOREIGN KEY (MaSV) REFERENCES sinhvien(MaSV);

-- diem.MaHP -> hocphan.MaHP
ALTER TABLE diem
ADD CONSTRAINT FK_diem_hocphan
FOREIGN KEY (MaHP) REFERENCES hocphan(MaHP);

-- diem.MaLop -> lophocphan.MaLop
ALTER TABLE diem
ADD CONSTRAINT FK_diem_lophocphan
FOREIGN KEY (MaLop) REFERENCES lophocphan(MaLop);

-- capgiayto.MaSV -> sinhvien.MaSV
ALTER TABLE capgiayto
ADD CONSTRAINT FK_capgiayto_sinhvien
FOREIGN KEY (MaSV) REFERENCES sinhvien(MaSV);


--DELETE FROM [sinhvien];--

INSERT INTO [dbo].[Admin] VALUES ('001','admin1','1234'),('002','admin2','5678');
GO

INSERT INTO [dbo].[vien] VALUES 
(N'FAMI', N'Nguyen Thị Hồng Thúy', N'Viện Toán ứng dụng và Tin học', N'sami.hust.edu.vn', N'D3 - 106'),
(N'SET', N'Ha Phi Vũ', N'Viện Điện tử - Viễn thông', N'set.hust.edu.vn', N'C9 - 405'),
(N'SEE', N'Phạm Thành Sự', N'Viện Điện', N'see.hust.edu.vn', N'C1 - 320'),
(N'SME', N'Bùi Thị Hường', N'Viện Cơ khí', N'sme.hust.edu.vn', N'C10 - 304'),
(N'SOFL', N'Nguyễn Tam Giang', N'Viện Ngoại ngữ', N'sofl.hust.edu.vn', N'D4 - 209'),
(N'SOICT', N'Nguyễn Thị Hương', N'Viện Công nghệ Thông Tin và Truyền Thông', N'soict.hust.edu.vn', N'Nhà B1');	
GO 
INSERT INTO [dbo].[nganhdaotao] VALUES
(N'EE1', N'SEE', N'Kỹ thuật điện'),
(N'EE2', N'SEE', N'Kỹ thuật điều khiển tự động hóa'),
(N'ET1', N'SET', N'Điện tử - Viễn thông'),
(N'ET2', N'SET', N'Kỹ thuật y sinh'),
(N'FL1', N'SOFL', N'Tiếng anh khoa học và công nghệ'),
(N'FL2', N'SOFL', N'Tiếng anh chuyên nghiệp quốc tế'),
(N'IT1', N'SOICT', N'Khoa học máy tính'),
(N'IT2', N'SOICT', N'Kỹ thuật máy tính'),
(N'ME1', N'SME', N'Kỹ thuật cơ điện tử'),
(N'ME2', N'SME', N'Kỹ thuật cơ khí'),
(N'MI1', N'FAMI', N'Toán Tin'),
(N'MI2', N'FAMI', N'Hệ thống thông tin quản lý');
GO
INSERT INTO [dbo].[sinhvien] VALUES
(N'20213923', N'Phạm Minh Hiếu ', N'Nam', N'2003-11-05', N'Hà Nội',N'001203043965',N'0985347834',N'ET1'),
(N'20210218', N'Hoàng Đức Long ', N'Nam', N'2003-01-21', N'Lâm Đồng',N'036303046278',N'0353982742',N'ET1'),
(N'20210219', N'Bùi Nhật Vương Nam ', N'Nam', N'2003-09-12', N'Đắk Lắk',N'036303021404',N'0353946486',N'ET1'),
(N'20210253', N'Nguyễn Ngọc Hạnh ', N'Nữ', N'2003-11-21', N'Điện Biên',N'036303018722',N'0353982662',N'ET1'),
(N'20210260', N'Nguyễn Thùy Giang ', N'Nữ', N'2003-01-06', N'Khánh Hòa',N'036303003013',N'0353974648',N'ET1'),

(N'20201907', N'Bùi Thị Ánh Vân', N'Nữ', N'2002-04-14	', N'Nghệ An',N'036303048378',N'0353946697',N'ET2'),
(N'20201990', N'Nguyễn Thế Mạnh', N'Nam ', N'2002-02-15', N'Thanh Hóa',N'036303027900',N'0353977807',N'ET2'),
(N'20202019', N'Lê Thi Thu Linh', N'Nữ ', N'2002-07-16', N'Bình Dương',N'036303046205',N'0353946855',N'ET2'),						
(N'20202020', N'Đào Quang Trung Nguyên', N'Nam ', N'2002-07-23', N'Hải Dương',N'036303015212',N'0353960534',N'ET2'),
(N'20202028', N'Đoàn Đức Đăng Quang', N'Nam ', N'2002-10-24', N'Phú Thọ',N'036303020125',N'0353949208',N'ET2'),					
			
(N'20221075', N'Hồ Dương Gia Phú', N'Nam', N'2004-03-31', N'Hà Tĩnh',N'036303003877',N'0353973389',N'MI1'),
(N'20221138', N'Cao Thanh Ngân', N'Nữ', N'2004-01-18', N'Hậu Giang',N'036303024035',N'0353986869',N'MI1'),
(N'20221220', N'Hoàng Thị Huệ Nhi', N'Nữ', N'2004-05-12', N'Cao Bằng',N'036303030795',N'0353981841',N'MI1'),
(N'20221258', N'Hà Thùy Chi	Nữ ', N'Nữ', N'2004-06-28', N'Hòa Bình',N'036303043521',N'0353966372',N'MI1'),
(N'20221279', N'Lư Phúc Trọng ', N'Nam', N'2004-06-18', N'Ninh Bình',N'036303037091',N'0353949458',N'MI1'),

(N'20207880', N'Lê Đức Nhân', N'Nam', '2002-07-30', N'Quảng Trị', N'036303021691', N'0353987204', N'ME1'),
(N'20207808', N'Đinh Anh Quân', N'Nam', '2002-04-28', N'Ninh Thuận', N'036303017339', N'0353986385', N'ME1'),
(N'20207811', N'Phan Bá Trường', N'Nam', '2002-06-05', N'Hồ Chí Minh', N'036303035721', N'0353975966', N'ME1'),
(N'20207821', N'Đào Văn Hậu', N'Nam', '2002-04-12', N'Quảng Ninh', N'036303034421', N'0353985574', N'ME1'),
(N'20207866', N'Lê Thi Thu Linh', N'Nữ', '2002-08-04', N'Hải Phòng', N'036303049550', N'0353957086', N'ME1'),

(N'20212905', N'Thân Thị Định', N'Nữ', '2003-07-30', N'Hồ Chí Minh', N'036303005031', N'0353990946', N'MI2'),
(N'20212927', N'Trần Thị Thúy Nga', N'Nữ', '2003-02-06', N'Tây Ninh', N'036303003900', N'0353964201', N'MI2'),
(N'20212939', N'Vũ Thị Khiếu', N'Nữ', '2003-10-11', N'Trà Vinh', N'036303039266', N'0353973925', N'MI2'),
(N'20212956', N'Phạm Thị Thùy', N'Nữ', '2003-01-19', N'Hà Nội', N'036303024340', N'0353984862', N'MI2'),
(N'20212988', N'Nguyễn Bảo Lâm', N'Nam', '2003-02-28', N'Ninh Bình', N'036303018319', N'0353968076', N'MI2'),

(N'20213172', N'Phạm Thế Bách', N'Nam', '2003-02-19', N'Đà Nẵng', N'036303023973', N'0353955951', N'ME2'),
(N'20213200', N'Doãn Văn Thắng', N'Nam', '2003-05-13', N'Hà Nam', N'036303035736', N'0353968438', N'ME2'),
(N'20213204', N'Phạm Thị Thanh Xuân', N'Nữ', '2003-03-20', N'Khánh Hòa', N'036303042836', N'0353944997', N'ME2'),
(N'20213229', N'Ngô Minh Tâm', N'Nam', '2003-11-05', N'An Giang', N'036303004284', N'0353985716', N'ME2'),
(N'20213262', N'Phan Minh Cảnh', N'Nam', '2003-09-14', N'Sóc Trăng', N'036303032781', N'0353957052', N'ME2'),

(N'20223394', N'Đào Xuân Linh', N'Nam', '2004-07-18', N'Bình Dương', N'036303036003', N'0353946793', N'EE1'),
(N'20223405', N'Võ Anh', N'Nam', '2004-09-23', N'Bắc Kạn', N'036303039564', N'0353977005', N'EE1'),
(N'20223417', N'Nguyễn Dương Hoàng Duy', N'Nam', '2004-12-11', N'Hà Tĩnh', N'036303033257', N'0353984360', N'EE1'),
(N'20223457', N'Sầm Văn Đạo', N'Nam', '2004-05-14', N'Quảng Ngãi', N'036303019342', N'0353959433', N'EE1'),
(N'20223475', N'Phạm Khánh Hùng', N'Nam', '2004-10-31', N'Tuyên Quang', N'036303015035', N'0353971732', N'EE1'),

(N'20223565', N'Nguyễn Thị Thanh Hoài Thư', N'Nữ', '2004-01-07', N'Hải Dương', N'036303013602', N'0353970251', N'EE2'),
(N'20223603', N'Trần Hồng Mạnh', N'Nam', '2004-10-05', N'Vĩnh Long', N'036303024593', N'0353973803', N'EE2'),
(N'20223605', N'Nguyễn Trùng Khánh', N'Nam', '2004-11-09', N'Hà Giang', N'036303035325', N'0353958780', N'EE2'),
(N'20223617', N'Tô Xuân Hiếu', N'Nam', '2004-01-22', N'Bắc Giang', N'036303020115', N'0353953807', N'EE2'),
(N'20223625', N'Nguyễn Trần Thành Long', N'Nam', '2004-11-15', N'Đắk Lắk', N'036303039121', N'0353951940', N'EE2'),

(N'20223825', N'Phạm Vĩnh Khang', N'Nam', '2004-02-28', N'Đắk Nông', N'036303044329', N'0353993004', N'FL1'),
(N'20223865', N'Lê Thị Thanh Long', N'Nữ', '2004-04-23', N'Quảng Ngãi', N'036303014227', N'0353987268', N'FL1'),
(N'20223882', N'Nguyễn Thị Nhu Mì', N'Nữ', '2004-12-15', N'Cao Bằng', N'036303044583', N'0353963473', N'FL1'),
(N'20223896', N'Nguyễn Thị Huỳnh Nhung', N'Nữ', '2004-04-16', N'Hòa Bình', N'036303008781', N'0353953771', N'FL1'),
(N'20223897', N'Hồ Dương Gia Phú', N'Nam', '2004-01-20', N'Lào Cai', N'036303001326', N'0353953278', N'FL1'),

(N'20223984', N'Lương Thanh Phong', N'Nam', '2004-05-19', N'Thái Bình', N'036303006040', N'0353957743', N'IT1'),
(N'20224003', N'Nguyễn Đình Trí', N'Nam', '2004-06-30', N'Bình Thuận', N'036303031601', N'0353963220', N'IT1'),
(N'20224006', N'Phan Ngọc Quang', N'Nam', '2004-04-08', N'Hà Nam', N'036303016722', N'0353988058', N'IT1'),
(N'20224007', N'Đặng Thanh Ngân', N'Nữ', '2004-12-10', N'Bạc Liêu', N'036303022357', N'0353958449', N'IT1'),
(N'20224008', N'Phùng Thị Giang', N'Nữ', '2004-02-01', N'Hải Dương', N'036303003843', N'0353959907', N'IT1'),

(N'20214158', N'Đỗ Ngọc Như Quỳnh', N'Nữ', '2003-03-29', N'Hải Phòng', N'036303014047', N'0353946808', N'FL2'),
(N'20214200', N'Ngô Thị Trà Mi', N'Nữ', '2003-03-11', N'Bà Rịa - Vũng Tàu', N'036303003611', N'0353948477', N'FL2'),
(N'20214208', N'Lê Ngọc Thúy An', N'Nữ', '2003-04-08', N'Bến Tre', N'036303026512', N'0353984967', N'FL2'),
(N'20214308', N'Phan Xuân Tùng', N'Nam', '2003-09-30', N'Hà Nam', N'036303036217', N'0353980474', N'FL2'),
(N'20214321', N'Nguyễn Doãn Quý', N'Nam', '2003-10-05', N'Vĩnh Long', N'036303006628', N'0353962078', N'FL2'),

(N'20224210', N'Mai Phước Lợi', N'Nam', '2004-08-05', N'Quảng Nam', N'036303049274', N'0353965639', N'IT2'),
(N'20224212', N'Phạm Lộc', N'Nam', '2004-10-16', N'Bắc Giang', N'036303045865', N'0353952240', N'IT2'),
(N'20224230', N'Tào Minh Tiến', N'Nam', '2004-12-31', N'Hải Phòng', N'036303020279', N'0353985425', N'IT2'),
(N'20224237', N'Bùi Quang Tiến', N'Nam', '2004-06-18', N'Bình Dương', N'036303049155', N'0353989424', N'IT2'),
(N'20224252', N'Đỗ Tam Tài', N'Nam', '2004-11-05', N'Thái Bình', N'036303005385', N'0353984639', N'IT2');
GO
INSERT INTO [dbo].[giangvien]  VALUES
(N'2000706', N'Đặng Ðức Phong', N'Nam', '1982-09-12', N'Cần Thơ', N'01082946685', N'0397643191', N'FAMI'),
(N'2000778', N'Ngô Trường Chinh', N'Nam', '1987-01-12', N'Đà Nẵng', N'01082946815', N'0397643321', N'FAMI'),
(N'2000830', N'Đặng Ngọc Dũng', N'Nam', '1973-07-08', N'Thừa Thiên-Huế', N'01082946667', N'0397643173', N'SET'),
(N'2001065', N'Vương Danh Văn', N'Nam', '1982-05-10', N'Sơn La', N'01082947165', N'0397643671', N'SET'),
(N'2001360', N'Lý Vĩnh Thụy', N'Nam', '1983-02-23', N'Ninh Thuận', N'01082946905', N'0397643411', N'SEE'),
(N'2001403', N'Võ Duy Hiếu', N'Nam', '1986-01-29', N'Thái Nguyên', N'01082947040', N'397643546', N'SEE'),
(N'2575543', N'Nguyễn Vân Hà', N'Nữ', '1982-06-10', N'Đồng Nai', N'01082947318', N'0397643824', N'SME'),
(N'2601019', N'Lý Ngọc Loan', N'Nữ', '1978-12-31', N'Thái Bình', N'01082948046', N'0397644552', N'SME'),
(N'2613080', N'Giang Trúc Loan', N'Nữ', '1984-11-28', N'Hải Dương', N'01082948015', N'0397644521', N'SOFL'),
(N'2659604', N'Ngô Bích Hằng', N'Nữ', '1981-08-08', N'Phú Thọ', N'01082947722', N'0397644228', N'SOFL'),
(N'2709794', N'Vũ Diễm Chi', N'Nữ', '1980-12-06', N'Nam Định', N'01082947529', N'0397644035', N'SOICT'),
(N'2732723', N'Giang Thu Hồng', N'Nữ', '1984-07-05', N'Cần Thơ', N'01082948005', N'0397644511', N'SOICT');
GO
INSERT INTO  [dbo].[taikhoan_giangvien] VALUES
(N'2000706', N'DangDucPhong@sis.hust.edu.vn', N'JUCM73'),
(N'2000778', N'NgoTruongChinh@sis.hust.edu.vn', N'KRQL87'),
(N'2000830', N'DangNgocDung@sis.hust.edu.vn', N'TGQQ21'),
(N'2001065', N'VuongDanhVan@sis.hust.edu.vn', N'CULW35'),
(N'2001360', N'LyVinhThuy@sis.hust.edu.vn', N'WJVJ51'),
(N'2001403', N'VoDuyHieu@sis.hust.edu.vn', N'WGTJ33'),
(N'2575543', N'NguyenVanHa@sis.hust.edu.vn', N'SZZB63'),
(N'2601019', N'LyNgocLoan@sis.hust.edu.vn', N'YIWQ36'),
(N'2613080', N'GiangTrucLoan@sis.hust.edu.vn', N'ZZZZ88'),
(N'2659604', N'NgoBichHang@sis.hust.edu.vn', N'KLMN45'),
(N'2709794', N'VuDiemChi@sis.hust.edu.vn', N'LRVU87'),
(N'2732723', N'GiangThuHong@sis.hust.edu.vn', N'XCVR29');
GO
INSERT INTO  [dbo].[taikhoan_sinhvien] VALUES
(N'20213923', N'PhamMinhHieu@sis.hust.edu.vn', N'B94MIG'),
(N'20210218', N'HoangDucLong@sis.hust.edu.vn', N'I19SSU'),
(N'20210219', N'BuiNhatVuongNam@sis.hust.edu.vn', N'Q9B1EO'),
(N'20210253', N'NguyenNgocHanh@sis.hust.edu.vn', N'QUYN23'),
(N'20210260', N'NguyenThuyGiang@sis.hust.edu.vn', N'U1XCF2'),
(N'20201907', N'BuiThiAnhVan@sis.hust.edu.vn', N'K7LZP2'),
(N'20201990', N'NguyenTheManh@sis.hust.edu.vn', N'R3MTS9'),
(N'20202019', N'LeThiThuLinh@sis.hust.edu.vn', N'V5WXY8'),
(N'20202020', N'DaoQuangTrungNguyen@sis.hust.edu.vn', N'J4ABC1'),
(N'20202028', N'DoanDucDangQuang@sis.hust.edu.vn', N'P2DEF3'),
(N'20221075', N'HoDuongGiaPhu@sis.hust.edu.vn', N'S6GHI4'),
(N'20221138', N'CaoThanhNgan@sis.hust.edu.vn', N'T7JKL5'),
(N'20221220', N'HoangThiHueNhi@sis.hust.edu.vn', N'U8MNO6'),
(N'20221258', N'HaThuyChiNu@sis.hust.edu.vn', N'V9PQR7'),
(N'20221279', N'LuPhucTrong@sis.hust.edu.vn', N'W0STU8'),
(N'20207880', N'LeDucNhan@sis.hust.edu.vn', N'X1VWX9'),
(N'20207808', N'DinhAnhQuan@sis.hust.edu.vn', N'Y2ZAB0'),
(N'20207811', N'PhanBaTruong@sis.hust.edu.vn', N'Z3CDE1'),
(N'20207821', N'DaoVanHau@sis.hust.edu.vn', N'A4FGH2'),
(N'20207866', N'LeThiThuLinh2@sis.hust.edu.vn', N'B5IJK3'),
(N'20212905', N'ThanThiDinh@sis.hust.edu.vn', N'C6LMN4'),
(N'20212927', N'TranThiThuyNga@sis.hust.edu.vn', N'D7OPQ5'),
(N'20212939', N'VuThiKhieu@sis.hust.edu.vn', N'E8RST6'),
(N'20212956', N'PhamThiThuy@sis.hust.edu.vn', N'F9UVW7'),
(N'20212988', N'NguyenBaoLam@sis.hust.edu.vn', N'G0XYZ8'),
(N'20213172', N'PhamTheBach@sis.hust.edu.vn', N'H1A2B3'),
(N'20213200', N'DoanVanThang@sis.hust.edu.vn', N'I4C5D6'),
(N'20213204', N'PhamThiThanhXuan@sis.hust.edu.vn', N'J7E8F9'),
(N'20213229', N'NgoMinhTam@sis.hust.edu.vn', N'K0G1H2'),
(N'20213262', N'PhanMinhCanh@sis.hust.edu.vn', N'L3I4J5'),
(N'20223394', N'DaoXuanLinh@sis.hust.edu.vn', N'M6K7L8'),
(N'20223405', N'VoAnh@sis.hust.edu.vn', N'N9M0O1'),
(N'20223417', N'NguyenDuongHoangDuy@sis.hust.edu.vn', N'O2P3Q4'),
(N'20223457', N'SamVanDao@sis.hust.edu.vn', N'P5R6S7'),
(N'20223475', N'PhamKhanhHung@sis.hust.edu.vn', N'Q8T9U0'),
(N'20223565', N'NguyenThiThanhHoaThu@sis.hust.edu.vn', N'R1V2W3'),
(N'20223603', N'TranHongManh@sis.hust.edu.vn', N'S4X5Y6'),
(N'20223605', N'NguyenTrungKhanh@sis.hust.edu.vn', N'T7Z8A9'),
(N'20223617', N'ToXuanHieu@sis.hust.edu.vn', N'U0B1C2'),
(N'20223625', N'NguyenTranThanhLong@sis.hust.edu.vn', N'V3D4E5'),
(N'20223825', N'PhamVinhKhang@sis.hust.edu.vn', N'W6F7G8'),
(N'20223865', N'LeThiThanhLong@sis.hust.edu.vn', N'X9H0I1'),
(N'20223882', N'NguyenThiNhuMi@sis.hust.edu.vn', N'Y2J3K4'),
(N'20223896', N'NguyenThiHuynhNhung@sis.hust.edu.vn', N'Z5L6M7'),
(N'20223897', N'HoDuongGiaPhu2@sis.hust.edu.vn', N'A8N9O0'),
(N'20223984', N'LuongThanhPhong@sis.hust.edu.vn', N'B1P2Q3'),
(N'20224003', N'NguyenDinhTri@sis.hust.edu.vn', N'C4R5S6'),
(N'20224006', N'PhanNgocQuang@sis.hust.edu.vn', N'D7T8U9'),
(N'20224007', N'DangThanhNgan@sis.hust.edu.vn', N'E0V1W2'),
(N'20224008', N'PhungThiGiang@sis.hust.edu.vn', N'F3X4Y5'),
(N'20214158', N'DoNgocNhuQuynh@sis.hust.edu.vn', N'G6Z7A8'),
(N'20214200', N'NgoThiTraMi@sis.hust.edu.vn', N'H9B0C1'),
(N'20214208', N'LeNgocThuyAn@sis.hust.edu.vn', N'I2D3E4'),
(N'20214308', N'PhanXuanTung@sis.hust.edu.vn', N'J5F6G7'),
(N'20214321', N'NguyenDoanQuy@sis.hust.edu.vn', N'K8H9I0'),
(N'20224210', N'MaiPhuocLoi@sis.hust.edu.vn', N'L1J2K3'),
(N'20224212', N'PhamLoc@sis.hust.edu.vn', N'M4L5M6'),
(N'20224230', N'TaoMinhTien@sis.hust.edu.vn', N'N7O8P9'),
(N'20224237', N'BuiQuangTien@sis.hust.edu.vn', N'O0Q1R2'),
(N'20224252', N'DoTamTai@sis.hust.edu.vn', N'P3S4T5');
GO
INSERT INTO [dbo].[hocphan] VALUES
(N'FL1125', N'IELTS Speaking 2', 3, N'SOFL'),
(N'FL1143', N'IELTS Speaking 1', 2, N'SOFL'),
(N'IT1110', N'Tin học đại cương', 4, N'SOICT'),
(N'IT2000', N'Nhập môn CNTT và TT', 3, N'SOICT'),
(N'ET3220', N'Điện tử số', 3, N'SET'),
(N'ET3230', N'Điện tử tương tự I', 3, N'SET'),
(N'MI1111', N'Giải tích I', 4, N'FAMI'),
(N'MI1141', N'Đại số', 4, N'FAMI'),
(N'ME2140', N'Cơ học kỹ thuật 1', 3, N'SME'),
(N'ME3040', N'Sức bền vật liệu 1', 2, N'SME'),
(N'EE4226', N'Điều khiển logic và PLC', 3, N'SEE'),
(N'EE4341', N'Kỹ thuật Robot', 3, N'SEE');
GO
INSERT INTO [dbo].[lophocphan] VALUES
(N'733515', N'MI1141', N'FAMI', N'20242', N'2000706'),
(N'972032', N'MI1111', N'FAMI', N'20241', N'2000778'),
(N'183730', N'ET3220', N'SET', N'20241', N'2000830'),
(N'925466', N'ET3230', N'SET', N'20242', N'2001065'),
(N'832485', N'EE4341', N'SEE', N'20241', N'2001360'),
(N'753685', N'EE4226', N'SEE', N'20242', N'2001403'),
(N'488527', N'ME3040', N'SME', N'20242', N'2575543'),
(N'607805', N'ME2140', N'SME', N'20242', N'2601019'),
(N'636524', N'FL1125', N'SOFL', N'20241', N'2613080'),
(N'207657', N'FL1143', N'SOFL', N'20242', N'2659604'),
(N'625301', N'IT2000', N'SOICT', N'20242', N'2709794'),
(N'206015', N'IT1110', N'SOICT', N'20241', N'2732723');
-- Dữ liệu điểm học phần với cấu trúc mới
INSERT INTO[dbo].[diem] (MaHP, MaLop, MaSV, MaKi, DiemGiuaKi, DiemCuoiKi) VALUES
-- Môn MI1141 - Kỳ 20242 (5 học sinh)
(N'MI1141', N'733515', N'20221075', N'20242', 8, 7),
(N'MI1141', N'733515', N'20221138', N'20242', 6, 9),
(N'MI1141', N'733515', N'20221220', N'20242', 7, 8),
(N'MI1141', N'733515', N'20221258', N'20242', 9, 6),
(N'MI1141', N'733515', N'20221279', N'20242', 5, 8),

-- Môn MI1111 - Kỳ 20241 (5 học sinh)
(N'MI1111', N'972032', N'20212905', N'20241', 7, 9),
(N'MI1111', N'972032', N'20212927', N'20241', 8, 7),
(N'MI1111', N'972032', N'20212939', N'20241', 6, 8),
(N'MI1111', N'972032', N'20212956', N'20241', 9, 6),
(N'MI1111', N'972032', N'20212988', N'20241', 7, 8),

-- Môn ET3220 - Kỳ 20241 (5 học sinh)
(N'ET3220', N'183730', N'20213923', N'20241', 8, 7),
(N'ET3220', N'183730', N'20210218', N'20241', 6, 9),
(N'ET3220', N'183730', N'20210219', N'20241', 7, 8),
(N'ET3220', N'183730', N'20210253', N'20241', 9, 6),
(N'ET3220', N'183730', N'20210260', N'20241', 5, 8),

-- Môn ET3230 - Kỳ 20242 (5 học sinh)
(N'ET3230', N'925466', N'20201907', N'20242', 7, 9),
(N'ET3230', N'925466', N'20201990', N'20242', 8, 7),
(N'ET3230', N'925466', N'20202019', N'20242', 6, 8),
(N'ET3230', N'925466', N'20202020', N'20242', 9, 6),
(N'ET3230', N'925466', N'20202028', N'20242', 7, 8),

-- Môn EE4341 - Kỳ 20241 (5 học sinh)
(N'EE4341', N'832485', N'20223394', N'20241', 8, 7),
(N'EE4341', N'832485', N'20223405', N'20241', 6, 9),
(N'EE4341', N'832485', N'20223417', N'20241', 7, 8),
(N'EE4341', N'832485', N'20223457', N'20241', 9, 6),
(N'EE4341', N'832485', N'20223475', N'20241', 5, 8),

-- Môn EE4226 - Kỳ 20242 (5 học sinh)
(N'EE4226', N'753685', N'20223565', N'20242', 7, 9),
(N'EE4226', N'753685', N'20223603', N'20242', 8, 7),
(N'EE4226', N'753685', N'20223605', N'20242', 6, 8),
(N'EE4226', N'753685', N'20223617', N'20242', 9, 6),
(N'EE4226', N'753685', N'20223625', N'20242', 7, 8),

-- Môn ME3040 - Kỳ 20242 (5 học sinh)
(N'ME3040', N'488527', N'20213172', N'20242', 8, 7),
(N'ME3040', N'488527', N'20213200', N'20242', 6, 9),
(N'ME3040', N'488527', N'20213204', N'20242', 7, 8),
(N'ME3040', N'488527', N'20213229', N'20242', 9, 6),
(N'ME3040', N'488527', N'20213262', N'20242', 5, 8),

-- Môn ME2140 - Kỳ 20242 (5 học sinh)
(N'ME2140', N'607805', N'20207880', N'20242', 7, 9),
(N'ME2140', N'607805', N'20207808', N'20242', 8, 7),
(N'ME2140', N'607805', N'20207811', N'20242', 6, 8),
(N'ME2140', N'607805', N'20207821', N'20242', 9, 6),
(N'ME2140', N'607805', N'20207866', N'20242', 7, 8),

-- Môn FL1125 - Kỳ 20241 (5 học sinh)
(N'FL1125', N'636524', N'20223825', N'20241', 8, 7),
(N'FL1125', N'636524', N'20223865', N'20241', 6, 9),
(N'FL1125', N'636524', N'20223882', N'20241', 7, 8),
(N'FL1125', N'636524', N'20223896', N'20241', 9, 6),
(N'FL1125', N'636524', N'20223897', N'20241', 5, 8),

-- Môn FL1143 - Kỳ 20242 (5 học sinh)
(N'FL1143', N'207657', N'20214158', N'20242', 7, 9),
(N'FL1143', N'207657', N'20214200', N'20242', 8, 7),
(N'FL1143', N'207657', N'20214208', N'20242', 6, 8),
(N'FL1143', N'207657', N'20214308', N'20242', 9, 6),
(N'FL1143', N'207657', N'20214321', N'20242', 7, 8),

-- Môn IT2000 - Kỳ 20242 (5 học sinh)
(N'IT2000', N'625301', N'20224210', N'20242', 8, 7),
(N'IT2000', N'625301', N'20224212', N'20242', 6, 9),
(N'IT2000', N'625301', N'20224230', N'20242', 7, 8),
(N'IT2000', N'625301', N'20224237', N'20242', 9, 6),
(N'IT2000', N'625301', N'20224252', N'20242', 5, 8),

-- Môn IT1110 - Kỳ 20241 (5 học sinh)
(N'IT1110', N'206015', N'20223984', N'20241', 7, 9),
(N'IT1110', N'206015', N'20224003', N'20241', 8, 7),
(N'IT1110', N'206015', N'20224006', N'20241', 6, 8),
(N'IT1110', N'206015', N'20224007', N'20241', 9, 6),
(N'IT1110', N'206015', N'20224008', N'20241', 7, 8);
GO
-- Dữ liệu xác nhận giấy tờ sinh viên
INSERT INTO [dbo].[capgiayto] (MaSV, NgayCap, LoaiGiayTo, TrangThai) VALUES
(N'20221075', '2024-04-22', N'CCCD', N'Xác nhận'),
(N'20221138', '2024-04-25', N'CCCD', N'Xác nhận'),
(N'20221220', '2024-04-23', N'CCCD', N'Xác nhận'),
(N'20210218', '2024-04-28', N'CCCD', N'Xác nhận'),
(N'20210253', '2024-04-21', N'CCCD', N'Xác nhận'),
(N'20201990', '2024-04-26', N'CCCD', N'Xác nhận'),
(N'20202020', '2024-04-24', N'CCCD', N'Xác nhận'),
(N'20207880', '2024-04-27', N'CCCD', N'Xác nhận'),
(N'20207821', '2024-04-29', N'CCCD', N'Xác nhận'),
(N'20212905', '2024-04-30', N'CCCD', N'Xác nhận');