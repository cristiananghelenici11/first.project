using UniversityRating.Data.Core.DomainModels.Identity;

namespace UniversityRating.Data.Core.DomainModels
{
    public class UserCustomer : Customer
    {
        public User User { get; set; }

        
    }
}