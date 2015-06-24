create database QLPhongMach;
go
--drop database QLPhongMach
use QlPhongMach;
go
--drop table NguoiDung
set dateformat dmy
create table NguoiDung
(
	MaND int not null identity(1,1),
	TenND nvarchar(100) not null,
	NgaySinh varchar(10),
	GioiTinh bit,
	DiaChi nvarchar(100),
	SDT varchar(20),
	TenDangNhap varchar(100) not null unique,
	MatKhau varchar(100) not null,
	ChucVu nvarchar(50)
	constraint PK_NguoiDung primary key (MaND)
)
go
--select *from NguoiDung
insert NguoiDung(TenND,NgaySinh,GioiTinh ,DiaChi ,SDT ,TenDangNhap,MatKhau,ChucVu) 
	values(N'Phước Lộc','06/01/1992',0,N'TP.HCM','0123456789','admin','202cb962ac59075b964b07152d234b70',N'Admin');
go
insert NguoiDung(TenND,NgaySinh,GioiTinh ,DiaChi ,SDT ,TenDangNhap,MatKhau,ChucVu) 
	values(N'Cẩm Vân','29/02/1992',0,N'TP.HCM','0123456789','camvan','202cb962ac59075b964b07152d234b70',N'Admin');
go
insert NguoiDung(TenND,NgaySinh,GioiTinh ,DiaChi ,SDT ,TenDangNhap,MatKhau,ChucVu) 
	values(N'Điều hành viên','01/01/2014',1,N'TP.HCM','094757676','dieuhanh','202cb962ac59075b964b07152d234b70',N'Điều Hành');
go
create table BenhNhan
(
	MaBN int not null identity (1,1),
	TenBN nvarchar(50) not null,
	NgaySinh datetime,
	GioiTinh bit,
	DiaChi nvarchar(100)
	constraint PK_BenhNhan primary key (MaBN)
)
go
insert BenhNhan (TenBN, NgaySinh, GioiTinh, DiaChi)
	values (N'Nguyễn Văn Tèo','21/1/1990',1,'TP.HCM');
go
insert BenhNhan (TenBN, NgaySinh, GioiTinh, DiaChi)
	values (N'Bành Thị Nở','21/3/1990',0,'TP.HCM');
go
create table PhieuKham
(
	MaPK int not null identity (1,1),
	NgayKham datetime default getdate(),
	TrieuChung nvarchar(100),
	LoaiBenh nvarchar(100),
	MaBN int
	constraint PK_PhieuKham primary key(MaPK)
	constraint FK_PhieuKham_BenhNhan foreign key (MaBN) references BenhNhan(MaBN) on delete cascade on update cascade
)
go
--create table ToaThuoc
--(
--	MaToa int not null identity (1,1),
--	BSKeToa int,
--	NgayKeToa date default getdate(),
--	MaBN int,
--	MaPK int
--	constraint PK_ToaThuoc primary key(MaToa)
--	constraint FK_ToaThuoc_BenhNhan foreign key (MaBN) references BenhNhan(MaBN) on delete cascade on update cascade,
--	constraint FK_ToaThuoc_PhieuKham foreign key (MaPK) references PhieuKham(MaPK)on delete cascade on update cascade
--)
--drop table HoaDonThuoc
create table HoaDonThuoc
(
	MaHD int not null identity (1,1),
	NgayBan datetime default getdate(),
	TienThuoc int,
	TienKham int,
	MaPK int
	constraint PK_HoaDonThuoc primary key(MaHD)
	constraint FK_HoaDonThuoc_PhieuKham foreign key (MaPK) references PhieuKham(MaPK) on delete cascade on update cascade
)
go

create table Thuoc
(
	MaThuoc int not null identity (1,1),
	TenThuoc nvarchar(100),
	DonVi nvarchar(10),
	DonGia int
	constraint PK_Thuoc primary key(MaTHuoc)
)
go

insert Thuoc(TenThuoc,DonVi,DonGia) values (N'Paradon',N'Viên',1000)
go
insert Thuoc(TenThuoc,DonVi,DonGia) values (N'Caxium',N'Viên',2000)
go
insert Thuoc(TenThuoc,DonVi,DonGia) values (N'Alaxan',N'Viên',1500)
go
insert Thuoc(TenThuoc,DonVi,DonGia) values (N'Ospamox',N'Viên',2500)
go
insert Thuoc(TenThuoc,DonVi,DonGia) values (N'Aparin',N'Viên',2500)
go
insert Thuoc(TenThuoc,DonVi,DonGia) values (N'Astest',N'Hộp',50000)
go
create table ChiTietToaThuoc
(
	MaPK int not null,
	MaThuoc int not null,
	SoLuong int,
	CachDung nvarchar(100)
	constraint PK_ChiTietToaThuoc primary key(MaPK,MaThuoc),
	constraint FK_ChiTietToaThuoc_PhieuKham foreign key(MaPK) references PhieuKham(MaPK) on delete cascade on update cascade,
	constraint FK_ChiTietToaThuoc_Thuoc foreign key(MaThuoc) references Thuoc(MaThuoc) on delete cascade on update cascade
)
go
insert PhieuKham(NgayKham,TrieuChung,LoaiBenh,MaBN)
	values ('31/12/2013',N'Nhức đầu',N'Cảm',1)
go
insert PhieuKham(NgayKham,TrieuChung,LoaiBenh,MaBN)
	values ('30/12/2013',N'Đau bụng, khó tiêu',N'Rối loạn tiêu hóa',2)
go
insert ChiTietToaThuoc values (1,5,3,N'Ngày uống 3 lần, mỗi lần 1 viên')
go
insert ChiTietToaThuoc values (2,3,3,N'Ngày uống 3 lần, mỗi lần 1 viên')
go
insert HoaDonThuoc(MaPK,NgayBan,TienKham,TienThuoc) 
	values (1,'31/12/2013',50000,7500)
