namespace GenericRepository
{
    public class Phone : Entity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
