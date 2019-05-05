using UniversityRating.Services.Common.DTOs.Mark;

namespace UniversityRating.Services.Abstractions
{
    public interface IMarkService
    {
        void AddMarkTeacher(MarkTeacherDto markTeacher);
        void AddMarkCourse(MarkCourseDto markTeacher);
        void AddMarkCourseTeacher(MarkCourseTeacherDto markCourseTeacher);
    }
}