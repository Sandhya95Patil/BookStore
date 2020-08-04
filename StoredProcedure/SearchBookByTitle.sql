USE [BookStoreDB]
GO
/****** Object:  StoredProcedure [dbo].[SearchBookByTitle]    Script Date: 04-08-2020 18:57:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SearchBookByTitle]
@SearchTitle varchar(50)
AS
BEGIN
	begin try
		select * from Books where Book_Title like '%' +@SearchTitle+ '%'
	end try
	begin catch
		raiserror('Books Not Available', 16,1)
	end catch
END
