USE [BookStoreDB]
GO
/****** Object:  StoredProcedure [dbo].[AddCart]    Script Date: 06-07-2020 16:43:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[AddCart]
@UserId int,
@BookId int,
@IsUsed bit,
@CreatedDate datetime,
@ModifiedDate datetime
AS
BEGIN
	insert into Cart values(@UserId, @BookId, @IsUsed, @CreatedDate, @ModifiedDate)
	select * from Cart
END