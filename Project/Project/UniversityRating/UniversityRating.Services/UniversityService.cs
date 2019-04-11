using System.Collections.Generic;
using AutoMapper;
using UniversityRating.Data.Abstractions.Models;
using UniversityRating.Data.Abstractions.Repositories;
using UniversityRating.Services.Abstractions;
using UniversityRating.Services.Common.DTOs.University;

namespace UniversityRating.Services
{
    public class UniversityService : IUniversityService
    {
        private readonly IUniversityRepository _universityRepository;
        private readonly IMapper _mapper;

        public UniversityService(IUniversityRepository universityRepository, IMapper mapper)
        {
            _universityRepository = universityRepository;
            _mapper = mapper;
        }

        public List<TopUniversityDto> GetTopUniversities(int numberOfUniversities)
        {
            List<TopUniversity> universities = _universityRepository.GetTopUniversities(numberOfUniversities);

            return _mapper.Map<List<TopUniversity>, List<TopUniversityDto>>(universities);
        }
    }
}