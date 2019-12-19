USE [TaskPlannerServiceDb]
GO
/****** Object:  StoredProcedure [dbo].[CreateSeverity]    Script Date: 12/11/2019 9:56:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[CreateSeverity]
	@Name nvarchar(50),
	@UserId int
AS
BEGIN
	INSERT INTO dbo.Severities (Name, UserId)
	VALUES (@Name, @UserId);
END
