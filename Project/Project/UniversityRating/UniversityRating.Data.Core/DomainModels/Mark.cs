namespace UniversityRating.Data.Core.DomainModels
{
    public abstract class Mark : Entity
    {
        public long UserId { get; set; }
        public float Value { get; set; }
        public virtual User User { get; set; }
    }
}
