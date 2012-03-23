namespace Shared.Infrastructure.Dto
{
    public class UidRequest
    {
        public UidRequest(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}