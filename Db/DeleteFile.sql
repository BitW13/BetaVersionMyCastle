USE [FileSharingDb]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteFile]
	@Id int
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM dbo.Files
	WHERE dbo.Files.Id = @Id
END
GO