using AutoMapper;
using UniversityRating.Presentation.Models.Comment;
using UniversityRating.Services.Common.DTOs.Comment;

namespace UniversityRating.Infrastructure.Profiles
{
    public class ViewModelToDtoProfile : Profile
    {
        public ViewModelToDtoProfile()
        {
            CreateMap<CommentUniversityShowViewModel, CommentUniversityShowDto>();
        }
    }
}