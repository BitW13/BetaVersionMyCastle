USE [FileSharingDb]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateFile]
	@Id int,
	@Name nvarchar(50),
	@Size real,
	@Description nvarchar(max),
	@DownloadDate datetime,
	@CategoryId int,
	@FileAccessId int,
	@FileUrlId int,
	@UserId int
AS
BEGIN
	SET NOCOUNT ON;

    UPDATE dbo.Files
	SET Name = @Name, 
		Size = @Size, 
		Description = @Description, 
		DownloadDate = @DownloadDate, 
		CategoryId = @CategoryId, 
		FileAccessId = @FileAccessId,
		FileUrlId = @FileUrlId,
		UserId = @UserId
	WHERE dbo.Files.Id = @Id
END
GO
