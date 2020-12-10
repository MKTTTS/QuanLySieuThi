USE [QuanLySieuThi]
GO
/****** Object:  Table [dbo].[ChucVu]    Script Date: 12/10/2020 7:28:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChucVu](
	[MaChucVu] [varchar](10) NOT NULL,
	[TenChucVu] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaChucVu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DangNhap]    Script Date: 12/10/2020 7:28:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DangNhap](
	[MaNhanVien] [varchar](10) NULL,
	[MatKhau] [varchar](30) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DonViHangHoa]    Script Date: 12/10/2020 7:28:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonViHangHoa](
	[ID] [varchar](10) NOT NULL,
	[MaMatHang] [varchar](10) NULL,
	[NgaySanXuat] [date] NULL,
	[HanSuDung] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 12/10/2020 7:28:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[MaHoaDon] [varchar](20) NOT NULL,
	[MaKhachHang] [varchar](10) NULL,
	[NgayTao] [date] NULL,
	[TongTien] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDon_MatHang]    Script Date: 12/10/2020 7:28:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon_MatHang](
	[MaHoaDon] [varchar](20) NULL,
	[MaMatHang] [varchar](10) NULL,
	[Soluong] [int] NULL,
	[ThanhTien] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 12/10/2020 7:28:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiMatHang]    Script Date: 12/10/2020 7:28:23 AM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MatHang]    Script Date: 12/10/2020 7:28:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 12/10/2020 7:28:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhieuNhap]    Script Date: 12/10/2020 7:28:23 AM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhieuNhap_ChiTiet]    Script Date: 12/10/2020 7:28:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu]) VALUES (N'AD', N'Quản lý siêu thị')
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu]) VALUES (N'LC', N'Lao công')
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu]) VALUES (N'SC', N'Bảo vệ')
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu]) VALUES (N'TK', N'Quản lý kho')
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu]) VALUES (N'TN', N'Thu ngân')
GO
INSERT [dbo].[DangNhap] ([MaNhanVien], [MatKhau]) VALUES (N'NV00000001', N'123456')
INSERT [dbo].[DangNhap] ([MaNhanVien], [MatKhau]) VALUES (N'NV00000002', N'123456')
INSERT [dbo].[DangNhap] ([MaNhanVien], [MatKhau]) VALUES (N'NV00000003', N'123456')
INSERT [dbo].[DangNhap] ([MaNhanVien], [MatKhau]) VALUES (N'NV00000004', N'123456')
GO
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
GO
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
INSERT [dbo].[KhachHang] ([MaKhachHang], [HoTen], [GioiTinh], [DiemThuong], [SDT]) VALUES (N'KH00000015', N'Phan Anh Tú', N'Nam', 0, N'0253567122')
GO
SET IDENTITY_INSERT [dbo].[LoaiMatHang] ON 

INSERT [dbo].[LoaiMatHang] ([MaLoai], [TenLoai]) VALUES (1, N'Thực phẩm')
INSERT [dbo].[LoaiMatHang] ([MaLoai], [TenLoai]) VALUES (2, N'Đồ gia dụng')
INSERT [dbo].[LoaiMatHang] ([MaLoai], [TenLoai]) VALUES (3, N'Văn phòng phẩm')
INSERT [dbo].[LoaiMatHang] ([MaLoai], [TenLoai]) VALUES (4, N'Đồ sinh hoạt cá nhân')
INSERT [dbo].[LoaiMatHang] ([MaLoai], [TenLoai]) VALUES (5, N'Bánh kẹo')
INSERT [dbo].[LoaiMatHang] ([MaLoai], [TenLoai]) VALUES (6, N'Đồ uống')
INSERT [dbo].[LoaiMatHang] ([MaLoai], [TenLoai]) VALUES (7, N'Linh tinh')
INSERT [dbo].[LoaiMatHang] ([MaLoai], [TenLoai]) VALUES (8, N'Linh Tinh 2')
INSERT [dbo].[LoaiMatHang] ([MaLoai], [TenLoai]) VALUES (9, N'Linh Tinhc 3')
SET IDENTITY_INSERT [dbo].[LoaiMatHang] OFF
GO
INSERT [dbo].[MatHang] ([MaMatHang], [TenMatHang], [Soluong], [MaLoai], [XuatXu], [GiaBan]) VALUES (N'1#00000001', N'Gạo tẻ', 2, 1, N'Việt Nam', 80000)
INSERT [dbo].[MatHang] ([MaMatHang], [TenMatHang], [Soluong], [MaLoai], [XuatXu], [GiaBan]) VALUES (N'1#00000002', N'Thịt bò Kobe 300 gram', 0, 1, N'Nhật Bản', 900000)
INSERT [dbo].[MatHang] ([MaMatHang], [TenMatHang], [Soluong], [MaLoai], [XuatXu], [GiaBan]) VALUES (N'2#00000001', N'Nồi cơm điện Cookoo', 1, 2, N'Hàn Quốc', 1200000)
INSERT [dbo].[MatHang] ([MaMatHang], [TenMatHang], [Soluong], [MaLoai], [XuatXu], [GiaBan]) VALUES (N'3#00000001', N'Vở Hồng Hà 100 trang', 3, 3, N'Việt Nam', 10000)
INSERT [dbo].[MatHang] ([MaMatHang], [TenMatHang], [Soluong], [MaLoai], [XuatXu], [GiaBan]) VALUES (N'4#00000001', N'Dầu gội X-men for Boss', 2, 4, N'Việt Nam', 95000)
INSERT [dbo].[MatHang] ([MaMatHang], [TenMatHang], [Soluong], [MaLoai], [XuatXu], [GiaBan]) VALUES (N'5#00000001', N'Chocopie anh đào', 1, 5, N'Việt Nam', 60000)
INSERT [dbo].[MatHang] ([MaMatHang], [TenMatHang], [Soluong], [MaLoai], [XuatXu], [GiaBan]) VALUES (N'5#00000002', N'Sô cô la Gorki', 0, 5, N'Nga', 230000)
INSERT [dbo].[MatHang] ([MaMatHang], [TenMatHang], [Soluong], [MaLoai], [XuatXu], [GiaBan]) VALUES (N'6#00000001', N'CocaCola chai 1,5l', 2, 6, N'Việt Nam', 30000)
INSERT [dbo].[MatHang] ([MaMatHang], [TenMatHang], [Soluong], [MaLoai], [XuatXu], [GiaBan]) VALUES (N'6#00000002', N'Fanta lon', 0, 6, N'Việt Nam', 10000)
GO
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTenNhanVien], [NgaySinh], [SDT], [SoCMND], [DiaChi], [AnhDaiDien], [MaChucVu], [QueQuan], [GioiTinh]) VALUES (N'NV00000001', N'Đinh Xuân Tùng', CAST(N'1998-06-16' AS Date), N'0973380598', N'035098000142', N'75 Đội Cấn', NULL, N'AD', N'Tượng Lĩnh, Kim Bảng, Hà Nam', N'Nam')
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTenNhanVien], [NgaySinh], [SDT], [SoCMND], [DiaChi], [AnhDaiDien], [MaChucVu], [QueQuan], [GioiTinh]) VALUES (N'NV00000002', N'Trần Bảo Trí', CAST(N'1999-10-10' AS Date), N'0123512453', N'032546132523', N'236 Hoàng Quốc Việt', NULL, N'TK', N'Vinh, Nghệ An', N'Nam')
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTenNhanVien], [NgaySinh], [SDT], [SoCMND], [DiaChi], [AnhDaiDien], [MaChucVu], [QueQuan], [GioiTinh]) VALUES (N'NV00000003', N'Nguyễn Mạnh Sơn', CAST(N'1999-01-20' AS Date), N'0934762483', N'035673000234', N'236 Hoàng Quốc Việt', NULL, N'TN', N'Nhân Hòa, Vĩnh Bảo, Hải Phòng', N'Nam')
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTenNhanVien], [NgaySinh], [SDT], [SoCMND], [DiaChi], [AnhDaiDien], [MaChucVu], [QueQuan], [GioiTinh]) VALUES (N'NV00000004', N'Nguyễn Văn Kiên', CAST(N'1998-10-09' AS Date), N'0924657123', N'035087000645', N'236 Hoàng Quốc Việt', NULL, N'TN', N'Hưng Yên', N'Nam')
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTenNhanVien], [NgaySinh], [SDT], [SoCMND], [DiaChi], [AnhDaiDien], [MaChucVu], [QueQuan], [GioiTinh]) VALUES (N'NV00000005', N'Ngô Nhật Minh', CAST(N'1999-10-20' AS Date), N'0925781546', N'026789000124', N'236 Hoàng Quốc Việt', NULL, N'SC', N'Tĩnh Gia, Thanh Hóa', N'Nam')
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTenNhanVien], [NgaySinh], [SDT], [SoCMND], [DiaChi], [AnhDaiDien], [MaChucVu], [QueQuan], [GioiTinh]) VALUES (N'NV00000006', N'Đặng Trọng Tiến', CAST(N'1999-04-05' AS Date), N'0344045609', N'035621000789', N'236 Hoàng Quốc Việt', NULL, N'LC', N'Thanh Chương, Nghệ An', N'Nam')
GO
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
/****** Object:  StoredProcedure [dbo].[INSERTMATHANG]    Script Date: 12/10/2020 7:28:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  CREATE PROC [dbo].[INSERTMATHANG] 
  @mamathang varchar(10),
  @tenmathang nvarchar(100),
  @soluong int,
  @maloai int,
  @xuatxu nvarchar(50),
  @giaban int
  AS
  BEGIN
	INSERT INTO dbo.MatHang
	(
	    MaMatHang,
	    TenMatHang,
	    Soluong,
	    MaLoai,
	    XuatXu,
	    GiaBan
	)
	VALUES
	(   @mamathang,  -- MaMatHang - varchar(10)
	    @tenmathang, -- TenMatHang - nvarchar(100)
	    @soluong,   -- Soluong - int
	    @maloai,   -- MaLoai - int
	    @xuatxu, -- XuatXu - nvarchar(50)
	    @giaban    -- GiaBan - int
	    )
  END
GO
/****** Object:  StoredProcedure [dbo].[MAKHMAX]    Script Date: 12/10/2020 7:28:23 AM ******/
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
/****** Object:  StoredProcedure [dbo].[MAMHMAX]    Script Date: 12/10/2020 7:28:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  CREATE PROC [dbo].[MAMHMAX]
  @tenloai nvarchar(100)
  AS
  BEGIN
	IF(EXISTS(SELECT * FROM dbo.MatHang JOIN dbo.LoaiMatHang ON dbo.MatHang.MaLoai = dbo.LoaiMatHang.MaLoai WHERE dbo.LoaiMatHang.TenLoai = @tenloai))
	BEGIN
	SELECT TOP(1) (CAST(RIGHT(MaMatHang, 8) AS INT)) AS MaLonNhat, dbo.LoaiMatHang.MaLoai FROM dbo.MatHang RIGHT JOIN dbo.LoaiMatHang ON dbo.MatHang.MaLoai = dbo.LoaiMatHang.MaLoai WHERE TenLoai = @tenloai ORDER BY(CAST(RIGHT(MaMatHang, 8) AS INT)) DESC
	END
	ELSE
	BEGIN
		SELECT 0 AS MaLonNhat, dbo.LoaiMatHang.MaLoai FROM dbo.LoaiMatHang WHERE dbo.LoaiMatHang.TenLoai = @tenloai
	END
  END
GO
/****** Object:  StoredProcedure [dbo].[MUAHANG]    Script Date: 12/10/2020 7:28:23 AM ******/
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
/****** Object:  StoredProcedure [dbo].[THEMKHACHHANG]    Script Date: 12/10/2020 7:28:23 AM ******/
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
/****** Object:  StoredProcedure [dbo].[THONGTINLOAIMATHANG]    Script Date: 12/10/2020 7:28:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[THONGTINLOAIMATHANG]
@maloai INT
AS
BEGIN
	SELECT LoaiMatHang.TenLoai, COUNT(MatHang.MaMatHang) AS Soluong FROM LoaiMatHang LEFT JOIN MatHang ON( LoaiMatHang.MaLoai = MatHang.MaLoai) WHERE LoaiMatHang.MaLoai = @maloai GROUP BY(LoaiMatHang.TenLoai)
END
GO
