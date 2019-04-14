//
//
//using System.Collections.Generic;
//using System.Linq;
//using Microsoft.EntityFrameworkCore;
//using UniversityRating.Data.Abstractions.Models.Comment;
//using UniversityRating.Data.Abstractions.Repositories;
//using UniversityRating.Data.Core.DomainModels;
//
//namespace UniversityRating.Data.Repositories
//{
//    public class CommentRepository : Repository<CommentUniversity> , ICommentRepository
//    {
//        public CommentRepository(DbContext context) : base(context)
//        {
//        }
//
//        public List<CommentUniversityShow> GetCommentsByUniversityId(long universityId)
//        {
//            return BuildQuery()
//                .Where(x => x.UniversityId == universityId)
//                .Select(c => new CommentUniversityShow
//                {
//                    Subject = c.Subject,
//                    Message = c.Message,
//                    UniversityId = c.UniversityId,
//                    UserId = c.UserId
//                })
//                .ToList();
//        }
//    }
//}