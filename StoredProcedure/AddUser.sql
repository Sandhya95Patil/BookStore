USE [BookStoreDB]
GO
/****** Object:  StoredProcedure [dbo].[AddUser]    Script Date: 06-07-2020 16:19:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[AddUser]
(
@FirstName varchar(50),
@LastName varchar(50),
@Email varchar(50),
@Password varchar(50),
@IsActive bit,
@UserRole varchar(50),
@CreatedDate datetime,
@ModifiedDate datetime
)
AS
BEGIN
	declare @Exist int 
		if exists (select Email from Users where Email=@Email)
		begin
			begin transaction
				set @Exist=1
			rollback transaction
				print 'Email id already present'
		end
		else
			begin
				begin transaction
					set @Exist=0
					insert into Users (FirstName, LastName, Email, Password, IsActive, UserRole, CreatedDate, ModifiedDate)
					values(@FirstName, @LastName, @Email, @Password, @IsActive, @UserRole, @CreatedDate, @ModifiedDate)
					select * from Users where Email=@Email
				commit transaction
					print 'Register Successfully'
			end
END