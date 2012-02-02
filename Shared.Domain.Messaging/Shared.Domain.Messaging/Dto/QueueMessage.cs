namespace Shared.Infrastructure.Messaging.Dto
{
    public class QueueMessage
    {
        public QueueMessage(string messageTitle, string messageBodyPlain, string messageBodyRich,
                            string attachmentFilePath)
        {
            MessageTitle = messageTitle;
            MessageBodyPlain = messageBodyPlain;
            MessageBodyRich = messageBodyRich;
            AttachmentFilePath = attachmentFilePath;
        }

        public string MessageTitle { get; set; }
        public string MessageBodyPlain { get; set; }
        public string MessageBodyRich { get; set; }
        public string AttachmentFilePath { get; set; }
       
    }
}