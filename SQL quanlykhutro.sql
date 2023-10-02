CREATE DATABASE quanlykhutro
USE quanlykhutro

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
    cancuoccongdannguoithue float,
	hovatennguoithue NVARCHAR(40) NOT NULL,	
    sodienthoainguoithue float(20),
    sophong int, FOREIGN KEY (sophong) REFERENCES phongtro(sophong),
	sotiencoc decimal (10, 3),
    ngaybatdau DATE,
    ngayketthuc DATE,
);



delete from hopdongthue
delete from phongtro
select * from phongtro
select * from hopdongthue

create view tonghop
as
select 
phongtro.sophong,
hopdongthue.mahopdong, 
phongtro.dientich,
phongtro.giathue,
phongtro.tiendien,
phongtro.tiennuoc,
phongtro.tienmang,
phongtro.trangthaiphong,
hopdongthue.hovatennguoithue,
hopdongthue.cancuoccongdannguoithue,
hopdongthue.sodienthoainguoithue,
hopdongthue.sotiencoc,
hopdongthue.ngaybatdau,
hopdongthue.ngayketthuc
from phongtro
full join hopdongthue on phongtro.sophong = hopdongthue.sophong;


-- hiển thị tổng quát
create proc tongquat
as
select 
phongtro.sophong,
phongtro.dientich,
phongtro.giathue,
phongtro.tiendien,
phongtro.tiennuoc,
phongtro.tienmang,
phongtro.trangthaiphong,
hopdongthue.mahopdong,
hopdongthue.hovatennguoithue,
hopdongthue.cancuoccongdannguoithue,
hopdongthue.sodienthoainguoithue,
hopdongthue.sotiencoc,
hopdongthue.ngaybatdau,
hopdongthue.ngayketthuc
from phongtro
full join  hopdongthue on phongtro.sophong = hopdongthue.sophong



-- Proc hiển thị phòng trọ
create proc hienthiphongtro
as 
select phongtro.sophong,
phongtro.dientich,
phongtro.giathue,
phongtro.tiendien,
phongtro.tiennuoc,
phongtro.tienmang,
phongtro.trangthaiphong
from phongtro
full join hopdongthue on phongtro.sophong = hopdongthue.sophong
order by phongtro.trangthaiphong

-- proc hiển thị các phòng chưa được thuê
create proc cacphongchuaduocthue
as
select sophong,
dientich, giathue,
tiendien,
tiennuoc,
tienmang,
trangthaiphong
from tonghop
where trangthaiphong = N'Chưa có người thuê'

--proc hiển thị phòng trọ đã được thuê
create proc cacphongdaduocthue
as
select sophong,
dientich, giathue,
tiendien,
tiennuoc,
tienmang,
trangthaiphong
from tonghop
where trangthaiphong = N'Đã cho thuê'


--proc thêm phòng trọ
create proc themphongtro
    @sophong int,
    @dientich decimal, 
    @giathue decimal,
	@tiendien decimal,
	@tiennuoc decimal,
	@tienmang decimal,
    @trangthaiphong NVARCHAR(40)
as
	
	insert into phongtro(sophong, dientich, giathue, tiendien, tiennuoc, tienmang, trangthaiphong)
	values(@sophong, @dientich, @giathue, @tiendien, @tiennuoc, @tienmang, @trangthaiphong)
	-- Xóa stored procedure có tên "MyStoredProcedure"




-- proc cập nhật phòng trọ
create proc capnhatphongtro
    @sophong int,
    @dientich decimal,
    @giathue decimal,
	@tiendien decimal,
	@tiennuoc decimal,
	@tienmang decimal,
    @trangthaiphong NVARCHAR(40)
as
	update phongtro
	set	dientich = @dientich,
		giathue = @giathue,
		tiendien = @tiendien,
		tiennuoc = @tiennuoc,
		tienmang = @tienmang,
		trangthaiphong = @trangthaiphong
	where sophong = @sophong


--proc xóa phòng trọ
create proc xoaphongtro
	@sophong int
as
	delete from phongtro
	where sophong = @sophong

