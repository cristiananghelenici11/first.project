using AutoMapper;
using UniversityRating.Presentation.Models.Comment;
using UniversityRating.Presentation.Models.Mark;
using UniversityRating.Services.Common.DTOs.Comment;
using UniversityRating.Services.Common.DTOs.Mark;

namespace UniversityRating.Infrastructure.Profiles
{
    public class ViewModelToDtoProfile : Profile
    {
        public ViewModelToDtoProfile()
        {
            CreateMap<CommentUniversityShowViewModel, CommentUniversityShowDto>();

            CreateMap<MarkTeacherViewModel, MarkTeacherDto>();

            CreateMap<MarkCourseViewModel, MarkCourseDto>();

            CreateMap<CommentTeacherViewModel, CommentTeacherDto>();

            CreateMap<CommentUniversityViewModel, CommentUniversityDto>();

            CreateMap<CommentCourseTeacherViewModel, CommentCourseTeacherDto>();

            CreateMap<CommentCourseViewModel, CommentCourseDto>();
        }
    }
}