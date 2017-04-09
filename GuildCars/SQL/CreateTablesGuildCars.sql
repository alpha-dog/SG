use GuildCars
go

--special vehicles(in jumbotron), featured vehicles (below jumbotron), vehicles (new/used),
--purchaseLog, customer, salesperson, 


if exists(select * from sys.tables where name='PurchaseLog')
drop table PurchaseLog 
go
  
if exists(select * from sys.tables where name='Vehicle')
drop table Vehicle
go

if exists(select * from sys.tables where name='Customer')
drop table Customer
go

if exists(select * from sys.tables where name='SalesPerson')
drop table SalesPerson
go



create table Vehicle
(
	VehicleId int identity primary key,
	Make varchar(15) not null,
	Model varchar(15) not null,
	[Type] varchar(4) not null,
	Body Style varchar(10) not null,
	[Year] varchar(4) not null,
	Transmission varchar(10) not null,
	Color varchar(10) not null,
	Interior varchar(10) not null,
	Mileage int not null,
	VIN int varchar (17) not null,
	MSRP money not null,
	SalePrice money not null,
	[Description] varchar(500) not null,
	Picture file null
)

create table Customer
(
	CustomerId int identity primary key,
	FirstName nvarchar(20) not null,
	LastName nvarchar(20) not null
)

create table SalesPerson
(
	EmployeeId int identity primary key,
	FirstName nvarchar(20) not null,
	LastName nvarchar(20) not null
)

create table PurchaseLog
(
	PurchaseId int identity primary key,
	CustomerId int foreign key references Customer(CustomerId),
	EmployeeId int foreign key references SalesPerson(EmployeeId),
	VehicleId int foreign key references Vehicle(VehicleId)	
)

--if exists(select * from sys.tables where name='Special')
--drop table Special
--go


--create table Special
--(
	
--)

--if exists(select * from sys.tables where name='Featured')
--drop table Featured 
--go
