USE [BookStoreDB]
GO
/****** Object:  StoredProcedure [dbo].[GetcartByCartId]    Script Date: 07-07-2020 22:10:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[GetcartByCartId]
@CartId int
AS
BEGIN
	select * from Cart where Id=@CartId
END
