USE [BookStoreDB]
GO
/****** Object:  StoredProcedure [dbo].[GetAllWishList]    Script Date: 07-07-2020 22:10:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[GetAllWishList]
AS
BEGIN
	select * from WishList
END
