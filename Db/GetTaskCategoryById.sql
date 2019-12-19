USE [TaskPlannerServiceDb]
GO
/****** Object:  StoredProcedure [dbo].[GetTaskCategoryById]    Script Date: 12/11/2019 9:54:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[GetTaskCategoryById] 
	@Id int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM dbo.TaskCategories
	WHERE dbo.TaskCategories.Id = @Id
END
