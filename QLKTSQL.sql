CREATE DATABASE QLKT
USE QLKT

CREATE TABLE phongtro (
    sophong INT PRIMARY KEY,
    dientich decimal (10,3),
    giathue decimal (10, 3),
	tiendien decimal (10, 3),
	tiennuoc decimal (10, 3),
	tienmang decimal (10, 3),
    trangthaiphong NVARCHAR(40)
);
delete from phongtro


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

create table hoadontungthang (
	mahoadon int primary key,
	thang int,
	nam int,
	mahopdong int foreign key (mahopdong) references hopdongthue(mahopdong),
	sodiencu int,
	sodienmoi int, 
	sonuoccu int,
	sonuocmoi int,
);

ALTER TABLE hopdongthue
ADD CONSTRAINT FK_hopdongthue_phongtro
FOREIGN KEY (sophong) REFERENCES phongtro(sophong)
ON DELETE CASCADE;

ALTER TABLE hoadontungthang
ADD CONSTRAINT FK_hoadontungthang_hopdongthue
FOREIGN KEY (mahopdong) REFERENCES hopdongthue(mahopdong)
ON DELETE CASCADE;


CREATE PROCEDURE HienThiThongTinTongQuat
AS
BEGIN
    SELECT
        pt.*,
        hd.mahopdong,
        hd.cancuoccongdannguoithue,
        hd.hovatennguoithue,
        hd.sodienthoainguoithue,
        hd.sotiencoc,
        hd.ngaybatdau,
        hd.ngayketthuc
    FROM
        phongtro pt
    LEFT JOIN
        hopdongthue hd ON pt.sophong = hd.sophong;
END;
drop proc HienThiThongTinTongQuat






CREATE VIEW vw_ThongTinPhongTroHopDongHoaDon AS
SELECT pt.sophong, pt.dientich, pt.giathue, pt.tiendien, pt.tiennuoc, pt.tienmang, pt.trangthaiphong,
       hd.mahopdong, hd.cancuoccongdannguoithue, hd.hovatennguoithue, hd.sodienthoainguoithue, hd.sotiencoc, hd.ngaybatdau, hd.ngayketthuc,
       ht.mahoadon, ht.thang, ht.nam, ht.sodiencu, ht.sodienmoi, ht.sonuoccu, ht.sonuocmoi
FROM phongtro pt
left JOIN hopdongthue hd ON pt.sophong = hd.sophong
left JOIN hoadontungthang ht ON hd.mahopdong = ht.mahopdong;




CREATE PROCEDURE HienThiThongTinTongQuat
AS
select * from vw_ThongTinPhongTroHopDongHoaDon






