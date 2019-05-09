using AutoMapper;
using UniversityRating.Data.Abstractions.Models.Comment;
using UniversityRating.Data.Abstractions.Models.Teacher;
using UniversityRating.Data.Abstractions.Models.University;
using UniversityRating.Data.Core.DomainModels;
using UniversityRating.Services.Common.DTOs.Comment;
using UniversityRating.Services.Common.DTOs.Teacher;
using UniversityRating.Services.Common.DTOs.University;

namespace UniversityRating.Presentation.Profiles
{
    public class DomainToDtoProfile : Profile
    {
        public DomainToDtoProfile()
        {
            CreateMap<TopTeacher, TopTeacherDto>();
            CreateMap<TeacherShow, TeacherShowDto>();

            CreateMap<TopUniversity, TopUniversityDto>();
            CreateMap<UniversityShow, UniversityShowDto>();

            CreateMap<CommentUniversityShow, CommentUniversityShowDto>();

            CreateMap<CommentUniversity, CommentUniversityDto>();
            CreateMap<CommentCourse, CommentCourseDto>()
                .ForMember(x => x.UniversityId, opt => opt.Ignore());

            CreateMap<Comment, EditCommentDto>();

            CreateMap<CommentView, CommentDto>();

            CreateMap<CommentCourseTeacher, CommentCourseTeacherDto>()
                .ForMember(x => x.CourseId, opt => opt.MapFrom(y => y.CourseTeacher.CourseId))
                .ForMember(x => x.TeacherId, opt => opt.MapFrom(y => y.CourseTeacher.TeacherId))
                .ForMember(x => x.UniversityId, opt => opt.MapFrom(y => y.CourseTeacher.Course.Faculty.UniversityId));
        }

    }
}