using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web;

namespace ronin.Web.Mvc.Validation
{
    /// <summary>
    /// validates file is under size limit
    /// </summary>
    public class FileUploadImageOnlyAttribute : ValidationAttribute
    {

        public override bool IsValid(object value)
        {
            var validImageMimeTypes = new[] { "image/jpg", "image/jpeg", "image/gif", "image/png" };

            var uploadFile = value as HttpPostedFileBase;
            return uploadFile != null ? validImageMimeTypes.Any(v => v.ToLowerTrim() == uploadFile.ContentType.ToLowerTrim()) : true;
        }
    }
}
