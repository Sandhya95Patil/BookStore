USE [BookStoreDB]
GO
/****** Object:  StoredProcedure [dbo].[DeleteCart]    Script Date: 06-07-2020 16:44:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[DeleteCart]
@CartId int
AS
BEGIN
	delete from Cart where Id=@CartId
END
