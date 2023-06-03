using Dropbox.Api;
using Dropbox.Api.Files;

namespace SDT
{
	public class DropboxClientImpl : IDropboxClient
	{
        private readonly DropboxClient _client;

        public DropboxClientImpl(string accessToken)
        {
            _client = new DropboxClient(accessToken);
        }

        public async Task UploadFile(string localFilePath, string destinationFolder)
        {
            await using var fileStream = File.OpenRead(localFilePath);
            var fileName = localFilePath.TrimStart('/');
            
            await _client.Files.UploadAsync(
                $"{destinationFolder}/{fileName}",
                WriteMode.Overwrite.Instance,
                body: fileStream
            );
            
            fileStream.Close();
        }

        public async Task<FileMetadata> GetFileMetadata(string filePath)
        {
            var response = await _client.Files.GetMetadataAsync(filePath);

            return response.IsFile ? response.AsFile : null!;
        }

        public async Task DeleteFile(string filePath)
        {
            await _client.Files.DeleteV2Async(filePath);
        }
    }
}
