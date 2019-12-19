USE [FileSharingDb]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteFileAccess]
	@Id int
AS
BEGIN
	SET NOCOUNT ON;
	DELETE FROM dbo.FileAccesses
	WHERE dbo.FileAccesses.Id = @Id
END
GO