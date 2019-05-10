using System.Collections.Generic;
using UniversityRating.Services.Common.DTOs.Teacher;

namespace UniversityRating.Services.Abstractions
{
    public interface ITeacherService
    {
        List<TopTeacherDto> GetTopTeachers(int numberOfTeachers);

        List<TeacherShowDto> GetAllTeachers();

        List<TeacherShowDto> GetAllTeachersByUniversityId(long universityId);

        List<TeacherShowDto> GetAllTeachersWithoutUniversity();

        void Update(TeacherDto teacherDto);

        void DeleteTeacherById(int id);

        void AddTeacher(TeacherDto teacherDto);

        List<TeacherShowDto> GetAllTeachersByUniversityId(long universityId, int pageNumber, string search, int numberOfRecordsPerPage, bool skipRecords);
    }
}