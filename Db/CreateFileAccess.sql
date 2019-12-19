USE [FileSharingDb]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateFileAccess]
	@Name nvarchar(50)
AS
BEGIN
	INSERT INTO dbo.FileAccesses (Name)
	VALUES (@Name)
END
GO
