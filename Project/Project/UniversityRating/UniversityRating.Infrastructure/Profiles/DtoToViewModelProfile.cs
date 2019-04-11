using AutoMapper;
using UniversityRating.Presentation.Models.Teacher;
using UniversityRating.Services.Common.DTOs.Teacher;

namespace UniversityRating.Infrastructure.Profiles
{
    public class DtoToViewModelProfile : Profile
    {
        public DtoToViewModelProfile()
        {
            CreateMap<TopTeacherDto, TopTeacherViewModel>();
        }
    }
}