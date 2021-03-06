USE [BookStoreDB]
GO
/****** Object:  StoredProcedure [dbo].[DeleteCart]    Script Date: 04-08-2020 18:54:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[DeleteCart]
@UserId int,
@CartId int
AS
BEGIN
	begin try
		if exists (select * from Cart where UserId=@UserId and Id=@CartId)
		begin
			delete from Cart where UserId = @UserId and Id = @CartId
		end
	else
			raiserror('User Id Not Present', 16,1);
	end try
	begin catch
		raiserror('User Id Not Present', 16,1);
	end catch
END
