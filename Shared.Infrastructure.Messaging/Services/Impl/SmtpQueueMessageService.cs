#region

using System.Net.Mail;
using Shared.Infrastructure.Messaging.Dto;

#endregion

namespace Shared.Infrastructure.Messaging.Services.Impl
{
    public class SmtpQueueMessageService : IQueueMessageService
    {
        #region Implementation of IQueueMessageService

        public void Push(QueueMessageSendRequest messageSendRequest)
        {
            var message = messageSendRequest.Message;
            using (var smtpMessage = new MailMessage(messageSendRequest.OwnerAddress, messageSendRequest.RecipientAddress))
            {
                var hasHtmlBody = !string.IsNullOrWhiteSpace(message.MessageBodyRich);
                foreach (var replyToRecipient in messageSendRequest.ReplyToRecipients)
                {
                    smtpMessage.ReplyToList.Add(new MailAddress(replyToRecipient.Address, replyToRecipient.DisplayName));
                }


                smtpMessage.Subject = message.MessageTitle;
                smtpMessage.IsBodyHtml = hasHtmlBody;

                smtpMessage.AddView(message.MessageBodyPlain, "text/plain");
                smtpMessage.AddView(message.MessageBodyRich, "text/html");
                smtpMessage.AddAttachment(message.AttachmentFilePath);


                using (var client = new SmtpClient { EnableSsl = messageSendRequest.IsSecure })
                {
                    client.Send(smtpMessage);
                }
            }
        }

        #endregion
    }
}