USE [FileSharingDb]
GO
/****** Object:  StoredProcedure [dbo].[GetFileCardById]    Script Date: 12/19/2019 1:47:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[GetFileCardById]
	@Id int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT files.Id as FileId, 
			files.Name as FileName, Size, 
			Description, 
			CategoryId as FileCategoryId, 
			FileUrlId, 
			DownloadDate, 
			FileAccessId, 
			UserId,
			accesses.Name as FileAccessName,
			categories.Name as FileCategoryName,
			urls.Url as FileUrlName
	FROM dbo.Files as files
	LEFT JOIN dbo.FileAccesses as accesses ON accesses.Id = FileAccessId
	LEFT JOIN dbo.FileCategories as categories ON categories.Id = files.CategoryId
	LEFT JOIN dbo.FileUrls as urls ON urls.Id = files.FileUrlId
	WHERE files.Id = @Id
END
