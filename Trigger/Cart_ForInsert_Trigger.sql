USE [BookStoreDB]
GO
/****** Object:  Trigger [dbo].[Cart_FroInsert]    Script Date: 07-07-2020 22:07:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER TRIGGER [dbo].[Cart_FroInsert]
on [dbo].[Cart]
for insert
AS 
BEGIN
	declare @Id int	
	select @Id=Id from inserted
	insert into CartDetails
	values('New Cart is added with id  =' +CAST(@Id as nvarchar(5)) + '  is added at ' + CAST(GetDate() as nvarchar(50)))
END