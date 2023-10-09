--Bảng phòng trọ
--View

drop view PhongTroHopDongView
drop trigger 
drop proc PTHienThiThongTinPhong

--Hiển thị thông tin phòng từ bảng
CREATE PROC PTHienThiThongTinPhong
AS
BEGIN
    SELECT *
    FROM
        phongtro;
END;


-- Hiển thị thông tin phòng đã thuê
CREATE PROC PTHienThiThongTinPhongDaChoThue
AS
SELECT*
FROM phongtro pt
LEFT JOIN hopdongthue hd ON pt.sophong = hd.sophong
WHERE hd.mahopdong IS NOT NULL;


-- Hiển thị thông tin phòng chưa cho thuê
CREATE PROC PTHienThiThongTinPhongChuaChoThue
AS
SELECT * FROM phongtro
WHERE trangthaiphong = 'Chưa cho thuê'

drop proc PTHienThiThongTinPhongChuaChoThue
-- Proc Thêm phòng trọ
CREATE PROCEDURE PTThem
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



-- Proc Sửa phòng trọ

CREATE PROCEDURE PTSua
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


-- Proc xóa phòng trọ
CREATE PROCEDURE PTXoa
    @sophong INT
AS
BEGIN
    DELETE FROM phongtro
    WHERE sophong = @sophong
END

--Proc Không Thêm khi chùng số phòng
create proc PTKhongThemKhiTrung
	@sophong int
as
	declare @result bit
	if exists (select 1 from phongtro where sophong = @sophong)
	set @result = 1;
	else
	set @result = 0
	select @result as 'result'


drop proc PTKhongThemKhiTrung 

-- Không sửa khi số phòng không tồn tại
create proc PTKhongSuaKhiKhongtontai
	@sophong int
as
	declare @result bit
	if exists (select 1 from phongtro where sophong = @sophong)
	set @result = 1;
	else
	set @result = 0
	select @result as 'result'


-- Không xóa khi không tồn tại SP
create proc PTKhongXoaKhiKhongTonTai
	@sophong int
as
	declare @result bit
	if exists (select 1 from phongtro where sophong = @sophong)
	set @result = 1;
	else
	set @result = 0
	select @result as 'result'

	drop proc PTKhongSuaKhiKhongtontai



-- Không xóa khi phòng đang có người thuê
create proc PTKhongXoaKhiDangCoNguoiThue 
	@sophong int
as
	declare @result bit
	if exists (
	select 1 from phongtro
	left join hopdongthue on phongtro.sophong = hopdongthue.sophong
	where hopdongthue.sophong = @sophong and hopdongthue.sophong is not null)
	set @result = 1;
	else 
	set @result = 0
	select @result  as 'result' 


-- Không thể cập nhật trạng thái phòng khi đang có người thuê


--Trigger cập nhật trạng thái phòng khi thêm
CREATE TRIGGER PTCapNhatTrangThaiPhongKhiThem
ON hopdongthue
AFTER INSERT
AS
BEGIN
    UPDATE phongtro
    SET trangthaiphong = N'Đã cho thuê'
    FROM phongtro
    INNER JOIN inserted ON phongtro.sophong = inserted.sophong;
END;


-- Trigger cập nhật trạng thái phòng khi sửa
CREATE TRIGGER PTCapNhatTrangThaiPhongKhiSua
ON hopdongthue
AFTER UPDATE
AS
BEGIN
    IF UPDATE(sophong)
    BEGIN

        UPDATE phongtro
        SET trangthaiphong = N'Chưa cho thuê'
        FROM phongtro
        INNER JOIN deleted ON phongtro.sophong = deleted.sophong;

        UPDATE phongtro
        SET trangthaiphong = N'Đã cho thuê'
        FROM phongtro
        INNER JOIN inserted ON phongtro.sophong = inserted.sophong;
    END;
END;


-- Cập nhật trạng thái phòng khi xóa
CREATE TRIGGER PTCapNhatTrangThaiPhongKhiXoa
ON hopdongthue
AFTER DELETE
AS
BEGIN
    UPDATE phongtro 
    SET trangthaiphong = N'Chưa cho thuê'
    FROM phongtro
    INNER JOIN deleted ON phongtro.sophong = deleted.sophong;
END;



--Tìm kiếm
CREATE PROCEDURE PTtimkiem
    @searchTerm NVARCHAR(100)
AS
BEGIN
    -- Tìm kiếm dữ liệu từ tất cả các cột trong bảng phongtro
    SELECT * FROM phongtro
    WHERE
        sophong = CAST(@searchTerm AS INT)
        OR dientich = CAST(@searchTerm AS DECIMAL(10, 3))
        OR giathue = CAST(@searchTerm AS DECIMAL(10, 3))
        OR tiendien = CAST(@searchTerm AS DECIMAL(10, 3))
        OR tiennuoc = CAST(@searchTerm AS DECIMAL(10, 3))
        OR tienmang = CAST(@searchTerm AS DECIMAL(10, 3))
        OR trangthaiphong LIKE '%' + @searchTerm + '%';
END;

