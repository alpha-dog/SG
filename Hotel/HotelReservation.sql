set nocount on
go

use master
go

if exists(select * from sysdatabases where name ='HotelReservation')
	drop database HotelReservation

create database HotelReservation
go

use HotelReservation
go

create table Customer
(
	CustomerID int identity(1,1) primary key,
	FirstName nvarchar(30) not null,
	LastName nvarchar(30) not null,
	PhoneNumber varchar (20) not null,
	CardNumber varchar (20) not null,
)


create table Promotions
(
	PromoCode int identity(1,1) primary key,
	PromoPercentage int null,
	PromoFlat money null,
	PromoExpDate datetime2 not null,
	PromoType varchar(30) not null
)

create table Reservation
(
	ReservationID int identity(1,1) primary key,
	CustomerID int foreign key references Customer(CustomerID) not null,
	CheckIn datetime2 not null,
	CheckOut datetime2 null,
	NumberOfRooms int not null,
	PromoCode int foreign key references Promotions(PromoCode) null,
	RoomID varchar(20) not null,
	BillID int not null
)

create table Guest
(
	GuestID int identity(1,1) primary key,
	FirstName nvarchar(30) not null,
	LastName nvarchar(30) not null,
	ReservationID int foreign key references Reservation(ReservationID) not null
)

create table Bill
(
	BillID int identity primary key,
	ReservationID int foreign key references Reservation(ReservationID),
	Taxes money not null,
	--Details money null,
	Total money not null,
)

create table Room
(
	RoomID int identity primary key,

	RoomNum varchar(10) not null,
	[Floor] int not null,
	Occupants int not null,
	RoomTypeID int not null,
	AddOnID int null,
	--AmenityID int null
)

create table ReservationRoom
(
	ReservationID int not null,
	RoomID int not null,
	constraint PK_ReservationRoom 
		primary key(ReservationID, RoomID),
	constraint FK_Room_Reservation 
		foreign key (RoomID) references Room(RoomID),
	constraint FK_Reservation_Room 
		foreign key (ReservationID) references Reservation(ReservationID) 
)

create table Amenity
(
	AmenityID int identity primary key,
	AmenityName varchar(10) not null,
	--RoomID int foreign key references Room(RoomID),
)

create table RoomAmenity
(
	RoomID int not null,
	AmenityID int not null,
	constraint PK_RoomAmenity primary key(RoomID, AmenityID),
	constraint FK_Amenity_Room foreign key(AmenityID) references Amenity(AmenityID),
	constraint FK_Room_Amenity foreign key(RoomID) references Room(RoomID)
)

create table RoomType
(
	RoomTypeID int identity primary key,
	[Type] VarChar(10) not null,
	RateID int not null
)

create table Rate
(
	RateID int identity primary key,
	--RoomTypeID int foreign key references RoomType(RoomTypeID),
	DateRange datetime2 not null,
	BaseRate money not null,
)

create table AddOn
(
	--David said the two atributes comented out below shouldn't be in there but i dont know what to reaplsve them with
	--AddOnID int identity primary key,
	--AddOnType varchar (10) not null,
	RoomID int foreign key references Room(RoomID),
	RateID int foreign key references Rate(RateID),
)

create table Details
(
	DetailID int identity primary key,
	BillID int foreign key references Bill(BillID),
	Subtotal money not null,
	DetailType int not null,
	--AddOnID int foreign key references AddOn(AddOnID)
)

--SET NOCOUNT ON
--GO

--USE master
--GO
--if exists (select * from sysdatabases where name='Northwind')
--		drop database Northwind
--go

--DECLARE @device_directory NVARCHAR(520)
--SELECT @device_directory = SUBSTRING(filename, 1, CHARINDEX(N'master.mdf', LOWER(filename)) - 1)
--FROM master.dbo.sysaltfiles WHERE dbid = 1 AND fileid = 1

