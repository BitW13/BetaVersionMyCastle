USE [FileSharingDb]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetFileCategoryByName]
	@Name nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM dbo.FileCategories
	WHERE dbo.FileCategories.Name = @Name
END
GO
