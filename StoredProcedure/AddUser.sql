USE [BookStoreDB]
GO
/****** Object:  StoredProcedure [dbo].[AddUser]    Script Date: 04-08-2020 18:53:55 ******/
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
	begin try
		begin transaction
			if not exists (select Email from Users where Email=@Email)
			begin		
					insert into Users (FirstName, LastName, Email, Password, IsActive, UserRole, CreatedDate, ModifiedDate)
					values(@FirstName, @LastName, @Email, @Password, @IsActive, @UserRole, @CreatedDate, @ModifiedDate)
					select * from Users where Email=@Email
					commit transaction
					print 'Register Successfully'
			end
		else
			raiserror('Email Id Already Present', 16,1);
	end try
	begin catch
		if @@TRANCOUNT > 0
		rollback transaction
			raiserror('Email Id Already Present', 16,1);	
	end catch						
END