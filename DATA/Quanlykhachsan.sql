﻿CREATE DATABASE QuanLyKhachSan
GO

USE QuanLyKhachSan
GO 

CREATE TABLE NHANVIEN
(
	MANV INT IDENTITY  PRIMARY KEY,
	TENNV NVARCHAR(100) NOT NULL,
	LUONG FLOAT NOT NULL DEFAULT 0,
	ANHDAIDIEN varbinary(MAX)
)
GO
CREATE TABLE LOAIPHONG
(
	IDLOAIPHONG INT IDENTITY PRIMARY KEY,
	TENLOAIPHONG NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt Tên',
)
GO
CREATE TABLE KIEUPHONG
(
	IDKIEUPHONG INT IDENTITY PRIMARY KEY,
	TENKIEUPHONG NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt Tên',
	GIANGAY FLOAT,
	GIAGIO FLOAT,

)
GO
CREATE TABLE VATTU
(
	IDVATTU INT IDENTITY PRIMARY KEY,
	TENVATTU NVARCHAR(100) NOT NULL,
	XUATXU NVARCHAR(100) NOT NULL,
)
GO

CREATE TABLE PHONG
(
	MAPHONG INT IDENTITY PRIMARY KEY,
	TENPHONG NVARCHAR(50)NOT NULL DEFAULT N'PHÒNG CHƯA ĐẶT TÊN',
	IDKIEUPHONG int NOT NULL,
	IDLOAIPHONG INT NOT NULL
	FOREIGN KEY (IDLOAIPHONG) REFERENCES dbo.LOAIPHONG(IDLOAIPHONG),
	FOREIGN KEY (IDKIEUPHONG) REFERENCES dbo.KIEUPHONG(IDKIEUPHONG),
)
GO
CREATE TABLE PHIEULAPDAT
(
	SOPHIEULAPDAT INT IDENTITY PRIMARY KEY,
	NGAYLAPDAT DateTime,
	MANV int,
	MAPHONG INT,
	FOREIGN KEY (MANV) REFERENCES dbo.NHANVIEN(MANV),
	FOREIGN KEY (MAPHONG) REFERENCES dbo.PHONG(MAPHONG),
)
go
CREATE TABLE CHITIETLAPDAT
(
	SOPHIEULAPDAT INT  ,
	IDVATTU INT,
	TINHTRANG NVARCHAR(100),
	PRIMARY KEY(SOPHIEULAPDAT,IDVATTU),
	FOREIGN KEY (IDVATTU) REFERENCES dbo.VATTU(IDVATTU),
	FOREIGN KEY (SOPHIEULAPDAT) REFERENCES dbo.PHIEULAPDAT(SOPHIEULAPDAT),
)
GO

CREATE TABLE KHACHHANG
(
	CMND NVARCHAR(20)  PRIMARY KEY,
	TENKHACHHANG NVARCHAR(100) NOT NULL,
	SDT NVARCHAR(15) NOT NULL,
	DIACHI NVARCHAR(100) NOT NULL,
	GIOITINH BIT NOT NULL DEFAULT 0,
	QUOCTICH NVARCHAR(50) NOT null

)
GO

