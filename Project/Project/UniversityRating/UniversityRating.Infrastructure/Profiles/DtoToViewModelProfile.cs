using AutoMapper;
using UniversityRating.Presentation.Models.Teacher;
using UniversityRating.Presentation.Models.University;
using UniversityRating.Services.Common.DTOs.Teacher;
using UniversityRating.Services.Common.DTOs.University;

namespace UniversityRating.Infrastructure.Profiles
{
    public class DtoToViewModelProfile : Profile
    {
        public DtoToViewModelProfile()
        {
            CreateMap<TopTeacherDto, TopTeacherViewModel>();
            CreateMap<TopUniversityDto, TopUniversityViewModel>();
            CreateMap<TeacherShowDto, TeacherShowViewModel>();
        }
    }
}