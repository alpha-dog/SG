use ShackUp
go

if exists(select * from INFORMATION_SCHEMA.ROUTINEs
	where ROUTINE_NAME = 'StatesSelectAll')
		drop procedure StatesSelectAll
go

create procedure StatesSelectAll as
begin
	select StateId, StateName
	from States
end

go

if exists(select * from INFORMATION_SCHEMA.ROUTINEs
	where ROUTINE_NAME = 'BathroomTypesSelectAll')
		drop procedure BathroomTypesSelectAll
go

create procedure BathroomTypesSelectAll as
begin
	select BathroomTypeId, BathroomTypeName 
	from BathroomTypes
	order by BathroomTypeName
end

go

if exists(select * from INFORMATION_SCHEMA.ROUTINEs
	where ROUTINE_NAME = 'ListingsInsert')
		drop procedure ListingsInsert
go

create procedure ListingsInsert 
(
	@ListingId int output,
	@UserId nvarchar(128),
	@StateId char(2),
	@BathroomTypeId int,
	@Nickname nvarchar(50),
	@City nvarchar(50),
	@Rate decimal(7, 2),
	@SquareFootage decimal(7,2),
	@HasElectric bit,
	@HasHeat bit,
	@ListingDescription varchar(500),
	@ImageFileName varchar(50)
)as

begin
	insert into Listings(UserId, StateId, BathroomTypeId, Nickname, City, Rate, SquareFootage, HasElectric, HasHeat, ListingDescription, ImageFileName)
	values (@UserId, @StateId, @BathroomTypeId, @Nickname, @City, @Rate, @SquareFootage, @HasElectric, @HasHeat, @ListingDescription, @ImageFileName)

	set @ListingId = SCOPE_IDENTITY();
end
go

if exists(select * from INFORMATION_SCHEMA.ROUTINEs
	where ROUTINE_NAME = 'ListingsUpdate')
		drop procedure ListingsUpdate
go

create procedure ListingsUpdate 
(
	@ListingId int,
	@UserId nvarchar(128),
	@StateId char(2),
	@BathroomTypeId int,
	@Nickname nvarchar(50),
	@City nvarchar(50),
	@Rate decimal(7, 2),
	@SquareFootage decimal(7,2),
	@HasElectric bit,
	@HasHeat bit,
	@ListingDescription varchar(500),
	@ImageFileName varchar(50)
)as

begin
	update Listings set 
		UserId = @UserId,
		StateId = @StateId,
		BathroomTypeId = @BathroomTypeId,
		Nickname = @Nickname,
		City = @City,
		Rate = @Rate, 
		SquareFootage = @SquareFootage, 
		HasElectric = @HasElectric, 
		HasHeat = @HasHeat, 
		ListingDescription = @ListingDescription,
		ImageFileName = @ImageFileName
	where ListingId = @ListingId
end
go

if exists(select * from INFORMATION_SCHEMA.ROUTINEs
	where ROUTINE_NAME = 'ListingsDelete')
		drop procedure ListingsDelete
go

create procedure ListingsDelete 
(
	@ListingId int
)as
begin
	begin transaction

	delete from Contacts Where ListingId = @ListingId;
	delete from Favorites Where ListingId = @ListingId;
	delete from Listings Where ListingId = @ListingId;

	commit transaction
end
go

if exists(select * from INFORMATION_SCHEMA.ROUTINEs
	where ROUTINE_NAME = 'ListingsSelect')
		drop procedure ListingsSelect
go

create procedure ListingsSelect 
(
	@ListingId int
)as
begin
	select ListingId, UserId, StateId, BathroomTypeId, Nickname, City, Rate, SquareFootage, HasElectric, HasHeat, ListingDescription, ImageFileName
	from Listings
	where ListingId = @ListingId
end
go

if exists(select * from INFORMATION_SCHEMA.ROUTINEs
	where ROUTINE_NAME = 'ListingsSelectRecent')
		drop procedure ListingsSelectRecent
go

create procedure ListingsSelectRecent as 
begin
	select top 5 ListingId, UserId, StateId, City, Rate, ImageFileName
	from Listings
	order by CreatedDate desc
end
go

