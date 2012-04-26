namespace Shared.Web.Infrastructure.IO
{
    public interface IFileUploader
    {
        UploadResponse Upload(UploadRequest uploadRequest);
    }
}