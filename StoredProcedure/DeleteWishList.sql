USE [BookStoreDB]
GO
/****** Object:  StoredProcedure [dbo].[DeleteWishList]    Script Date: 07-07-2020 22:11:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[DeleteWishList]
@WishListId int
AS
BEGIN
declare @returnValue int
		if exists (select * from WishList where Id = @WishListId)
		begin
			set @returnValue=0
			begin transaction
				delete from WishList where Id=@WishListId
			commit transaction 
				print 'Wish list deleted successfully'
		end
		else
		begin
			begin transaction
				set @returnValue=1
				print 'Id not present'
			rollback transaction
		end
END