#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using SendGridMail;
using SendGridMail.Transport;
using Shared.Infrastructure.Messaging.Dto;

#endregion

namespace Shared.Infrastructure.Messaging.Services.Impl
{
    public class SendGridQueueMessageService : IQueueMessageService
    {
        private readonly string _userName;
        private readonly string _password;

        public SendGridQueueMessageService(string userName, string password)
        {
            _userName = userName;
            _password = password;
        }

        #region Implementation of IQueueMessageService

        public void Push(QueueMessageSendRequest messageSendRequest)
        {
           
            var message = messageSendRequest.Message;
            //create a new message object
            var sgMessage = SendGrid.GenerateInstance();

            sgMessage.To = new[] { new MailAddress(messageSendRequest.RecipientAddress) };

            if (messageSendRequest.ReplyToRecipients.Count > 0)
            {
                sgMessage.ReplyTo = messageSendRequest.ReplyToRecipients
                                    .Select(replyToRecipient => new MailAddress(replyToRecipient.Address, replyToRecipient.DisplayName))
                                    .ToArray();
            }

            //set the sender
            sgMessage.From = new MailAddress(messageSendRequest.OwnerAddress);

            //set the sgMessage body
            sgMessage.Html = message.MessageBodyRich;
            sgMessage.Text = message.MessageBodyPlain;

            //set the sgMessage subject
            sgMessage.Subject = message.MessageTitle;

            //create an instance of the SMTP transport mechanism
            var transportInstance = SMTP.GenerateInstance(new NetworkCredential(_userName, _password));

            if (!string.IsNullOrWhiteSpace(message.AttachmentFilePath))
                sgMessage.AddAttachment(message.AttachmentFilePath);

            //send the mail
            transportInstance.Deliver(sgMessage);
        }

        #endregion
    }
}