USE [BookStoreDB]
GO
/****** Object:  StoredProcedure [dbo].[SearchBookByTitle]    Script Date: 06-07-2020 16:44:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SearchBookByTitle]
@SearchTitle varchar(50)
AS
BEGIN
	select * from Books where Book_Title like '%' +@SearchTitle+ '%'
END
