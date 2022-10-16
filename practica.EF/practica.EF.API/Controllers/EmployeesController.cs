using practica.EF.Entities;
using practica.EF.Logic;
using practica.EF.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace practica.EF.API.Controllers
{
    public class EmployeesController : ApiController
    {

        EmployeesLogic logic = new EmployeesLogic();
        // GET: /api/Employees
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            try
            {
                List<Employees> listEmployees = logic.GetAll();
                List<EmployeesResponse> response = listEmployees.Select(e => new EmployeesResponse
                {
                    EmployeeID = e.EmployeeID,
                    LastName = e.LastName,
                    FirstName = e.FirstName                  
                }).ToList();

                return Ok(response);
            }
            catch (Exception)
            {
                return Content(HttpStatusCode.BadRequest, "Error");
            }
        }

        // POST: /api/Employees
        [HttpPost]
        public IHttpActionResult Add(EmployeesRequest newEmployees)
        {
            try
            {
                Employees employee = new Employees
                {
                    LastName = newEmployees.LastName,
                    FirstName = newEmployees.FirstName                    
                };
                logic.Add(employee);
                return Content(HttpStatusCode.Created, employee);
            }
            catch (Exception)
            {
                return Content(HttpStatusCode.BadRequest, "Error");
            }
        }

        // POST: /api/Employees/{id}
        [HttpPost]
        public IHttpActionResult Delete(string id)
        {
            try
            {
                logic.Delete(id);
                return Content(HttpStatusCode.OK, "Employee deleted successfully!");
            }
            catch (Exception)
            {
                return Content(HttpStatusCode.BadRequest, "Error");
            }
        }

        // PUT: /api/Employees/{id}
        [HttpPut]
        public IHttpActionResult Update(EmployeesRequest newEmployees)
        {
            try
            {
                Employees employee = new Employees
                {
                    EmployeeID = newEmployees.EmployeeID,
                    LastName = newEmployees.LastName,
                    FirstName = newEmployees.FirstName                    
                };
                logic.Update(employee);
                return Content(HttpStatusCode.OK, employee);
            }
            catch (Exception)
            {
                return Content(HttpStatusCode.BadRequest, "Error");
            }
        }
    }
}