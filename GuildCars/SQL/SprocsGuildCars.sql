use GuildCars
go

if exists(select * from information_schema.routines
	where routine_name = 'VehiclesGetAll')
	drop proc VehiclesGetAll
go

create proc VehiclesGetAll as
begin
	select * from Vehicle
end


go
if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'AddVehicles')
	drop procedure AddVehicles
go

create proc AddVehicles
(
	@VehicleId int, 
	@MakeId int,
	@Model varchar(20),
	@TypeId int,
	@BodyStyleId int,
	@Year varchar(4),
	@TransmissionId int,
	@ColorId int,
	@InteriorId int,
	@Mileage int,
	@VIN varchar(17),
	@MSRP money,
	@SalePrice money,
	@Description varchar(500),
	@PictureFilePath nvarchar(100)
) as 
begin
	insert into Vehicle 
	(MakeId, Model, TypeId, BodyStyleId, [Year], TransmissionId, 
		ColorId, InteriorId, Mileage, VIN, MSRP, SalePrice, [Description], 
		PictureFilePath)

	values (@MakeId, @Model, @TypeId, @BodyStyleId, @Year, @TransmissionId, 
		@ColorId, @InteriorId, @Mileage, @VIN, @MSRP, @SalePrice, @Description, 
		@PictureFilePath)

	set @VehicleId = SCOPE_IDENTITY();
end
go

if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'VehicleUpdate')
	drop proc VehicleUpdate
go 

create proc VehicleUpdate
(
	@VehicleId int, 
	@MakeId int,
	@Model varchar(20),
	@TypeId int,
	@BodyStyleId int,
	@Year varchar(4),
	@TransmissionId int,
	@ColorId int,
	@InteriorId int,
	@Mileage int,
	@VIN varchar(17),
	@MSRP money,
	@SalePrice money,
	@Description varchar(500),
	@PictureFilePath nvarchar(100)
)as
begin 
	update Vehicle set
		MakeId = @MakeId,
		Model = @Model,
		TypeId = @TypeId,
		BodyStyleId = @BodyStyleId,
		[Year] = @Year,
		TransmissionId = @TransmissionId,
		ColorId = @ColorId,
		InteriorId = @InteriorId,
		Mileage = @Mileage,
		VIN = @VIN,
		MSRP = @MSRP,
		SalePrice = @SalePrice,
		[Description] = @Description,
		PictureFilePath = @PictureFilePath
	where VehicleId = @VehicleId
end

go 
if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'VehicleDelete')
		drop proc VehicleDelete
go

create proc VehicleDelete 
(
	@VehicleId int
)as
begin 
	begin transaction 
	delete from Vehicle where VehicleId = @VehicleId;
	commit transaction
end

go
if exists(select * from INFORMATION_SCHEMA.ROUTINEs	
	where routine_name = 'SpecialAdd')
	drop proc SpecialAdd
go

create proc SpecialAdd
(
	@SpecialId int,
	@SpecialName varchar(20),
	@SpecialDetails varchar(200) 
)as
begin 
	insert into Specials (SpecialName, SpecialDetails)
	values (@SpecialName, @SpecialDetails)
	set @SpecialId = SCOPE_IDENTITY();
end