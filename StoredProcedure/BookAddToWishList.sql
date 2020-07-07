USE [BookStoreDB]
GO
/****** Object:  StoredProcedure [dbo].[BookAddToWishList]    Script Date: 07-07-2020 22:12:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[BookAddToWishList]
@UserId int,
@BookId int,
@IsUsed bit,
@CreatedDate datetime,
@ModifiedDate datetime
AS
BEGIN
	insert into WishList values(@UserId, @BookId, @IsUsed, @CreatedDate, @ModifiedDate)
	select * from WishList
	print 'Book added to wish list successfully'
END
