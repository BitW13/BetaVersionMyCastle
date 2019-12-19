USE [FileSharingDb]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateFileCategory]
	@Name nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO dbo.FileCategories (Name)
	VALUES (@Name)
END
GO
