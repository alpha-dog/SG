use GuildCars
go

if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'VehiclesSelectAll')
		drop procedure VehiclesSelectAll
go

create procedure VehiclesSelectAll as
begin
	select VehicleId, MakeId, Model, [Year]
	from Vehicle
end
go 

if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'SalesPersonSelectAll')
	drop procedure SalesPersonSelectAll
go

create proc SalesPersonSelectAll as 
begin
	select EmployeeId, FirstName, LastName
	from SalesPerson
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
	where ROUTINE_NAME = 'SalesInfoSelectById')
	drop procedure SalesInfoSelectById
go

create proc SalesInfoSelectById
(
	@SalesInfoId int
) as 
begin
	select SalesInfoId, FirstName, LastName
	from SalesInfo
	where SalesInfoId = @SalesInfoId
end
go

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'SalesInfoUpdate')
      DROP PROCEDURE SalesInfoUpdate
GO

CREATE PROCEDURE SalesInfoUpdate (
	@SalesInfoId int,
	@FirstName nvarchar(20),
	@LastName nvarchar(20)
) As
BEGIN
	UPDATE SalesInfo SET 
		FirstName = @FirstName,
		LastName = @LastName
	WHERE SalesInfoId = @SalesInfoId
END
GO
if EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'SalesInfoDelete')
      DROP PROCEDURE SalesInfoDelete
GO

CREATE PROCEDURE SalesInfoDelete (
	@SalesInfoId int
) AS
BEGIN
	BEGIN TRANSACTION
	DELETE FROM SalesInfo WHERE SalesInfoId = @SalesInfoId;
	COMMIT TRANSACTION
END
