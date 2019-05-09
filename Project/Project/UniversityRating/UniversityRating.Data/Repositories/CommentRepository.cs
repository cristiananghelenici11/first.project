

using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using UniversityRating.Data.Abstractions.Models.Comment;
using UniversityRating.Data.Abstractions.Repositories;
using UniversityRating.Data.Core.DomainModels;

namespace UniversityRating.Data.Repositories
{
    public class CommentRepository : Repository<Comment> , ICommentRepository
    {
        public CommentRepository(DbContext context) : base(context)
        {
        }

        public void AddCommentUniversity(CommentUniversity commentUniversity)
        {
            Add(commentUniversity);
            SaveChanges();
        }

        public void AddCommentTeacher(CommentTeacher commentTeacher)
        {
            Add(commentTeacher);
            SaveChanges();
        }

        public void AddCommentCourse(CommentCourse commentCourse)
        {
            Add(commentCourse);
            SaveChanges();
        }

        public void AddCommentCourseTeacher(CommentCourseTeacher commentCourseTeacher)
        {
            Add(commentCourseTeacher);
            SaveChanges();
        }

        public List<CommentUniversity> GetCommentUniversitiesByUserId(long id)
        {
            return BuildQuery()
                .Where(x => x.UserId.Equals(id))
                .Select(x => new CommentUniversity
                {
                    Message = x.Message,
                    Subject = x.Subject,
                })
                .ToList();
        }

        public List<CommentView> GetUniversityComments(int pageNumber, long universityId, int numberOfRecordsPerPage = 10, bool skipRecords = true)
        {
            if (universityId.Equals(0))
            {
                var qq = BuildQuery()
                    .Select(x => new CommentView()
                    {
                        Id = x.Id,
                        Subject = x.Subject,
                        Message = x.Message,
                        UserName = x.User.LastName,
                        Type = x.Subject
                    }).ToList();
                return qq;
            }
            return new List<CommentView>();
        }
    }
}