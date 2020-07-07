USE [BookStoreDB]
GO
/****** Object:  StoredProcedure [dbo].[UpdateBookPrice]    Script Date: 07-07-2020 22:09:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[UpdateBookPrice]
@BookId int,
@Price int
AS
BEGIN
	update Books
	set Price =@Price where Id=@BookId
	select * from Books
END
