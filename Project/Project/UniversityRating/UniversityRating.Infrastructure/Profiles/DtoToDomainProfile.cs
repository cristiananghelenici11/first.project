using AutoMapper;
using UniversityRating.Data.Abstractions.Models.Comment;
using UniversityRating.Data.Core.DomainModels;
using UniversityRating.Services.Common.DTOs.Comment;

namespace UniversityRating.Infrastructure.Profiles
{
    public class DtoProfileToDomain : Profile
    {

        public DtoProfileToDomain()
        {
            CreateMap<CommentUniversityShowDto, CommentUniversity>();
        }
        
    }
}