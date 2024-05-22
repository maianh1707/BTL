create database LTNET
CREATE TABLE tblloai (
    maloai NVARCHAR(10) NOT NULL PRIMARY KEY,
    tenloai NVARCHAR(20) NOT NULL
);

CREATE TABLE tblco (
    maco NVARCHAR(10) NOT NULL PRIMARY KEY,
    tenco NVARCHAR(20) NOT NULL
);

CREATE TABLE tblchatlieu (
    machatlieu NVARCHAR(10) NOT NULL PRIMARY KEY,
    tenchatlieu NVARCHAR(20) NOT NULL
);

CREATE TABLE tblmau (
    mamau NVARCHAR(10) NOT NULL PRIMARY KEY,
    tenmau NVARCHAR(20) NOT NULL
);

CREATE TABLE tblmua (
    mamua NVARCHAR(10) NOT NULL PRIMARY KEY,
    tenmua NVARCHAR(20) NOT NULL
);

CREATE TABLE tblnhacungcap (
    mancc NVARCHAR(10) NOT NULL PRIMARY KEY,
    tenncc NVARCHAR(50) NOT NULL,
    diachi NVARCHAR(50) NOT NULL,
    dienthoai NVARCHAR(15) NOT NULL
);

CREATE TABLE tblsanpham (
    masanpham NVARCHAR(10) NOT NULL PRIMARY KEY,
    tensanpham NVARCHAR(50) NOT NULL,
    soluong FLOAT NOT NULL,
    anh NVARCHAR(200) NOT NULL,
    dongianhap FLOAT NOT NULL,
    dongiaban FLOAT NOT NULL,
    maloai NVARCHAR(10) NOT NULL,
    maco NVARCHAR(10) NOT NULL,
    machatlieu NVARCHAR(10) NOT NULL,
    mamau NVARCHAR(10) NOT NULL,
    mamua NVARCHAR(10) NOT NULL,
    mancc NVARCHAR(10) NOT NULL,
    FOREIGN KEY (maloai) REFERENCES tblloai(maloai),
    FOREIGN KEY (maco) REFERENCES tblco(maco),
    FOREIGN KEY (machatlieu) REFERENCES tblchatlieu(machatlieu),
    FOREIGN KEY (mamau) REFERENCES tblmau(mamau),
    FOREIGN KEY (mamua) REFERENCES tblmua(mamua),
    FOREIGN KEY (mancc) REFERENCES tblnhacungcap(mancc)
);

CREATE TABLE tblchucvu (
    macv NVARCHAR(10) NOT NULL PRIMARY KEY,
    tencv NVARCHAR(20) NOT NULL
);

CREATE TABLE tbltaikhoan (
    matk NVARCHAR(10) NOT NULL PRIMARY KEY,
    tentk NVARCHAR(20) NOT NULL,
	tendangnhap NVARCHAR(20) NOT NULL,
    matkhau NVARCHAR(20) NOT NULL
);

CREATE TABLE tblnhanvien (
    manv NVARCHAR(10) NOT NULL PRIMARY KEY,
    tennv NVARCHAR(50) NOT NULL,
    gioitinh NVARCHAR(10) NOT NULL,
    ngaysinh DATETIME NOT NULL,
    diachi NVARCHAR(50) NOT NULL,
    dienthoai NVARCHAR(15) NOT NULL,
    macv NVARCHAR(10) NOT NULL,
    matk NVARCHAR(10) NOT NULL,
    FOREIGN KEY (macv) REFERENCES tblchucvu(macv),
    FOREIGN KEY (matk) REFERENCES tbltaikhoan(matk)
);

CREATE TABLE tblkhachhang (
    makh NVARCHAR(10) NOT NULL PRIMARY KEY,
    tenkh NVARCHAR(50) NOT NULL,
    diachi NVARCHAR(50) NOT NULL,
    dienthoai NVARCHAR(15) NOT NULL
);

CREATE TABLE tblgiamgia (
    magiamgia NVARCHAR(10) NOT NULL PRIMARY KEY,
    tengiamgia NVARCHAR(50) NOT NULL,
    giatrigiam FLOAT NOT NULL,
    ngaybatdau DATETIME NOT NULL,
    ngayketthuc DATETIME NOT NULL,
    dieukien FLOAT NOT NULL,
    soluong FLOAT NOT NULL,
    trangthai NVARCHAR(50) NOT NULL
);

CREATE TABLE tblhoadonban (
    mahdb NVARCHAR(30) NOT NULL PRIMARY KEY,
    ngayban DATETIME NOT NULL,
    tongtienhang FLOAT NOT NULL,
    magiamgia NVARCHAR(10)  NULL,
    tongthanhtoan FLOAT NOT NULL,
    makh NVARCHAR(10) NOT NULL,
    manv NVARCHAR(10) NOT NULL,
    FOREIGN KEY (magiamgia) REFERENCES tblgiamgia(magiamgia),
    FOREIGN KEY (makh) REFERENCES tblkhachhang(makh),
    FOREIGN KEY (manv) REFERENCES tblnhanvien(manv)
);

CREATE TABLE tblchitiethdb (
    mahdb NVARCHAR(30) NOT NULL,
    masanpham NVARCHAR(10) NOT NULL,
    soluongxuat FLOAT NOT NULL,
    dongiaban FLOAT NOT NULL,
    thanhtien FLOAT NOT NULL,
    PRIMARY KEY (mahdb, masanpham),
    FOREIGN KEY (masanpham) REFERENCES tblsanpham(masanpham)
);

