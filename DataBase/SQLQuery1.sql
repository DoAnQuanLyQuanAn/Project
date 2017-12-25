drop table info_HOADON
drop table HOADON

create table HOADON
(
	idBan int,
	tenMon nvarchar(50),
	donGia varchar(10),
	soLuong int,
	ngayLap datetime
)

create table ThanhToan
(
	idBan int,
	tongTien float,
	ngayTinh datetime
)

create proc BaoCao
	@ngay1 datetime,
	@ngay2 datetime,
	@tong float output
as 
begin
	set @tong=0
	while @ngay1<=@ngay2
	begin
		declare cur1 cursor for (select tt.tongTien from ThanhToan tt where tt.ngayTinh=@ngay1)
		open cur1
		declare @a float 
		set @a=0
		fetch next from cur1 into @a
		while @@FETCH_STATUS=0
		begin
			set @tong=@tong+@a
			fetch next from cur1 into @a
		end
		close cur1
		deallocate cur1
		set @ngay1=@ngay1+1
	end
end

