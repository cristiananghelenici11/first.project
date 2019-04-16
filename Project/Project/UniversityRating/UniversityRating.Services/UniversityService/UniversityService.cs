﻿using System.Collections.Generic;
using AutoMapper;
using UniversityRating.Data.Abstractions.Models.University;
using UniversityRating.Data.Abstractions.Repositories;
using UniversityRating.Services.Abstractions;
using UniversityRating.Services.Common.DTOs.University;

namespace UniversityRating.Services.UniversityService
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


        public List<UniversityShowDto> GetAllUniversities()
        {
            List<UniversityShow> universityShows = _universityRepository.GetAllUniversities();

            return _mapper.Map<List<UniversityShow>, List<UniversityShowDto>>(universityShows);
        }


        public List<TopUniversityDto> GetTopUniversities(int numberOfUniversities)
        {
            List<TopUniversity> universities = _universityRepository.GetTopUniversities(numberOfUniversities);

            return _mapper.Map<List<TopUniversity>, List<TopUniversityDto>>(universities);
        }
    }
}