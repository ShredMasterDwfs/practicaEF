using FluentValidation;
using practica.EF.Entities;
using practica.EF.Entities.Validations;
using practica.EF.Logic;
using practica.EF.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practica.EF.Services.Models
{
    public class EmployeesService : IServices
    {
        private EmployeesLogic _employees;
        public EmployeesLogic EmployeesLogic
        {
            get
            {
                if (_employees == null)
                {
                    _employees = new EmployeesLogic();
                }
                return _employees;
            }

            set { _employees = value; }
        }

        public void AddEmployees(Employees employees)
        {
            try
            {
                ValidateEmployees(employees);
                EmployeesLogic logic = new EmployeesLogic();
                logic.Add(employees);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Employees> ListEmployees()
        {
            EmployeesLogic employees = new EmployeesLogic();

            try
            {
                return this.EmployeesLogic.GetAll();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private static void ValidateEmployees(Employees employees)
        {
            var validate = new EmployeesValidations();
            validate.ValidateAndThrow(employees);
        }

        public void UpdateEmployees(Employees employees)
        {
            try
            {
                ValidateEmployees(employees);
                EmployeesLogic.Update(employees);
            }
            catch (Exception ex)
            {
                throw ex;
            };
        }

        public void DeleteEmployees(string id)
        {
            try
            {
                EmployeesLogic.Delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
