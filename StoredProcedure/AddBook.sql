USE [BookStoreDB]
GO
/****** Object:  StoredProcedure [dbo].[AddBook]    Script Date: 06-07-2020 16:41:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[AddBook]
@Book_Title varchar(50),
@Author varchar(50),
@Language varchar(50),
@Category varchar(50),
@ISBN_No int,
@Price int,
@Pages int,
@CreatedDate datetime,
@ModifiedDate datetime
AS
BEGIN
	insert into Books (Book_Title, Author, Language, Category, ISBN_No, Price, Pages, CreatedDate, ModifiedDate)
	values(@Book_Title, @Author, @Language, @Category, @ISBN_No, @Price, @Pages, @CreatedDate, @ModifiedDate)
	select * from Books
	print 'Book Added Successfully'
END
