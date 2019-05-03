using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using UniversityRating.Data.Abstractions.Repositories;
using UniversityRating.Data.Core.DomainModels;
using UniversityRating.Services.Abstractions;
using UniversityRating.Services.Common.DTOs.Course;

namespace UniversityRating.Services.CourseService
{
    public class CourseService : ICourseService
    {
        private IMapper _mapper;
        private ICourseRepository _courseRepository;

        public CourseService(IMapper mapper, ICourseRepository courseRepository)
        {
            _mapper = mapper;
            _courseRepository = courseRepository;
        }

        public List<CourseDto> GetAllCoursesByUniversityId(long universityId)
        {
            List<Course> courses = _courseRepository.GetAllCoursesByUniversityId(universityId);

            return _mapper.Map<List<Course>, List<CourseDto>>(courses);
        }

        public List<CourseDto> GetAllCoursesByTeacherId(long teacherId)
        {
            List<Course> courses = _courseRepository.GetAllCoursesByTeacherId(teacherId);

            return _mapper.Map<List<Course>, List<CourseDto>>(courses);
        }
    }
}
