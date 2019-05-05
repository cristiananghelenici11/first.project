using System.Collections.Generic;
using AutoMapper;
using UniversityRating.Data.Abstractions.Models.Comment;
using UniversityRating.Data.Abstractions.Repositories;
using UniversityRating.Data.Core.DomainModels;
using UniversityRating.Services.Abstractions;
using UniversityRating.Services.Common.DTOs.Comment;

namespace UniversityRating.Services.CommentService
{

    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        private ICourseRepository _courseRepository;

        public CommentService(ICommentRepository commentRepository, IMapper mapper, ICourseRepository courseRepository)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
            _courseRepository = courseRepository;
        }

        public List<CommentUniversityShowDto> GetCommentsByUniversityId(long universityId)
        {
            List<CommentUniversityShow> commentUniversityShows =
                _commentRepository.GetCommentsByUniversityId(universityId);


            return _mapper.Map<List<CommentUniversityShow>, List<CommentUniversityShowDto>>(commentUniversityShows);
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
            var commentTeacher = new CommentTeacher
            {
                Subject = commentTeacherDto.Subject,
                Message = commentTeacherDto.Message,
                TeacherId = commentTeacherDto.TeacherId,
                UserId = commentTeacherDto.UserId
            };
            _commentRepository.AddCommentTeacher(commentTeacher);
        }

        public void AddCommentCourse(CommentCourseDto commentCourseDto)
        {
            var commentCourse = new CommentCourse
            {
                Subject = commentCourseDto.Subject,
                Message = commentCourseDto.Message,
                CourseId = commentCourseDto.CourseId,
                UserId = commentCourseDto.UserId
            };

            _commentRepository.AddCommentCourse(commentCourse);
        }

        public void AddCommentCourseTeacher(CommentCourseTeacherDto commentCourseTeacherDto)
        {
            var commentCourseTeacher = new CommentCourseTeacher
            {
                Subject = commentCourseTeacherDto.Subject,
                Message = commentCourseTeacherDto.Message,
                CourseTeacherId = _courseRepository.GetCourseTeacherId(commentCourseTeacherDto.CourseId, commentCourseTeacherDto.TeacherId),
                UserId = commentCourseTeacherDto.UserId
            };

            _commentRepository.AddCommentCourseTeacher(commentCourseTeacher);
        }
    }
}