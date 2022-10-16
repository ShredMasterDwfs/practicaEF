using practica.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practica.EF.Services.Interface
{
    interface IServices
    {
        List<Employees> ListEmployees();
        void UpdateEmployees(Employees employees);
        void DeleteEmployees(string id);
        void AddEmployees(Employees employees);
    }
}
