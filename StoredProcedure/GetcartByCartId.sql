USE [BookStoreDB]
GO
/****** Object:  StoredProcedure [dbo].[GetcartByCartId]    Script Date: 04-08-2020 18:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[GetcartByCartId]
@CartId int
AS
BEGIN
	begin try
	if exists (select * from Cart where Id = @CartId)
	begin
		select * from Cart where Id=@CartId
	end
	else
		raiserror('Cart id Not Present', 16, 1);
	end try
	begin catch
		raiserror('Cart id Not Present', 16, 1);
	end catch
END
