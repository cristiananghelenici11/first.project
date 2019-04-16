using System.Collections.Generic;
using UniversityRating.Data.Abstractions.Models.Comment;
using UniversityRating.Data.Core.DomainModels;

namespace UniversityRating.Data.Abstractions.Repositories
{
    public interface ICommentRepository : IRepository<CommentUniversity>
    {
        List<CommentUniversityShow> GetCommentsByUniversityId(long universityId);
        void AddCommentUniversity(CommentUniversityShow commentUniversity);
    }
}