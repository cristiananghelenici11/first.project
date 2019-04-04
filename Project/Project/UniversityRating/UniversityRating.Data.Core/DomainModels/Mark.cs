namespace UniversityRating.Data.Core.DomainModels
{
    public abstract class Mark : Entity
    {
        public long UserId { get; set; }
        public float Value { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
