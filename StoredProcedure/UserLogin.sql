USE [BookStoreDB]
GO
/****** Object:  StoredProcedure [dbo].[UserLogin]    Script Date: 04-08-2020 18:58:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[UserLogin]
 @Email varchar(50),
 @Password varchar(50)
AS
BEGIN
	begin try
		If Exists(SELECT * from Users where Email=@Email AND Password=@Password and UserRole='user')
		begin
			SELECT Id, FirstName, LastName, Email, Password, IsActive, UserRole, CreatedDate, ModifiedDate from Users where Email=@Email AND Password=@Password
			print 'User Login Successfully'
		end
		else
			raiserror('Failed To Login', 16,1);
	end try
	begin catch
		raiserror('Failed To Login', 16,1);
	end catch
END