USE [BookStoreDB]
GO
/****** Object:  StoredProcedure [dbo].[SortBooks]    Script Date: 04-08-2020 18:57:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SortBooks]
AS
BEGIN
	select * from Books order by Book_Title 
END
