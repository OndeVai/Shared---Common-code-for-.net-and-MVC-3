namespace Shared.Infrastructure.Location.Service
{
    public class State
    {
        public State(int id, string nameAbbr, string nameFull)
        {
            NameFull = nameFull;
            NameAbbr = nameAbbr;
            Id = id;
        }

        public int Id { get; private set; }
        public string NameAbbr { get; private set; }
        public string NameFull { get; private set; }
    }
}