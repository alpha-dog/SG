use GuildCars
go

if exists(select * from INFORMATION_SCHEMA.ROUTINEs
	where ROUTINE_NAME = 'CarResetDB')
		drop procedure CarResetDB
go

create procedure CarResetDB as 
begin
	delete from Vehicle;
	delete from SalesInfo;
	delete from SalesPerson;
	delete from PurchaseLog;
	delete from Color;
	delete from BodyStyle;
	delete from [State];
	delete from Transmission;
	delete from [Type];
	delete from PurchaseType;
	


	dbcc checkident ('SalesInfo', reseed, 1)

	set identity_insert [Type] on;

		insert into [Type] (TypeId, NewOrUsed)
		values (1, 'New'), (2, 'Used')

	set identity_insert [Type] off;

	set identity_insert BodyStyle on;

		insert into BodyStyle (BodyStyleId, BodyStyle)
		values (1, 'Convertible'), (2, 'Coupe'), (3, 'Hatchback')

	set identity_insert BodyStyle off;
	
	set identity_insert Transmission on;

		insert into Transmission (TransmissionId, TransmissionType)
		values (1, 'Auto'), (2, 'Manual')

	set identity_insert Transmission off;

	set identity_insert Color on;

	insert into Color (ColorId, Color)
	values (1, 'White'), (2, 'Black'), (3, 'Red')

	set identity_insert Color off;

		insert into [State] (StateId, StateName)
		values ('MN', 'Minnesota'), ('FL', 'Florida')

	set identity_insert PurchaseType on;

		insert into PurchaseType (PurchaseTypeId, PurchaseType)
		values (1, 'Cash'), (2, 'Credit')

	set identity_insert PurchaseType off;

	set identity_insert Make on;

		insert into Make (MakeId, MakeName)
		values (1, 'VW'), (2, 'Ford'), (3, 'Geo')

	set identity_insert Make off;

	set identity_insert Vehicle on;
	
		insert into Vehicle (VehicleId, MakeId, Model, TypeId, BodyStyleId, [Year], TransmissionId, ColorId, InteriorId, Mileage, VIN, MSRP, SalePrice, [Description], PictureFilePath)
		values (1, 1, 'Cabriolet', 2, 1, '1988', 2, 3, 3, 3333, 1, 5000, 3500, 'super cute', 'cabbiePic.jpg')
	

	set identity_insert Vehicle off;

	set identity_insert SalesInfo on;
	
		insert into SalesInfo (SalesInfoId, FirstName, LastName, Phone, Email, Street1, Street2, City, [State], Zip, PurchasePrice, PurchaseTypeId)
		values (1, 'Marshawn', 'JerMichael', '612-555-5555', 'marchMan@test.com', null, null, null, null, null, 3000, 1)

	set identity_insert SalesInfo off;

	set identity_insert SalesPerson on;

		insert into SalesPerson (EmployeeId, FirstName, LastName)
		values (1, 'Joby', 'Dowd')


	set identity_insert SalesPerson off;
end