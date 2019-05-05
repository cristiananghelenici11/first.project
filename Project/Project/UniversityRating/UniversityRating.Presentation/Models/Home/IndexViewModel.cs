﻿using System.Collections.Generic;
using UniversityRating.Presentation.Models.Comment;
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
        public List<CommentUniversityViewModel> CommentUniversityViewModels { get; set; }
        public List<CommentCourseViewModel> CommentCourseViewModels { get; set; }
        public List<CommentTeacherViewModel> CommentTeacherViewModels { get; set; }
        public List<CommentCourseTeacherViewModel> CommentCourseTeacherViewModels { get; set; }

    }
}