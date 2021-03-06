USE [BookStoreDB]
GO
/****** Object:  StoredProcedure [dbo].[DeleteBook]    Script Date: 04-08-2020 18:54:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[DeleteBook]
@BookId int
AS
BEGIN
	begin try
		if exists (select * from Books where Id=@BookId)
		begin
			delete from Books where Id=@BookId
		end
		else
			raiserror('Book Id Not Present', 16,1);
	end try
	begin catch
		raiserror('Book Id Not Present', 16,1);
	end catch
END
