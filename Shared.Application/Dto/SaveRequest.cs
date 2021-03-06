namespace Shared.Application.Dto
{
    public class SaveRequest<T>
    {
        public SaveRequest(T itemToSave)
        {
            ItemToSave = itemToSave;
        }

        public T ItemToSave { get; private set; }
    }
}