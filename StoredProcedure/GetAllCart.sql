USE [BookStoreDB]
GO
/****** Object:  StoredProcedure [dbo].[GetAllCart]    Script Date: 04-08-2020 18:55:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[GetAllCart]
@UserId int
AS
BEGIN
	begin try
		if exists (select * from Cart where UserId=@UserId)
		begin
			select * from Cart where UserId=@UserId
		end
	else
		raiserror('User Id Not Present', 16,1);
	end try
	begin catch
		raiserror('User Id Not Present', 16,1);
	end catch
END