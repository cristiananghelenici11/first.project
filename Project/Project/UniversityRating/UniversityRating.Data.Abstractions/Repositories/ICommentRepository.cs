using System.Collections.Generic;
using UniversityRating.Data.Abstractions.Models.Comment;
using UniversityRating.Data.Core.DomainModels;

namespace UniversityRating.Data.Abstractions.Repositories
{
    public interface ICommentRepository : IRepository<Comment>
    {
        List<CommentUniversityShow> GetCommentsByUniversityId(long universityId);

        void AddCommentUniversity(CommentUniversity commentUniversity);

        void AddCommentTeacher(CommentTeacher commentTeacher);

        void AddCommentCourse(CommentCourse commentCourse);

        void AddCommentCourseTeacher(CommentCourseTeacher commentCourseTeacher);

        List<CommentUniversity> GetCommentUniversitiesByUserId(long id);
    }
}