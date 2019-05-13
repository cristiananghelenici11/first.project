using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet]
        public IActionResult ViewComment()
        {
            List<UniversityShowDto> universities = _universityService.GetAllUniversities();
            List<CommentDto> commentUniversityDtos = _commentService.GetUniversityComments(1, 0, 10);
            List<CommentDto> commentTeacherDtos = _commentService.GetTeacherComments(1, 0, 10);
            List<CommentDto> commentCourseDtos = _commentService.GetCourseComments(1, 0, 10);
            List<CommentDto> commentCourseTeachers = _commentService.GetCourseTeacherComments(1, 0, 0, 10);

            return View(new IndexViewModel
            {
                CommentUniversity = _mapper.Map<List<CommentDto>, List<CommentViewModel>>(commentUniversityDtos),
                CommentTeacher = _mapper.Map<List<CommentDto>, List<CommentViewModel>>(commentTeacherDtos),
                CommentCourse = _mapper.Map<List<CommentDto>, List<CommentViewModel>>(commentCourseDtos),
                CommentCourseTeachers = _mapper.Map<List<CommentDto>, List<CommentViewModel>>(commentCourseTeachers),
                UniversityShowViewModels = _mapper.Map<List<UniversityShowDto>, List<UniversityShowViewModel>>(universities),
            });
        }

        [HttpPost]
        public IActionResult AddCommentTeacher(CommentTeacherViewModel commentTeacherViewModel)
        {
            if (!ModelState.IsValid) return Content(JsonConvert.SerializeObject("Not valid"));

            commentTeacherViewModel.UserId = Convert.ToInt32(_signInManager.UserManager.GetUserId(User));
            _commentService.AddCommentTeacher(_mapper.Map<CommentTeacherViewModel, CommentTeacherDto>(commentTeacherViewModel));

            return RedirectToAction("AddComment");
        }

        [HttpPost]
        public IActionResult AddCommentUniversity(CommentUniversityViewModel commentUniversityViewModel)
        {
            if (!ModelState.IsValid) return Content(JsonConvert.SerializeObject("Not valid"));

            commentUniversityViewModel.UserId = Convert.ToInt32(_signInManager.UserManager.GetUserId(User));
            _commentService.AddCommentUniversity(
                _mapper.Map<CommentUniversityViewModel, CommentUniversityDto>(commentUniversityViewModel));

            return RedirectToAction("AddComment");
        }

        [HttpPost]
        public IActionResult AddCommentCourse(CommentCourseViewModel commentCourseViewModel)
        {
            if (!ModelState.IsValid) return Content(JsonConvert.SerializeObject("Not valid"));

            commentCourseViewModel.UserId = Convert.ToInt32(_signInManager.UserManager.GetUserId(User)); ;
            _commentService.AddCommentCourse(_mapper.Map<CommentCourseViewModel, CommentCourseDto>(commentCourseViewModel));

            return RedirectToAction("AddComment");
        }

        [HttpPost]
        public IActionResult AddCommentCourseTeacher(CommentCourseTeacherViewModel commentCourseTeacherView)
        {
            if (!ModelState.IsValid) return Content(JsonConvert.SerializeObject("Not valid"));

            commentCourseTeacherView.UserId = Convert.ToInt32(_signInManager.UserManager.GetUserId(User));
            _commentService.AddCommentCourseTeacher(
                _mapper.Map<CommentCourseTeacherViewModel, CommentCourseTeacherDto>(commentCourseTeacherView));

            return RedirectToAction("AddComment", "Comment");
        }

        [HttpPost]
        public IActionResult DeleteComment(long id)
        {
            if (!ModelState.IsValid) return Content(JsonConvert.SerializeObject("Not valid"));
            _commentService.DeleteCommentById(id);

            return RedirectToAction("AddComment");
        }

        [HttpPost]
        [Authorize(Roles = "moderator")]
        public IActionResult DeleteViewComment(long id)
        {
            if (!ModelState.IsValid) return Content(JsonConvert.SerializeObject("Not valid"));
            _commentService.DeleteCommentById(id);

            return RedirectToAction("ViewComment");
        }

        [HttpPost]
        public ActionResult EditComment(EditCommentViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            _commentService.UpdateComment(_mapper.Map<EditCommentViewModel, EditCommentDto>(model));

            return RedirectToAction("AddComment");
        }

        [HttpGet]
        public ActionResult EditComment(long id)
        {
            if (!ModelState.IsValid) return View();
            EditCommentDto commentDto = _commentService.GetCommentById(id);
            EditCommentViewModel model = commentDto == null
                ? new EditCommentViewModel()
                : _mapper.Map<EditCommentDto, EditCommentViewModel>(commentDto);

            return View(model);
        }
        [HttpGet]
        public ActionResult UniversityComments(int pageNumber, long universityId, int numberOfRecordsPerPage = 10, bool skipRecords = true)
        {
            List<CommentDto> commentDtos = _commentService.GetUniversityComments(pageNumber, universityId,
                numberOfRecordsPerPage = 10, skipRecords = true);
            List<CommentViewModel> commentViewModels = _mapper.Map<List<CommentDto>, List<CommentViewModel>>(commentDtos);

            return PartialView("_ViewListComment", commentViewModels);
        }

        [HttpGet]
        public ActionResult CourseComment(int pageNumber, long courseId, int numberOfRecordsPerPage = 10, bool skipRecords = true)
        {
            List<CommentDto> commentDtos = _commentService.GetCourseComments(pageNumber, courseId,
                numberOfRecordsPerPage = 10, skipRecords = true);
            List<CommentViewModel> commentViewModels = _mapper.Map<List<CommentDto>, List<CommentViewModel>>(commentDtos);

            return PartialView("_ViewListComment", commentViewModels);
        }

        [HttpGet]
        public ActionResult TeacherComment(int pageNumber, long teacherId, int numberOfRecordsPerPage = 10, bool skipRecords = true)
        {
            List<CommentDto> commentDtos = _commentService.GetTeacherComments(pageNumber, teacherId,
                numberOfRecordsPerPage = 10, skipRecords = true);
            List<CommentViewModel> commentViewModels = _mapper.Map<List<CommentDto>, List<CommentViewModel>>(commentDtos);

            return PartialView("_ViewListComment", commentViewModels);
        }

        [HttpGet]
        public ActionResult CourseTeacherComment(int pageNumber, long courseId, long teacherId, int numberOfRecordsPerPage = 10, bool skipRecords = true)
        {
            List<CommentDto> commentDtos = _commentService.GetCourseTeacherComments(pageNumber, courseId, teacherId,
                numberOfRecordsPerPage = 10, skipRecords = true);
            List<CommentViewModel> commentViewModels = _mapper.Map<List<CommentDto>, List<CommentViewModel>>(commentDtos);

            return PartialView("_ViewListComment", commentViewModels);
        }
    }
}