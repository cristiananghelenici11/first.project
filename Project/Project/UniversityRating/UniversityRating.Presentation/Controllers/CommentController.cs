using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        private readonly IUniversityService _universityService;
        private readonly SignInManager<User> _signInManager;

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

        
        public IActionResult AddComment()
        {
            long currentUser = Convert.ToInt32(_signInManager.UserManager.GetUserId(User));

            List<CommentCourseDto> commentCourseDtos = _commentService.GetCommentCourseByUserId(currentUser);
            List<UniversityShowDto> universities = _universityService.GetAllUniversities();
            List<CommentUniversityDto> commentUniversityDtos = _commentService.GetCommentUniversitiesByUserId(currentUser);
            List<CommentTeacherDto> commentTeacherDtos = _commentService.GetCommentTeachersByUserId(currentUser);
            List<CommentCourseTeacherDto> commentCourseTeacherDtos = _commentService.GetCommentCourseTeachersByUserId(currentUser);

            return View(new IndexViewModel
            {
                CommentTeacherViewModels = _mapper.Map<List<CommentTeacherDto>, List<CommentTeacherViewModel>>(commentTeacherDtos),
                CommentCourseViewModels = _mapper.Map<List<CommentCourseDto>, List<CommentCourseViewModel>>(commentCourseDtos),
                CommentUniversityViewModels = _mapper.Map<List<CommentUniversityDto>, List<CommentUniversityViewModel>>(commentUniversityDtos),
                UniversityShowViewModels = _mapper.Map<List<UniversityShowDto>, List<UniversityShowViewModel>>(universities),
                CommentCourseTeacherViewModels = _mapper.Map<List<CommentCourseTeacherDto>, List<CommentCourseTeacherViewModel>>(commentCourseTeacherDtos)
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

        [HttpPost]
        public IActionResult DeleteComment(long id)
        {
            if (!ModelState.IsValid) return Content(JsonConvert.SerializeObject("Not valid"));

            _commentService.DeleteCommentById(id);

            return RedirectToAction("AddComment");
        }

        [HttpGet]
        public IActionResult ViewComment()
        {
            List<UniversityShowDto> universityShowDtos = _universityService.GetAllUniversities();

            return View(new IndexViewModel
            {
                UniversityShowViewModels = 
                    _mapper.Map<List<UniversityShowDto>, List<UniversityShowViewModel>>(universityShowDtos)
            });
        }
        
        [HttpGet]
        public ActionResult EditComment(long id)
        {
            CommentDto commentDto = _commentService.GetCommentById(id);

            EditCommentViewModel model = commentDto == null
                ? new EditCommentViewModel()
                : _mapper.Map<CommentDto, EditCommentViewModel>(commentDto);

            return View(model);
        }
        
        [HttpPost]
        public ActionResult EditComment(EditCommentViewModel model)
        {

            if (!ModelState.IsValid) return View(model);
            _commentService.UpdateComment(_mapper.Map<EditCommentViewModel, CommentDto>(model));

            return RedirectToAction("AddComment");
        }
    }
}