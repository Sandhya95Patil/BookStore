USE [BookStoreDB]
GO
/****** Object:  StoredProcedure [dbo].[GetAllBooks]    Script Date: 04-08-2020 18:55:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[GetAllBooks]
AS
BEGIN
	begin try
		select * from Books
	end try
	begin catch
		raiserror('Books Not Available', 16,1);
	end catch
END
