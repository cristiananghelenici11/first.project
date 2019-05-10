using AutoMapper;
using UniversityRating.Data.Abstractions.Models.Comment;
using UniversityRating.Data.Core.DomainModels;
using UniversityRating.Services.Common.DTOs.Comment;
using UniversityRating.Services.Common.DTOs.Mark;
using UniversityRating.Services.Common.DTOs.Teacher;
using UniversityRating.Services.Common.DTOs.University;

namespace UniversityRating.Infrastructure.Profiles
{
    public class DtoProfileToDomain : Profile
    {

        public DtoProfileToDomain()
        {
            CreateMap<CommentUniversityShowDto, CommentUniversity>();

            CreateMap<EditMarkDto, Mark>();

            CreateMap<CommentDto, CommentView>();

            CreateMap<UniversityDto, University>()
                .ForMember(x => x.Address, opt => opt.Ignore());

            CreateMap<TeacherDto, Teacher>()
                .ForMember(x => x.Idnp, opt => opt.Ignore())
                .ForMember(x => x.Phone, opt => opt.Ignore());
        }
    }
}