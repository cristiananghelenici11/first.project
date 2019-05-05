using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UniversityRating.Data.Core.DomainModels.Identity;
using UniversityRating.Presentation.Models.Comment;
using UniversityRating.Presentation.Models.Home;
using UniversityRating.Presentation.Models.University;
using UniversityRating.Services.Abstractions;
using UniversityRating.Services.Common.DTOs.Comment;
using UniversityRating.Services.Common.DTOs.University;

namespace UniversityRating.Presentation.Controllers
{
    public class CommentController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICommentService _commentService;
        private IUniversityService _universityService;
        private SignInManager<User> _signInManager;

        public CommentController(
            IMapper mapper, 
            ICommentService commentService, 
            IUniversityService universityService,
            SignInManager<User> signInManager)
        {
            _mapper = mapper;
            _commentService = commentService;
            _universityService = universityService;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            List<UniversityShowDto> universities = _universityService.GetAllUniversities();

            return View(new IndexViewModel
            {
                UniversityShowViewModels = _mapper.Map<List<UniversityShowDto>, List<UniversityShowViewModel>>(universities)
            });
        }

        [HttpPost]
        public IActionResult AddCommentTeacher(CommentTeacherViewModel commentTeacherViewModel)
        {
            if (!ModelState.IsValid) return Content(JsonConvert.SerializeObject("Not valid"));

            commentTeacherViewModel.UserId = Convert.ToInt32(_signInManager.UserManager.GetUserId(User));
            _commentService.AddCommentTeacher(_mapper.Map<CommentTeacherViewModel, CommentTeacherDto>(commentTeacherViewModel));

            string result = JsonConvert.SerializeObject($"{commentTeacherViewModel.UniversityId} , {commentTeacherViewModel.TeacherId}, {commentTeacherViewModel.Subject}, {commentTeacherViewModel.Message}");
            return Content(result, "application/json");

        }

        [HttpPost]
        public IActionResult AddCommentUniversity(CommentUniversityViewModel commentUniversityViewModel)
        {
            if (!ModelState.IsValid) return Content(JsonConvert.SerializeObject("Not valid"));

            commentUniversityViewModel.UserId = Convert.ToInt32(_signInManager.UserManager.GetUserId(User));
            _commentService.AddCommentUniversity(_mapper.Map<CommentUniversityViewModel, CommentUniversityDto>(commentUniversityViewModel));

            string result = JsonConvert.SerializeObject($"{commentUniversityViewModel.UniversityId}, {commentUniversityViewModel.Subject}, {commentUniversityViewModel.Message}");
            return Content(result, "application/json");
        }

        [HttpPost]
        public IActionResult AddCommentCourse(CommentCourseViewModel commentCourseViewModel)
        {
            if (!ModelState.IsValid) return Content(JsonConvert.SerializeObject("Not valid"));

            commentCourseViewModel.UserId = Convert.ToInt32(_signInManager.UserManager.GetUserId(User));;
            _commentService.AddCommentCourse(_mapper.Map<CommentCourseViewModel, CommentCourseDto>(commentCourseViewModel));
            
            string result = JsonConvert.SerializeObject($"{commentCourseViewModel.UniversityId} {commentCourseViewModel.CourseId}, {commentCourseViewModel.Subject}, {commentCourseViewModel.Message}");
            return Content(result, "application/json");
        }

        [HttpPost]
        public IActionResult AddCommentCourseTeacher(CommentCourseTeacherViewModel commentCourseTeacherView)
        {
            if (!ModelState.IsValid) return Content(JsonConvert.SerializeObject("Not valid"));
            
            commentCourseTeacherView.UserId = Convert.ToInt32(_signInManager.UserManager.GetUserId(User));
            _commentService.AddCommentCourseTeacher(_mapper.Map<CommentCourseTeacherViewModel, CommentCourseTeacherDto>(commentCourseTeacherView));

            string result = JsonConvert.SerializeObject($"{commentCourseTeacherView.UniversityId}, {commentCourseTeacherView.TeacherId}, {commentCourseTeacherView.CourseId}, {commentCourseTeacherView.Subject}, {commentCourseTeacherView.Message}");
            return Content(result, "application/json");
        }

        








        public ActionResult GetData()
        {
            List<CommentUniversityShowDto> commentUniversityShowDtos = _commentService.GetCommentsByUniversityId(2);

            return Json(new { data = commentUniversityShowDtos });

        }
        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new CommentUniversityShowDto());

            List<CommentUniversityShowDto> commentUniversityShowDtos = _commentService.GetCommentsByUniversityId(2);

            return View(commentUniversityShowDtos.FirstOrDefault(x => x.UniversityId == id));

        }

        [HttpPost]
        public ActionResult AddOrEdit(CommentUniversityShowViewModel comment)
        {
            if (comment.UniversityId == null)
            {
                comment.UniversityId = 2;
                comment.UserId = 1;
                //_commentService.AddCommentUniversity(_mapper.Map<CommentUniversityShowViewModel, CommentUniversityShowDto>(comment));
                return Json(new { success = true, message = "Saved Successfully" });
            }
            return Json(new { success = true, message = "Saved Successfully" });
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            int h = id;
            Console.WriteLine(h);
            return Json(new { success = true, message = "Deleted Successfully" });
        }

    }
}