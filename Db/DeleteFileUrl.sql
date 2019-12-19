USE [FileSharingDb]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteFileUrl]
	@Id int
AS
BEGIN
	SET NOCOUNT ON;
	DELETE FROM dbo.FileUrls
	WHERE dbo.FileUrls.Id = @Id
END
GO
