CREATE DATABASE LTNET;

USE LTNET;

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
    --soluong FLOAT NOT NULL,
    anh NVARCHAR(200) NOT NULL,
    dongianhap FLOAT NOT NULL,
    dongiaban FLOAT NOT NULL,
    maloai NVARCHAR(10) NOT NULL,
    machatlieu NVARCHAR(10) NOT NULL,
    mamua NVARCHAR(10) NOT NULL,
    mancc NVARCHAR(10) NOT NULL,
    FOREIGN KEY (maloai) REFERENCES tblloai(maloai),
    FOREIGN KEY (machatlieu) REFERENCES tblchatlieu(machatlieu),
    FOREIGN KEY (mamua) REFERENCES tblmua(mamua),
    FOREIGN KEY (mancc) REFERENCES tblnhacungcap(mancc)
);

CREATE TABLE tbchitietsp (
    masanpham NVARCHAR(10) NOT NULL,
    maco NVARCHAR(10) NOT NULL,
	mamau nvarchar(10) not null,
	soluong float not null,
    PRIMARY KEY (masanpham, maco,mamau),
    FOREIGN KEY (masanpham) REFERENCES tblsanpham(masanpham),
    FOREIGN KEY (maco) REFERENCES tblco(maco),
	FOREIGN KEY (mamau) REFERENCES tblmau(mamau)
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
    luong FLOAT NOT NULL,
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

CREATE TABLE tblhoadonban (
    mahdb NVARCHAR(30) NOT NULL PRIMARY KEY,
    ngayban DATETIME NOT NULL,
    tongtien FLOAT NOT NULL,
    makh NVARCHAR(10) NOT NULL,
    manv NVARCHAR(10) NOT NULL,
    FOREIGN KEY (makh) REFERENCES tblkhachhang(makh),
    FOREIGN KEY (manv) REFERENCES tblnhanvien(manv)
);

CREATE TABLE tblchitiethdb (
    mahdb NVARCHAR(30) NOT NULL,
    masanpham NVARCHAR(10) NOT NULL,
    maco NVARCHAR(10) NOT NULL,
    mamau NVARCHAR(10) NOT NULL,
    soluongxuat FLOAT NOT NULL,
    dongiaban FLOAT NOT NULL,
    giamgia FLOAT NOT NULL,
    thanhtien FLOAT NOT NULL,
    PRIMARY KEY (mahdb, masanpham, maco, mamau),
    FOREIGN KEY (mahdb) REFERENCES tblhoadonban(mahdb),
    FOREIGN KEY (masanpham) REFERENCES tblsanpham(masanpham),
    FOREIGN KEY (maco) REFERENCES tblco(maco),
    FOREIGN KEY (mamau) REFERENCES tblmau(mamau)
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
    maco NVARCHAR(10) NOT NULL,
    mamau NVARCHAR(10) NOT NULL,
    soluongnhap FLOAT NOT NULL,
    dongianhap FLOAT NOT NULL,
    thanhtien FLOAT NOT NULL,
    PRIMARY KEY (mahdn, masanpham, maco, mamau),
    FOREIGN KEY (mahdn) REFERENCES tblhoadonnhap(mahdn),
    FOREIGN KEY (masanpham) REFERENCES tblsanpham(masanpham),
    FOREIGN KEY (maco) REFERENCES tblco(maco),
    FOREIGN KEY (mamau) REFERENCES tblmau(mamau)
);

CREATE TABLE tblbckiemkho (
    makiemke NVARCHAR(30) NOT NULL PRIMARY KEY,
    thoigiantao DATETIME NOT NULL,
    manv NVARCHAR(10) NOT NULL,
    ghichu NVARCHAR(100),
    FOREIGN KEY (manv) REFERENCES tblnhanvien(manv)
);

CREATE TABLE tblchitietbckiemkho (
    makiemke NVARCHAR(30) NOT NULL,
    masanpham NVARCHAR(10) NOT NULL,
    soluongxuat FLOAT NOT NULL,
    soluongnhap FLOAT NOT NULL,
    soluongtonkho FLOAT NOT NULL,
    soluongtonkhothucte FLOAT NOT NULL,
    soluongchenhlech FLOAT NOT NULL,
    PRIMARY KEY (makiemke, masanpham),
    FOREIGN KEY (makiemke) REFERENCES tblbckiemkho(makiemke),
    FOREIGN KEY (masanpham) REFERENCES tblsanpham(masanpham)
);

INSERT INTO tblloai (maloai, tenloai) VALUES
('L01', N'Áo'),
('L02', N'Quần'),
('L03', N'Váy'),
('L04', N'Đầm');

INSERT INTO tblco (maco, tenco) VALUES
('C01', N'S'),
('C02', N'M'),
('C03', N'L');

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

INSERT INTO tblsanpham (masanpham, tensanpham, anh, dongianhap, dongiaban, maloai, machatlieu, mamua, mancc) VALUES
('SP01', N'Áo thun cổ tròn', 'anh_aothun.jpg', 50000, 55000, 'L01', 'CL01', 'MU01', 'NCC01'),
('SP02', N'Quần jean nam', 'anh_quanjean.jpg', 80000, 88000, 'L02', 'CL04', 'MU02', 'NCC02');

INSERT INTO tblchucvu (macv, tencv) VALUES
('CV01', N'Nhân viên bán hàng'),
('CV02', N'Quản lý kho');

INSERT INTO tbltaikhoan (matk, tentk, tendangnhap, matkhau) VALUES
('TK01', N'Nguyễn Mai Trang', 'nguyenmaitrang', '123456'),
('TK02', N'Trần Thị Nhung', 'tranthinhung', '123456');

INSERT INTO tblnhanvien (manv, tennv, gioitinh, ngaysinh, luong, diachi, dienthoai, macv, matk) VALUES
('NV01', N'Nguyễn Mai Trang', N'Nữ', '1990-01-01', 7000000, N'456 Đường ABC, Quận 1, TP. HCM', '0123456789', 'CV01', 'TK01'),
('NV02', N'Trần Thị Nhung', N'Nữ', '1995-05-10', 9000000, N'789 Đường XYZ, Quận 2, TP. HCM', '0987654321', 'CV02', 'TK02');

INSERT INTO tblkhachhang (makh, tenkh, diachi, dienthoai) VALUES
('KH01', N'Nguyễn Thanh Thảo', N'101 Đường KLM, Quận 3, TP. HCM', '0367891234'),
('KH02', N'Lê Hoàng Thương', N'202 Đường QRS, Quận 4, TP. HCM', '0912345678');

INSERT INTO tblhoadonban (mahdb, ngayban, tongtien, makh, manv) VALUES
('HDB01', '2024-05-15', 539000, 'KH01', 'NV01'),
('HDB02', '2024-05-16', 220000, 'KH02', 'NV02');

INSERT INTO tblchitiethdb (mahdb, masanpham, maco, mamau, soluongxuat, dongiaban, giamgia, thanhtien) VALUES
('HDB01', 'SP01', 'C01', 'M01', 5, 55000, 0, 275000),
('HDB01', 'SP02', 'C01', 'M01', 3, 88000, 0, 264000),
('HDB02', 'SP01', 'C01', 'M01', 4, 55000, 0, 220000);

INSERT INTO tblhoadonnhap (mahdn, ngaynhap, tongtienhang, chietkhau, tongthanhtoan, manv, mancc) VALUES
('HDN01', '2024-05-10', 1000000, 10000, 990000, 'NV01', 'NCC01'),
('HDN02', '2024-05-12', 1500000, 15000, 1485000, 'NV02', 'NCC02');

INSERT INTO tblchitiethdn (mahdn, masanpham, maco, mamau, soluongnhap, dongianhap, thanhtien) VALUES
('HDN01', 'SP01', 'C01', 'M01', 10, 50000, 500000),
('HDN01', 'SP02', 'C01', 'M01', 8, 80000, 640000),
('HDN02', 'SP01', 'C02', 'M02', 12, 50000, 600000),
('HDN02', 'SP02', 'C02', 'M02', 10, 80000, 800000);
