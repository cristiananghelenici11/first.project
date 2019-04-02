//using System;
//using System.Collections.Generic;
//using System.Text;
//using UniversityRating.DAL.Models;
//
//namespace UniversityRating.BLL.DTO
//{
//    public class UserDto
//    {
//        public string UserName { get; set; }
//        public string Password { get; set; }
//        public string FirstName { get; set; }
//        public string LastName { get; set; }
//        public long Idnp { get; set; }
//        public string Phone { get; set; }
//        public string Email { get; set; }
//
//        public static implicit operator User(UserDto user)
//        {
//            return new User
//            {
//                FirstName = user.FirstName,
//                LastName = user.LastName,
//                UserName = user.UserName,
//                Idnp = user.Idnp,
//                Phone = user.Phone,
//                Email = user.Email,
//                Password = user.Password
//            };
//        }
//    }
//}
