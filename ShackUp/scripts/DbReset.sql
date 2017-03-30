if exists(select * from INFORMATION_SCHEMA.ROUTINEs
	where ROUTINE_NAME = 'DbReset')
		drop procedure DbReset
go

create procedure DbReset as
begin
	delete from Favorites;
	delete from Contacts;
	delete from Listings;
	delete from States;
	delete from BathroomTypes;
	delete from AspNetUsers where id in ('00000000-0000-0000-0000-000000000000' , '11111111-1111-1111-1111-111111111111');

	dbcc checkident ('listings', reseed, 1)

	insert into States (StateId, StateName)
	values ('OH', 'Ohio'),
	('KY', 'Kentucky'),
	('MN', 'Minnesota');

	set identity_insert BathroomTypes on;

	insert into BathroomTypes (BathroomTypeId, BathroomTypeName)
	values (1, 'Indoor'),
	(2, 'Outdoor'),
	(3, 'None')

	set identity_insert BathroomTypes off;

	insert into AspNetUsers(Id, EmailConfirmed, PhoneNumberConfirmed, Email, StateId, TwoFactorEnabled, LockoutEnabled, AccessFailedCount, UserName)
	values('00000000-0000-0000-0000-000000000000', 0, 0, 'test@test.com', 'OH', 0, 0, 0, 'test');
	
	insert into AspNetUsers(Id, EmailConfirmed, PhoneNumberConfirmed, Email, StateId, TwoFactorEnabled, LockoutEnabled, AccessFailedCount, UserName)
	values('11111111-1111-1111-1111-111111111111', 0, 0, 'test2@test.com', 'OH', 0, 0, 0, 'test2');

	set identity_insert Listings on;

	insert into Listings(ListingId, UserId, StateId, BathroomTypeId, Nickname, City, Rate, SquareFootage, HasElectric, HasHeat, ImageFileName, ListingDescription)
	values (1, '00000000-0000-0000-0000-000000000000', 'OH', 3, 'Test shack 1', 'Cleveland', 120, 400, 0, 1, 'placeholder.png', 'Description'),
	(2, '00000000-0000-0000-0000-000000000000', 'OH', 3, 'Test shack 2', 'Cleveland', 130, 401, 0, 1, 'placeholder.png', null),
	(3, '00000000-0000-0000-0000-000000000000', 'OH', 3, 'Test shack 3', 'Cleveland', 140, 402, 0, 1, 'placeholder.png', null),
	(4, '00000000-0000-0000-0000-000000000000', 'OH', 3, 'Test shack 4', 'Cleveland', 150, 403, 0, 1, 'placeholder.png', 'Here is a shack description example'),
	(5, '00000000-0000-0000-0000-000000000000', 'OH', 3, 'Test shack 5', 'Cleveland', 160, 404, 0, 1, 'placeholder.png', null),
	(6, '00000000-0000-0000-0000-000000000000', 'OH', 3, 'Test shack 6', 'Cleveland', 170, 405, 0, 1, 'placeholder.png', null);

	set identity_insert Listings off;

	insert  into Favorites(ListingId, UserId)
	values (1, '11111111-1111-1111-1111-111111111111'),
	(2, '11111111-1111-1111-1111-111111111111')

	insert  into Contacts(ListingId, UserId)
	values (1, '11111111-1111-1111-1111-111111111111'),
	(3, '11111111-1111-1111-1111-111111111111')
end
