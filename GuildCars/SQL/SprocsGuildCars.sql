use GuildCars
go

if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'VehiclesSelectAll')
		drop procedure VehiclesSelectAll
go

create procedure VehiclesSelectAll as
begin
	select VehicleId, Make, Model, [Year]
	from Vehicle
end
go

if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'CustomersSelectAll')
	drop procedure CustomersSelectAll
go

create proc CustomersSelectAll as 
begin
	select CustomerId, FirstName, LastName
	from Customer
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
	where ROUTINE_NAME = 'CustomerAdd')
	drop procedure CustomerAdd
go

create proc CustomerAdd
(
	@CustomerId int, @FirstName nvarchar(20), @LastName nvarchar(20)
) as 
begin
	insert into Customer (FirstName, LastName)
	values (@FirstName, @LastName)
	set @CustomerId = SCOPE_IDENTITY();
end

go