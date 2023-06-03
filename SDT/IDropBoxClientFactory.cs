namespace SDT
{
    public class DropboxClientFactory
    {
        public IDropboxClient CreateDropboxClient(string accessToken)
        {
            return new DropboxClientImpl(accessToken);
        }
    }
}
