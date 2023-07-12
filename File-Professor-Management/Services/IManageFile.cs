namespace File_Professor_Management.Services
{
    public interface IManageFile
    {
        Task<string> UploadFile(IFormFile _IFormFile);
        Task<(byte[], string, string)> DownloadFile(string FileName);
    }
}
