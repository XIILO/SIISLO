


-- Tạo view tính tổng tiền thuê nhà
CREATE VIEW TongTienThueNha AS
SELECT 
    p.sophong,
    hd.mahopdong,
    ((hdt.sodienmoi - hdt.sodiencu) * p.tiendien) AS tiendien,
    ((hdt.sonuocmoi - hdt.sonuoccu) * p.tiennuoc) AS tiennuoc,
    p.tienmang,
    p.giathue,
    (((hdt.sodienmoi - hdt.sodiencu) * p.tiendien) + ((hdt.sonuocmoi - hdt.sonuoccu) * p.tiennuoc) + p.tienmang + p.giathue) AS tongtien
FROM 
    phongtro p
    JOIN hopdongthue hd ON p.sophong = hd.sophong
    JOIN hoadontungthang hdt ON hd.mahopdong = hdt.mahopdong;


create proc HoaDonCallViewPhongTroThongTinThue
as 
SELECT * FROM TongTienThueNha
																						
-- Thêm hóa đơn
CREATE PROCEDURE HoaDonT
	@mahoadon INT,
    @thang INT,
    @nam INT,
    @mahopdong INT,
    @sodiencu INT,
    @sodienmoi INT,
    @sonuoccu INT,
    @sonuocmoi INT

AS
BEGIN
    INSERT INTO hoadontungthang (mahoadon, thang, nam, mahopdong, sodiencu, sodienmoi, sonuoccu, sonuocmoi)
    VALUES (@mahoadon, @thang, @nam, @mahopdong, @sodiencu, @sodienmoi, @sonuoccu, @sonuocmoi)
END


-- Không thêm hóa đơn khi hợp đồng không tồn tại
CREATE PROCEDURE HoaDonKhongthethemkhihopdongkhongtontaimhd
    @mahopdong INT
AS

BEGIN
	declare @result bit
    IF EXISTS (SELECT 1 FROM hopdongthue WHERE mahopdong = @mahopdong)
    BEGIN
        SET @result = 1;
    END
    ELSE
    BEGIN
        SET @result = 0;
    END
   
    SELECT @result AS 'Result';
END;

-- Không thể thêm khi trùng mã hóa đơn
CREATE PROCEDURE HoaDonKhongthethemkhitrungmaHD
    @mahoadon INT
AS

BEGIN
	declare @result bit
    IF EXISTS (SELECT 1 FROM hoadontungthang WHERE hoadontungthang.mahoadon = @mahoadon)
    BEGIN
        SET @result = 1;
    END
    ELSE
    BEGIN
        SET @result = 0;
    END
   
    SELECT @result AS 'Result';
END;


exec HoaDonKhongthethemkhihopdongkhongtontaimhd @mahopdong = 123

drop proc HoaDonS

-- Sửa hóa đơn
CREATE PROCEDURE HoaDonS
	@mahoadon INT,
    @thang INT,
    @nam INT,
    @mahopdong INT,
    @sodiencu INT,
    @sodienmoi INT,
    @sonuoccu INT,
    @sonuocmoi INT
AS
BEGIN
    UPDATE hoadontungthang
    SET	thang = @thang,
		nam = @nam,
		mahopdong = @mahoadon,
		sodiencu = @sodiencu,
        sodienmoi = @sodienmoi,
        sonuoccu = @sonuoccu,
        sonuocmoi = @sonuocmoi
    WHERE mahoadon = @mahoadon
END


create proc  HoaDonKhongthesuakhimahoadonkhongtontai
	@mahoadon int
as
	declare @r bit
	if exists (select 1 from hoadontungthang where @mahoadon = hoadontungthang.mahoadon)
	set @r = 1
	else 
	set @r = 0
	select @r as 'R'


-- Xóa hóa đơn
CREATE PROCEDURE HoaDonX
    @mahoadon INT
AS
BEGIN
    DELETE FROM hoadontungthang
    WHERE mahoadon = @mahoadon
END

-- Nếu mã hoad dơn không tồn tại thì không xóa
create proc HoaDonKhongtontaithikhongxoa
	@mahoadon int
as
	declare @result bit
	if exists (select 1 from hoadontungthang where hoadontungthang.mahoadon = @mahoadon)
	set @result = 1
	else 
	set @result = 0
	select @result as 'result'

exec HoaDonKhongtontaithikhongxoa @mahoadon = 1

CREATE PROCEDURE HoaDonHT
AS
BEGIN
    SELECT 
        mahoadon,
        thang,
        nam,
        mahopdong,
        sodiencu,
        sodienmoi,
        sonuoccu,
        sonuocmoi
    FROM hoadontungthang
END




drop proc CheckHoaDon