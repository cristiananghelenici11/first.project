using System;
using System.ComponentModel.DataAnnotations;
using Form.Helpers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Serialization;

namespace Form.Models
{
    public class Form
    {
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Length > 1 < 50")]
        [PersonName(new string[] {"Tom", "Sam", "Alice" }, ErrorMessage ="Name is not dismissible")]
        public string Name { get; set; }

        [Required]
        [MinLength(12, ErrorMessage = "ddd")]
        [MaxLength(11)]
        [StringLength(12, MinimumLength = 34, ErrorMessage = "dd")]
        [Range(int.MinValue, 130)]
        public int Age { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int Tel { get; set; }

        [Required]
        public string Password { get; set; }        
        
        [Compare("Password", ErrorMessage = "Password not coincide")]
        public string ConfirmPassword { get; set; }

        [EmailAddress]
        [Remote(action: "CheckEmail", controller: "Home", ErrorMessage ="Email Exists")]
        public string Email { get; set; }

        [Required]
        public bool Sex { get; set; }
    }
}