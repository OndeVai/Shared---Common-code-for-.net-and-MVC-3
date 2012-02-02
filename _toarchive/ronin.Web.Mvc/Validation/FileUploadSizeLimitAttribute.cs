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
    public class FileUploadSizeLimitAttribute : ValidationAttribute
    {
        private readonly int _maxSizeBytes;


        public FileUploadSizeLimitAttribute()
            : this(5000)
        {
        }

        /// <param name="maxSize">size limit in bytes</param>
        public FileUploadSizeLimitAttribute(int maxSize)
        {
            _maxSizeBytes = maxSize;
        }

        public override bool IsValid(object value)
        {
            var uploadFile = value as HttpPostedFileBase;
            return uploadFile != null ? uploadFile.ContentLength <= _maxSizeBytes : true;
        }
    }
}
