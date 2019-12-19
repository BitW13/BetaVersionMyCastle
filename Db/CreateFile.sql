USE [FileSharingDb]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateFile]
	@Name nvarchar(50),
	@Size real,
	@Description nvarchar(max),
	@DownloadDate datetime,
	@CategoryId int,
	@UserId int,
	@FileAccessId int,
	@FileUrlId int
AS
BEGIN
	INSERT INTO dbo.Files (Name, Size, Description, DownloadDate, CategoryId, FileUrlId, FileAccessId, UserId)
	VALUES (@Name, @Size, @Description, @DownloadDate, @CategoryId, @FileUrlId, @FileAccessId, @UserId)
END
GO
