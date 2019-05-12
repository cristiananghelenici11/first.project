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
            var markTeacher = _mapper.Map<MarkTeacher>(markTeacherDto);
            _markRepository.AddMarkTeacher(markTeacher);
        }

        public void AddMarkCourse(MarkCourseDto markCourseDto)
        {
            var markCourse = _mapper.Map<MarkCourse>(markCourseDto);
            _markRepository.AddMarkCourse(markCourse);
        }

        public void AddMarkCourseTeacher(MarkCourseTeacherDto markCourseTeacherDto)
        {
            var markCourseTeacher = _mapper.Map<MarkCourseTeacher>(markCourseTeacherDto);
            markCourseTeacher.CourseTeacherId = _courseRepository.GetCourseTeacherId(markCourseTeacherDto.CourseId,
                markCourseTeacherDto.TeacherId);
            _markRepository.AddMarkCourseTeacher(markCourseTeacher);
        }

        public void DeleteMarkById(long id)
        {
            _markRepository.DeleteMarkById(id);
        }

        public void UpdateMark(EditMarkDto editMarkDto)
        {
            _markRepository.Update(_mapper.Map<EditMarkDto, Mark>(editMarkDto));
            _markRepository.SaveChanges();
        }

        public EditMarkDto GetMarkById(long id)
        {
            Mark mark = _markRepository.GetById(id);
            return _mapper.Map<Mark, EditMarkDto>(mark);
        }

        public List<EditMarkTeacherDto> GetMarkTeacherByUserId(long userId)
        {
            var spec = new Specification<MarkTeacher> { Predicate = teacher => teacher.User.Id.Equals(userId) };
            spec.Include(x => x.Teacher)
                .ThenInclude(x => x.UniversityTeachers).ThenInclude(x => x.University).ThenInclude(x => x.UniversityTeachers);
            List<MarkTeacher> markTeachers = _repositoryMarkTeacher.Find(spec).ToList();
            List<EditMarkTeacherDto> editMarkTeacherDtos = _mapper.Map<List<MarkTeacher>, List<EditMarkTeacherDto>>(markTeachers);

            return editMarkTeacherDtos;
        }

        public List<EditMarkCourseDto> GetMarkCourseByUserId(long id)
        {
            var spec = new Specification<MarkCourse> { Predicate = course => course.User.Id.Equals(id) };
            spec.Include(x => x.Course)
                .ThenInclude(x => x.CourseTeachers).Include(x => x.Course.Faculty.University);
            List<MarkCourse> markTeachers = _repositoryMarkCourse.Find(spec).ToList();
            List<EditMarkCourseDto> editMarkCourseDtos = _mapper.Map<List<EditMarkCourseDto>>(markTeachers);

            return editMarkCourseDtos;
        }

        public List<EditMarkCourseTeacherDto> GetMarkCourseTeacherByUserId(long id)
        {
            var spec = new Specification<MarkCourseTeacher> { Predicate = course => course.User.Id.Equals(id) };
            spec.Include(x => x.CourseTeacher)
                .ThenInclude(x => x.Course.Faculty.University);
            List<MarkCourseTeacher> markCourseTeachers = _repositoryMarkCourseTeacher.Find(spec).ToList();
            List<EditMarkCourseTeacherDto> editMarkCourseTeacherDtos = _mapper.Map<List<MarkCourseTeacher>, List<EditMarkCourseTeacherDto>>(markCourseTeachers);

            return editMarkCourseTeacherDtos;
        }
    }
}