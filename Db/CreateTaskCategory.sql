USE [TaskPlannerServiceDb]
GO
/****** Object:  StoredProcedure [dbo].[CreateTaskCategory]    Script Date: 12/11/2019 9:55:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[CreateTaskCategory] 
	@Name nvarchar(50),
	@IsOn bit,
	@Color nvarchar(50),
	@ImagePath nvarchar(max),
	@UserId int
AS
BEGIN
	INSERT INTO dbo.TaskCategories (Name, IsOn, ImagePath, Color, UserId)
	VALUES (@Name, @IsOn, @Color, @ImagePath, @UserId);
END
