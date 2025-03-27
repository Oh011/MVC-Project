using Microsoft.AspNetCore.Http;

namespace Projcet.BLL.Common.Services.AttachmentService
{
    public class AttachmentService : IAttachmentService
    {

        private readonly List<string> _AllowedExtensions = new List<string>()
        {


            ".png",".jpg",".jpeg"
        };




        private int _MaxSize = 2_097_152; //--> 2MB {written in bytes}


        public bool Delete(string path)
        {

            if (File.Exists(path))
            {

                File.Delete(path);
                return true;
            }

            return false;
        }
        public async Task<string> Upload(IFormFile file, string FolderName, string ExistingFile = "")
        {


            var Extension = Path.GetExtension(file.FileName);



            if (!_AllowedExtensions.Contains(Extension))
                return null;

            //Validate MaxSize

            if (file.Length > _MaxSize)
                return null;



            var FolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\File", FolderName);


            //set Unique Name for the image

            var FileName = string.Empty;


            FileName = string.IsNullOrEmpty(ExistingFile) == true ? $"{Guid.NewGuid()}{Extension}" : ExistingFile;



            var FilePath = Path.Combine(FolderPath, FileName);


            using var FileStream = new FileStream(FilePath, FileMode.Create);

            await file.CopyToAsync(FileStream);


            return FileName;


        }
    }
}
