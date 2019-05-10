

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
        private readonly IRepository<CommentUniversity> _commentUniversityRepository;

        public CommentRepository(DbContext context, IRepository<CommentUniversity> commentUniversityRepository) : base(context)
        {
            _commentUniversityRepository = commentUniversityRepository;
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
            //var a = GetAll().OfType<CommentUniversity>().Select(x=>x.UniversityId);
            return new List<CommentView>();
        }
    }
}

