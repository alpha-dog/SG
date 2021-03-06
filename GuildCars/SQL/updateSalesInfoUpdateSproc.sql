USE [GuildCars]
GO
/****** Object:  StoredProcedure [dbo].[SalesInfoUpdate]    Script Date: 4/10/2017 8:18:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[SalesInfoUpdate] (
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
) As
BEGIN
	UPDATE SalesInfo SET 
		FirstName = @FirstName,
		LastName = @LastName,
		Phone = @Phone,
		Email = @Email,
		Street1 = @Street1,
		Street2 = @Street2,
		City = @City,
		State = @State,
		Zip = @Zip,
		PurchasePrice = @PurchasePrice,
		PurchaseTypeId = @PurchaseTypeId
	WHERE SalesInfoId = @SalesInfoId
END
