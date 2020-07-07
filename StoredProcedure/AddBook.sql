USE [BookStoreDB]
GO
/****** Object:  StoredProcedure [dbo].[AddBook]    Script Date: 07-07-2020 22:15:40 ******/
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
	declare @Exist int
	if not exists (select * from Books where ISBN_No = @ISBN_No)
	begin
		begin transaction
			set @Exist=0
			insert into Books (Book_Title, Author, Language, Category, ISBN_No, Price, Pages, CreatedDate, ModifiedDate)
			values(@Book_Title, @Author, @Language, @Category, @ISBN_No, @Price, @Pages, @CreatedDate, @ModifiedDate)
			select * from Books
		commit transaction
	print 'Book Added Successfully'
	end
	else
	begin
		begin transaction 
			set @Exist = 1
		rollback transaction
		print 'Book Not Added With Same ISBN No'
	end
return @Exist
END