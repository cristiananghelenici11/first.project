using System;
using System.Collections.Generic;
using System.Text;
using UniversityRating.Services.Common.DTOs.Comment;

namespace UniversityRating.Services.Abstractions
{
    public interface ICommentService
    {
        List<CommentUniversityShowDto> GetCommentsByUniversityId(long universityId);

        void AddCommentUniversity(CommentUniversityDto commentUniversity);

        void AddCommentTeacher(CommentTeacherDto commentTeacherDto);

        void AddCommentCourse(CommentCourseDto commentCourseDto);

        void AddCommentCourseTeacher(CommentCourseTeacherDto commentCourseTeacherDto);
    }
}
