using Test.Quiz.Api.Models.File;

namespace Test.Quiz.Api.Services
{
    public class FileService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<string> UploadFileAsync(IFormFile? file, string folder)
        {
            string webRootPath = _webHostEnvironment.WebRootPath;
            string relativeFolderPath = folder;
            string uploadsFolder = Path.Combine(webRootPath, relativeFolderPath);

            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            string filePath = Path.Combine(relativeFolderPath, uniqueFileName);

            using (var stream = new FileStream(Path.Combine(webRootPath, filePath), FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            string absoluteFilePath = Path.Combine(webRootPath, folder, uniqueFileName);
            string relativeFilePath = Path.GetRelativePath(webRootPath, absoluteFilePath);

            return "/" + relativeFilePath.Replace("\\", "/");
        }

        //public async Task<string> UploadMultipleFileAsync(UploadMultipleFileRequest request, string folder)
        //{
        //    string webRootPath = _webHostEnvironment.WebRootPath;
        //    string relativeFolderPath = folder;
        //    string uploadsFolder = Path.Combine(webRootPath, relativeFolderPath);

        //    if (!Directory.Exists(uploadsFolder))
        //    {
        //        Directory.CreateDirectory(uploadsFolder);
        //    }

        //    string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
        //    string filePath = Path.Combine(relativeFolderPath, uniqueFileName);

        //    using (var stream = new FileStream(Path.Combine(webRootPath, filePath), FileMode.Create))
        //    {
        //        await file.CopyToAsync(stream);
        //    }

        //    string absoluteFilePath = Path.Combine(webRootPath, folder, uniqueFileName);
        //    string relativeFilePath = Path.GetRelativePath(webRootPath, absoluteFilePath);

        //    return "/" + relativeFilePath.Replace("\\", "/");
        //}

        public async Task<List<string>> UploadMultipleFilesAsync(UploadMultipleFileRequest request, string folder)
        {
            List<string> uploadedFilePaths = new List<string>();

            foreach (var file in request.Files)
            {
                if (file.Length > 0)
                {
                    string webRootPath = _webHostEnvironment.WebRootPath;
                    string relativeFolderPath = folder;
                    string uploadsFolder = Path.Combine(webRootPath, relativeFolderPath);

                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    //string uniqueFileName = file.FileName;
                    string uniqueFileName = request.AdditionalString+ "_" + file.FileName;

                    string filePath = Path.Combine(relativeFolderPath, uniqueFileName);

                    using (var stream = new FileStream(Path.Combine(webRootPath, filePath), FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    string absoluteFilePath = Path.Combine(webRootPath, folder, uniqueFileName);
                    string relativeFilePath = Path.GetRelativePath(webRootPath, absoluteFilePath);

                    uploadedFilePaths.Add("/" + relativeFilePath.Replace("\\", "/"));
                }
            }

            return uploadedFilePaths;
        }

        //public async Task<List<string>> UploadMultipleFilesAsync(UploadMultipleFileRequest request, string folder)
        //{
        //    List<string> uploadedFilePaths = new List<string>();

        //    foreach (var file in request.Files)
        //    {
        //        if (file.Length > 0)
        //        {
        //            string webRootPath = _webHostEnvironment.WebRootPath;
        //            string relativeFolderPath = folder;
        //            string uploadsFolder = Path.Combine(webRootPath, relativeFolderPath);

        //            if (!Directory.Exists(uploadsFolder))
        //            {
        //                Directory.CreateDirectory(uploadsFolder);
        //            }

        //            string uniqueFileName = file.FileName;
        //            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

        //            // Đảm bảo rằng thư mục cho filePath cũng đã được tạo
        //            string directoryPath = Path.GetDirectoryName(filePath);
        //            if (!Directory.Exists(directoryPath))
        //            {
        //                Directory.CreateDirectory(directoryPath);
        //            }

        //            using (var stream = new FileStream(filePath, FileMode.Create))
        //            {
        //                await file.CopyToAsync(stream);
        //            }

        //            string absoluteFilePath = Path.Combine(uploadsFolder, uniqueFileName);
        //            string relativeFilePath = Path.GetRelativePath(webRootPath, absoluteFilePath);

        //            uploadedFilePaths.Add("/" + relativeFilePath.Replace("\\", "/"));
        //        }
        //    }

        //    return uploadedFilePaths;
        //}


        public async Task<string> DeleteFileAsync(string fileUrl)
        {
            string webRootPath = _webHostEnvironment.WebRootPath;
            string filePath = Path.Combine(webRootPath, fileUrl.TrimStart('/'));

            if (File.Exists(filePath))
            {
                await Task.Run(() => File.Delete(filePath));
                return fileUrl;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<string>> DeleteFilesAsync(List<string> fileUrls)
        {
            List<string> deletedUrls = new List<string>();

            foreach (var fileUrl in fileUrls)
            {
                string webRootPath = _webHostEnvironment.WebRootPath;
                string filePath = Path.Combine(webRootPath, fileUrl.TrimStart('/'));

                if (File.Exists(filePath))
                {
                    await Task.Run(() => File.Delete(filePath));
                    deletedUrls.Add(fileUrl);
                }
            }

            return deletedUrls;
        }
    }
}
