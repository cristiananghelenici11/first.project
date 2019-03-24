using UniversityRating.BLL.DTO;
using UniversityRating.DAL.Context;
using UniversityRating.DAL.Models;
using UniversityRating.DAL.Repositories;

namespace UniversityRating.BLL.Services
{
    public class UserService
    {
        public void AddUser(UserDto newUser)
        {
            var user = new UniversityRatingRepository<User>(new UniversityRatingContext());
            user.Create(newUser);
        }
    }
}