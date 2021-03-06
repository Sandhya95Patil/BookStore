USE [BookStoreDB]
GO
/****** Object:  StoredProcedure [dbo].[AddBook]    Script Date: 04-08-2020 18:52:33 ******/
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
	begin try
		begin transaction
			if not exists (select * from Books where ISBN_No = @ISBN_No)
			begin
				insert into Books (Book_Title, Author, Language, Category, ISBN_No, Price, Pages, CreatedDate, ModifiedDate)
				values(@Book_Title, @Author, @Language, @Category, @ISBN_No, @Price, @Pages, @CreatedDate, @ModifiedDate)
				select * from Books where ISBN_No=@ISBN_No
				commit transaction
				print 'Book Added Successfully'
			end
			else
				raiserror('Cant add book with same ISBN no', 16,1);
	end try
	begin catch
		if @@TRANCOUNT > 0
		rollback transaction
			raiserror('Cant add book with same ISBN no', 16,1);	
	end catch
END