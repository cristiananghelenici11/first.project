using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Query;
using Remotion.Linq.Clauses;
using UniversityRating.Data.Abstractions.Extensions;
using UniversityRating.Data.Abstractions.Models.Comment;
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
        private readonly IRepository<Comment> _repositoryComment;

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
            _repositoryComment = repositoryComment;
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

        public List<CommentUniversityDto> GetCommentUniversitiesByUserId(long id)
        {
            List<CommentUniversity> commentUniversities = _repositoryCommentUniversity.Find().Where(x => x.UserId.Equals(id)).ToList();
            return _mapper.Map<List<CommentUniversity>, List<CommentUniversityDto>>(commentUniversities);
        }

        public List<CommentCourseDto> GetCommentCourseByUserId(long id)
        {
            List<CommentCourse> commentCourses = _repositoryCommentCourse.Find().Where(x => x.UserId.Equals(id)).ToList();
            var result = new  List<CommentCourseDto>();
            foreach (var comment in commentCourses)
            {
                result.Add(new CommentCourseDto
                {
                    UserId = comment.UserId,
                    CourseId = comment.CourseId,
                    Subject = comment.Subject,
                    Message = comment.Message,
                    Id = comment.Id
                });
            }
            return result;
        }

        public List<CommentTeacherDto> GetCommentTeachersByUserId(long id)
        {
            List<CommentTeacher> commentTeachers = _repositoryCommentTeacher.Find().Where(x => x.UserId.Equals(id)).ToList();
            var result = new  List<CommentTeacherDto>();

            foreach (var comment in commentTeachers)
            {
                result.Add(new CommentTeacherDto
                {
                    UserId = comment.UserId,
                    TeacherId = comment.TeacherId,
                    Subject = comment.Subject,
                    Message = comment.Message,
                    Id = comment.Id
                });
            }

            return result;
        }

        public List<CommentCourseTeacherDto> GetCommentCourseTeachersByUserId(long id)
        {
            
            var spec = new Specification<CommentCourseTeacher> {Predicate = teacher => teacher.User.Id == id};
            spec.Include(x => x.CourseTeacher)
                .ThenInclude(x => x.Course)
                .ThenInclude(x => x.Faculty);

            List<CommentCourseTeacher> commentCourseTeachers = _repositoryCommentCourseTeacher.Find(spec).ToList();
            return _mapper.Map<List<CommentCourseTeacher>, List<CommentCourseTeacherDto>>(commentCourseTeachers);
        }

        public void DeleteCommentById(long id)
        {
            Comment comment = _repositoryComment.GetById(id);
            _repositoryComment.Remove(comment);
            _repositoryComment.SaveChanges();
        }

        public CommentDto GetCommentById(long id)
        {
            Comment comment = _commentRepository.GetById(id);
            return _mapper.Map<Comment, CommentDto>(comment);
        }

        public void UpdateComment(CommentDto comment)
        {
            _commentRepository.Update(new Comment
            {
                Id = comment.Id, 
                Message = comment.Message, 
                Subject = comment.Subject, 
                UserId = comment.UserId
            });
            _commentRepository.SaveChanges();
        }
    }
}