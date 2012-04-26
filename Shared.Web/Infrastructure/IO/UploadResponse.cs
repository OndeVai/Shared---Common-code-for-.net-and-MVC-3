namespace Shared.Web.Infrastructure.IO
{
    public class UploadResponse
    {
        public UploadResponse(ValidationResponse validationResponse, string webUrl)
        {
            WebUrl = webUrl;
            ValidationResponse = validationResponse;
        }

        public ValidationResponse ValidationResponse { get; private set; }
        public string WebUrl { get; private set; }

    }
}