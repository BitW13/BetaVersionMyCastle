USE [TaskPlannerServiceDb]
GO
/****** Object:  StoredProcedure [dbo].[DeleteTaskCategory]    Script Date: 12/11/2019 9:55:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[DeleteTaskCategory]
	@Id int
AS
BEGIN
	DELETE FROM dbo.TaskCategories
	WHERE dbo.TaskCategories.Id = @Id;
END
