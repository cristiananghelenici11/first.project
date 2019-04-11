using System.Collections.Generic;
using UniversityRating.Data.Abstractions.Models;
using UniversityRating.Data.Core.DomainModels;

namespace UniversityRating.Data.Abstractions.Repositories
{
    public interface IUniversityRepository : IRepository<University>
    {  
        List<TopUniversity> GetTopUniversities(int numberOfTeachers);

    }
}