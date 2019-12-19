USE [TaskPlannerServiceDb]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateTaskCategory]
	@Id int,
	@Name nvarchar(50),
	@Color nvarchar(50),
	@ImagePath nvarchar(max),
	@IsOn bit,
	@UserId int
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE dbo.TaskCategories
	SET Name= @Name, 
		Color = @Color,
		ImagePath = @ImagePath,
		IsOn = @IsOn,
		UserId = @UserId
	WHERE dbo.TaskCategories.Id = @Id
END
GO
