USE [BookStoreDB]
GO
/****** Object:  StoredProcedure [dbo].[GetAllCart]    Script Date: 07-07-2020 22:11:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[GetAllCart]
AS
BEGIN
	select * from Cart
END
