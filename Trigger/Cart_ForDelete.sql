USE [BookStoreDB]
GO
/****** Object:  Trigger [dbo].[Cart_ForDelete]    Script Date: 07-07-2020 22:05:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER TRIGGER [dbo].[Cart_ForDelete]
on [dbo].[Cart]
for delete
AS 
BEGIN
	declare @Id int	
	select @Id=Id from deleted
	insert into CartDetails
	values('An existing cart with id  =' +CAST(@Id as nvarchar(5)) + '  is deleted at ' + CAST(GetDate() as nvarchar(50)))
END
