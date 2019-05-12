using AutoMapper;
using Microsoft.EntityFrameworkCore.Internal;
using System.Linq;
using UniversityRating.Data.Abstractions.Models.Comment;
using UniversityRating.Data.Abstractions.Models.Teacher;
using UniversityRating.Data.Abstractions.Models.University;
using UniversityRating.Data.Core.DomainModels;
using UniversityRating.Services.Common.DTOs.Comment;
using UniversityRating.Services.Common.DTOs.Mark;
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
            CreateMap<CommentTeacher, CommentTeacherDto>()
                .ForMember(x => x.UniversityId, opt => opt.Ignore());

            CreateMap<MarkTeacher, EditMarkTeacherDto>()
                .ForMember(x => x.TeacherName, opt => opt.MapFrom(y => y.Teacher.FirstName + " " + y.Teacher.LastName))
                .ForMember(x => x.UniversityId,
                    opt => opt.MapFrom(y => y.Teacher.UniversityTeachers.Select(x => x.UniversityId).FirstOrDefault()))
                .ForMember(x => x.UniversityName,
                    opt => opt.MapFrom(
                        y => y.Teacher.UniversityTeachers.Select(x => x.University.Name).FirstOrDefault()))
                .ForMember(x => x.Mark, opt => opt.MapFrom(y => y.Value));

            CreateMap<MarkCourse, EditMarkCourseDto>()
                .ForMember(x => x.Mark, opt => opt.MapFrom(y => y.Value))
                .ForMember(x => x.CourseName, opt => opt.MapFrom(y => y.Course.Name))
                .ForMember(x => x.UniversityName, opt => opt.MapFrom( y => y.Course.Faculty.University.Name))
                .ForMember(x => x.UniversityId, opt => opt.MapFrom(y => y.Course.Faculty.University.Id));

            CreateMap<MarkCourseTeacher, EditMarkCourseTeacherDto>()
                .ForMember(x => x.Mark, opt => opt.MapFrom(y => y.Value))
                .ForMember(x => x.CourseId, opt => opt.MapFrom(y => y.CourseTeacher.CourseId))
                .ForMember(x => x.CourseName, opt => opt.MapFrom(y => y.CourseTeacher.Course.Name))
                .ForMember(x => x.UniversityId, opt => opt.MapFrom(y => y.CourseTeacher.Course.Faculty.University.Id))
                .ForMember(x => x.UniversityName, opt => opt.MapFrom(y => y.CourseTeacher.Course.Faculty.University.Name));

            CreateMap<CommentUniversity, CommentDto>()
                .ForMember(x => x.UserName, opt => opt.MapFrom(y => y.User.Email))
                .ForMember(x => x.Type, opt => opt.MapFrom(y => y.University.Name));

            CreateMap<CommentCourse, CommentDto>()
                .ForMember(x => x.UserName, opt => opt.MapFrom(y => y.User.Email))
                .ForMember(x => x.Type, opt => opt.MapFrom(y => y.Course.Description));

            CreateMap<CommentTeacher, CommentDto>()
                .ForMember(x => x.UserName, opt => opt.MapFrom(y => y.User.Email))
                .ForMember(x => x.Type,
                    opt => opt.MapFrom(y =>
                        y.Teacher.UniversityTeachers.Select(x => x.University.Name).FirstOrDefault() + " " +
                        y.Teacher.FirstName + y.Teacher.LastName));

            CreateMap<CommentCourseTeacher, CommentDto>()
                .ForMember(x => x.UserName, opt => opt.MapFrom(y => y.User.Email))
                .ForMember(x => x.Type,
                    opt => opt.MapFrom(y =>
                        y.CourseTeacher.Course.Faculty.University.Name + " " + y.CourseTeacher.Teacher.FirstName + " " +
                        y.CourseTeacher.Teacher.LastName + " " + y.CourseTeacher.Course.Description));

            CreateMap<Teacher, TeacherShowDto>()
                .ForMember(x => x.AverageMarks,
                    opt => opt.MapFrom(y =>
                        y.MarkTeachers.Any() ? y.MarkTeachers.AsQueryable().Average(x => x.Value) : 0))
                .ForMember(x => x.Universities, opt => opt.MapFrom(y => y.UniversityTeachers.Select(z => z.University.Name)));
        }
    }
}