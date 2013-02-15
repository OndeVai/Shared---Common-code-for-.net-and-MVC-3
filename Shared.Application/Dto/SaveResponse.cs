namespace Shared.Application.Dto
{
    public class SaveResponse<T> : SaveRequest<T>
    {
        public SaveResponse(T itemToSave) : base(itemToSave)
        {
        }
    }
}