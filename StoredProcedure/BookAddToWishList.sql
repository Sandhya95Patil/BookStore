USE [BookStoreDB]
GO
/****** Object:  StoredProcedure [dbo].[BookAddToWishList]    Script Date: 04-08-2020 18:54:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[BookAddToWishList]
@UserId int,
@BookId int,
@IsUsed bit,
@CreatedDate datetime,
@ModifiedDate datetime
AS
BEGIN
	begin try
	begin transaction
		if exists (select * from Users where Id=@UserId)
			begin
				if exists (select * from Books where Id = @BookId)
				begin
					insert into WishList values(@UserId, @BookId, @IsUsed, @CreatedDate, @ModifiedDate)
					commit transaction
					select * from WishList where UserId=@UserId
					print 'Book added to wish list successfully'
				end
			else
				raiserror('Book Id Not Present To Add To WishList', 16,1);
			end
		else
			raiserror('Book Id Not Present To Add To WishList', 16,1);
	end try
	begin catch
		if @@TRANCOUNT > 0
		rollback transaction
		raiserror('Book Id or User Id Not Present To Add To WishList', 16,1);
	end catch
END
