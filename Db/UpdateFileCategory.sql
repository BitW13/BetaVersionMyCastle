USE [FileSharingDb]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateFileCategory]
	@Id int,
	@Name nvarchar(50)
AS
BEGIN
	UPDATE dbo.FileCategories
	SET Name = @Name
	WHERE dbo.FileCategories.Id = @Id
END
GO
