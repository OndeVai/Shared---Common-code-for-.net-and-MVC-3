namespace Shared.Web.Infrastructure.IO
{
    public enum ValidationResponse
    {
        InvalidFileType = 1,
        MaxSizeExceeded = 2,
        Empty = 4,
        Success = 5
    }
}