CREATE TABLE tblhoadonnhap (
    mahdn NVARCHAR(30) NOT NULL PRIMARY KEY,
    ngaynhap DATETIME NOT NULL,
    tongtienhang FLOAT NOT NULL,
    chietkhau FLOAT NOT NULL,
    tongthanhtoan FLOAT NOT NULL,
    manv NVARCHAR(10) NOT NULL,
    mancc NVARCHAR(10) NOT NULL,
    FOREIGN KEY (manv) REFERENCES tblnhanvien(manv),
    FOREIGN KEY (mancc) REFERENCES tblnhacungcap(mancc)
);

CREATE TABLE tblchitiethdn (
    mahdn NVARCHAR(30) NOT NULL,
    masanpham NVARCHAR(10) NOT NULL,
    soluongnhap FLOAT NOT NULL,
    dongianhap FLOAT NOT NULL,
    thanhtien FLOAT NOT NULL,
    PRIMARY KEY (mahdn, masanpham),
    FOREIGN KEY (masanpham) REFERENCES tblsanpham(masanpham)
);
INSERT INTO tblloai (maloai, tenloai) VALUES
('L01', N'Áo'),
('L02', N'Quần'),
('L03', N'Váy'),
('L04', N'Đầm');

INSERT INTO tblco (maco, tenco) VALUES
('C01', N'XS'),
('C02', N'S'),
('C03', N'M'),
('C04', N'L'),
('C05', N'XL');

INSERT INTO tblchatlieu (machatlieu, tenchatlieu) VALUES
('CL01', N'Cotton'),
('CL02', N'Len'),
('CL03', N'Silk'),
('CL04', N'Polyester');

INSERT INTO tblmau (mamau, tenmau) VALUES
('M01', N'Trắng'),
('M02', N'Đen'),
('M03', N'Xanh dương'),
('M04', N'Đỏ'),
('M05', N'Hồng');

INSERT INTO tblmua (mamua, tenmua) VALUES
('MU01', N'Xuân - Hè'),
('MU02', N'Thu - Đông');

INSERT INTO tblnhacungcap (mancc, tenncc, diachi, dienthoai) VALUES
('NCC01', N'Công ty TNHH May mặc ABC', N'123 Đường ABC, Quận 1, TP. HCM', '0123456789'),
('NCC02', N'Cửa hàng Quần áo XYZ', N'456 Đường XYZ, Quận 2, TP. HCM', '0987654321');

INSERT INTO tblsanpham (masanpham, tensanpham, soluong, anh, dongianhap, dongiaban, maloai, maco, machatlieu, mamau, mamua, mancc) VALUES
('SP01', N'Áo thun cổ tròn', 100, 'anh_aothun.jpg', 50000, 55000, 'L01', 'C01', 'CL01', 'M01', 'MU01', 'NCC01'),
('SP02', N'Quần jean nam', 80, 'anh_quanjean.jpg', 80000, 88000, 'L02', 'C02', 'CL04', 'M02', 'MU02', 'NCC02');

INSERT INTO tblchucvu (macv, tencv) VALUES
('CV01', N'Nhân viên bán hàng'),
('CV02', N'Quản lý kho');

INSERT INTO tbltaikhoan (matk, tentk, tendangnhap, matkhau) VALUES
('TK01', N'Nguyễn Mai Trang', 'nguyenmaitrang','123456'),
('TK02', N'Trần Thị Nhung', 'tranthinhung','123456');

INSERT INTO tblnhanvien (manv, tennv, gioitinh, ngaysinh, diachi, dienthoai, macv, matk) VALUES
('NV01', N'Nguyễn Mai Trang', N'Nữ', '1990-01-01', N'456 Đường ABC, Quận 1, TP. HCM', '0123456789', 'CV01', 'TK01'),
('NV02', N'Trần Thị Nhung', N'Nữ', '1995-05-10', N'789 Đường XYZ, Quận 2, TP. HCM', '0987654321', 'CV02', 'TK02');

INSERT INTO tblkhachhang (makh, tenkh, diachi, dienthoai) VALUES
('KH01', N'Nguyễn Thanh Thảo', N'101 Đường KLM, Quận 3, TP. HCM', '0367891234'),
('KH02', N'Lê Hoàng Thương', N'202 Đường QRS, Quận 4, TP. HCM', '0912345678');

INSERT INTO tblgiamgia (magiamgia, tengiamgia, giatrigiam, ngaybatdau, ngayketthuc, dieukien, soluong, trangthai) VALUES
('GG01', N'Chào hè 2024', 10000, '2024-05-01', '2024-05-31', '500000',50, N'Đang diễn ra'),
('GG02', N'Sale cuối tháng', 20000, '2024-06-01', '2024-06-30', '300000',50, N'Sắp diễn ra');

INSERT INTO tblhoadonban (mahdb, ngayban, tongtienhang, magiamgia, tongthanhtoan, makh, manv) VALUES
('HDB01', '2024-05-15', 539000, 'GG01', 529000, 'KH01', 'NV01'),
('HDB02', '2024-05-16', 220000, NULL, 220000, 'KH02', 'NV02');

INSERT INTO tblchitiethdb (mahdb, masanpham, soluongxuat, dongiaban, thanhtien) VALUES
('HDB01', 'SP01', 5, 55000, 275000),
('HDB01', 'SP02', 3, 88000, 264000),
('HDB02', 'SP01', 4, 55000, 220000);
