USE [TaskPlannerServiceDb]
GO
/****** Object:  StoredProcedure [dbo].[GetSeverityById]    Script Date: 12/11/2019 9:55:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[GetSeverityById]
	@Id int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM dbo.Severities
	WHERE dbo.Severities.Id = @Id
END
