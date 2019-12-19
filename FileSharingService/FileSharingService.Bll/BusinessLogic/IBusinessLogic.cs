using FileSharingService.Bll.Services.Interfaces;

namespace FileSharingService.Bll.BusinessLogic
{
    public interface IBusinessLogic
    {
        IFileService Files { get; set; }

        IFileAccessService FileAccesses { get; set; }

        IFileUrlService FileUrls { get; set; }

        IFileCategoryService FileCategories { get; set; }
    }
}
