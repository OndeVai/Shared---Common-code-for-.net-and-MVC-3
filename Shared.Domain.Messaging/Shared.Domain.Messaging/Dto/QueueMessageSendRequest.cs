using System.Collections.Generic;

namespace Shared.Infrastructure.Messaging.Dto
{
    public class QueueMessageSendRequest
    {
        public QueueMessageSendRequest(string owner, string recipient, bool isSecure, string messageTitle,
                                       string messageBodyPlain,
                                       string messageBodyRich, string attachmentFilePath = null)
        {
            OwnerAddress = owner;
            RecipientAddress = recipient;
            IsSecure = isSecure;
            Message = new QueueMessage(messageTitle, messageBodyPlain, messageBodyRich, attachmentFilePath);
            ReplyToRecipients = new List<QueueMessageReplyToRecipient>();
        }

        public string OwnerAddress { get; private set; }
        public string RecipientAddress { get; private set; }
        public List<QueueMessageReplyToRecipient> ReplyToRecipients { get; private set; }
        public bool IsSecure { get; private set; }
        public QueueMessage Message { get; private set; }
    }

    public class QueueMessageReplyToRecipient
    {
        public QueueMessageReplyToRecipient(string displayName, string address)
        {
            DisplayName = displayName;
            Address = address;
        }

        public string DisplayName { get; set; }
        public string Address { get; set; }
    }
}