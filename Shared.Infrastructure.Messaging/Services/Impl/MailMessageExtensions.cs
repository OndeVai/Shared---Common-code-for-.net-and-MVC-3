#region

using System.IO;
using System.Net.Mail;
using System.Net.Mime;

#endregion

namespace Shared.Infrastructure.Messaging.Services.Impl
{
    internal static class MailMessageExtensions
    {
        public static void AddView(this MailMessage stmpMessage, string messageBody, string mediaType)
        {
            if (!string.IsNullOrWhiteSpace(messageBody))
            {
                var view = AlternateView.CreateAlternateViewFromString(messageBody, null, mediaType);
                stmpMessage.AlternateViews.Add(view);
            }
        }

        public static void AddAttachment(this MailMessage stmpMessage, string attachmentPath)
        {
            if (!string.IsNullOrWhiteSpace(attachmentPath))
            {
                var attachment = new Attachment(attachmentPath, MediaTypeNames.Application.Octet);

                var disposition = attachment.ContentDisposition;
                disposition.CreationDate = File.GetCreationTime(attachmentPath);
                disposition.ModificationDate = File.GetLastWriteTime(attachmentPath);
                disposition.ReadDate = File.GetLastAccessTime(attachmentPath);
                stmpMessage.Attachments.Add(attachment);
            }
        }
    }
}