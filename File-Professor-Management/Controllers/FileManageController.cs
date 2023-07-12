using File_Professor_Management.Services;
using Microsoft.AspNetCore.Mvc;

namespace File_Professor_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileManageController : ControllerBase
    {
        private readonly IManageFile _iManageFile;
        public FileManageController(IManageFile iManageFile)
        {
            _iManageFile = iManageFile;
        }
        [HttpGet]
        [Route("downloadfile")]
        public async Task<IActionResult> DownloadFile(string FileName)
        {
            var result = await _iManageFile.DownloadFile(FileName);
            return File(result.Item1, result.Item2, result.Item3);
        }



        [HttpPost]
        [Route("uploadfile")]
        public async Task<IActionResult> UploadFile(IFormFile _IFormFile)
        {
            var result = await _iManageFile.UploadFile(_IFormFile);
            return Ok(result);
        }
    }
}
