using practica.EF.Data;
using practica.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practica.EF.Logic
{
    public class EmployeesLogic : BaseLogic
    {

        public List<Employees> GetAll()
        {
            return context.Employees.ToList();
        }
    }
}
