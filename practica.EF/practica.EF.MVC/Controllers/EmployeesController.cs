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
        EmployeesLogic logic = new EmployeesLogic();
        // GET: Employees
        public ActionResult Index()
        {
            
            List<Entities.Employees> employeesList = logic.GetAll();

            List<EmployeesView> employeesView = employeesList.Select(e => new EmployeesView
            {
                EmpId = e.EmployeeID,
                EmpFirstName = e.FirstName,
                EmpLastName = e.LastName
            }).ToList();

            return View(employeesView);
        }

        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(EmployeesView employeesView)
        {
            try
            {
                Employees employeesEntity = new Employees
                {
                    FirstName = employeesView.EmpFirstName,
                    LastName = employeesView.EmpLastName
                };

                logic.Add(employeesEntity);

                return RedirectToAction("Index");

            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Error");
            }
        }
    }
}