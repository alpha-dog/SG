use GuildCars
go

--special vehicles(in jumbotron), featured vehicles (below jumbotron), vehicles (new/used),
--purchaseLog, customer, salesperson, 
  
if exists(select * from sys.tables where name='Vehicle')
drop table Vehicle
go

create table Vehicle
(
	
)

if exists(select * from sys.tables where name='Customer')
drop table Customer
go

create table Customer
(
	
)

if exists(select * from sys.tables where name='SalesPerson')
drop table SalesPerson
go


create table SalesPerson
(
	
)

if exists(select * from sys.tables where name='Special')
drop table Special
go


create table Special
(
	
)

if exists(select * from sys.tables where name='Featured')
drop table Featured 
go


create table Featured
(
	
)

if exists(select * from sys.tables where name='PurchaseLog')
drop table PurchaseLog 
go


create table PurchaseLog
(
	
)