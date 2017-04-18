namespace UrlMinifier.Services.Interfaces
{
    public interface IUrlService
    {
        string MinifyUrl(string url);

        string GetRealUrl(string minifiedUrl);
    }
}
