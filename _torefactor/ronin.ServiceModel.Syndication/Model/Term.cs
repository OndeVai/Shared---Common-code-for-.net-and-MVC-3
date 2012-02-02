namespace ronin.ServiceModel.Syndication.Model
{
    public class Term
    {
        public string Content { get; set; }

        public override string ToString()
        {
            return Content;
        }
    }
}