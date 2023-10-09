CREATE DATABASE QLKT3
go
USE QLKT3

CREATE TABLE phongtro (
    sophong INT PRIMARY KEY,
    dientich decimal (10,3),
    giathue decimal (10, 3),
	tiendien decimal (10, 3),
	tiennuoc decimal (10, 3),
	tienmang decimal (10, 3),
    trangthaiphong NVARCHAR(40)
);


CREATE TABLE hopdongthue (
    mahopdong INT PRIMARY KEY,
    cancuoccongdannguoithue varchar(20),
	hovatennguoithue NVARCHAR(40) NOT NULL,	
    sodienthoainguoithue varchar(20),
    sophong int, FOREIGN KEY (sophong) REFERENCES phongtro(sophong),
	sotiencoc decimal (10, 3),
    ngaybatdau DATE,
    ngayketthuc DATE,
);

-- Tạo view FULL JOIN giữa bảng phongtro và bảng hopdongthue
CREATE VIEW PhongTroHopDongView AS
SELECT
    p.sophong,
    p.dientich,
    p.giathue,
    p.tiendien,
    p.tiennuoc,
    p.tienmang,
    p.trangthaiphong,
    h.mahopdong,
    h.cancuoccongdannguoithue,
    h.hovatennguoithue,
    h.sodienthoainguoithue,
    h.sotiencoc,
    h.ngaybatdau,
    h.ngayketthuc
FROM
    phongtro p
FULL JOIN
    hopdongthue h ON p.sophong = h.sophong;



-- Thống Kê Tiền Phòng Trọ
create proc ThongKeTP
as
select hd.mahopdong as 'Mã Hợp Đồng', pt.sophong as 'Số Phòng', hd.hovatennguoithue as 'Họ Tên',
pt.tiendien as 'Tiền Điện', pt.tiennuoc as 'Tiền Nước', pt.tienmang as'Tiền Mạng', pt.giathue as 'Tiền Phòng',
(pt.tiendien + pt.tiennuoc + pt.tienmang + pt.giathue) as 'Tổng Tiền Phòng Trọ'
from hopdongthue hd, phongtro pt
where hd.sophong = pt.sophong

-- Thống Kê Người Đang Thuê
create proc ThongKeNguoiDangThue
as
select hd.mahopdong as 'Mã Hợp Đồng', pt.sophong as 'Số Phòng', hd.cancuoccongdannguoithue as 'Căn Cước Công Dân', hd.hovatennguoithue as 'Họ Tên',
hd.sodienthoainguoithue as 'Số Điện Thoại', hd.ngaybatdau as 'Ngày Thuê', hd.ngayketthuc as 'Ngày Trả Phòng'
from hopdongthue hd, phongtro pt
where hd.sophong = pt.sophong and hd.ngayketthuc > getdate()

-- Hiển thị phòng đã thuê
CREATE PROC PhongDaThue AS 
SELECT *
FROM PhongTroHopDongView
WHERE mahopdong is not null

--Hiển thị phòng chưa thuê
CREATE PROC PhongChuaThue AS 
SELECT *
FROM PhongTroHopDongView
WHERE mahopdong is null;

drop proc 

-- Hiển thị tổng quát
CREATE PROCEDURE HienThiThongTinTongQuat
AS
BEGIN
    SELECT pt.sophong, pt.dientich, pt.giathue, pt.tiendien, pt.tiennuoc, pt.tienmang, pt.trangthaiphong,
           hd.mahopdong, hd.cancuoccongdannguoithue, hd.hovatennguoithue, hd.sodienthoainguoithue,
           hd.sotiencoc, hd.ngaybatdau, hd.ngayketthuc
    FROM phongtro pt
    LEFT JOIN hopdongthue hd ON pt.sophong = hd.sophong
END

drop proc HienThiThongTinPhongThue

-- Hiển thị phòng thuê
create proc  HienThiThongTinPhongThue
as
begin
	select * from phongtro;
end;

-- Hiển thị hợp đồng thuê	
create proc  HienThiThongTinHopDong
as
begin
	select * from hopdongthue;
end;


--Thêm phòng trọ
CREATE PROCEDURE ThemPhongTro
    @sophong INT,
    @dientich DECIMAL(10,3),
    @giathue DECIMAL(10,3),
    @tiendien DECIMAL(10,3),
    @tiennuoc DECIMAL(10,3),
    @tienmang DECIMAL(10,3),
    @trangthaiphong NVARCHAR(40)
AS
BEGIN
    INSERT INTO phongtro (sophong, dientich, giathue, tiendien, tiennuoc, tienmang, trangthaiphong)
    VALUES (@sophong, @dientich, @giathue, @tiendien, @tiennuoc, @tienmang, @trangthaiphong)
END




--Thêm Hợp đồng thuê
CREATE PROCEDURE ThemHopDongThue
    @mahopdong INT,
    @cancuoccongdannguoithue VARCHAR(20),
    @hovatennguoithue NVARCHAR(40),
    @sodienthoainguoithue VARCHAR(20),
    @sophong INT,
    @sotiencoc DECIMAL(10, 3),
    @ngaybatdau DATE,
    @ngayketthuc DATE
