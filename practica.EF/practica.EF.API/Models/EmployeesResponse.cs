using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace practica.EF.API.Models
{
    public class EmployeesResponse
    {
        public int EmployeeID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
    }
}
