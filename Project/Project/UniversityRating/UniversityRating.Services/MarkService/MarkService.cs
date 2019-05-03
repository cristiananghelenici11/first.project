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
        private IMapper _mapper;
        private IMarkRepository _markRepository;

        public MarkService(IMapper mapper, IMarkRepository markRepository)
        {
            _mapper = mapper;
            _markRepository = markRepository;
        }


        public void AddMarkTeacher(MarkTeacherDto markTeacherDto)
        {
            //_markRepository.AddMarkTeacher(_mapper.Map<MarkTeacherDto, MarkTeacher>(markTeacher));

            var markTeacher = new MarkTeacher()
            {
                TeacherId = markTeacherDto.TeacherId,
                UserId = markTeacherDto.UserId,
                Value = Convert.ToSingle(markTeacherDto.Mark)
            };
            _markRepository.AddMarkTeacher(markTeacher);
        }

        
        public void AddMarkCourse(MarkCourseDto markCourseDto)
        {
            var markCourse = new MarkCourse
            {
                UserId = markCourseDto.UserId,
                CourseId = markCourseDto.CourseId,
                Value = Convert.ToSingle(markCourseDto.Mark)
            };
            _markRepository.AddMarkCourse(markCourse);
        }
    }
}