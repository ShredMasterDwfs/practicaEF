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

        public EmployeesLogic() : base()
        {

        }
        public void Add(Employees newEmployees)
        {
            try
            {
                context.Employees.Add(newEmployees);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public void Delete(string id)
        {
            try
            {
                var employeeToDelete = context.Employees.Find(int.Parse(id));
                context.Employees.Remove(employeeToDelete);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }

        public List<Employees> GetAll()
        {
            try
            {
                return context.Employees.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public void Update(Employees employees)
        {
            var employeesUpdate = context.Employees.Find(employees.EmployeeID);
            employeesUpdate.FirstName = employees.FirstName;
            employeesUpdate.LastName = employees.LastName;
            context.SaveChanges();            
        }
    }
}