drop proc if exists xoahopdong
-- Proc tìm kiếm phòng trọ
CREATE PROCEDURE timkiemphongtro
    @sophong INT = NULL,
    @dientich decimal = NULL,
    @giathue decimal = NULL,
    @tiendien decimal = NULL,
    @tiennuoc decimal = NULL,
    @tienmang decimal = NULL,
    @trangthaiphong NVARCHAR(40) = NULL
AS
BEGIN
    SELECT * FROM phongtro
    WHERE
        (@sophong IS NULL OR sophong = @sophong)
        OR (@dientich IS NULL OR dientich = @dientich)
        OR (@giathue IS NULL OR giathue = @giathue)
        OR (@tiendien IS NULL OR tiendien = @tiendien)
        OR (@tiennuoc IS NULL OR tiennuoc = @tiennuoc)
        OR (@tienmang IS NULL OR tienmang = @tienmang)
        OR (@trangthaiphong IS NULL OR trangthaiphong = @trangthaiphong)	
END



--Bảng hợp đồng
create proc hienthihopdong
as
select * 
from hopdongthue



create proc themhopdongthue
    @mahopdong int,
    @cancuoccongdannguoithue float,
	@hovatennguoithue nvarchar(40),
    @sodienthoainguoithue float,
    @sophong INT, 
	@sotiencoc decimal (10,3),
    @ngaybatdau DATE,
    @ngayketthuc DATE
as
insert into hopdongthue(mahopdong, cancuoccongdannguoithue, hovatennguoithue, sodienthoainguoithue, sophong, sotiencoc, ngaybatdau, ngayketthuc)
	values (@mahopdong, @cancuoccongdannguoithue, @hovatennguoithue, @sodienthoainguoithue, @sophong, @sotiencoc, @ngaybatdau, @ngayketthuc)



create proc xoahopdong
	@mahopdong int
as
	begin 
		delete from hopdongthue
		where
			@mahopdong = mahopdong
	end






create trigger capnhatrangthaiphongkhixoahopdong
on hopdongthue
after delete
as
begin
	update phongtro
	set trangthaiphong = 'Chưa được thuê'
	from phongtro
	inner join deleted on phongtro.sophong = deleted.sophong
end






























	SELECT name
FROM sys.triggers


drop trigger if exists capnhattrangthaiphongkhithemhopdong

-- trigger cập nhật lại trạng thái phòng khi thêm hợp đồng
CREATE TRIGGER capnhattrangthaiphong
ON hopdongthue
AFTER INSERT
AS
BEGIN
    -- Cập nhật trạng thái phòng từ "Chưa có người thuê" thành "Đã cho thuê"
    UPDATE phongtro
    SET trangthaiphong = N'Đã cho thuê'
    FROM phongtro
    INNER JOIN inserted ON phongtro.sophong = inserted.sophong;
END;





--trigger cập nhật lại trạng thái phòng khi xóa hợp đồng
CREATE TRIGGER UpdateRoomStatusOnContractDelete
ON hopdongthue
AFTER DELETE
AS
BEGIN
    -- Cập nhật trạng thái của phòng thành "Chưa có người thuê"
    UPDATE phongtro
    SET trangthaiphong = N'Chưa có người thuê'
    FROM phongtro
    INNER JOIN deleted ON phongtro.sophong = deleted.sophong;
END;



-- trigger xóa hợp đồng khi xóa phòng
CREATE TRIGGER xoahopdongkhixoaphong
ON phongtro
AFTER DELETE
AS
BEGIN
    -- Xóa thông tin trong bảng hopdongthue liên quan đến phòng trọ đã bị xóa
    DELETE FROM hopdongthue
    WHERE sophong IN (SELECT deleted.sophong FROM deleted);

    -- Cập nhật trạng thái của phòng thành "Chưa có người thuê"
    UPDATE phongtro
    SET trangthaiphong = 'Chưa có người thuê'
    FROM phongtro
    INNER JOIN deleted ON phongtro.sophong = deleted.sophong;
END;


		