AS
BEGIN
    INSERT INTO hopdongthue (mahopdong, cancuoccongdannguoithue, hovatennguoithue, sodienthoainguoithue, sophong, sotiencoc, ngaybatdau, ngayketthuc)
    VALUES (@mahopdong, @cancuoccongdannguoithue, @hovatennguoithue, @sodienthoainguoithue, @sophong, @sotiencoc, @ngaybatdau, @ngayketthuc);
END;


-- Sửa hợp đồng 
CREATE PROCEDURE SuaHopDongThue
    @mahopdong INT,
    @cancuoccongdannguoithue VARCHAR(20),
    @hovatennguoithue NVARCHAR(40),
    @sodienthoainguoithue VARCHAR(20),
    @sophong INT,
    @sotiencoc DECIMAL(10, 3),
    @ngaybatdau DATE,
    @ngayketthuc DATE
AS
BEGIN
    UPDATE hopdongthue
    SET 
        cancuoccongdannguoithue = @cancuoccongdannguoithue,
        hovatennguoithue = @hovatennguoithue,
        sodienthoainguoithue = @sodienthoainguoithue,
        sophong = @sophong,
        sotiencoc = @sotiencoc,
        ngaybatdau = @ngaybatdau,
        ngayketthuc = @ngayketthuc
    WHERE mahopdong = @mahopdong;
END;


-- Xóa hợp đồng
CREATE PROCEDURE XoaHopDongThue
    @mahopdong INT
AS
BEGIN
    DELETE FROM hopdongthue WHERE mahopdong = @mahopdong;
END;



-- Sửa phòng trọ

CREATE PROCEDURE SuaPhongTro
    @sophong INT,
    @dientich DECIMAL(10,3),
    @giathue DECIMAL(10,3),
    @tiendien DECIMAL(10,3),
    @tiennuoc DECIMAL(10,3),
    @tienmang DECIMAL(10,3),
    @trangthaiphong NVARCHAR(40)
AS
BEGIN
    UPDATE phongtro
    SET dientich = @dientich,
        giathue = @giathue,
        tiendien = @tiendien,
        tiennuoc = @tiennuoc,
        tienmang = @tienmang,
        trangthaiphong = @trangthaiphong
    WHERE sophong = @sophong
END


--Xóa
CREATE PROCEDURE XoaPhongTro
    @sophong INT
AS
BEGIN
    DELETE FROM phongtro
    WHERE sophong = @sophong
END



-- Kiểm tra phòng mới nhập vào đã tồn tại hay chưa ?  
CREATE PROCEDURE CheckPhongTroExists
    @sophong INT,
    @exists BIT OUTPUT
AS
BEGIN
    SET @exists = 0;
    
    IF EXISTS (SELECT 1 FROM phongtro WHERE sophong = @sophong)
    BEGIN
        SET @exists = 1;
    END
END
 
 -- Kiểm tra mã hợp đồng và số phòng có trùng
CREATE PROCEDURE CheckHopDongMaPhong
    @mahopdong INT,
	@sophong INT, 
    @exists BIT OUTPUT
AS
BEGIN
    SET @exists = 0;
    
    IF EXISTS (SELECT 1 FROM hopdongthue WHERE mahopdong = @mahopdong and sophong = @sophong)
    BEGIN
        SET @exists = 1;
    END
	ELSE 
	BEGIN
		SET @exists = 0;
	END
END


drop proc CheckHopDongMaPhong






--Trigger
CREATE TRIGGER Trg_CapNhatTrangThaiPhong_Insert
ON hopdongthue
AFTER INSERT
AS
BEGIN
    UPDATE phongtro
    SET trangthaiphong = N'Đã cho thuê'
    FROM phongtro
    INNER JOIN inserted ON phongtro.sophong = inserted.sophong;
END;

-- Trigger 2: Cập nhật trạng thái phòng khi có cập nhật thông tin số phòng trong hợp đồng
CREATE TRIGGER Trigger_CapNhatTrangThaiPhong_Update
ON hopdongthue
AFTER UPDATE
AS
BEGIN
    IF UPDATE(sophong)
    BEGIN
        -- Cập nhật trạng thái phòng cũ thành 'Chưa cho thuê'
        UPDATE phongtro
        SET trangthaiphong = N'Chưa cho thuê'
        FROM phongtro
        INNER JOIN deleted ON phongtro.sophong = deleted.sophong;

        -- Cập nhật trạng thái phòng mới thành 'Đã cho thuê'
        UPDATE phongtro
        SET trangthaiphong = N'Đã cho thuê'
        FROM phongtro
        INNER JOIN inserted ON phongtro.sophong = inserted.sophong;
    END;
END;


	drop trigger Trg_CapNhatTrangThaiPhong_KhiXoa


CREATE TRIGGER Trg_CapNhatTrangThaiPhong_KhiXoa
ON hopdongthue
AFTER DELETE
AS
BEGIN
    UPDATE phongtro
    SET trangthaiphong = N'Chưa cho thuê'
    FROM phongtro
    INNER JOIN deleted ON phongtro.sophong = deleted.sophong;
END;
