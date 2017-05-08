
--due to time, I used * in some of the sprocs instead of writing out everything

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
	where ROUTINE_NAME = 'VehicleSelectById')
	drop procedure VehicleSelectById
go

create proc VehicleSelectById
(
	@VehicleId int
) as 
begin
	select *
	from Vehicle
	where VehicleId = @VehicleId
end
go

go
if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'AddVehicles')
	drop procedure AddVehicles
go

create proc AddVehicles
(
	@VehicleId int, 
	@MakeId int,
	@ModelId varchar(20),
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
	@PictureFilePath nvarchar(100),
	@IsFeature bit
) as 
begin
	insert into Vehicle 
	(MakeId, ModelId, TypeId, BodyStyleId, [Year], TransmissionId, 
		ColorId, InteriorId, Mileage, VIN, MSRP, SalePrice, [Description], 
		PictureFilePath, IsFeature)

	values (@MakeId, @ModelId, @TypeId, @BodyStyleId, @Year, @TransmissionId, 
		@ColorId, @InteriorId, @Mileage, @VIN, @MSRP, @SalePrice, @Description, 
		@PictureFilePath, @IsFeature)

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
	@ModelId int,
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
	@PictureFilePath nvarchar(100),
	@IsFeature bit
)as
begin 
	update Vehicle set
		MakeId = @MakeId,
		ModelId = @ModelId,
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
		PictureFilePath = @PictureFilePath,
		IsFeature = @IsFeature
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

go
if exists(select * from information_schema.routines
	where routine_name = 'SpecialsGetAll')
	drop proc SpecialsGetAll
go
create proc SpecialsGetAll as
begin
	select * from Specials
end

go
if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'SpecialSelectById')
	drop procedure SpecialSelectById
go

create proc SpecialSelectById
(
	@SpecialId int
) as 
begin
	select SpecialId, SpecialName, SpecialDetails
	from Specials
	where SpecialId = @SpecialId
end

go 
if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'SpecialDelete')
		drop proc SpecialDelete
go
create proc SpecialDelete 
(
	@SpecialId int
)as
begin 
	begin transaction 
	delete from Specials where SpecialId = @SpecialId;
	commit transaction
end



go
if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'VehicleSelectWithJoins')
	drop proc VehicleSelectWithJoins

go
create proc VehicleSelectWithJoins
(
	@VehicleId int
)as
begin
select VehicleId, 
		Vehicle.MakeId,
		Make.Make,
		Vehicle.ModelId,
		Model.ModelName,
		Vehicle.TypeId,
		[Type].NewOrUsed, 
		Vehicle.BodyStyleId,
		BodyStyle.BodyStyle, 
		[Year], 
		Vehicle.TransmissionId,
		Transmission.TransmissionType,
		Vehicle.ColorId,
		ExtColor.Color,
		Vehicle.InteriorId,
		IntColor.Color,
		Mileage,
		VIN,
		MSRP,
		SalePrice,
		[Description],
		PictureFilePath,
		IsFeature
		 
from Vehicle

join Make
	on Vehicle.MakeId = Make.MakeId
join Model
	on Vehicle.ModelId = Model.ModelId
join [Type]
	on Vehicle.TypeId = [Type].TypeId
join BodyStyle
	on Vehicle.BodyStyleId = BodyStyle.BodyStyleId
join Transmission
	on Vehicle.TransmissionId = Transmission.TransmissionId
join Color as ExtColor
	on Vehicle.ColorId = ExtColor.ColorId
join Color as IntColor
	on Vehicle.InteriorId = IntColor.ColorId
	
	where VehicleId = @VehicleId
end

go
if exists(select * from information_schema.routines
	where routine_name = 'VehicleGetAllWithJoins')
	drop proc VehicleGetAllWithJoins
go
create proc VehicleGetAllWithJoins as
begin
	select VehicleId, 
		Vehicle.MakeId,
		Make.Make,
		Vehicle.ModelId,
		Model.ModelName, 
		Vehicle.TypeId,
		[Type].NewOrUsed, 
		BodyStyle.BodyStyle,
		Vehicle.BodyStyleId, 
		[Year], 
		Vehicle.TransmissionId,
		Transmission.TransmissionType,
		Vehicle.ColorId,
		ExtColor.Color,
		Vehicle.InteriorId,
		IntColor.Color,
		--Vehicle.ColorId,
		--Vehicle.InteriorId,
		Mileage,
		VIN,
		MSRP,
		SalePrice,
		[Description],
		PictureFilePath,
		IsFeature
		 
from Vehicle

join Make
	on Vehicle.MakeId = make.MakeId
join Model
	on Vehicle.ModelId = Model.ModelId
join [Type]
	on Vehicle.TypeId = [Type].TypeId
join BodyStyle
	on Vehicle.BodyStyleId = BodyStyle.BodyStyleId
join Transmission
	on Vehicle.TransmissionId = Transmission.TransmissionId
join Color as ExtColor
	on Vehicle.ColorId = ExtColor.ColorId
join Color as IntColor
	on Vehicle.InteriorId = IntColor.ColorId
end

go 
--if exists(select * from INFORMATION_SCHEMA.ROUTINES
--	where ROUTINE_NAME = 'VehicleSearch')
--		drop proc VehicleSearch
--go
--create proc VehicleSearch 
--(
--	@SearchVal varchar(50)
--)as
--begin 
--	select VehicleId, 
--	Make.Make,
--	Model, 
--	[Type].TypeId, 
--	BodyStyle.BodyStyle, 
--	[Year], 
--	Transmission.TransmissionType,
--	Color.ColorId, 
--	Color.Color,
--	--interior color,
--	Mileage,
--	VIN,
--	MSRP,
--	SalePrice,
--	[Description],
--	PictureFilePath,
--	IsFeature
		 
--from Vehicle

--	join Make
--		on Vehicle.MakeId = make.MakeId
--	join [Type]
--		on Vehicle.TypeId = [Type].TypeId
--	join BodyStyle
--		on Vehicle.BodyStyleId = BodyStyle.BodyStyleId
--	join Transmission
--		on Vehicle.TransmissionId = Transmission.TransmissionId
--	join Color  
--		on Vehicle.ColorId = Color.ColorId
--	where Model like @SearchVal + '%' OR 
--		[Year] like @SearchVal + '%' OR 
--		Make.Make like @SearchVal + '%';
--end


