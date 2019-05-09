using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UniversityRating.Data.Core.DomainModels.Identity;
using UniversityRating.Presentation.Areas.Identity.Pages.Account;

namespace UniversityRating.Presentation.Controllers
{
    public class AuthenticationController : Controller
    {
//        private readonly UserManager<User> _userManager;
//        private readonly ILogger<RegisterModel> _logger;
//        private readonly IEmailSender _emailSender;
//        private readonly SignInManager<User> _signInManager;

//        public AuthenticationController(
//            UserManager<User> userManager,
//            ILogger<RegisterModel> logger,
//            IEmailSender emailSender,
//            SignInManager<User> signInManager
//
//            )
//        {
//            _userManager = userManager;
//            _logger = logger;
//            _emailSender = emailSender;
//            _signInManager = signInManager;
//        }
        public IActionResult Index()
        {

            return View();
        }

        [Authorize(AuthenticationSchemes = "Facebook")]
        public IActionResult Test()
        {
//            var register = new RegisterModel(_userManager,_signInManager,_logger,_emailSender);
            
            var test1 = User.Identity.Name;
            
//

//            var user = new User { UserName = Input.Email, Email = Input.Email };
//            var result = await _userManager.CreateAsync(user, Input.Password);
//            if (result.Succeeded)
//            {
//                _logger.LogInformation("User created a new account with password.");
//
//                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
//                var callbackUrl = Url.Page(
//                    "/Account/ConfirmEmail",
//                    pageHandler: null,
//                    values: new { userId = user.Id, code = code },
//                    protocol: Request.Scheme);
//
//                await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
//                    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");
//
//                await _signInManager.SignInAsync(user, isPersistent: false);
//                return LocalRedirect(returnUrl);
//            }
//            foreach (var error in result.Errors)
//            {
//                ModelState.AddModelError(string.Empty, error.Description);
//            }
            return Redirect("~/Home/Index");
        }
    }
}