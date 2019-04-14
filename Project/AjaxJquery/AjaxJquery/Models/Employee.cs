using System.Web;

namespace AjaxJquery.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employee")]
    public class Employee
    {
        public int EmployeeID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Position { get; set; }

        [StringLength(50)]
        public string Office { get; set; }

        public int? Salary { get; set; }

        [StringLength(500)]
        public string ImagePath { get; set; }

        [NotMapped]
        public HttpPostedFileBase MyPostedFileBase { get; set; }

        public Employee()
        {
            ImagePath = @"~/AppFiles/default.png";
        }
    }
}
