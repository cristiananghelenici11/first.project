

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
    }
}