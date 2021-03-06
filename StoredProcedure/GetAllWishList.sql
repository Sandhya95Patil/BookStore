USE [BookStoreDB]
GO
/****** Object:  StoredProcedure [dbo].[GetAllWishList]    Script Date: 04-08-2020 18:56:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[GetAllWishList]
@UserId int 
AS
BEGIN
	begin try
		if exists (select * from WishList where UserId=@UserId)
		begin
			select * from WishList where UserId=@UserId
		end
		else
			raiserror('User Id Not Present', 16,1);
	end try
	begin catch
		raiserror('User Id Not Present', 16,1);
	end catch
END