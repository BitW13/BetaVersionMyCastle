USE [TaskPlannerServiceDb]
GO
/****** Object:  StoredProcedure [dbo].[DeleteSeverity]    Script Date: 12/11/2019 9:55:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[DeleteSeverity]
	@Id int
AS
BEGIN
	DELETE FROM dbo.Severities
	WHERE dbo.Severities.Id = @Id
END
