using AutoMapper;
using UniversityRating.Data.Abstractions.Models;
using UniversityRating.Data.Abstractions.Models.Comment;
using UniversityRating.Data.Abstractions.Models.Teacher;
using UniversityRating.Data.Abstractions.Models.University;
using UniversityRating.Data.Core.DomainModels;
using UniversityRating.Services.Common.DTOs.Comment;
using UniversityRating.Services.Common.DTOs.Mark;
using UniversityRating.Services.Common.DTOs.Teacher;
using UniversityRating.Services.Common.DTOs.University;

namespace UniversityRating.Infrastructure.Profiles
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
        }
        
    }
}