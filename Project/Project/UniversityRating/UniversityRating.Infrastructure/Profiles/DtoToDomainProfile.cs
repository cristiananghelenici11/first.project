using AutoMapper;
using UniversityRating.Data.Abstractions.Models.Comment;
using UniversityRating.Data.Core.DomainModels;
using UniversityRating.Services.Common.DTOs.Comment;
using UniversityRating.Services.Common.DTOs.Mark;
using UniversityRating.Services.Common.DTOs.Teacher;
using UniversityRating.Services.Common.DTOs.University;

namespace UniversityRating.Infrastructure.Profiles
{
    public class DtoProfileToDomain : Profile
    {

        public DtoProfileToDomain()
        {
            CreateMap<CommentUniversityShowDto, CommentUniversity>();

            CreateMap<EditMarkDto, Mark>();

            CreateMap<CommentDto, CommentView>();

            CreateMap<UniversityDto, University>()
                .ForMember(x => x.Address, opt => opt.Ignore());

            CreateMap<TeacherDto, Teacher>()
                .ForMember(x => x.Idnp, opt => opt.Ignore())
                .ForMember(x => x.Phone, opt => opt.Ignore());

            CreateMap<CommentCourseDto, CommentUniversity>()
                .ForMember(x => x.User, opt => opt.Ignore())
                .ForMember(x => x.UniversityId, opt => opt.MapFrom(y => y.UniversityId))
                .ForMember(x => x.UserId, opt => opt.MapFrom(y => y.UserId))
                .ForMember(x => x.Id, opt => opt.MapFrom(y => y.Id))
                .ForMember(x => x.Message, opt => opt.MapFrom(y => y.Message))
                .ForMember(x => x.Subject, opt => opt.MapFrom(y => y.Subject))
                .ForMember(x => x.University, opt => opt.Ignore());

            CreateMap<CommentTeacherDto, CommentTeacher>();

            CreateMap<CommentCourseDto, CommentCourse>();

            CreateMap<CommentCourseTeacherDto, CommentCourseTeacher>();

            CreateMap<EditCommentDto, Comment>()
                .ForMember(x => x.User, opt => opt.Ignore());

            CreateMap<MarkTeacherDto, MarkTeacher>()
                .ForMember(x => x.Teacher, opt => opt.Ignore())
                .ForMember(x => x.User, opt => opt.Ignore())
                .ForMember(x => x.Value, opt => opt.MapFrom(y => y.Mark));

            CreateMap<MarkCourseDto, MarkCourse>()
                .ForMember(x => x.Course, opt => opt.Ignore())
                .ForMember(x => x.User, opt => opt.Ignore())
                .ForMember(x => x.Value, opt => opt.MapFrom(y => y.Mark));

            CreateMap<MarkCourseTeacherDto, MarkCourseTeacher>()
                .ForMember(x => x.CourseTeacher, opt => opt.Ignore())
                .ForMember(x => x.User, opt => opt.Ignore())
                .ForMember(x => x.Value, opt => opt.MapFrom(y => y.Mark));
        }
    }
}