USE [BookStoreDB]
GO
/****** Object:  StoredProcedure [dbo].[AdminLogin]    Script Date: 04-08-2020 18:54:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[AdminLogin]
 @Email varchar(50),
 @Password varchar(50)
AS
BEGIN
	begin try
			If Exists(SELECT * from Users where Email=@Email AND Password=@Password  and UserRole='admin')
			begin
				SELECT Id, FirstName, LastName, Email, Password, IsActive, UserRole, CreatedDate, ModifiedDate from Users where Email=@Email AND Password=@Password
				print 'Admin Login Successfully'
				select * from Users where Email=@Email
			end
		else
			raiserror('Failed To Login', 16,1);
	end try
	begin catch
		raiserror('Failed To Login', 16,1);
	end catch	
END