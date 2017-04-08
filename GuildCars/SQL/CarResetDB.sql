
if exists(select * from INFORMATION_SCHEMA.ROUTINEs
	where ROUTINE_NAME = 'CarReset')
		drop procedure CarReset
go

use GuildCars
go

create procedure CarReset as 
begin
	delete from Vehicle;
	delete from Customer;
	delete from SalesPerson;
	delete from PurchaseLog;

	--dbcc checkident ('PurchaseLog', reseed, 1)

	set identity_insert Vehicle on;
	
	insert into Vehicle (VehicleId, Make, Model, [Year])
	values (1, 'VW', 'Cabriolet', '1988'),
	(2, 'Chrysler','LeBaron','1993');

	set identity_insert Vehicle off;

	set identity_insert Customer on;
	
	insert into Customer (CustomerId, FirstName, LastName)
	values (1, 'Marshawn', 'JerMichael'),
	(2, 'Larry','David');

	set identity_insert Customer off;

	set identity_insert SalesPerson on;

	insert into SalesPerson (EmployeeId, FirstName, LastName)
	values (1, 'Joby', 'Dowd'),
	(2, 'Tom', 'Cruise');

	set identity_insert SalesPerson off;

end