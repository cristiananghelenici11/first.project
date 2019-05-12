using System.Collections.Generic;
using UniversityRating.Data.Abstractions.Models;
using UniversityRating.Data.Abstractions.Models.University;
using UniversityRating.Data.Core.DomainModels;
using UniversityRating.Services.Common.DTOs.Enums;

namespace UniversityRating.Data.Abstractions.Repositories
{
    public interface IUniversityRepository : IRepository<University>
    {  
        List<TopUniversity> GetTopUniversities(int numberOfTeachers);

        List<University> GetAllUniversities();

        List<UniversityShow> GetAllUniversities(UniversitiesSortColumn? universitiesSortColumn, SortType sortType, int pageNumber, string search,
            int numberOfRecordsPerPage = 10, bool skipRecords = true);

        void DeleteUniversityById(int id);

        void AddNewUniversity(University university);

        void UpdateUniversity(University university);
    }
}