USE [TaskPlannerServiceDb]
GO
/****** Object:  StoredProcedure [dbo].[GetSeverities]    Script Date: 12/11/2019 9:55:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[GetSeverities]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM dbo.Severities
END
