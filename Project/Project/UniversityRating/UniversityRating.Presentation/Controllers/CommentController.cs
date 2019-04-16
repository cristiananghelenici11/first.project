using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UniversityRating.Presentation.Models.Comment;
using UniversityRating.Services.Abstractions;
using UniversityRating.Services.Common.DTOs.Comment;

namespace UniversityRating.Presentation.Controllers
{
    public class CommentController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICommentService _commentService;

        public CommentController(IMapper mapper, ICommentService commentService)
        {
            _mapper = mapper;
            _commentService = commentService;
        }

        public IActionResult Index()
        {
            return View();
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
                _commentService.AddCommentUniversity(_mapper.Map<CommentUniversityShowViewModel, CommentUniversityShowDto>(comment));
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