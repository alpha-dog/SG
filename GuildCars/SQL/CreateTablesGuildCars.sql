use GuildCars
go

if exists(select * from sys.tables where name='PurchaseLog')
drop table PurchaseLog 
go
  
if exists(select * from sys.tables where name='Vehicle')
drop table Vehicle
go

if exists(select * from sys.tables where name ='Color')
drop table Color
go

if exists(select * from sys.tables where name ='Transmission')
drop table Transmission
go

if exists(select * from sys.tables where name ='BodyStyle')
drop table BodyStyle
go

if exists(select * from sys.tables where name ='Type')
drop table [Type]
go

if exists(select * from sys.tables where name='SalesInfo')
drop table SalesInfo
go

if exists(select * from sys.tables where name='SalesPerson')
drop table SalesPerson
go

if exists(select * from sys.tables where name='State')
drop table [State]
go

if exists(select * from sys.tables where name='PurchaseType')
drop table PurchaseType
go

if exists(select * from sys.tables where name='Make')
drop table Make
go 

if exists(select * from sys.tables where name = 'Specials')
drop table Specials
go


create table Specials
(
	SpecialId int identity primary key,
	SpecialName varchar(20) not null,
	SpecialDetails varchar(200) not null
)


create table Make
(
	MakeId int identity primary key,
	Make varchar(20) not null
)

--create table PurchaseType
--(
--	PurchaseTypeId int identity primary key,
--	PurchaseType varchar(20) not null
--)

--create table [State]
--(
--	StateId varchar(2) primary key,
--	StateName varchar(20) not null
--)

create table [Type]
(
	TypeId int identity primary key,
	NewOrUsed varchar(4) not null
)

create table BodyStyle
(
	BodyStyleId int identity primary key,
	BodyStyle varchar(20) not null
)

create table Transmission
(
	TransmissionId int identity primary key,
	TransmissionType varchar(10) not null
)

create table Color
(
	ColorId int identity primary key,
	Color varchar(30) not null
)

create table Vehicle
(
	VehicleId int identity primary key,
	MakeId int foreign key references Make(MakeId) not null,
	Model varchar(15) not null,
	TypeId int foreign key references [Type](TypeId) not null,
	BodyStyleId int foreign key references BodyStyle(BodyStyleId) not null,
	[Year] varchar(4) not null,
	TransmissionId int foreign key references Transmission(TransmissionId) not null,
	ColorId int foreign key references Color(ColorId) not null,
	InteriorId int foreign key references Color(ColorId) not null,
	Mileage int not null,
	VIN varchar(17) not null,
	MSRP money not null,
	SalePrice money not null,
	[Description] varchar(500) not null,
	PictureFilePath nvarchar(100) null,
	IsFeature bit not null
)

--create table SalesInfo
--(
--	SalesInfoId int identity primary key,
--	FirstName nvarchar(20) not null,
--	LastName nvarchar(20) not null,
--	Phone varchar(20) not null,
--	Email nvarchar(40) null,
--	Street1 nvarchar(40) null,
--	Street2 nvarchar(40) null,
--	City nvarchar(40) null,
--	[State] varchar(2) foreign key references [State](StateId) null,
--	Zip varchar(5) null,
--	PurchasePrice money not null,
--	PurchaseTypeId int foreign key references PurchaseType(PurchaseTypeId)
--)

--create table SalesPerson
--(
--	EmployeeId int identity primary key,
--	FirstName nvarchar(20) not null,
--	LastName nvarchar(20) not null
--)

--create table PurchaseLog
--(
--	PurchaseId int identity primary key,
--	SalesInfoId int foreign key references SalesInfo(SalesInfoId),
--	EmployeeId int foreign key references SalesPerson(EmployeeId),
--	VehicleId int foreign key references Vehicle(VehicleId)	
--)
