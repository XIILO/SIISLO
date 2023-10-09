

--Hiển thị hợp đồng thuê
CREATE PROC HDTHienThi
AS
BEGIN
    SELECT *
    FROM hopdongthue;
END;


--Thêm Hợp đồng thuê
CREATE PROCEDURE HDTThem
    @mahopdong INT,
    @cancuoccongdannguoithue VARCHAR(20),
    @hovatennguoithue NVARCHAR(40),
    @sodienthoainguoithue VARCHAR(20),
    @sophong INT,
    @sotiencoc DECIMAL(10, 3),
    @ngaybatdau DATE,PTKhongSuaKhiKhongtontai    @ngayketthuc DATE
AS
BEGIN
    INSERT INTO hopdongthue (mahopdong, cancuoccongdannguoithue, hovatennguoithue, sodienthoainguoithue, sophong, sotiencoc, ngaybatdau, ngayketthuc)
    VALUES (@mahopdong, @cancuoccongdannguoithue, @hovatennguoithue, @sodienthoainguoithue, @sophong, @sotiencoc, @ngaybatdau, @ngayketthuc);
END; 



-- Sửa hợp đồng thuê
CREATE PROCEDURE HDTSua
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


-- Xóa hợp đồng thuê
CREATE PROCEDURE HDTXoa
    @mahopdong INT
AS
BEGIN
    DELETE FROM hopdongthue WHERE mahopdong = @mahopdong;
END;



-- Không thêm khi trùng
create proc HDTKhongthemkhitrungMHD
	@mahopdong int
as 
	declare @result bit
	if exists (select 1 from hopdongthue where hopdongthue.mahopdong = @mahopdong)
	set @result  = 1
	else
	set @result = 0
	select @result as 'result'

-- Không thêm hợp đồng số phòng không tồn tại
create proc HDTKhongthemkhikhongtontaisp
	@sophong int
as 
	declare @result bit
	IF NOT EXISTS (SELECT 1 FROM phongtro WHERE sophong = @sophong)
	set @result = 1
	else set @result = 0
	select @result as 'result'

	-- Không thêm khi phòng đã dùng
create proc HDTKhongthethemkhiphongdadung
	@sophong int
as
	declare @result bit
	IF EXISTS (SELECT 1 FROM hopdongthue WHERE sophong = @sophong)
	set @result = 1
	else set @result = 0
	select @result as 'result'

	--Không sửa khi không tồn tại mã hợp đồng
	--kiemtrasophongtontai
create proc HDTKhongsuakhikhongtontaiSP
	@sophong int
as 
	declare @result bit
	if exists (select 1 from phongtro where phongtro.sophong = @sophong)
	set @result  = 1
	else
	set @result = 0
	select @result as 'result' 


create proc HDTKhongchinhsuakhiphongdangduocthue
	@sophong int
as
	declare @r bit
	if exists (select 1 from phongtro
	left join hopdongthue on phongtro.sophong = hopdongthue.sophong
	where phongtro.sophong = @sophong and hopdongthue.sophong is null)
	set @r = 1
	else 
	set @r = 0
	select @r as 'r'


	exec HDTKhongchinhsuakhiphongdangduocthue @sophong = 100
	exec HDTKhongsuakhikhongtontaiSP @sophong =123124
	 
	drop proc HDTKhongsuakhikhongtontaiSP

-- Không xóa khi không tồn tại ma 

create proc HDTKhongxoakhikhongtontaimhd
	@mahopdong int
as
	declare @result bit
	if exists(select 1 from hopdongthue
	where hopdongthue.mahopdong = @mahopdong)
	set @result = 1
	else
	set @result = 0
	select @result as 'result'	



-- Xóa hóa đơn khi xóa hợp đồng
-- Tạo trigger
CREATE TRIGGER XoaHoaDonTungThangTruocKhiXoaHopDong
ON hopdongthue
AFTER DELETE
AS
BEGIN
    SET NOCOUNT ON;

    -- Xóa các hóa đơn tương ứng
    DELETE FROM hoadontungthang
    WHERE mahopdong IN (SELECT deleted.mahopdong FROM deleted);
END;