GO
CREATE TABLE PHIEUDATPHONG
(
	SOPHIEUDATPHONG INT IDENTITY PRIMARY KEY,
	NGAYDATPHONG DateTime NOT NULL,
	TONGTIENDATPHONG FLOAT NOT NULL DEFAULT 0 ,
	CMND NVARCHAR(20) NOT NULL,
	MANV INT NOT null,
	FOREIGN KEY (CMND) REFERENCES dbo.KhachHang(CMND),
	FOREIGN KEY (MANV) REFERENCES dbo.NHANVIEN(MANV),
)
GO
CREATE TABLE CHITIETPHIEUDATPHONG
(
	SOPHIEUDATPHONG INT,
	MAPHONG INT,
	GIOVAO DATETIME NOT NULL,
	GIORA DATETIME NOT NULL,
	SONGUOI int not null,
	TINHTRANGPHONG NVARCHAR(50)NOT NULL DEFAULT N'Đã Đặt',
	PRIMARY KEY(SOPHIEUDATPHONG,MAPHONG),
	FOREIGN KEY (MAPHONG) REFERENCES dbo.phong(MAPHONG),
	FOREIGN KEY (SOPHIEUDATPHONG) REFERENCES dbo.PHIEUDATPHONG(SOPHIEUDATPHONG),

)
--XONG
create table LOAIDICHVU
(
	IDLOAIDICHVU INT IDENTITY PRIMARY KEY,
	TENLOAIDICHVU NVARCHAR(100)NOT NULL DEFAULT N'CHƯA ĐẶT TÊN',
)
CREATE TABLE DICHVU
(
	IDDICHVU INT IDENTITY PRIMARY KEY,
	TENDICHVU NVARCHAR(100)NOT NULL DEFAULT N'CHƯA ĐẶT TÊN',
	DONGIABAN FLOAT NOT NULL DEFAULT 0,
	DVT NVARCHAR(100),
	IDLOAIDICHVU INT,
	FOREIGN KEY (IDLOAIDICHVU) REFERENCES dbo.LOAIDICHVU(IDLOAIDICHVU),
)
GO 
CREATE TABLE PHIEUSDDV
(
	SOPHIEUSDDV INT  IDENTITY PRIMARY KEY,
	MAPHONG INT ,
	NGAYSDDV DateTime,
	TONGTIENDV FLOAT,
	SOPHIEUDATPHONG INT,
	FOREIGN KEY (MAPHONG) REFERENCES dbo.PHONG(MAPHONG),
	FOREIGN KEY (SOPHIEUDATPHONG) REFERENCES dbo.PHIEUDATPHONG(SOPHIEUDATPHONG)
)
GO
CREATE TABLE CHITIETSDDICHVU
(
	SOPHIEUSDDV INT,
	IDDICHVU INT NOT NULL,
	SOLUONG INT NOT NULL DEFAULT 0,
	PRIMARY KEY(SOPHIEUSDDV,IDDICHVU),
	FOREIGN KEY (IDDICHVU) REFERENCES dbo.DICHVU(IDDICHVU),
	FOREIGN KEY (SOPHIEUSDDV) REFERENCES dbo.PHIEUSDDV(SOPHIEUSDDV),
)
GO
CREATE TABLE HOADON
(
	IDHOADON INT IDENTITY PRIMARY KEY,
	NGAYLAP DateTime ,
	TONGTIEN FLOAT NOT NULL DEFAULT 0,
	TINHTRANG INT NOT NULL DEFAULT 0,
	SOPHIEUDATPHONG INT,
	SOPHIEUSDDV INT,
	MANV INT,
	MAPHONG int ,
	FOREIGN KEY (SOPHIEUSDDV) REFERENCES dbo.PHIEUSDDV(SOPHIEUSDDV),
	FOREIGN KEY (SOPHIEUDATPHONG) REFERENCES dbo.PHIEUDATPHONG(SOPHIEUDATPHONG),
	FOREIGN KEY (MANV) REFERENCES dbo.NhanVien(MANV),
	FOREIGN KEY (MAPHONG) REFERENCES dbo.PHONG(MAPHONG),
)
GO
CREATE TABLE TAIKHOAN
(
	TENTAIKHOAN NVARCHAR(50) PRIMARY KEY,
	MATKHAU  NVARCHAR(1000)NOT NULL,
	MANV INT,
	QUYEN INT NOT NULL DEFAULT 0
	FOREIGN KEY (MANV) REFERENCES dbo.NhanVien(MANV),
)
GO
create PROC USP_GetListPhongByDate
@CheckIn DATEtime, @CheckOut DATEtime
AS 
BEGIN

	SELECT * FROM dbo.PHONG 
	WHERE MAPHONG not in (select p.MAPHONG from PHONG p, CHITIETPHIEUDATPHONG CTPDP where p.MAPHONG = CTPDP.MAPHONG and GIOVAO = @CheckIn and GIORA =  @CheckOut)
END
GO
