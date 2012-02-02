#region

using Shared.Infrastructure.Messaging.Dto;

#endregion

namespace Shared.Infrastructure.Messaging.Services
{
    public interface IQueueMessageService
    {
        void Push(QueueMessageSendRequest messageSendRequest);
    }
}