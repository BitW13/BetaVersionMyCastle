using FileSharingService.Bll.Services.Interfaces;

namespace FileSharingService.Bll.BusinessLogic
{
    public class BusinessLogic : IBusinessLogic
    {
        public BusinessLogic(IFileAccessService fileAccesses,
                                IFileCategoryService fileCategories,
                                IFileService files,
                                IFileUrlService fileUrls)
        {
            Files = files;
            FileCategories = fileCategories;
            FileAccesses = fileAccesses;
            FileUrls = fileUrls;
        }

        public IFileService Files { get; set; }
        public IFileAccessService FileAccesses { get; set; }
        public IFileUrlService FileUrls { get; set; }
        public IFileCategoryService FileCategories { get; set; }
    }
}
