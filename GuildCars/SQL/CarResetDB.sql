use GuildCars
go

if exists(select * from INFORMATION_SCHEMA.ROUTINEs
	where ROUTINE_NAME = 'CarResetDB')
		drop procedure CarResetDB
go

create procedure CarResetDB as 
begin
	delete from Vehicle;
	delete from Make;
	delete from Model; 
	delete from Color;
	delete from BodyStyle;
	delete from Transmission;
	delete from [Type];
	delete from Specials;
	

	dbcc checkident ('Vehicle', reseed, 1)

	set identity_insert Specials on;
		insert into Specials (SpecialId, SpecialName ,SpecialDetails)
		values (1, 'Free Oil Changes', 'Electric vehicles only'),
		(2, 'Test Special 2', 'blah blah blah blah blah blah blah blah blah blah'),
		(3, 'Another Special', 'Free bus pass with purchase of geo prizm')

	set identity_insert Specials off;
	
	set identity_insert [Type] on;

		insert into [Type] (TypeId, NewOrUsed)
		values (1, 'New'), (2, 'Used')

	set identity_insert [Type] off;

	set identity_insert BodyStyle on;

		insert into BodyStyle (BodyStyleId, BodyStyle)
		values (1, 'Convertible'), (2, 'Coupe'), (3, 'Economy'),(4, 'SUV'),(5, 'Truck')

	set identity_insert BodyStyle off;
	
	set identity_insert Transmission on;

		insert into Transmission (TransmissionId, TransmissionType)
		values (1, 'Auto'), (2, 'Manual')

	set identity_insert Transmission off;

	set identity_insert Color on;

	insert into Color (ColorId, Color)
	values (1, 'White'), (2, 'Black'), (3, 'Red'),(4, 'Multi-Tone'),(5, 'Other')

	set identity_insert Color off;

	set identity_insert Make on;

		insert into Make (MakeId, Make)
		values (1, 'VW'), (2, 'Ford'), (3, 'Geo'),(4, 'GMC')

	set identity_insert Make off;

	set identity_insert Model on;

		insert into Model (ModelId, ModelName, MakeId)
		values (1, 'Cabriolet', 1), (2, 'Thing', 1), (3, 'F-150', 2),(4,'Typhoon', 4), (5, 'Prizm', 3)

	set identity_insert Model off;

	set identity_insert Vehicle on;
	
		insert into Vehicle (VehicleId, MakeId, ModelId, TypeId, BodyStyleId, [Year], TransmissionId, ColorId, InteriorId, Mileage, VIN, MSRP, SalePrice, [Description], PictureFilePath, IsFeature)
		values (1, 1, 1, 2, 1, '1988', 2, 3, 2, 3333, 987654321, 5000, 3500, 'super cute', 'SmallerCabbyPic.jpg', 1),
			(2,1,2,2,1,'1976',2,4,4,5500,123456789,8000,7500,'a hideous classic sure to turn heads', 'SmallerThing.jpg', 1),
			(3,2,3,1,5,'1995',1,2,2,0,123123123,12000,11800,'a classic that has never left the showroom floor. 4x4 is great for winter driving.','SmallerF150pic.jpg',0),
			(4,4,4,2,4,'1996',1,2,4,30000,111222333444,8000,6500,'this thing is fast but dont make any sharp turns, it will roll','SmallerTyphoon.jpg',1),
			(5,3,5,2,3,'1996',2,2,2,150000,998877665544,2500,800,'great option for low-income people','prizmPic2.jpg',1),
			(6,1,2,2,1,'1974',2,4,4,500,223456789,10000,9500,'a hideous classic sure to turn heads', 'SmallerThing.jpg', 1)
	

	set identity_insert Vehicle off;

	exec CarResetDB
	
end