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
            var spec = new Specification<CommentUniversity> {Predicate = user => user.UserId.Equals(id)};
            spec.Include(x => x.User);

            IEnumerable<CommentUniversity> commentUniversities = _repositoryCommentUniversity.Find(spec);
            var result = commentUniversities.ToList();
            return _mapper.Map<List<CommentUniversity>, List<CommentUniversityDto>>(result);
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

        public EditCommentDto GetCommentById(long id)
        {
            Comment comment = _commentRepository.GetById(id);
            return _mapper.Map<Comment, EditCommentDto>(comment);
        }

        public void UpdateComment(EditCommentDto comment)
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

        public List<CommentDto> GetUniversityComments(int pageNumber, long universityId, int numberOfRecordsPerPage = 10, bool skipRecords = true)
        {
            if (universityId.Equals(0))
            {
                var spec2 = new Specification<CommentUniversity>();
                spec2.Include(x => x.University).Include(y => y.User);
                IEnumerable<CommentUniversity> allComments = _repositoryCommentUniversity.Find(spec2);

                if (skipRecords)
                    allComments = allComments.Skip((pageNumber - 1) * numberOfRecordsPerPage);
                allComments = allComments.Take(numberOfRecordsPerPage);
                List<CommentDto> comments = new List<CommentDto>().ToList();

                foreach (CommentUniversity commentUniversity in allComments)
                {
                    comments.Add(new CommentDto
                    {
                        Id = commentUniversity.Id,
                        UserName = commentUniversity.User.Email,
                        Subject = commentUniversity.Subject,
                        Message = commentUniversity.Message,
                        Type = commentUniversity.University.Name
                    });
                }

                return comments;
            }

            var spec = new Specification<CommentUniversity> {Predicate = comment => comment.UniversityId.Equals(universityId)};
            spec.Include(x => x.University).Include(y => y.User);
            IEnumerable<CommentUniversity> commentUniversities = _repositoryCommentUniversity.Find(spec);

            if (skipRecords)
                commentUniversities = commentUniversities.Skip((pageNumber - 1) * numberOfRecordsPerPage);

            commentUniversities = commentUniversities.Take(numberOfRecordsPerPage);

            List<CommentDto> commentDtos = new List<CommentDto>();
            foreach (CommentUniversity commentUniversity in commentUniversities)
            {
                commentDtos.Add(new CommentDto
                {
                    Id = commentUniversity.Id,
                    UserName = commentUniversity.User.Email,
                    Subject = commentUniversity.Subject,
                    Message = commentUniversity.Message,
                    Type = commentUniversity.University.Name
                });
            }
           
            return commentDtos;
        }

        public List<CommentDto> GetCourseComments(int pageNumber, long courseId, int numberOfRecordsPerPage = 10, bool skipRecords = true)
        {
            if (courseId.Equals(0))
            {
                var spec2 = new Specification<CommentCourse>();
                spec2.Include(x => x.Course).Include(y => y.User).Include(x => x.Course.Faculty.University);
                IEnumerable<CommentCourse> allComments = _repositoryCommentCourse.Find(spec2);

                if (skipRecords)
                    allComments = allComments.Skip((pageNumber - 1) * numberOfRecordsPerPage);
                allComments = allComments.Take(numberOfRecordsPerPage);
                List<CommentDto> comments = new List<CommentDto>();

                foreach (var comment in allComments)
                {
                    comments.Add(new CommentDto
                    {
                        Id = comment.Id,
                        UserName = comment.User.Email,
                        Subject = comment.Subject,
                        Message = comment.Message,
                        Type = comment.Course.Faculty.University.Name + " "+comment.Course.Description
                    });
                }

                return comments;
            }

            var spec = new Specification<CommentCourse> {Predicate = comment => comment.CourseId.Equals(courseId)};
            spec.Include(x => x.Course).Include(y => y.User).Include(x => x.Course.Faculty.University);
            IEnumerable<CommentCourse> commentCourses = _repositoryCommentCourse.Find(spec);

            if (skipRecords)
                commentCourses = commentCourses.Skip((pageNumber - 1) * numberOfRecordsPerPage);

            commentCourses = commentCourses.Take(numberOfRecordsPerPage);

            List<CommentDto> commentDtos = new List<CommentDto>();
            foreach (var comment in commentCourses)
            {
                commentDtos.Add(new CommentDto
                {
                    Id = comment.Id,
                    UserName = comment.User.Email,
                    Subject = comment.Subject,
                    Message = comment.Message,
                    Type = comment.Course.Faculty.University.Name + " "+comment.Course.Description
                });
            }
            return commentDtos;
        }

        public List<CommentDto> GetTeacherComments(int pageNumber, long teacherId, int numberOfRecordsPerPage = 10, bool skipRecords = true)
        {
            if (teacherId.Equals(0))
            {
                var spec2 = new Specification<CommentTeacher>();
                spec2.Include(x => x.Teacher).Include(y => y.User).Include(x => x.Teacher.UniversityTeachers).ThenInclude(x=>x.University);
                IEnumerable<CommentTeacher> allComments = _repositoryCommentTeacher.Find(spec2);

                if (skipRecords)
                    allComments = allComments.Skip((pageNumber - 1) * numberOfRecordsPerPage);
                allComments = allComments.Take(numberOfRecordsPerPage).ToList();
                List<CommentDto> comments = new List<CommentDto>();

                foreach (CommentTeacher comment in allComments)
                {
                    comments.Add(new CommentDto
                    {
                        Id = comment.Id,
                        UserName = comment.User.Email,
                        Subject = comment.Subject,
                        Message = comment.Message,
                        Type = comment.Teacher.UniversityTeachers.Select(x=>x.University.Name).FirstOrDefault() +" "+comment.Teacher.FirstName + comment.Teacher.LastName
                    });
                }

                return comments;
            }

            var spec = new Specification<CommentTeacher> {Predicate = comment => comment.TeacherId.Equals(teacherId)};
            spec.Include(x => x.Teacher).Include(y => y.User).Include(x => x.Teacher.UniversityTeachers)
                .ThenInclude(x => x.University);
            IEnumerable<CommentTeacher> commentTeachers = _repositoryCommentTeacher.Find(spec);

            if (skipRecords)
                commentTeachers = commentTeachers.Skip((pageNumber - 1) * numberOfRecordsPerPage);

            commentTeachers = commentTeachers.Take(numberOfRecordsPerPage).ToList();

            List<CommentDto> commentDtos = new List<CommentDto>();
            foreach (CommentTeacher comment in commentTeachers)
            {
                commentDtos.Add(new CommentDto
                {
                    Id = comment.Id,
                    UserName = comment.User.Email,
                    Subject = comment.Subject,
                    Message = comment.Message,
                    Type = comment.Teacher.UniversityTeachers.Select(x=>x.University.Name)+" "+comment.Teacher.FirstName + comment.Teacher.LastName
                });
            }
           
            return commentDtos;
        }

        public List<CommentDto> GetCourseTeacherComments(int pageNumber, long courseId, long teacherId, int numberOfRecordsPerPage,
            bool skipRecords)
        {
            if (teacherId.Equals(0) && courseId.Equals(0))
            {
                var spec2 = new Specification<CommentCourseTeacher>();
                spec2.Include(x => x.CourseTeacher.Teacher).Include(x => x.User).Include(y => y.CourseTeacher.Course).Include(x => x.CourseTeacher.Course.Faculty.University);
                IEnumerable<CommentCourseTeacher> allComments = _repositoryCommentCourseTeacher.Find(spec2);

                if (skipRecords)
                    allComments = allComments.Skip((pageNumber - 1) * numberOfRecordsPerPage);
                allComments = allComments.Take(numberOfRecordsPerPage).ToList();
                List<CommentDto> comments = new List<CommentDto>();

                foreach (var comment in allComments)
                {
                    comments.Add(new CommentDto
                    {
                        Id = comment.Id,
                        UserName = comment.User.Email,
                        Subject = comment.Subject,
                        Message = comment.Message,
                        Type = comment.CourseTeacher.Course.Faculty.University.Name + " " + comment.CourseTeacher.Teacher.FirstName + " " + comment.CourseTeacher.Teacher.LastName + " " +comment.CourseTeacher.Course.Description 
                    });
                }
                return comments;
            }

            var spec = new Specification<CommentCourseTeacher> {Predicate = comment => comment.CourseTeacher.TeacherId.Equals(teacherId) && comment.CourseTeacher.CourseId.Equals(courseId)};
            spec.Include(x => x.CourseTeacher.Teacher).Include(y => y.CourseTeacher.Course).Include(x => x.CourseTeacher.Course.Faculty.University);

            IEnumerable<CommentCourseTeacher> commentCourseTeachers = _repositoryCommentCourseTeacher.Find(spec);

            if (skipRecords)
                commentCourseTeachers = commentCourseTeachers.Skip((pageNumber - 1) * numberOfRecordsPerPage);

            commentCourseTeachers = commentCourseTeachers.Take(numberOfRecordsPerPage);

            List<CommentDto> commentDtos = new List<CommentDto>();
            foreach (var comment in commentCourseTeachers)
            {
                commentDtos.Add(new CommentDto
                {
                    Id = comment.Id,
                    UserName = comment.User.Email,
                    Subject = comment.Subject,
                    Message = comment.Message,
                    Type = comment.CourseTeacher.Course.Faculty.University.Name + " " + comment.CourseTeacher.Teacher.FirstName + " " + comment.CourseTeacher.Teacher.LastName + " " +comment.CourseTeacher.Course.Description 
                });
            }
            return commentDtos;
        }
    }
}