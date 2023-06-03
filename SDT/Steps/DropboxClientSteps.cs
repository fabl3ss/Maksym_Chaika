using Dropbox.Api;
using Dropbox.Api.Files;
using NUnit.Framework;

namespace SDT.Steps;

[Binding]
public class DropboxClientSteps
{
    private readonly IDropboxClient _client;
    private string? _localFileName;
    private string? _dropboxFilePath;
    private Metadata? _metadata;

    public DropboxClientSteps(IDropboxClient client)
    {
        _client = client;
    }

    [Given(@"I have a local file ""(.*)""")]
    public void GivenIHaveALocalFile(string filePath)
    {
        if (!File.Exists(filePath))
        {
            try
            {
                File.Create(filePath).Close();
            }
            catch (Exception ex)
            {
                Assert.Fail($"An exception occurred during file creation: {ex.Message}");
            }
        }
        
        _localFileName = filePath;
    }

    [When(@"I upload the file to Dropbox folder ""(.*)""")]
    public async Task WhenIUploadTheFileToDropboxFolder(string destinationFolder)
    {
        try
        {
            await _client.UploadFile(_localFileName!, destinationFolder);
        }
        catch (Exception ex)
        {
            Assert.Fail($"An exception occurred during file upload: {ex.Message}");
        }
    }
    
    [Then(@"file ""(.*)"" exist in Dropbox")]
    public async Task ThenFileExistInDropbox(string dropboxFilePath)
    {
        try
        {
            await _client.GetFileMetadata(dropboxFilePath);
            _dropboxFilePath = dropboxFilePath;
        }
        catch (Exception ex)
        {
            Assert.Fail($"File {dropboxFilePath} does not exist in Dropbox: {ex.Message}");
        }
    }

    [Given(@"there is a file ""(.*)"" in Dropbox")]
    public async Task ThereIsAFileAtInDropbox(string dropboxFilePath)
    {
        try
        {
            var lastSlashIndex = dropboxFilePath.LastIndexOf('/');
            var localFileName = dropboxFilePath[(lastSlashIndex + 1)..];
            var destinationFolder = dropboxFilePath[..lastSlashIndex];

            if (!File.Exists(localFileName))
            {
                File.Create(localFileName).Close();
            }
            await _client.UploadFile(localFileName, destinationFolder);

            _localFileName = localFileName;
            _dropboxFilePath = dropboxFilePath;
        }
        catch (Exception ex)
        {
            Assert.Fail($"An exception occurred during file upload: {ex.Message}");
        }
    }
    
    [When(@"I delete the file from Dropbox")]
    public async Task WhenIDeleteFileFromDropbox()
    {
        try
        {
            await _client.DeleteFile(_dropboxFilePath!);
        }
        catch (Exception ex)
        {
            Assert.Fail($"An exception occurred during file delete: {ex.Message}");
        } 
    }

[Then(@"the file does not exist in Dropbox")]
    public async Task ThenFileDoesNotExistInDropbox()
    {
        try
        {
            await _client.GetFileMetadata(_dropboxFilePath!);
        }
        catch (ApiException<GetMetadataError> ex)
        {
            if (ex.ErrorResponse.AsPath.Value.IsNotFound)
            {
                return;
            }
            
            Assert.Fail($"An exception occurred during file existence check: {ex.Message}");
        } 
    }

    [When(@"I retrieve the metadata for the file")]
    public async Task WhenIRetrieveTheMetadataForTheFile()
    {
        try
        {
            _metadata = await _client.GetFileMetadata(_dropboxFilePath!);
        }
        catch (Exception ex)
        {
            Assert.Fail($"An exception occurred during file metadata request: {ex.Message}");
        }
    }

    [Then(@"file metadata should match with file")]
    public void ThenIShouldReceiveTheFileMetadata()
    {
        Assert.AreEqual(_metadata!.PathDisplay, _dropboxFilePath!);
    }
}