if exists(select * from INFORMATION_SCHEMA.ROUTINEs
	where ROUTINE_NAME = 'ListingsSelectDetails')
		drop procedure ListingsSelectDetails
go

create procedure ListingsSelectDetails 
(
	@ListingId int
)
as 
begin
	select ListingId, UserId, Nickname, City, StateId, Rate, SquareFootage, HasElectric, HasHeat, l.BathroomTypeId, BathroomTypeName, ImageFileName, l.ListingDescription
	from Listings l
	inner join BathroomTypes b on l.BathroomTypeId = b.BathroomTypeId
	where @ListingId = @ListingId
end
go

if exists(select * from INFORMATION_SCHEMA.ROUTINEs
	where ROUTINE_NAME = 'ListingsSelectFavorites')
		drop procedure ListingsSelectFavorites
go

create procedure ListingsSelectFavorites 
(
	@UserId nvarchar(128)
) as
begin
	select l.ListingId, l.City, l.StateId, l.Rate, l.SquareFootage, l.UserId, l.HasElectric, l.HasHeat, l.BathroomTypeId, b.BathroomTypeName
	from Favorites f
		inner join Listings l on f.ListingId = l.ListingId
		inner join BathroomTypes b on l.BathroomTypeId = b.BathroomTypeId
	where f.UserId = @UserId;
end
go

if exists(select * from INFORMATION_SCHEMA.ROUTINEs
	where ROUTINE_NAME = 'ListingsSelectContacts')
		drop procedure ListingsSelectContacts
go

create procedure ListingsSelectContacts 
(
	@UserId nvarchar(128)
) as
begin
	select l.listingId, u.Email, u.Id as UserId, l.Nickname, l.City, l.StateId, l.Rate
	from Listings l
		inner join Contacts c on l.ListingId = c.ListingId
		inner join AspNetUsers u on c.UserId = u.Id
	where l.UserId = @UserId;
end
go

if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'ListingsSelectByUser')
		drop procedure ListingsSelectByUser
go

create procedure ListingsSelectByUser
(
	@UserId nvarchar(128)
) AS
BEGIN
select ListingId, UserId, Nickname, City, StateId, Rate, SquareFootage, HasElectric, HasHeat, l.BathroomTypeId, BathroomTypeName, ImageFileName
	from Listings l
	inner join BathroomTypes b on l.BathroomTypeId = b.BathroomTypeId
	where UserId = @UserId
END
go

if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'FavoritesInsert')
		drop procedure FavoritesInsert
go

create procedure FavoritesInsert
(
	@UserId nvarchar(128),
	@ListingId int
) AS
BEGIN
	insert into Favorites(UserId, ListingId)
	values (@UserId, @ListingId)
END
go

if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'FavoritesDelete')
		drop procedure FavoritesDelete
go

create procedure FavoritesDelete
(
	@UserId nvarchar(128),
	@ListingId int
) AS
BEGIN
	delete from Favorites
	where UserId = @UserId and ListingId = @ListingId
END
go

if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'ContactsInsert')
		drop procedure ContactsInsert
go

create procedure ContactsInsert
(
	@UserId nvarchar(128),
	@ListingId int
) AS
BEGIN
	insert into Contacts(UserId, ListingId)
	values (@UserId, @ListingId)
END
go

if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'ContactsDelete')
		drop procedure ContactsDelete
go

create procedure ContactsDelete
(
	@UserId nvarchar(128),
	@ListingId int
) AS
BEGIN
	delete from Contacts
	where UserId = @UserId and ListingId = @ListingId
END
go

if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'ContactsSelect')
		drop procedure ContactsSelect
go

create procedure ContactsSelect
(
	@UserId nvarchar(128),
	@ListingId int
) AS
BEGIN
	select UserId, ListingId
	from Contacts
	where UserId = @UserId and ListingId = @ListingId
END
go

if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'FavoritesSelect')
		drop procedure FavoritesSelect
go

create procedure FavoritesSelect
(
	@UserId nvarchar(128),
	@ListingId int
) AS
BEGIN
	select UserId, ListingId
	from Favorites
	where UserId = @UserId and ListingId = @ListingId
END
go