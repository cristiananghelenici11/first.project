namespace DataAcces
{
    public class Telephone
    {
        public long Id { get; set; }
        public long Number { get; set; }
        public string Mark { get; set; }

        public long PersonId { get; set; }
        public virtual Person Person { get; set; }
    }
}