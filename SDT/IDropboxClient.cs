namespace SDT
{
    using System.Threading.Tasks;
    using Dropbox.Api.Files;

    public interface IDropboxClient
    {
        Task UploadFile(string fileName, string destination);
        Task<FileMetadata> GetFileMetadata(string filePath);
        Task DeleteFile(string filePath);
    }
}
