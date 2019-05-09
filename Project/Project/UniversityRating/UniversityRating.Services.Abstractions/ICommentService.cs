using System;
using System.Collections.Generic;
using System.Text;
using UniversityRating.Services.Common.DTOs.Comment;

namespace UniversityRating.Services.Abstractions
{
    public interface ICommentService
    {
        void AddCommentUniversity(CommentUniversityDto commentUniversity);

        void AddCommentTeacher(CommentTeacherDto commentTeacherDto);

        void AddCommentCourse(CommentCourseDto commentCourseDto);

        void AddCommentCourseTeacher(CommentCourseTeacherDto commentCourseTeacherDto);

        List<CommentUniversityDto> GetCommentUniversitiesByUserId(long id);

        List<CommentCourseDto> GetCommentCourseByUserId(long id);

        List<CommentTeacherDto> GetCommentTeachersByUserId(long id);

        List<CommentCourseTeacherDto> GetCommentCourseTeachersByUserId(long id);

        void DeleteCommentById(long id);

        EditCommentDto GetCommentById(long id);

        void UpdateComment(EditCommentDto comment);

        List<CommentDto> GetUniversityComments(int pageNumber, long universityId, int numberOfRecordsPerPage = 10, bool skipRecords = true);

        List<CommentDto> GetCourseComments(int pageNumber, long courseId, int numberOfRecordsPerPage = 10, bool skipRecords = true);

        List<CommentDto> GetTeacherComments(int pageNumber, long teacherId, int numberOfRecordsPerPage = 10, bool skipRecords = true);

        List<CommentDto> GetCourseTeacherComments(int pageNumber, long courseId, long teacherId, int numberOfRecordsPerPage = 10, bool skipRecords = true);
    }
}

