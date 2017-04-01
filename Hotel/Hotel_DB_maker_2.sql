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
	PromoExp datetime2 not null,
	PromoStart datetime2 not null
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
	--DetailID int foreign key references Details(DetailID), 
	Taxes money not null,
	Total money not null
)

create table Rate
(
	RateID int identity primary key,
	StartDate datetime2 not null,
	EndDate datetime2 not null,
	Rate money not null
)

create table RoomType
(
	RoomTypeID int identity primary key,
	RateID int foreign key references Rate(RateID),
	[Description] varchar(10) not null
)

create table Room
(
	RoomID int identity primary key,
	RoomTypeID int foreign key references RoomType(RoomTypeID),
	RoomNum varchar(10) not null,
	[Floor] int not null,
	Occupants int not null,
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
	[Description] varchar(10) not null,
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

create table AddOn
(
	AddOnID int identity primary key,
	RoomID int foreign key references Room(RoomID),
	Rate money not null,
	[Description] varchar(30) not null,
	Startdate datetime2 not null,
	enddate datetime2 not null
)

create table Details
(
	DetailID int identity primary key,
	BillID int foreign key references Bill(BillID),
	RoomID int foreign key references Room(RoomID),
	Subtotal money not null,
	AddOnID int foreign key references AddOn(AddOnID)
)
