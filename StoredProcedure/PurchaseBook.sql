USE [BookStoreDB]
GO
/****** Object:  StoredProcedure [dbo].[PurchaseBook]    Script Date: 07-07-2020 22:09:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[PurchaseBook]
@CartId int,
@Address varchar(50),
@CreatedDate datetime,
@ModifiedDate datetime
AS
BEGIN
	insert into Purchase_Book(UserId, BookId, CartId, Address, Price, CreatedDate, ModifiedDate)
	select Users.Id, Books.Id, Cart.Id, @Address, Books.Price, @CreatedDate, @ModifiedDate
	from Users
	join Cart on Users.Id=Cart.UserId
	join Books on Cart.BookId=Books.Id
	select * from Purchase_Book
END
