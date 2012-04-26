using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web;

namespace Shared.Web.Infrastructure.IO.Impl
{
    public class WebImageUploader : IFileUploader
    {
        public UploadResponse Upload(UploadRequest uploadRequest)
        {
            var validationResponse = Validate(uploadRequest);

            string webUrl = null;

            if (validationResponse == ValidationResponse.Success)
            {
                var postedFile = uploadRequest.PostedFile;
                var relativeFolderPath = uploadRequest.RelativeFolderPath;
                var fileName = string.Format("{0}{1}", Guid.NewGuid(), Path.GetExtension(postedFile.FileName));
                var savePath = string.Format("{0}{1}", HttpContext.Current.Server.MapPath(relativeFolderPath), fileName);
                postedFile.SaveAs(savePath);
                webUrl = string.Format("{0}{1}", relativeFolderPath, fileName);
            }

            return new UploadResponse(validationResponse, webUrl);
        }

        private static ValidationResponse Validate(UploadRequest uploadRequest)
        {
            var validationResponse = ValidationResponse.Success;
            var postedFile = uploadRequest.PostedFile;
            if (!ValidateEmpty(postedFile)) validationResponse = ValidationResponse.Empty;
            else if (!ValidateSize(postedFile, uploadRequest.MaxSize)) validationResponse = ValidationResponse.MaxSizeExceeded;
            else if (!ValidateType(postedFile.InputStream)) validationResponse = ValidationResponse.InvalidFileType;

            return validationResponse;
        }

        private static bool ValidateEmpty(HttpPostedFileBase postedFile)
        {
            return postedFile != null && postedFile.ContentLength > 0;
        }

        private static bool ValidateSize(HttpPostedFileBase postedFile, int maxSize)
        {
            return postedFile.ContentLength <= maxSize;
        }

        private static bool ValidateType(Stream stream)
        {
            try
            {
                //Read an image from the stream...
                var image = Image.FromStream(stream);

                //Move the pointer back to the beginning of the stream
                stream.Seek(0, SeekOrigin.Begin);

                return ImageFormat.Jpeg.Equals(image.RawFormat) 
                        || ImageFormat.Png.Equals(image.RawFormat) 
                        || !ImageFormat.Gif.Equals(image.RawFormat);
            }
            catch (Exception)
            {

                return false;
            }

        }
    }
}