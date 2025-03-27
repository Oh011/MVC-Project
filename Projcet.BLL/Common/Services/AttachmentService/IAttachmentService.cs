using Microsoft.AspNetCore.Http;

namespace Projcet.BLL.Common.Services.AttachmentService
{
    public interface IAttachmentService
    {


        public bool Delete(string path);




        public Task<string> Upload(IFormFile file, string FolderName, string ExistingFile = "");
    }
}
