USE [FileSharingDb]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateFileAccess]
	@Id int,
	@Name nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE dbo.FileAccesses
	SET Name = @Name
	WHERE dbo.FileAccesses.Id = @Id
END
GO
