USE [master]
GO
/****** Object:  Database [QuanLySieuThi]    Script Date: 11/28/2020 11:16:16 PM ******/
CREATE DATABASE [QuanLySieuThi]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QuanLySieuThi', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\QuanLySieuThi.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QuanLySieuThi_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\QuanLySieuThi_log.ldf' , SIZE = 816KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [QuanLySieuThi] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QuanLySieuThi].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QuanLySieuThi] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QuanLySieuThi] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QuanLySieuThi] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QuanLySieuThi] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QuanLySieuThi] SET ARITHABORT OFF 
GO
ALTER DATABASE [QuanLySieuThi] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QuanLySieuThi] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QuanLySieuThi] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QuanLySieuThi] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QuanLySieuThi] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QuanLySieuThi] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QuanLySieuThi] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QuanLySieuThi] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QuanLySieuThi] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QuanLySieuThi] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QuanLySieuThi] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QuanLySieuThi] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QuanLySieuThi] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QuanLySieuThi] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QuanLySieuThi] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QuanLySieuThi] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QuanLySieuThi] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QuanLySieuThi] SET RECOVERY FULL 
GO
ALTER DATABASE [QuanLySieuThi] SET  MULTI_USER 
GO
ALTER DATABASE [QuanLySieuThi] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QuanLySieuThi] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QuanLySieuThi] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QuanLySieuThi] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [QuanLySieuThi] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'QuanLySieuThi', N'ON'
GO
USE [QuanLySieuThi]
GO
/****** Object:  Table [dbo].[ChucVu]    Script Date: 11/28/2020 11:16:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ChucVu](
	[MaChucVu] [varchar](10) NOT NULL,
	[TenChucVu] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaChucVu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DangNhap]    Script Date: 11/28/2020 11:16:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DangNhap](
	[MaNhanVien] [varchar](10) NULL,
	[MatKhau] [varchar](30) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DonViHangHoa]    Script Date: 11/28/2020 11:16:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DonViHangHoa](
	[ID] [varchar](10) NOT NULL,
	[MaMatHang] [varchar](10) NULL,
	[NgaySanXuat] [date] NULL,
	[HanSuDung] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 11/28/2020 11:16:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HoaDon](
	[MaHoaDon] [varchar](20) NOT NULL,
	[MaKhachHang] [varchar](10) NULL,
	[NgayTao] [date] NULL,
	[TongTien] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HoaDon_MatHang]    Script Date: 11/28/2020 11:16:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HoaDon_MatHang](
	[MaHoaDon] [varchar](20) NULL,
	[MaMatHang] [varchar](10) NULL,
	[Soluong] [int] NULL,
	[ThanhTien] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 11/28/2020 11:16:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[KhachHang](
	[MaKhachHang] [varchar](10) NOT NULL,
	[HoTen] [nvarchar](50) NULL,
	[GioiTinh] [nvarchar](10) NULL,
	[DiemThuong] [int] NULL,
	[SDT] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaKhachHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LoaiMatHang]    Script Date: 11/28/2020 11:16:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiMatHang](
	[MaLoai] [int] IDENTITY(1,1) NOT NULL,
	[TenLoai] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaLoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MatHang]    Script Date: 11/28/2020 11:16:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MatHang](
	[MaMatHang] [varchar](10) NOT NULL,
	[TenMatHang] [nvarchar](100) NULL,
	[Soluong] [int] NULL,
	[MaLoai] [int] NULL,
	[XuatXu] [nvarchar](50) NULL,
	[GiaBan] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaMatHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 11/28/2020 11:16:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNhanVien] [varchar](10) NOT NULL,
	[HoTenNhanVien] [nvarchar](100) NULL,
	[NgaySinh] [date] NULL,
	[SDT] [varchar](20) NULL,
	[SoCMND] [varchar](30) NULL,
	[DiaChi] [nvarchar](100) NULL,
	[AnhDaiDien] [image] NULL,
	[MaChucVu] [varchar](10) NULL,
	[QueQuan] [nvarchar](100) NULL,
	[GioiTinh] [nvarchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PhieuNhap]    Script Date: 11/28/2020 11:16:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuNhap](
	[MaphieuNhap] [nvarchar](7) NOT NULL,
	[NgayNhap] [date] NULL,
	[TongTien] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaphieuNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PhieuNhap_ChiTiet]    Script Date: 11/28/2020 11:16:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PhieuNhap_ChiTiet](
	[MaphieuNhap] [nvarchar](7) NULL,
	[MaMatHang] [varchar](10) NULL,
	[NgaySanXuat] [date] NULL,
	[HanSuDung] [date] NULL,
	[SoLuong] [int] NULL,
	[TongGia] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu]) VALUES (N'AD', N'Quản lý siêu thị')
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu]) VALUES (N'LC', N'Lao công')
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu]) VALUES (N'SC', N'Bảo vệ')
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu]) VALUES (N'TK', N'Quản lý kho')
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu]) VALUES (N'TN', N'Thu ngân')
INSERT [dbo].[DangNhap] ([MaNhanVien], [MatKhau]) VALUES (N'NV00000001', N'123456')
INSERT [dbo].[DangNhap] ([MaNhanVien], [MatKhau]) VALUES (N'NV00000002', N'123456')
INSERT [dbo].[DangNhap] ([MaNhanVien], [MatKhau]) VALUES (N'NV00000003', N'123456')
INSERT [dbo].[DangNhap] ([MaNhanVien], [MatKhau]) VALUES (N'NV00000004', N'123456')
INSERT [dbo].[DonViHangHoa] ([ID], [MaMatHang], [NgaySanXuat], [HanSuDung]) VALUES (N'1000000001', N'1#00000001', CAST(N'2020-05-06' AS Date), NULL)
INSERT [dbo].[DonViHangHoa] ([ID], [MaMatHang], [NgaySanXuat], [HanSuDung]) VALUES (N'1000000002', N'1#00000001', CAST(N'2020-05-06' AS Date), NULL)
INSERT [dbo].[DonViHangHoa] ([ID], [MaMatHang], [NgaySanXuat], [HanSuDung]) VALUES (N'1000000003', N'2#00000001', CAST(N'2020-10-06' AS Date), NULL)
INSERT [dbo].[DonViHangHoa] ([ID], [MaMatHang], [NgaySanXuat], [HanSuDung]) VALUES (N'1000000004', N'3#00000001', CAST(N'2020-05-06' AS Date), NULL)
INSERT [dbo].[DonViHangHoa] ([ID], [MaMatHang], [NgaySanXuat], [HanSuDung]) VALUES (N'1000000005', N'3#00000001', CAST(N'2020-04-06' AS Date), NULL)
INSERT [dbo].[DonViHangHoa] ([ID], [MaMatHang], [NgaySanXuat], [HanSuDung]) VALUES (N'1000000006', N'3#00000001', CAST(N'2020-03-10' AS Date), NULL)
INSERT [dbo].[DonViHangHoa] ([ID], [MaMatHang], [NgaySanXuat], [HanSuDung]) VALUES (N'1000000007', N'4#00000001', CAST(N'2020-10-04' AS Date), CAST(N'2022-11-11' AS Date))
INSERT [dbo].[DonViHangHoa] ([ID], [MaMatHang], [NgaySanXuat], [HanSuDung]) VALUES (N'1000000008', N'4#00000001', CAST(N'2020-10-06' AS Date), CAST(N'2022-11-11' AS Date))
INSERT [dbo].[DonViHangHoa] ([ID], [MaMatHang], [NgaySanXuat], [HanSuDung]) VALUES (N'1000000009', N'5#00000001', CAST(N'2020-03-01' AS Date), CAST(N'2021-10-22' AS Date))
INSERT [dbo].[DonViHangHoa] ([ID], [MaMatHang], [NgaySanXuat], [HanSuDung]) VALUES (N'1000000010', N'6#00000001', CAST(N'2020-10-03' AS Date), CAST(N'2023-11-30' AS Date))
INSERT [dbo].[DonViHangHoa] ([ID], [MaMatHang], [NgaySanXuat], [HanSuDung]) VALUES (N'1000000011', N'6#00000001', CAST(N'2020-10-10' AS Date), CAST(N'2023-12-04' AS Date))
INSERT [dbo].[KhachHang] ([MaKhachHang], [HoTen], [GioiTinh], [DiemThuong], [SDT]) VALUES (N'KH00000001', N'Nguyễn Minh Trí', N'Nam', 0, N'0912243877')
INSERT [dbo].[KhachHang] ([MaKhachHang], [HoTen], [GioiTinh], [DiemThuong], [SDT]) VALUES (N'KH00000002', N'Hoàng Trần Trung Kiên', N'Nam', 0, N'0924754999')
INSERT [dbo].[KhachHang] ([MaKhachHang], [HoTen], [GioiTinh], [DiemThuong], [SDT]) VALUES (N'KH00000003', N'Võ Minh Khải', N'Nam', 0, N'0436272888')
INSERT [dbo].[KhachHang] ([MaKhachHang], [HoTen], [GioiTinh], [DiemThuong], [SDT]) VALUES (N'KH00000004', N'Nguyễn Thị Mơ', N'Nữ', 0, N'0963266100')
INSERT [dbo].[KhachHang] ([MaKhachHang], [HoTen], [GioiTinh], [DiemThuong], [SDT]) VALUES (N'KH00000005', N'Ngô Thị Nhật Minh', N'Nữ', 0, N'0945277912')
INSERT [dbo].[KhachHang] ([MaKhachHang], [HoTen], [GioiTinh], [DiemThuong], [SDT]) VALUES (N'KH00000006', N'Lê Thành Phong', N'Nam', 0, N'0914872300')
INSERT [dbo].[KhachHang] ([MaKhachHang], [HoTen], [GioiTinh], [DiemThuong], [SDT]) VALUES (N'KH00000007', N'Phạm Quang Huy', N'Nam', 0, N'0967988129')
INSERT [dbo].[KhachHang] ([MaKhachHang], [HoTen], [GioiTinh], [DiemThuong], [SDT]) VALUES (N'KH00000008', N'Nguyễn Lê Diệu', N'Nam', 0, N'0925788155')
INSERT [dbo].[KhachHang] ([MaKhachHang], [HoTen], [GioiTinh], [DiemThuong], [SDT]) VALUES (N'KH00000009', N'Nguyễn Quang Nam', N'Nam', 0, N'0912899333')
INSERT [dbo].[KhachHang] ([MaKhachHang], [HoTen], [GioiTinh], [DiemThuong], [SDT]) VALUES (N'KH00000010', N'Phan Thị Mỹ Duyên', N'Nữ', 0, N'0923222787')
INSERT [dbo].[KhachHang] ([MaKhachHang], [HoTen], [GioiTinh], [DiemThuong], [SDT]) VALUES (N'KH00000011', N'Nguyễn Vĩnh Hiền', N'Nam', 0, N'0924763188')
INSERT [dbo].[KhachHang] ([MaKhachHang], [HoTen], [GioiTinh], [DiemThuong], [SDT]) VALUES (N'KH00000012', N'Phạm Đức Trường', N'Nam', 0, N'0645982333')
INSERT [dbo].[KhachHang] ([MaKhachHang], [HoTen], [GioiTinh], [DiemThuong], [SDT]) VALUES (N'KH00000013', N'Đậu Thị Liên', N'Nữ', 0, N'0345152777')
INSERT [dbo].[KhachHang] ([MaKhachHang], [HoTen], [GioiTinh], [DiemThuong], [SDT]) VALUES (N'KH00000014', N'Nguyễn Văn Long', N'Nam', 0, N'0456823111')
SET IDENTITY_INSERT [dbo].[LoaiMatHang] ON 

INSERT [dbo].[LoaiMatHang] ([MaLoai], [TenLoai]) VALUES (1, N'Thực phẩm')
INSERT [dbo].[LoaiMatHang] ([MaLoai], [TenLoai]) VALUES (2, N'Đồ gia dụng')
INSERT [dbo].[LoaiMatHang] ([MaLoai], [TenLoai]) VALUES (3, N'Văn phòng phẩm')
INSERT [dbo].[LoaiMatHang] ([MaLoai], [TenLoai]) VALUES (4, N'Đồ sinh hoạt cá nhân')
INSERT [dbo].[LoaiMatHang] ([MaLoai], [TenLoai]) VALUES (5, N'Bánh kẹo')
INSERT [dbo].[LoaiMatHang] ([MaLoai], [TenLoai]) VALUES (6, N'Đồ uống')
SET IDENTITY_INSERT [dbo].[LoaiMatHang] OFF
INSERT [dbo].[MatHang] ([MaMatHang], [TenMatHang], [Soluong], [MaLoai], [XuatXu], [GiaBan]) VALUES (N'1#00000001', N'Gạo tẻ', 2, 1, N'Việt Nam', 80000)
INSERT [dbo].[MatHang] ([MaMatHang], [TenMatHang], [Soluong], [MaLoai], [XuatXu], [GiaBan]) VALUES (N'2#00000001', N'Nồi cơm điện Cookoo', 1, 2, N'Hàn Quốc', 1200000)
INSERT [dbo].[MatHang] ([MaMatHang], [TenMatHang], [Soluong], [MaLoai], [XuatXu], [GiaBan]) VALUES (N'3#00000001', N'Vở Hồng Hà 120 trang', 3, 3, N'Việt Nam', 10000)
INSERT [dbo].[MatHang] ([MaMatHang], [TenMatHang], [Soluong], [MaLoai], [XuatXu], [GiaBan]) VALUES (N'4#00000001', N'Dầu gội X-men for Boss', 2, 4, N'Việt Nam', 95000)
INSERT [dbo].[MatHang] ([MaMatHang], [TenMatHang], [Soluong], [MaLoai], [XuatXu], [GiaBan]) VALUES (N'5#00000001', N'Chocopie anh đào', 1, 5, N'Việt Nam', 60000)
INSERT [dbo].[MatHang] ([MaMatHang], [TenMatHang], [Soluong], [MaLoai], [XuatXu], [GiaBan]) VALUES (N'6#00000001', N'CocaCola chai 1,5l', 2, 6, N'Việt Nam', 30000)
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTenNhanVien], [NgaySinh], [SDT], [SoCMND], [DiaChi], [AnhDaiDien], [MaChucVu], [QueQuan], [GioiTinh]) VALUES (N'NV00000001', N'Đinh Xuân Tùng', CAST(N'1998-06-16' AS Date), N'0973380598', N'035098000142', N'75 Đội Cấn', NULL, N'AD', N'Tượng Lĩnh, Kim Bảng, Hà Nam', N'Nam')
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTenNhanVien], [NgaySinh], [SDT], [SoCMND], [DiaChi], [AnhDaiDien], [MaChucVu], [QueQuan], [GioiTinh]) VALUES (N'NV00000002', N'Trần Bảo Trí', CAST(N'1999-10-10' AS Date), N'0123512453', N'032546132523', N'236 Hoàng Quốc Việt', NULL, N'TK', N'Vinh, Nghệ An', N'Nam')
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTenNhanVien], [NgaySinh], [SDT], [SoCMND], [DiaChi], [AnhDaiDien], [MaChucVu], [QueQuan], [GioiTinh]) VALUES (N'NV00000003', N'Nguyễn Mạnh Sơn', CAST(N'1999-01-20' AS Date), N'0934762483', N'035673000234', N'236 Hoàng Quốc Việt', NULL, N'TN', N'Nhân Hòa, Vĩnh Bảo, Hải Phòng', N'Nam')
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTenNhanVien], [NgaySinh], [SDT], [SoCMND], [DiaChi], [AnhDaiDien], [MaChucVu], [QueQuan], [GioiTinh]) VALUES (N'NV00000004', N'Nguyễn Văn Kiên', CAST(N'1998-10-09' AS Date), N'0924657123', N'035087000645', N'236 Hoàng Quốc Việt', NULL, N'TN', N'Hưng Yên', N'Nam')
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTenNhanVien], [NgaySinh], [SDT], [SoCMND], [DiaChi], [AnhDaiDien], [MaChucVu], [QueQuan], [GioiTinh]) VALUES (N'NV00000005', N'Ngô Nhật Minh', CAST(N'1999-10-20' AS Date), N'0925781546', N'026789000124', N'236 Hoàng Quốc Việt', NULL, N'SC', N'Tĩnh Gia, Thanh Hóa', N'Nam')
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTenNhanVien], [NgaySinh], [SDT], [SoCMND], [DiaChi], [AnhDaiDien], [MaChucVu], [QueQuan], [GioiTinh]) VALUES (N'NV00000006', N'Đặng Trọng Tiến', CAST(N'1999-04-05' AS Date), N'0344045609', N'035621000789', N'236 Hoàng Quốc Việt', NULL, N'LC', N'Thanh Chương, Nghệ An', N'Nam')
ALTER TABLE [dbo].[DangNhap]  WITH CHECK ADD FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NhanVien] ([MaNhanVien])
GO
ALTER TABLE [dbo].[DonViHangHoa]  WITH CHECK ADD FOREIGN KEY([MaMatHang])
REFERENCES [dbo].[MatHang] ([MaMatHang])
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD FOREIGN KEY([MaKhachHang])
REFERENCES [dbo].[KhachHang] ([MaKhachHang])
GO
ALTER TABLE [dbo].[HoaDon_MatHang]  WITH CHECK ADD FOREIGN KEY([MaHoaDon])
REFERENCES [dbo].[HoaDon] ([MaHoaDon])
GO
ALTER TABLE [dbo].[HoaDon_MatHang]  WITH CHECK ADD FOREIGN KEY([MaMatHang])
REFERENCES [dbo].[MatHang] ([MaMatHang])
GO
ALTER TABLE [dbo].[MatHang]  WITH CHECK ADD FOREIGN KEY([MaLoai])
REFERENCES [dbo].[LoaiMatHang] ([MaLoai])
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD FOREIGN KEY([MaChucVu])
REFERENCES [dbo].[ChucVu] ([MaChucVu])
GO
ALTER TABLE [dbo].[PhieuNhap_ChiTiet]  WITH CHECK ADD FOREIGN KEY([MaMatHang])
REFERENCES [dbo].[MatHang] ([MaMatHang])
GO
ALTER TABLE [dbo].[PhieuNhap_ChiTiet]  WITH CHECK ADD FOREIGN KEY([MaphieuNhap])
REFERENCES [dbo].[PhieuNhap] ([MaphieuNhap])
GO
/****** Object:  StoredProcedure [dbo].[MAKHMAX]    Script Date: 11/28/2020 11:16:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[MAKHMAX]
AS
BEGIN
	SELECT TOP(1)(CAST(RIGHT(MaKhachHang, 8) AS INT)) as MaLonNhat FROM KhachHang ORDER BY (CAST(RIGHT(MaKhachHang, 8) AS INT)) DESC
END
GO
/****** Object:  StoredProcedure [dbo].[MUAHANG]    Script Date: 11/28/2020 11:16:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[MUAHANG] @id varchar(10)
AS
BEGIN
SELECT MatHang.TenMatHang as N'Tên mặt hàng', MatHang.XuatXu as N'Xuất xứ', MatHang.GiaBan as N'Giá bán' FROM MatHang, DonViHangHoa WHERE MatHang.MaMatHang = DonViHangHoa.MaMatHang AND DonViHangHoa.ID = @id
END
GO
/****** Object:  StoredProcedure [dbo].[THEMKHACHHANG]    Script Date: 11/28/2020 11:16:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[THEMKHACHHANG] 
@makhachhang varchar(10),
@hoten nvarchar(50),
@gioitinh nvarchar(10),
@sdt varchar(20)
AS
BEGIN
	INSERT INTO KhachHang(MaKhachHang, HoTen, GioiTinh, DiemThuong, SDT) VALUES
	(@makhachhang, @hoten, @gioitinh, 0, @sdt)
END
GO
USE [master]
GO
ALTER DATABASE [QuanLySieuThi] SET  READ_WRITE 
GO
