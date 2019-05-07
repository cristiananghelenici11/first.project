using AutoMapper;
using UniversityRating.Presentation.Models.Comment;
using UniversityRating.Presentation.Models.Mark;
using UniversityRating.Presentation.Models.Teacher;
using UniversityRating.Presentation.Models.University;
using UniversityRating.Services.Common.DTOs.Comment;
using UniversityRating.Services.Common.DTOs.Mark;
using UniversityRating.Services.Common.DTOs.Teacher;
using UniversityRating.Services.Common.DTOs.University;

namespace UniversityRating.Presentation.Profiles
{
    public class DtoToViewModelProfile : Profile
    {
        public DtoToViewModelProfile()
        {
            CreateMap<TopTeacherDto, TopTeacherViewModel>();
            CreateMap<TeacherShowDto, TeacherShowViewModel>();

            CreateMap<TopUniversityDto, TopUniversityViewModel>();
            CreateMap<UniversityShowDto, UniversityShowViewModel>();

            CreateMap<CommentUniversityShowDto, CommentUniversityShowViewModel>();

            CreateMap<CommentUniversityDto, CommentUniversityViewModel>();
            CreateMap<CommentCourseDto, CommentCourseViewModel>();
            CreateMap<CommentCourseTeacherDto, CommentCourseTeacherViewModel>();

            CreateMap<EditMarkDto, EditMarkViewModel>();

        }
    }
}