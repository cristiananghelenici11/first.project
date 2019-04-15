using System;
using System.Collections.Generic;

namespace DataTable.Models
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Office { get; set; }
        public int? Age { get; set; }
        public int? Salary { get; set; }
    }
}
