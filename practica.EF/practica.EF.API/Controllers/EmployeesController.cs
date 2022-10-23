using practica.EF.Entities;
using practica.EF.Logic;
using practica.EF.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using practica.EF.Services.Models;
using System.Web.Http.Cors;

namespace practica.EF.API.Controllers
{
    public class EmployeesController : ApiController
    {

        EmployeesService logic = new EmployeesService();
        // GET: /api/Employees
        [HttpGet]
        public IHttpActionResult GetAll()
            {
            try
            {
                List<Employees> listEmployees = logic.ListEmployees();
                List<EmployeesResponse> response = listEmployees.Select(e => new EmployeesResponse
                {
                    EmployeeId = e.EmployeeID,
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
                logic.AddEmployees(employee);
                return Content(HttpStatusCode.Created, employee);
            }
            catch (Exception)
            {
                return Content(HttpStatusCode.BadRequest, "Error");
            }
        }

        // DELETE: /api/Employees/{id}
        [HttpDelete]
        public IHttpActionResult Delete(string id)
        {
            try
            {
                logic.DeleteEmployees(id);
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
                logic.UpdateEmployees(employee);
                return Content(HttpStatusCode.OK, employee);
            }
            catch (Exception)
            {
                return Content(HttpStatusCode.BadRequest, "Error");
            }
        }
    }
}