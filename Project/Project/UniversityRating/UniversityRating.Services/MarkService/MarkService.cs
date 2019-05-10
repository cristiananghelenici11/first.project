using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using UniversityRating.Data.Abstractions.Extensions;
using UniversityRating.Data.Abstractions.Repositories;
using UniversityRating.Data.Core.DomainModels;
using UniversityRating.Data.Repositories;
using UniversityRating.Services.Abstractions;
using UniversityRating.Services.Common.DTOs.Mark;

namespace UniversityRating.Services.MarkService
{
    public class MarkService : IMarkService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;
        private readonly IMarkRepository _markRepository;
        private readonly IRepository<MarkTeacher> _repositoryMarkTeacher;
        private readonly IRepository<MarkCourse> _repositoryMarkCourse;
        private readonly IRepository<MarkCourseTeacher> _repositoryMarkCourseTeacher;

        public MarkService(
            IMapper mapper,
            IMarkRepository markRepository,
            ICourseRepository courseRepository,
            IRepository<MarkTeacher> repositoryMarkTeacher,
            IRepository<MarkCourse> repositoryMarkCourse,
            IRepository<MarkCourseTeacher> repositoryMarkCourseTeacher
            )
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
            _markRepository = markRepository;
            _repositoryMarkTeacher = repositoryMarkTeacher;
            _repositoryMarkCourse = repositoryMarkCourse;
            _repositoryMarkCourseTeacher = repositoryMarkCourseTeacher;
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

        public List<EditMarkTeacherDto> GetMarkTeacherByUserId(long userId)
        {
            var spec = new Specification<MarkTeacher> { Predicate = teacher => teacher.User.Id.Equals(userId) };
            spec.Include(x => x.Teacher)
                .ThenInclude(x => x.UniversityTeachers).ThenInclude(x => x.University).ThenInclude(x => x.UniversityTeachers);

            List<MarkTeacher> markTeachers = _repositoryMarkTeacher.Find(spec).ToList();
            List<EditMarkTeacherDto> editMarkTeacherDtos = new List<EditMarkTeacherDto>();

            foreach (MarkTeacher markTeacher in markTeachers)
            {
                editMarkTeacherDtos.Add(new EditMarkTeacherDto
                {
                    Id = markTeacher.Id,
                    TeacherId = markTeacher.Teacher.Id,
                    TeacherName = markTeacher.Teacher.FirstName + markTeacher.Teacher.LastName,
                    UniversityId = markTeacher.Teacher.UniversityTeachers.Select(x => x.UniversityId).FirstOrDefault(),
                    UniversityName = markTeacher.Teacher.UniversityTeachers.Select(x => x.University.Name).FirstOrDefault(),
                    UserId = markTeacher.UserId,
                    Mark = markTeacher.Value
                });
            }

            return editMarkTeacherDtos;
        }

        public void DeleteMarkById(long id)
        {
            Mark mark = _markRepository.GetById(id);
            _markRepository.Remove(mark);
            _markRepository.SaveChanges();
        }

        public EditMarkDto GetMarkById(long id)
        {
            Mark mark = _markRepository.GetById(id);

            return _mapper.Map<Mark, EditMarkDto>(mark);
        }

        public void UpdateMark(EditMarkDto editMarkDto)
        {
            _markRepository.Update(_mapper.Map<EditMarkDto, Mark>(editMarkDto));
            _markRepository.SaveChanges();
        }

        public List<EditMarkCourseDto> GetMarkCourseByUserId(long id)
        {
            var spec = new Specification<MarkCourse> { Predicate = course => course.User.Id.Equals(id) };
            spec.Include(x => x.Course)
                .ThenInclude(x => x.CourseTeachers).Include(x => x.Course.Faculty.University);

            List<MarkCourse> markTeachers = _repositoryMarkCourse.Find(spec).ToList();
            List<EditMarkCourseDto> editMarkCourseDtos = new List<EditMarkCourseDto>();

            foreach (MarkCourse markCourse in markTeachers)
            {
                editMarkCourseDtos.Add(new EditMarkCourseDto
                {
                    Id = markCourse.Id,
                    UserId = markCourse.UserId,
                    Mark = markCourse.Value,
                    CourseId = markCourse.CourseId,
                    CourseName = markCourse.Course.Name,
                    UniversityId = markCourse.Course.Faculty.University.Id,
                    UniversityName = markCourse.Course.Faculty.University.Name
                });
            }
            return editMarkCourseDtos;
        }

        public List<EditMarkCourseTeacherDto> GetMarkCourseTeacherByUserId(long id)
        {
            var spec = new Specification<MarkCourseTeacher> { Predicate = course => course.User.Id.Equals(id) };
            spec.Include(x => x.CourseTeacher)
                .ThenInclude(x => x.Course.Faculty.University);

            List<MarkCourseTeacher> markCourseTeachers = _repositoryMarkCourseTeacher.Find(spec).ToList();
            List<EditMarkCourseTeacherDto> editMarkCourseTeacherDtos = new List<EditMarkCourseTeacherDto>();

            foreach (MarkCourseTeacher markCourseTeacher in markCourseTeachers)
            {
                editMarkCourseTeacherDtos.Add(new EditMarkCourseTeacherDto
                {
                    Id = markCourseTeacher.Id,
                    UserId = markCourseTeacher.UserId,
                    Mark = markCourseTeacher.Value,
                    CourseId = markCourseTeacher.CourseTeacher.CourseId,
                    CourseName = markCourseTeacher.CourseTeacher.Course.Name,
                    UniversityId = markCourseTeacher.CourseTeacher.Course.Faculty.University.Id,
                    UniversityName = markCourseTeacher.CourseTeacher.Course.Faculty.University.Name
                });
            }

            return editMarkCourseTeacherDtos;
        }
    }
}