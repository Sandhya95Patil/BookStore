USE [BookStoreDB]
GO
/****** Object:  StoredProcedure [dbo].[DeleteWishList]    Script Date: 04-08-2020 18:55:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[DeleteWishList]
@UserId int,
@WishListId int
AS
BEGIN
	begin try
		if exists (select * from WishList where UserId = @UserId and Id = @WishListId)
		begin
			begin transaction
			delete from WishList where Id=@WishListId
			print 'Wish list deleted successfully'
		end
		else
		raiserror('User Id & WishList Id Not Present', 16,1);
	end try
	begin catch
		raiserror('User Id & WishList Id Not Present', 16,1);
	end catch 
END