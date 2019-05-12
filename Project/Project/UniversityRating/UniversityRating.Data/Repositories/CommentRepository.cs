using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using UniversityRating.Data.Abstractions.Extensions;
using UniversityRating.Data.Abstractions.Interfaces;
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

        public void UpdateComment(Comment comment)
        {
            Update(comment);
            SaveChanges();
        }

        public List<CommentUniversity> GetCommentUniversitiesByUserId(long id)
        {
            var spec = new Specification<Comment> {Predicate = user => user.UserId.Equals(id)};
            spec.Include(x => x.User);
            IQueryable<CommentUniversity> commentUniversities = BuildQuery(spec).OfType<CommentUniversity>();

            return commentUniversities.ToList();
        }

        public List<CommentCourse> GetCommentCourseByUserId(long id)
        {
            var spec = new Specification<Comment> {Predicate = user => user.UserId.Equals(id)};
            spec.Include(x => x.User);
            IQueryable<CommentCourse> commentCourses = BuildQuery(spec).OfType<CommentCourse>();

            return commentCourses.ToList();
        }

        public List<CommentTeacher> GetCommentTeachersByUserId(long id)
        {
            var spec = new Specification<Comment> {Predicate = user => user.UserId.Equals(id)};
            spec.Include(x => x.User);
            IQueryable<CommentTeacher> commentTeachers = BuildQuery(spec).OfType<CommentTeacher>();

            return commentTeachers.ToList();
        }

        public List<CommentCourseTeacher> GetCommentCourseTeachersByUserId(long id)
        {
            var spec = new Specification<Comment> {Predicate = teacher => teacher.User.Id == id};
            spec.Include(x => x.User);
            IQueryable<CommentCourseTeacher> commentCourseTeachers = BuildQuery(spec).OfType<CommentCourseTeacher>();
            
            return commentCourseTeachers.ToList();
        }

        public void DeleteCommentById(long id)
        {
            Comment comment = GetById(id);
            if (comment == null) return;
            Remove(comment);
            SaveChanges();
        }
    }
}

