namespace Shared.Application.Dto
{
    public class UidRequest<TUId>
    {
        public UidRequest(TUId id)
        {
            Id = id;
        }

        public TUId Id { get; private set; }
    }

    public class UidRequest : UidRequest<int>
    {
        public UidRequest(int id) : base(id)
        {
        }
    }
}