go
insert HoaDonThuoc(MaPK,NgayBan,TienKham,TienThuoc) 
	values (2,'30/12/2013',50000,4500)
go
-- Tao trigger insert PhieuKham -- Neu insert mot phieu kham se insert them 1 HoaDonThuoc luon
create trigger insertPhieuKham
on PhieuKham
after insert as
begin
	declare @MaPK int, @NgayKham date
	select @MaPK = MaPK, @NgayKham = NgayKham from inserted
	insert HoaDonThuoc(NgayBan,TienThuoc,TienKham,MaPK) values(@NgayKham,0,50000,@MaPK)
end
go
--select *from BenhNhan
--insert PhieuKham(TrieuChung, LoaiBenh, MaBN) values (N'Nhức đầu',N'Cảm',1)
--select * from HoaDonThuoc
--select * from PhieuKham
-- 
--delete from PhieuKham where MaPk = 2

--Nếu insert ChiTietToaThuoc se cap nhat lai cho 
create trigger insertChiTietToaThuoc
on ChiTietToaThuoc
after insert as
begin
	declare @TienThuoc int, @MaPK int
	select @TienThuoc = i.SoLuong*t.DonGia,@MaPK = i.MaPK from inserted i join Thuoc t on t.MaThuoc = i.MaThuoc
	update HoaDonThuoc set TienThuoc = TienThuoc + @TienThuoc where MaPK = @MaPK
end
--insert ChiTietToaThuoc values(3,1,2,N'Ngày uống 2 lần sáng và tối 1 lần uống 1 viên')
--insert ChiTietToaThuoc values(3,2,2,N'Ngày uống 2 lần sáng và tối 1 lần uống 1 viên')
go
create trigger deleteChiTietToaThuoc
on ChiTietToaThuoc
for delete as
begin
	declare @TienThuoc int, @MaPK int
	select @TienThuoc = i.SoLuong*t.DonGia,@MaPK = i.MaPK from deleted i join Thuoc t on t.MaThuoc = i.MaThuoc
	update HoaDonThuoc set TienThuoc = TienThuoc - @TienThuoc where MaPK = @MaPK
end
--delete from ChiTietToaThuoc where MaPK = 3 and MaThuoc = 1;
go
create trigger updateChiTietToaThuoc
on ChiTietToaThuoc
for update as
begin
	declare @TienThuocCu int, @MaPK int, @TienThuocMoi int
	select @TienThuocCu = d.SoLuong*t.DonGia from deleted d join Thuoc t on t.MaThuoc = d.MaThuoc
	select @TienThuocMoi = i.SoLuong*t.DonGia,@MaPK = i.MaPK from inserted i join Thuoc t on t.MaThuoc = i.MaThuoc
	update HoaDonThuoc set TienThuoc = TienThuoc - @TienThuocCu + @TienThuocMoi where MaPK = @MaPK
end
--update ChiTietToaThuoc set SoLuong = 4 where MaPK = 3 and MaThuoc = 1;
--select *from ChiTietToaThuoc
--select * from HoaDonThuoc
--select * from PhieuKham
--delete from PhieuKham where MaPK =1
--select *from chitiettoathuoc
go

create procedure BCDoanhThu 
	@Thang int, @Nam int
as
 select NgayKham, count(*) as 'SoBN', sum(TienThuoc + TienKham) as 'DoanhThu'
 from BenhNhan bn join PhieuKham pk on bn.MaBN = pk.MaBN join HoaDonThuoc hd on hd.MaPK = pk.MaPK
 where month(NgayKham) = @Thang and year(NgayKham) = @Nam
 group by NgayKham
go

create procedure BCSDThuoc
	@Thang int, @Nam int
as
select ROW_NUMBER() over(order by TenThuoc desc) as STT, TenThuoc, DonVi, sum(SoLuong) as 'TongSoLuong', count(*) as 'SoLanDung'
from Thuoc t join ChiTietToaThuoc ct on t.MaThuoc = ct.MaThuoc join PhieuKham pk on ct.MaPK = pk.MaPK join HoaDonThuoc hd on hd.MaPK = pk.MaPK
where month(NgayKham) = @Thang and year(NgayKham) = @Nam and TienThuoc != 0
group by t.MaThuoc, TenThuoc, DonVi
 --delete from BenhNhan
go
 
--select TenThuoc, DonVi, sum(SoLuong) as 'TongSoLuong', count(*) as 'SoLanDung'
--from Thuoc t join ChiTietToaThuoc ct on t.MaThuoc = ct.MaThuoc join PhieuKham pk on ct.MaPK = pk.MaPK
--where month(NgayKham) = 6 and year(NgayKham) = 2012
--group by t.MaThuoc, TenThuoc, DonVi
--go

--select TenThuoc,DonVi,SoLuong,Congdung
--from Thuoc t join ChiTietToaThuoc ct on t.MaThuoc=ct.MaThuoc join ToaThuoc tt on tt.MaToa=ct.MaToa join BenhNhan b on b.MaBN=tt.MaBN
--where month(NgayKham) = 6                    
--go


create Procedure LayThuoc
(
	@PageIndex int,
	@PageSize int
)
as
begin
select * from
(
	select ROW_NUMBER() over(order by TenThuoc desc) as STT, MaThuoc, TenThuoc, DonVi, DonGia
	from Thuoc
) Tam
where Tam.STT between (@PageIndex*@PageSize + 1) and ((@PageIndex+1)*@PageSize)
end
go

create Procedure DemThuoc
as
select COUNT(*) from Thuoc