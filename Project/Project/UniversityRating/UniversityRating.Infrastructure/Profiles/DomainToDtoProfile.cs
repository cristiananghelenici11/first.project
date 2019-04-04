using AutoMapper;
using UniversityRating.Data.Core.DomainModels;
using UniversityRating.Services.Common.DTOs.Comment;
using UniversityRating.Services.Common.DTOs.Mark;

namespace UniversityRating.Infrastructure.Profiles
{
    public class DomainToDtoProfile : Profile
    {
        public DomainToDtoProfile()
        {
            CreateMap<Comment, CommentDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Message, opt => opt.MapFrom(src => src.Message))
                .ForMember(dest => dest.Subject, opt => opt.MapFrom(src => src.Subject))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.Customer));

            CreateMap<CommentCourse, CommentCourseDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Subject, opt => opt.MapFrom(src => src.Subject))
                .ForMember(dest => dest.Message, opt => opt.MapFrom(dest => dest.Message))
                .ForMember(dest => dest.Course, opt => opt.MapFrom(src => src.Course))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.Customer));

            CreateMap<CommentTeacher, CommentTeacherDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Subject, opt => opt.MapFrom(src => src.Subject))
                .ForMember(dest => dest.Message, opt => opt.MapFrom(dest => dest.Message))
                .ForMember(dest => dest.Teacher, opt => opt.MapFrom(src => src.Teacher))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.Customer));

            CreateMap<CommentUniversity, CommentUniversityDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Subject, opt => opt.MapFrom(src => src.Subject))
                .ForMember(dest => dest.Message, opt => opt.MapFrom(dest => dest.Message))
                .ForMember(dest => dest.University, opt => opt.MapFrom(src => src.University))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.Customer));

            CreateMap<CommentCourseTeacher, CommentCourseTeacherDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Subject, opt => opt.MapFrom(src => src.Subject))
                .ForMember(dest => dest.Message, opt => opt.MapFrom(dest => dest.Message))
                .ForMember(dest => dest.CourseTeacher, opt => opt.MapFrom(src => src.CourseTeacher))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.Customer));

            CreateMap<Mark, MarkDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.Customer));

            CreateMap<MarkCourse, MarkCourseDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.Customer))
                .ForMember(dest => dest.Course, opt => opt.MapFrom(src => src.Course));

            CreateMap<MarkTeacher, MarkTeacherDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.Customer))
                .ForMember(dest => dest.Teacher, opt => opt.MapFrom(src => src.Teacher));

            CreateMap<MarkCourseTeacher, MarkCourseTeacherDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.Customer))
                .ForMember(dest => dest.CourseTeacher, opt => opt.MapFrom(src => src.CourseTeacher));
        }
        
    }
}