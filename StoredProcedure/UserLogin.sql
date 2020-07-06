USE [BookStoreDB]
GO
/****** Object:  StoredProcedure [dbo].[UserLogin]    Script Date: 06-07-2020 16:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[UserLogin]
 @Email varchar(50),
 @Password varchar(50)
AS
BEGIN
	declare @Status int
	If Exists(SELECT Email, Password from Users where Email=@Email AND Password=@Password and UserRole='user')
    begin
	begin transaction
		set @Status=1
		SELECT Id, FirstName, LastName, Email, Password, IsActive, UserRole, CreatedDate, ModifiedDate from Users where Email=@Email AND Password=@Password
	commit transaction
		print 'User Login Successfully'
	end
	else
	begin
	begin transaction
		set @Status=0
	rollback transaction
		print 'Failed To Login'
	end
select @Status	
END