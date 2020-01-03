using Common.Entity.FileService;
using Microsoft.AspNetCore.Http;

namespace FileSharingService.WebApi.Models
{
    public class CreateFileModel
    {
        public string Description { get; set; }

        public string CategoryId { get; set; }

        public string AccessId { get; set; }

        public IFormFile File { get; set; }
    }
}
