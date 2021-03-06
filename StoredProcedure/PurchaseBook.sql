USE [BookStoreDB]
GO
/****** Object:  StoredProcedure [dbo].[PurchaseBook]    Script Date: 04-08-2020 18:57:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[PurchaseBook]
@UserId int,
@CartId int,
@BookId int,
@IsUsed bit,
@Address varchar(50),
@CreatedDate datetime,
@ModifiedDate datetime
AS
BEGIN
	begin try
		begin transaction
			if exists (select * from Cart where Id=@CartId and IsUsed='false')
			begin
				insert into Purchase_Book(UserId, BookId, CartId, Address, Price, CreatedDate, ModifiedDate)
				select Users.Id, Books.Id, Cart.Id, @Address, Books.Price, @CreatedDate, @ModifiedDate
				from Users
				join Cart on Users.Id=@UserId and Cart.UserId=@UserId
				join Books on Cart.BookId=@BookId and Books.Id=Cart.BookId
				update Cart 
				set IsUsed='true'
				commit transaction
				select * from Purchase_Book where UserId =@UserId and BookId=@BookId
			end 
			else
				raiserror('Cart id not present or already use', 16,1);
	end try
	begin catch
		if @@TRANCOUNT > 0
		rollback transaction
		raiserror('Cart id not present or already use', 16,1);
	end catch
END