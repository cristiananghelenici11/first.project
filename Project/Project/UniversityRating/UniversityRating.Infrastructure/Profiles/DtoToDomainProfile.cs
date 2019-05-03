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
            //CreateMap<MarkTeacherDto, MarkTeacher>()
            //    .ForMember(x => x.TeacherId, y => y.MapFrom(z => z.TeacherId))
            //    .ForMember(x => x.UserId, y => y.MapFrom(z => z.UserId))
            //    .ForMember(x => x.Value, y => y.MapFrom(z => z.Mark))
            //    .ForAllOtherMembers(y => y.Ignore());
            
        }
        
    }
}