using System.Web;

namespace Shared.Web.Infrastructure.IO
{
    public class UploadRequest
    {
        public UploadRequest(HttpPostedFileBase httpPostedFile, int maxFileSize, string relativeFolderPath)
        {
            RelativeFolderPath = relativeFolderPath;
            PostedFile = httpPostedFile;
            MaxSize = maxFileSize;
        }

        public HttpPostedFileBase PostedFile { get; private set; }
        public int MaxSize { get; private set; }
        public string RelativeFolderPath { get; private set; }
    }
}