--EXECUTE (N'CREATE DATABASE Northwind
--  ON PRIMARY (NAME = N''Northwind'', FILENAME = N''' + @device_directory + N'northwnd.mdf'')
--  LOG ON (NAME = N''Northwind_log'',  FILENAME = N''' + @device_directory + N'northwnd.ldf'')')
--go

----exec sp_dboption 'Northwind','trunc. log on chkpt.','true'
----exec sp_dboption 'Northwind','select into/bulkcopy','true'
--GO

--set quoted_identifier on
--GO

--/* Set DATEFORMAT so that the date strings are interpreted correctly regardless of
--   the default DATEFORMAT on the server.
--*/
--SET DATEFORMAT mdy
--GO
--use "Northwind"
--go
--if exists (select * from sysobjects where id = object_id('dbo.Employee Sales by Country') and sysstat & 0xf = 4)
--	drop procedure "dbo"."Employee Sales by Country"
--GO
--if exists (select * from sysobjects where id = object_id('dbo.Sales by Year') and sysstat & 0xf = 4)
--	drop procedure "dbo"."Sales by Year"
--GO
--if exists (select * from sysobjects where id = object_id('dbo.Ten Most Expensive Products') and sysstat & 0xf = 4)
--	drop procedure "dbo"."Ten Most Expensive Products"
--GO
--if exists (select * from sysobjects where id = object_id('dbo.Category Sales for 1997') and sysstat & 0xf = 2)
--	drop view "dbo"."Category Sales for 1997"
--GO
--if exists (select * from sysobjects where id = object_id('dbo.Sales by Category') and sysstat & 0xf = 2)
--	drop view "dbo"."Sales by Category"
--GO
--if exists (select * from sysobjects where id = object_id('dbo.Sales Totals by Amount') and sysstat & 0xf = 2)
--	drop view "dbo"."Sales Totals by Amount"
--GO
--if exists (select * from sysobjects where id = object_id('dbo.Summary of Sales by Quarter') and sysstat & 0xf = 2)
--	drop view "dbo"."Summary of Sales by Quarter"
--GO
--if exists (select * from sysobjects where id = object_id('dbo.Summary of Sales by Year') and sysstat & 0xf = 2)
--	drop view "dbo"."Summary of Sales by Year"
--GO
--if exists (select * from sysobjects where id = object_id('dbo.Invoices') and sysstat & 0xf = 2)
--	drop view "dbo"."Invoices"
--GO
--if exists (select * from sysobjects where id = object_id('dbo.Order Details Extended') and sysstat & 0xf = 2)
--	drop view "dbo"."Order Details Extended"
--GO
--if exists (select * from sysobjects where id = object_id('dbo.Order Subtotals') and sysstat & 0xf = 2)
--	drop view "dbo"."Order Subtotals"
--GO
--if exists (select * from sysobjects where id = object_id('dbo.Product Sales for 1997') and sysstat & 0xf = 2)
--	drop view "dbo"."Product Sales for 1997"
--GO
--if exists (select * from sysobjects where id = object_id('dbo.Alphabetical list of products') and sysstat & 0xf = 2)
--	drop view "dbo"."Alphabetical list of products"
--GO
--if exists (select * from sysobjects where id = object_id('dbo.Current Product List') and sysstat & 0xf = 2)
--	drop view "dbo"."Current Product List"
--GO
--if exists (select * from sysobjects where id = object_id('dbo.Orders Qry') and sysstat & 0xf = 2)
--	drop view "dbo"."Orders Qry"
--GO
--if exists (select * from sysobjects where id = object_id('dbo.Products Above Average Price') and sysstat & 0xf = 2)
--	drop view "dbo"."Products Above Average Price"
--GO
--if exists (select * from sysobjects where id = object_id('dbo.Products by Category') and sysstat & 0xf = 2)
--	drop view "dbo"."Products by Category"
--GO
--if exists (select * from sysobjects where id = object_id('dbo.Quarterly Orders') and sysstat & 0xf = 2)
--	drop view "dbo"."Quarterly Orders"
--GO
--if exists (select * from sysobjects where id = object_id('dbo.Customer and Suppliers by City') and sysstat & 0xf = 2)
--	drop view "dbo"."Customer and Suppliers by City"
--GO
--if exists (select * from sysobjects where id = object_id('dbo.Order Details') and sysstat & 0xf = 3)
--	drop table "dbo"."Order Details"
--GO
--if exists (select * from sysobjects where id = object_id('dbo.Orders') and sysstat & 0xf = 3)
--	drop table "dbo"."Orders"
--GO
--if exists (select * from sysobjects where id = object_id('dbo.Products') and sysstat & 0xf = 3)
--	drop table "dbo"."Products"
--GO
--if exists (select * from sysobjects where id = object_id('dbo.Categories') and sysstat & 0xf = 3)
--	drop table "dbo"."Categories"
--GO
--if exists (select * from sysobjects where id = object_id('dbo.Customers') and sysstat & 0xf = 3)
--	drop table "dbo"."Customers"
--GO
--if exists (select * from sysobjects where id = object_id('dbo.Shippers') and sysstat & 0xf = 3)
--	drop table "dbo"."Shippers"
--GO
--if exists (select * from sysobjects where id = object_id('dbo.Suppliers') and sysstat & 0xf = 3)
--	drop table "dbo"."Suppliers"
--GO
--if exists (select * from sysobjects where id = object_id('dbo.Employees') and sysstat & 0xf = 3)
--	drop table "dbo"."Employees"
--GO
--CREATE TABLE "Employees" (
--	"EmployeeID" "int" IDENTITY (1, 1) NOT NULL ,
--	"LastName" nvarchar (20) NOT NULL ,
--	"FirstName" nvarchar (10) NOT NULL ,
--	"Title" nvarchar (30) NULL ,
--	"TitleOfCourtesy" nvarchar (25) NULL ,
--	"BirthDate" "datetime" NULL ,
--	"HireDate" "datetime" NULL ,
--	"Address" nvarchar (60) NULL ,
--	"City" nvarchar (15) NULL ,
--	"Region" nvarchar (15) NULL ,
--	"PostalCode" nvarchar (10) NULL ,
--	"Country" nvarchar (15) NULL ,
--	"HomePhone" nvarchar (24) NULL ,
--	"Extension" nvarchar (4) NULL ,
--	"Photo" "image" NULL ,
--	"Notes" "ntext" NULL ,
--	"ReportsTo" "int" NULL ,
--	"PhotoPath" nvarchar (255) NULL ,
--	CONSTRAINT "PK_Employees" PRIMARY KEY  CLUSTERED 
--	(
--		"EmployeeID"
--	),
--	CONSTRAINT "FK_Employees_Employees" FOREIGN KEY 
--	(
--		"ReportsTo"
--	) REFERENCES "dbo"."Employees" (
--		"EmployeeID"
--	),
--	CONSTRAINT "CK_Birthdate" CHECK (BirthDate < getdate())
--)
--GO
-- CREATE  INDEX "LastName" ON "dbo"."Employees"("LastName")
--GO
-- CREATE  INDEX "PostalCode" ON "dbo"."Employees"("PostalCode")
--GO

--CREATE TABLE "Categories" (
--	"CategoryID" "int" IDENTITY (1, 1) NOT NULL ,
--	"CategoryName" nvarchar (15) NOT NULL ,
--	"Description" "ntext" NULL ,
--	"Picture" "image" NULL ,
--	CONSTRAINT "PK_Categories" PRIMARY KEY  CLUSTERED 
--	(
--		"CategoryID"
--	)
--)
--GO
-- CREATE  INDEX "CategoryName" ON "dbo"."Categories"("CategoryName")
--GO

--CREATE TABLE "Customers" (
--	"CustomerID" nchar (5) NOT NULL ,
--	"CompanyName" nvarchar (40) NOT NULL ,
--	"ContactName" nvarchar (30) NULL ,
--	"ContactTitle" nvarchar (30) NULL ,
--	"Address" nvarchar (60) NULL ,
--	"City" nvarchar (15) NULL ,
--	"Region" nvarchar (15) NULL ,
--	"PostalCode" nvarchar (10) NULL ,
--	"Country" nvarchar (15) NULL ,
--	"Phone" nvarchar (24) NULL ,
--	"Fax" nvarchar (24) NULL ,
--	CONSTRAINT "PK_Customers" PRIMARY KEY  CLUSTERED 
--	(
--		"CustomerID"
--	)
--)
--GO
-- CREATE  INDEX "City" ON "dbo"."Customers"("City")
--GO
-- CREATE  INDEX "CompanyName" ON "dbo"."Customers"("CompanyName")
--GO
-- CREATE  INDEX "PostalCode" ON "dbo"."Customers"("PostalCode")
--GO
-- CREATE  INDEX "Region" ON "dbo"."Customers"("Region")
--GO

--CREATE TABLE "Shippers" (
--	"ShipperID" "int" IDENTITY (1, 1) NOT NULL ,
--	"CompanyName" nvarchar (40) NOT NULL ,
--	"Phone" nvarchar (24) NULL ,
--	CONSTRAINT "PK_Shippers" PRIMARY KEY  CLUSTERED 
--	(
--		"ShipperID"
--	)
--)
--GO
--CREATE TABLE "Suppliers" (
--	"SupplierID" "int" IDENTITY (1, 1) NOT NULL ,
--	"CompanyName" nvarchar (40) NOT NULL ,
--	"ContactName" nvarchar (30) NULL ,
--	"ContactTitle" nvarchar (30) NULL ,
--	"Address" nvarchar (60) NULL ,
--	"City" nvarchar (15) NULL ,
--	"Region" nvarchar (15) NULL ,
--	"PostalCode" nvarchar (10) NULL ,
--	"Country" nvarchar (15) NULL ,
--	"Phone" nvarchar (24) NULL ,
--	"Fax" nvarchar (24) NULL ,
--	"HomePage" "ntext" NULL ,
--	CONSTRAINT "PK_Suppliers" PRIMARY KEY  CLUSTERED 
--	(
--		"SupplierID"
--	)
--)
--GO
-- CREATE  INDEX "CompanyName" ON "dbo"."Suppliers"("CompanyName")
--GO
-- CREATE  INDEX "PostalCode" ON "dbo"."Suppliers"("PostalCode")
--GO

--CREATE TABLE "Orders" (
--	"OrderID" "int" IDENTITY (1, 1) NOT NULL ,
--	"CustomerID" nchar (5) NULL ,
--	"EmployeeID" "int" NULL ,
--	"OrderDate" "datetime" NULL ,
--	"RequiredDate" "datetime" NULL ,
--	"ShippedDate" "datetime" NULL ,
--	"ShipVia" "int" NULL ,
--	"Freight" "money" NULL CONSTRAINT "DF_Orders_Freight" DEFAULT (0),
--	"ShipName" nvarchar (40) NULL ,
--	"ShipAddress" nvarchar (60) NULL ,
--	"ShipCity" nvarchar (15) NULL ,
--	"ShipRegion" nvarchar (15) NULL ,
--	"ShipPostalCode" nvarchar (10) NULL ,
--	"ShipCountry" nvarchar (15) NULL ,
--	CONSTRAINT "PK_Orders" PRIMARY KEY  CLUSTERED 
--	(
--		"OrderID"
--	),
--	CONSTRAINT "FK_Orders_Customers" FOREIGN KEY 
--	(
--		"CustomerID"
--	) REFERENCES "dbo"."Customers" (
--		"CustomerID"
--	),
--	CONSTRAINT "FK_Orders_Employees" FOREIGN KEY 
--	(
--		"EmployeeID"
--	) REFERENCES "dbo"."Employees" (
--		"EmployeeID"
--	),
--	CONSTRAINT "FK_Orders_Shippers" FOREIGN KEY 
--	(
--		"ShipVia"
--	) REFERENCES "dbo"."Shippers" (
--		"ShipperID"
--	)
--)
--GO
-- CREATE  INDEX "CustomerID" ON "dbo"."Orders"("CustomerID")
--GO
-- CREATE  INDEX "CustomersOrders" ON "dbo"."Orders"("CustomerID")
--GO
-- CREATE  INDEX "EmployeeID" ON "dbo"."Orders"("EmployeeID")
--GO
-- CREATE  INDEX "EmployeesOrders" ON "dbo"."Orders"("EmployeeID")
--GO
-- CREATE  INDEX "OrderDate" ON "dbo"."Orders"("OrderDate")
--GO
-- CREATE  INDEX "ShippedDate" ON "dbo"."Orders"("ShippedDate")
--GO
-- CREATE  INDEX "ShippersOrders" ON "dbo"."Orders"("ShipVia")
--GO
-- CREATE  INDEX "ShipPostalCode" ON "dbo"."Orders"("ShipPostalCode")
--GO

--CREATE TABLE "Products" (
--	"ProductID" "int" IDENTITY (1, 1) NOT NULL ,
--	"ProductName" nvarchar (40) NOT NULL ,
--	"SupplierID" "int" NULL ,
--	"CategoryID" "int" NULL ,
--	"QuantityPerUnit" nvarchar (20) NULL ,
--	"UnitPrice" "money" NULL CONSTRAINT "DF_Products_UnitPrice" DEFAULT (0),
--	"UnitsInStock" "smallint" NULL CONSTRAINT "DF_Products_UnitsInStock" DEFAULT (0),
--	"UnitsOnOrder" "smallint" NULL CONSTRAINT "DF_Products_UnitsOnOrder" DEFAULT (0),
--	"ReorderLevel" "smallint" NULL CONSTRAINT "DF_Products_ReorderLevel" DEFAULT (0),
--	"Discontinued" "bit" NOT NULL CONSTRAINT "DF_Products_Discontinued" DEFAULT (0),
--	CONSTRAINT "PK_Products" PRIMARY KEY  CLUSTERED 
--	(
--		"ProductID"
--	),
--	CONSTRAINT "FK_Products_Categories" FOREIGN KEY 
--	(
--		"CategoryID"
--	) REFERENCES "dbo"."Categories" (
--		"CategoryID"
--	),
--	CONSTRAINT "FK_Products_Suppliers" FOREIGN KEY 
--	(
--		"SupplierID"
--	) REFERENCES "dbo"."Suppliers" (
--		"SupplierID"
--	),
--	CONSTRAINT "CK_Products_UnitPrice" CHECK (UnitPrice >= 0),
--	CONSTRAINT "CK_ReorderLevel" CHECK (ReorderLevel >= 0),
--	CONSTRAINT "CK_UnitsInStock" CHECK (UnitsInStock >= 0),
--	CONSTRAINT "CK_UnitsOnOrder" CHECK (UnitsOnOrder >= 0)
--)
--GO
-- CREATE  INDEX "CategoriesProducts" ON "dbo"."Products"("CategoryID")
--GO
-- CREATE  INDEX "CategoryID" ON "dbo"."Products"("CategoryID")
--GO
-- CREATE  INDEX "ProductName" ON "dbo"."Products"("ProductName")
--GO
-- CREATE  INDEX "SupplierID" ON "dbo"."Products"("SupplierID")
--GO
-- CREATE  INDEX "SuppliersProducts" ON "dbo"."Products"("SupplierID")
--GO

--CREATE TABLE "Order Details" (
--	"OrderID" "int" NOT NULL ,
--	"ProductID" "int" NOT NULL ,
--	"UnitPrice" "money" NOT NULL CONSTRAINT "DF_Order_Details_UnitPrice" DEFAULT (0),
--	"Quantity" "smallint" NOT NULL CONSTRAINT "DF_Order_Details_Quantity" DEFAULT (1),
--	"Discount" "real" NOT NULL CONSTRAINT "DF_Order_Details_Discount" DEFAULT (0),
--	CONSTRAINT "PK_Order_Details" PRIMARY KEY  CLUSTERED 
--	(
--		"OrderID",
--		"ProductID"
--	),
--	CONSTRAINT "FK_Order_Details_Orders" FOREIGN KEY 
--	(
--		"OrderID"
--	) REFERENCES "dbo"."Orders" (
--		"OrderID"
--	),
--	CONSTRAINT "FK_Order_Details_Products" FOREIGN KEY 
--	(
--		"ProductID"
--	) REFERENCES "dbo"."Products" (
--		"ProductID"
--	),
--	CONSTRAINT "CK_Discount" CHECK (Discount >= 0 and (Discount <= 1)),
--	CONSTRAINT "CK_Quantity" CHECK (Quantity > 0),
--	CONSTRAINT "CK_UnitPrice" CHECK (UnitPrice >= 0)
--)
--GO
-- CREATE  INDEX "OrderID" ON "dbo"."Order Details"("OrderID")
--GO
-- CREATE  INDEX "OrdersOrder_Details" ON "dbo"."Order Details"("OrderID")
--GO
-- CREATE  INDEX "ProductID" ON "dbo"."Order Details"("ProductID")
--GO
-- CREATE  INDEX "ProductsOrder_Details" ON "dbo"."Order Details"("ProductID")
--GO

