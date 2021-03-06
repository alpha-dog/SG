USE [GuildCars]
GO
/****** Object:  StoredProcedure [dbo].[SalesInfoAdd]    Script Date: 4/10/2017 8:31:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER proc [dbo].[SalesInfoAdd]
(
	@SalesInfoId int, 
	@FirstName nvarchar(20), 
	@LastName nvarchar(20),
	@Phone varchar(20),
	@Email nvarchar(40),
	@Street1 nvarchar(40),
	@Street2 nvarchar(40),
	@City nvarchar(40),
	@State varchar(2),
	@Zip varchar(5),
	@PurchasePrice money,
	@PurchaseTypeId int
) as 
begin
	insert into SalesInfo (FirstName, LastName, Phone, Email, Street1, Street2, City, [State], Zip, PurchasePrice, PurchaseTypeId)
	values (@FirstName, @LastName, @Phone, @Email, @Street1, @Street2, @City, @State, @Zip, @PurchasePrice, @PurchaseTypeId)
	set @SalesInfoId = SCOPE_IDENTITY();
end

