USE [FileSharingDb]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateFileUrl]
	@Url nvarchar(max)
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO dbo.FileUrls (Url)
	VALUES (@Url);
END
GO
