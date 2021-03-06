USE [TaskPlannerServiceDb]
GO
/****** Object:  StoredProcedure [dbo].[UpdateSeverity]    Script Date: 12/11/2019 9:54:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[UpdateSeverity]
	@Id int,
	@Name nvarchar(50),
	@UserId int
AS
BEGIN
	UPDATE dbo.Severities
	SET Name = @Name,
		UserId = @UserId
	WHERE dbo.Severities.Id = @Id
END
