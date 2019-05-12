using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using UniversityRating.Data.Abstractions.Extensions;
using UniversityRating.Data.Abstractions.Repositories;
using UniversityRating.Data.Core.DomainModels;
using UniversityRating.Data.Repositories;
using UniversityRating.Services.Abstractions;
using UniversityRating.Services.Common.DTOs.Comment;

namespace UniversityRating.Services.CommentService
{

    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        private readonly ICourseRepository _courseRepository;
        private readonly IRepository<CommentUniversity> _repositoryCommentUniversity;
        private readonly IRepository<CommentCourse> _repositoryCommentCourse;
        private readonly IRepository<CommentTeacher> _repositoryCommentTeacher;
        private readonly IRepository<CommentCourseTeacher> _repositoryCommentCourseTeacher;

        public CommentService(
            ICommentRepository commentRepository, 
            IMapper mapper, 
            ICourseRepository courseRepository, 
            IRepository<CommentUniversity> repositoryCommentUniversity,
            IRepository<CommentCourse> repositoryCommentCourse,
            IRepository<CommentTeacher> repositoryCommentTeacher,
            IRepository<CommentCourseTeacher> repositoryCommentCourseTeacher,
            IRepository<Comment> repositoryComment
            )
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
            _courseRepository = courseRepository;
            _repositoryCommentUniversity = repositoryCommentUniversity;
            _repositoryCommentCourse = repositoryCommentCourse;
            _repositoryCommentTeacher = repositoryCommentTeacher;
            _repositoryCommentCourseTeacher = repositoryCommentCourseTeacher;
        }

        public void AddCommentUniversity(CommentUniversityDto commentUniversityDto)
        {
            var commentUniversity = new CommentUniversity
            {
                Subject = commentUniversityDto.Subject,
                Message = commentUniversityDto.Message,
                UserId = commentUniversityDto.UserId,
                UniversityId = commentUniversityDto.UniversityId
            };
            _commentRepository.AddCommentUniversity(commentUniversity);
        }

        public void AddCommentTeacher(CommentTeacherDto commentTeacherDto)
        {
            var commentTeacher = _mapper.Map<CommentTeacher>(commentTeacherDto);
            _commentRepository.AddCommentTeacher(commentTeacher);
        }

        public void AddCommentCourse(CommentCourseDto commentCourseDto)
        {
            var commentCourse = _mapper.Map<CommentCourse>(commentCourseDto);
            _commentRepository.AddCommentCourse(commentCourse);
        }

        public void AddCommentCourseTeacher(CommentCourseTeacherDto commentCourseTeacherDto)
        {
            
            var commentCourseTeacher = _mapper.Map<CommentCourseTeacher>(commentCourseTeacherDto);
            commentCourseTeacher.CourseTeacherId =
                _courseRepository.GetCourseTeacherId(commentCourseTeacherDto.CourseId,
                    commentCourseTeacherDto.TeacherId);
            _commentRepository.AddCommentCourseTeacher(commentCourseTeacher);
        }

        public List<CommentUniversityDto> GetCommentUniversitiesByUserId(long id)
        {
            List<CommentUniversity> commentUniversities = _commentRepository.GetCommentUniversitiesByUserId(id);
            List<CommentUniversityDto> commentUniversityDtos =
                _mapper.Map<List<CommentUniversity>, List<CommentUniversityDto>>(commentUniversities);

            return commentUniversityDtos;
        }

        public List<CommentCourseDto> GetCommentCourseByUserId(long id)
        {
            List<CommentCourse> commentCourses = _commentRepository.GetCommentCourseByUserId(id);
            List<CommentCourseDto> commentCourseDtos =
                _mapper.Map<List<CommentCourse>, List<CommentCourseDto>>(commentCourses);

            return commentCourseDtos;
        }

        public List<CommentTeacherDto> GetCommentTeachersByUserId(long id)
        {
            List<CommentTeacher> commentTeachers = _commentRepository.GetCommentTeachersByUserId(id);
            List<CommentTeacherDto> commentCourseDtos =
                _mapper.Map<List<CommentTeacher>, List<CommentTeacherDto>>(commentTeachers);

            return commentCourseDtos;
        }

        public List<CommentCourseTeacherDto> GetCommentCourseTeachersByUserId(long id)
        {
            List<CommentCourseTeacher> commentCourseTeachers = _commentRepository.GetCommentCourseTeachersByUserId(id);
            List<CommentCourseTeacherDto> commentCourseTeacherDtos =
                _mapper.Map<List<CommentCourseTeacher>, List<CommentCourseTeacherDto>>(commentCourseTeachers);

            return commentCourseTeacherDtos;
        }

        public void DeleteCommentById(long id)
        {
            _commentRepository.DeleteCommentById(id);
        }

        public EditCommentDto GetCommentById(long id)
        {
            Comment comment = _commentRepository.GetById(id);
            return comment == null ? new EditCommentDto() : _mapper.Map<Comment, EditCommentDto>(comment);
        }

        public void UpdateComment(EditCommentDto editCommentDto)
        {
            var comment = _mapper.Map<Comment>(editCommentDto);
            _commentRepository.UpdateComment(comment);
        }

        public List<CommentDto> GetUniversityComments(int pageNumber, long universityId, int numberOfRecordsPerPage = 10, bool skipRecords = true)
        {
            var spec = new Specification<CommentUniversity>();
            spec.Include(x => x.University).Include(y => y.User);

            if (universityId.Equals(0))
            {
                IEnumerable<CommentUniversity> allComments = _repositoryCommentUniversity.Find(spec);
                if (skipRecords)
                    allComments = allComments.Skip((pageNumber - 1) * numberOfRecordsPerPage);
                allComments = allComments.Take(numberOfRecordsPerPage);
                return _mapper.Map<List<CommentDto>>(allComments);
            }

            spec.Predicate = comment => comment.UniversityId.Equals(universityId);
            IEnumerable<CommentUniversity> commentUniversities = _repositoryCommentUniversity.Find(spec);
            if (skipRecords)
                commentUniversities = commentUniversities.Skip((pageNumber - 1) * numberOfRecordsPerPage);
            commentUniversities = commentUniversities.Take(numberOfRecordsPerPage);
            var tr = _mapper.Map<List<CommentDto>>(commentUniversities);
            Console.WriteLine(tr);
            return _mapper.Map<List<CommentDto>>(commentUniversities);
        }

        public List<CommentDto> GetCourseComments(int pageNumber, long courseId, int numberOfRecordsPerPage = 10, bool skipRecords = true)
        {
            var spec = new Specification<CommentCourse>();
            spec.Include(x => x.Course).Include(y => y.User).Include(x => x.Course.Faculty.University);

            if (courseId.Equals(0))
            {
                IEnumerable<CommentCourse> allComments = _repositoryCommentCourse.Find(spec);
                if (skipRecords)
                    allComments = allComments.Skip((pageNumber - 1) * numberOfRecordsPerPage);
                allComments = allComments.Take(numberOfRecordsPerPage);
                return _mapper.Map<List<CommentDto>>(allComments);
            }

            spec.Predicate = comment => comment.CourseId.Equals(courseId);
            IEnumerable<CommentCourse> commentCourses = _repositoryCommentCourse.Find(spec);
            if (skipRecords)
                commentCourses = commentCourses.Skip((pageNumber - 1) * numberOfRecordsPerPage);
            commentCourses = commentCourses.Take(numberOfRecordsPerPage);
            return _mapper.Map<List<CommentDto>>(commentCourses);
        }

        public List<CommentDto> GetTeacherComments(int pageNumber, long teacherId, int numberOfRecordsPerPage = 10, bool skipRecords = true)
        {
            var spec = new Specification<CommentTeacher>();
            spec.Include(x => x.Teacher).Include(y => y.User).Include(x => x.Teacher.UniversityTeachers)
                .ThenInclude(x => x.University);

            if (teacherId.Equals(0))
            {
                IEnumerable<CommentTeacher> allComments = _repositoryCommentTeacher.Find(spec);
                if (skipRecords)
                    allComments = allComments.Skip((pageNumber - 1) * numberOfRecordsPerPage);
                allComments = allComments.Take(numberOfRecordsPerPage).ToList();
                return _mapper.Map<List<CommentDto>>(allComments);
            }
            spec.Predicate = comment => comment.TeacherId.Equals(teacherId);
            IEnumerable<CommentTeacher> commentTeachers = _repositoryCommentTeacher.Find(spec);
            if (skipRecords)
                commentTeachers = commentTeachers.Skip((pageNumber - 1) * numberOfRecordsPerPage);
            commentTeachers = commentTeachers.Take(numberOfRecordsPerPage);
            return _mapper.Map<List<CommentDto>>(commentTeachers);
        }

        public List<CommentDto> GetCourseTeacherComments(int pageNumber, long courseId, long teacherId, int numberOfRecordsPerPage,
            bool skipRecords)
        {
            var spec = new Specification<CommentCourseTeacher>();
            spec.Include(x => x.User)
                .Include(x => x.CourseTeacher).ThenInclude(y => y.Teacher)
                .Include(y => y.CourseTeacher.Course)
                .Include(x => x.CourseTeacher.Course.Faculty.University);

            if (teacherId.Equals(0) && courseId.Equals(0))
            {
                IEnumerable<CommentCourseTeacher> allComments = _repositoryCommentCourseTeacher.Find(spec);
                if (skipRecords)
                    allComments = allComments.Skip((pageNumber - 1) * numberOfRecordsPerPage);
                allComments = allComments.Take(numberOfRecordsPerPage).ToList();
                return _mapper.Map<List<CommentDto>>(allComments);
            }
            spec.Predicate = comment => comment.CourseTeacher.TeacherId.Equals(teacherId) && comment.CourseTeacher.CourseId.Equals(courseId);
            IEnumerable<CommentCourseTeacher> commentCourseTeachers = _repositoryCommentCourseTeacher.Find(spec);
            if (skipRecords)
                commentCourseTeachers = commentCourseTeachers.Skip((pageNumber - 1) * numberOfRecordsPerPage);
            commentCourseTeachers = commentCourseTeachers.Take(numberOfRecordsPerPage);
            return _mapper.Map<List<CommentDto>>(commentCourseTeachers);
        }
    }
}