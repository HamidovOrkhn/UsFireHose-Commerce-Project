using DevExtreme.AspNet.Mvc.FileManagement;
using Microsoft.AspNetCore.Mvc;
using USFH.Areas.Admin.Filters;

namespace USFH.Areas.Admin.Controllers
{
    [Area("Admin")]
    [LoginFilter]
    public class FileManagerImagesApiController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileManagerImagesApiController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [Route("api/file-manager-file-system-images", Name = "FileManagementImagesApi")]
        public object FileSystem(FileSystemCommand command, string arguments)
        {
            var config = new FileSystemConfiguration
            {
                Request = Request,
                FileSystemProvider = new PhysicalFileSystemProvider(
                    Path.Combine(_webHostEnvironment.WebRootPath, "uploads"),
                    (fileSystemItem, clientItem) =>
                    {
                        if (!clientItem.IsDirectory)
                            clientItem.CustomFields["url"] = GetFileItemUrl(fileSystemItem);
                    }
                ),
                //uncomment the code below to enable file/directory management
                AllowCopy = true,
                AllowCreate = true,
                AllowMove = true,
                AllowDelete = true,
                AllowRename = true,
                AllowUpload = true,
                AllowDownload = true
            };
            var processor = new FileSystemCommandProcessor(config);
            var result = processor.Execute(command, arguments);
            return result.GetClientCommandResult();
        }

        private string GetFileItemUrl(FileSystemInfo fileSystemItem)
        {
            var relativeUrl = fileSystemItem.FullName
                .Replace(_webHostEnvironment.WebRootPath, "")
                .Replace(Path.DirectorySeparatorChar, '/');
            return $"{Request.Scheme}://{Request.Host}{Request.PathBase}{relativeUrl}";
        }
    }
}
