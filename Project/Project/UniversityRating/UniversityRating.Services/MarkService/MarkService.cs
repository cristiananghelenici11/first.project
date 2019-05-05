using System;
using AutoMapper;
using UniversityRating.Data.Abstractions.Repositories;
using UniversityRating.Data.Core.DomainModels;
using UniversityRating.Services.Abstractions;
using UniversityRating.Services.Common.DTOs.Mark;

namespace UniversityRating.Services.MarkService
{
    public class MarkService : IMarkService
    {
        private ICourseRepository _courseRepository;
        private IMapper _mapper;
        private IMarkRepository _markRepository;

        public MarkService(IMapper mapper, IMarkRepository markRepository, ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
            _markRepository = markRepository;
        }


        public void AddMarkTeacher(MarkTeacherDto markTeacherDto)
        {
            var markTeacher = new MarkTeacher()
            {
                TeacherId = markTeacherDto.TeacherId,
                UserId = markTeacherDto.UserId,
                Value = markTeacherDto.Mark
            };
            _markRepository.AddMarkTeacher(markTeacher);
        }

        
        public void AddMarkCourse(MarkCourseDto markCourseDto)
        {
            var markCourse = new MarkCourse
            {
                UserId = markCourseDto.UserId,
                CourseId = markCourseDto.CourseId,
                Value = markCourseDto.Mark
            };
            _markRepository.AddMarkCourse(markCourse);
        }

        public void AddMarkCourseTeacher(MarkCourseTeacherDto markCourseTeacherDto)
        {
            var markCourseTeacher = new MarkCourseTeacher
            {
                UserId = markCourseTeacherDto.UserId,
                CourseTeacherId = _courseRepository.GetCourseTeacherId(markCourseTeacherDto.CourseId, markCourseTeacherDto.TeacherId),
                Value = markCourseTeacherDto.Mark
            };
            _markRepository.AddMarkCourseTeacher(markCourseTeacher);

        }
    }
}