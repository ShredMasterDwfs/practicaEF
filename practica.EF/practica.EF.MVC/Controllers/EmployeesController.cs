using practica.EF.Entities;
using practica.EF.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace practica.EF.MVC.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employees
        public ActionResult Index()
        {
            var logic = new EmployeesLogic();
            List<Employees> employeesList = logic.GetAll();
            return View(employeesList);
        }
    }
}