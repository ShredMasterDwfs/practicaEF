using practica.EF.Entities;
using practica.EF.Logic;
using practica.EF.MVC.Models;
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
            List<Entities.Employees> employeesList = logic.GetAll();

            List<EmployeesView> employeesView = employeesList.Select(e => new EmployeesView
            {
                EmpId = e.EmployeeID,
                EmpFirstName = e.FirstName,
                EmpLastName = e.LastName
            }).ToList();

            return View(employeesView);
        }
    }
}