USE [BookStoreDB]
GO
/****** Object:  StoredProcedure [dbo].[GetAllBooks]    Script Date: 06-07-2020 16:44:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[GetAllBooks]
AS
BEGIN
	select * from Books
END
