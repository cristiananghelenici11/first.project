using AutoMapper;
using UniversityRating.Data.Abstractions.Models;
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
            CreateMap<TopUniversity, TopUniversityDto>();
            CreateMap<TeacherShow, TeacherShowDto>();
        }
        
    }
}