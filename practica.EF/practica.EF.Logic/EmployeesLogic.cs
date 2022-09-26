using practica.EF.Data;
using practica.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practica.EF.Logic
{
    public class EmployeesLogic : BaseLogic, IABMLogic<Employees>
    {
        public void Add(Employees newEmployees)
        {
            context.Employees.Add(newEmployees);
            context.SaveChanges();
        }

        public void Delete(string id)
        {
            var employeeToDelete = context.Employees.Find(int.Parse(id));
            context.Employees.Remove(employeeToDelete);
            context.SaveChanges();
        }

        public List<Employees> GetAll()
        {
            return context.Employees.ToList();
        }

        public void Update(Employees employees)
        {
            var employeesUpdate = context.Employees.Find(employees.EmployeeID);
            employeesUpdate.FirstName = employees.FirstName;
            employeesUpdate.LastName = employees.LastName;
            employeesUpdate.Title = employees.Title;
            context.SaveChanges();
        }
    }
}
