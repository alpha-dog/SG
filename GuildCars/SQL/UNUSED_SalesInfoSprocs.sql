use GuildCars
go

if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'SalesInfoSelectAll')
	drop procedure SalesInfoSelectAll
go

create proc SalesInfoSelectAll as 
begin
	select SalesInfoId, FirstName, LastName
	from SalesInfo
end

go 

if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'SalesInfoAdd')
	drop procedure SalesInfoAdd
go

create proc SalesInfoAdd
(
	@SalesInfoId int, @FirstName nvarchar(20), @LastName nvarchar(20)
) as 
begin
	insert into SalesInfo (FirstName, LastName)
	values (@FirstName, @LastName)
	set @SalesInfoId = SCOPE_IDENTITY();
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
