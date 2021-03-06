USE [BookStoreDB]
GO
/****** Object:  StoredProcedure [dbo].[UpdateBookPrice]    Script Date: 04-08-2020 18:58:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[UpdateBookPrice]
@BookId int,
@Price int
AS
BEGIN
	begin try
		begin transaction
			if exists (select * from Users where UserRole='admin' or UserRole='Admin')
			begin
				if exists (select * from Books where Id=@BookId)
				begin
					update Books
					set Price =@Price where Id=@BookId
					commit transaction
					select * from Books where Id=@BookId
				end
				else
				raiserror('Book Id Not Present', 16,1);
			end
			else
			raiserror('Only Admin Update Book', 16,1);
	end try
	begin catch
		if @@TRANCOUNT > 0
		rollback transaction
		raiserror('Only Admin Update Book or Book id Not Found', 16,1);
	end catch
END