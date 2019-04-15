using System.Collections.Generic;
using AutoMapper;
using UniversityRating.Data.Abstractions.Models.Comment;
using UniversityRating.Data.Abstractions.Repositories;
using UniversityRating.Services.Abstractions;
using UniversityRating.Services.Common.DTOs.Comment;

namespace UniversityRating.Services.CommentService
{

    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public CommentService(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public List<CommentUniversityShowDto> GetCommentsByUniversityId(long universityId)
        {
            List<CommentUniversityShow> commentUniversityShows =
                _commentRepository.GetCommentsByUniversityId(universityId);


            return _mapper.Map<List<CommentUniversityShow>, List<CommentUniversityShowDto>>(commentUniversityShows);
        }
    }
}