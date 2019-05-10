using System.Collections.Generic;
using UniversityRating.Services.Common.DTOs.Mark;

namespace UniversityRating.Services.Abstractions
{
    public interface IMarkService
    {
        void AddMarkTeacher(MarkTeacherDto markTeacher);

        void AddMarkCourse(MarkCourseDto markTeacher);

        void AddMarkCourseTeacher(MarkCourseTeacherDto markCourseTeacher);

        List<EditMarkTeacherDto> GetMarkTeacherByUserId(long currentUser);

        void DeleteMarkById(long id);

        EditMarkDto GetMarkById(long id);

        void UpdateMark(EditMarkDto editMarkDto);

        List<EditMarkCourseDto> GetMarkCourseByUserId(long id);

        List<EditMarkCourseTeacherDto> GetMarkCourseTeacherByUserId(long id);
    }
}