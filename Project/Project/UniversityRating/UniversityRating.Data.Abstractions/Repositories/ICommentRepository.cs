using System.Collections.Generic;
using UniversityRating.Data.Abstractions.Models.Comment;
using UniversityRating.Data.Core.DomainModels;

namespace UniversityRating.Data.Abstractions.Repositories
{
    public interface ICommentRepository : IRepository<Comment>
    {
        void AddCommentUniversity(CommentUniversity commentUniversity);

        void AddCommentTeacher(CommentTeacher commentTeacher);

        void AddCommentCourse(CommentCourse commentCourse);

        void AddCommentCourseTeacher(CommentCourseTeacher commentCourseTeacher);

        void UpdateComment(Comment comment);

        List<CommentUniversity> GetCommentUniversitiesByUserId(long id);

        List<CommentCourse> GetCommentCourseByUserId(long id);

        List<CommentTeacher> GetCommentTeachersByUserId(long id);

        List<CommentCourseTeacher> GetCommentCourseTeachersByUserId(long id);

        void DeleteCommentById(long id);
    }
}