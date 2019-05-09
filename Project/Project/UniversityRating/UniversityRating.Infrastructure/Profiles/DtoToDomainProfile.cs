using AutoMapper;
using UniversityRating.Data.Abstractions.Models.Comment;
using UniversityRating.Data.Core.DomainModels;
using UniversityRating.Services.Common.DTOs.Comment;
using UniversityRating.Services.Common.DTOs.Mark;

namespace UniversityRating.Infrastructure.Profiles
{
    public class DtoProfileToDomain : Profile
    {

        public DtoProfileToDomain()
        {
            CreateMap<CommentUniversityShowDto, CommentUniversity>();
            CreateMap<EditMarkDto, Mark>();
            CreateMap<CommentDto, CommentView>();
        }
    }
}