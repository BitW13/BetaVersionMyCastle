USE [FileSharingDb]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateFileUrl]
	@Id int,
	@Url nvarchar(max)
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE dbo.FileUrls
	SET Url = @Url
	WHERE dbo.FileUrls.Id = @Id
END
GO
