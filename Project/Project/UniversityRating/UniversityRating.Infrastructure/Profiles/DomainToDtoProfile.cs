using AutoMapper;
using Microsoft.EntityFrameworkCore.Internal;
using System.Linq;
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

            CreateMap<Teacher, TeacherShow>()
                .ForMember(x => x.AverageMarks, opt => opt.MapFrom(y => y.MarkTeachers.Any() ? y.MarkTeachers.Average(x => x.Value) : 0))
                .ForMember(x => x.Universities, opt => opt.MapFrom(y => y.UniversityTeachers.Select(x => x.University.Name)));

            CreateMap<Teacher, TopTeacher>()
                .ForMember(x => x.MarkAvg,
                    opt => opt.MapFrom(y =>
                        y.MarkTeachers.Any() ? y.MarkTeachers.AsQueryable().Average(x => x.Value) : 0));

            CreateMap<University, UniversityShow>()
                .ForMember(x => x.AverageMark, opt => opt.MapFrom(u => u.UniversityTeachers.Any()
                    ? u.UniversityTeachers.Where(z => z.Teacher.MarkTeachers.Count > 0).Average(x =>
                        x.Teacher.MarkTeachers.Any()
                            ? x.Teacher.MarkTeachers.Average(y => y.Value)
                            : 0)
                    : 0));

            CreateMap<University, TopUniversity>()
                .ForMember(x => x.AvgMark, opt => opt.MapFrom(u => u.UniversityTeachers.Any()
                    ? u.UniversityTeachers.Where(z => z.Teacher.MarkTeachers.Count > 0).Average(x =>
                        x.Teacher.MarkTeachers.Any()
                            ? x.Teacher.MarkTeachers.Average(y => y.Value)
                            : 0)
                    : 0));
        }
    }
}