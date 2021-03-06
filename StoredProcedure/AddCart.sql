USE [BookStoreDB]
GO
/****** Object:  StoredProcedure [dbo].[AddCart]    Script Date: 04-08-2020 18:53:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[AddCart]
@UserId int,
@BookId int,
@IsUsed bit,
@CreatedDate datetime,
@ModifiedDate datetime
AS
BEGIN
	begin try
		begin transaction 
			if exists (select Id from Users where Id=@UserId)
			begin
				if exists (select Id from Books where Id=@BookId)
				begin
					insert into Cart values(@UserId, @BookId, @IsUsed, @CreatedDate, @ModifiedDate)
					commit transaction 
					select * from Cart where UserId = @UserId
				end
				else
					raiserror('Book id not present', 16,1);  
			end
			else
				raiserror('User id not present', 16,1);  
	end try
	begin catch
		if @@TRANCOUNT > 0
		rollback transaction 
		raiserror('User id or Book id not present', 16,1);  
	end catch
END