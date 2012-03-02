namespace Shared.Infrastructure.Transaction
{
    public class SaveResponse<T> : SaveRequest<T>
    {
        public SaveResponse(T itemToSave) : base(itemToSave)
        {
        }
    }
}