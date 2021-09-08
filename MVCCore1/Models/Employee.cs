using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCore1.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        [Required(ErrorMessage ="Please Enter Employee Name")]
        [Display(Name ="Employee name")]
        public string EmployeeName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public decimal Salary { get; set; }
        public string Address { get; set; }
        public DateTime BOD { get; set; }
        public bool isDeleted { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

    }
}
