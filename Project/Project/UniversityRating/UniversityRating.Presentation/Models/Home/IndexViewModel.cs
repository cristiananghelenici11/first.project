using System.Collections.Generic;
using UniversityRating.Presentation.Models.Teacher;
using UniversityRating.Presentation.Models.University;

namespace UniversityRating.Presentation.Models.Home
{
    public class IndexViewModel
    {
        public List<TopTeacherViewModel> TopTeachers { get; set; }
        public List<TopUniversityViewModel> TopUniversities { get; set; }
        public List<TeacherShowViewModel> TeacherShows { get; set; }
        public List<UniversityShowViewModel> UniversityShowViewModels { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}