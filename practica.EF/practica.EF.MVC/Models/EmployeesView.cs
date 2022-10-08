using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace practica.EF.MVC.Models
{
    public class EmployeesView
    {        
        public int EmpId { get; set; }

        [Required]
        [Display(Name="First Name")]
        public string EmpFirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string EmpLastName { get; set; }
    }
}