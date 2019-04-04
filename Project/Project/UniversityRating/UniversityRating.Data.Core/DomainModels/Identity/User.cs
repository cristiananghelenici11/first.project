using System;
using Microsoft.AspNetCore.Identity;

namespace UniversityRating.Data.Core.DomainModels.Identity
{
    public class User : IdentityUser<long>
    {
        public UserCustomer Customer { get; set; }

        public int Year { get; set; }

    }
}