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

        List<CommentUniversity> GetCommentUniversitiesByUserId(long id);

        List<CommentView> GetUniversityComments(int pageNumber, long universityId, int numberOfRecordsPerPage = 10, bool skipRecords = true);
    }
}