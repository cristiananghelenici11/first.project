namespace UniversityRating.Data.Abstractions.Models.University
{
    public class UniversityShow
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Contact { get; set; }
        public int Age { get; set; }
        public double AverangeMark { get; set; }
    }
}