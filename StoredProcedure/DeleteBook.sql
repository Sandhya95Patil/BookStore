USE [BookStoreDB]
GO
/****** Object:  StoredProcedure [dbo].[DeleteBook]    Script Date: 07-07-2020 22:12:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[DeleteBook]
@BookId int
AS
BEGIN
	delete from Books where Id=@BookId
END
