USE [TaskPlannerServiceDb]
GO
/****** Object:  StoredProcedure [dbo].[GetTaskCategories]    Script Date: 12/11/2019 9:55:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[GetTaskCategories]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM dbo.TaskCategories
END
