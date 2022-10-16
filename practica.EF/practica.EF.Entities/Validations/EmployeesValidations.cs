using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practica.EF.Entities.Validations
{
    public class EmployeesValidations : AbstractValidator<Employees>
    {
        public EmployeesValidations()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Field Required.");
            RuleFor(x => x.FirstName).MaximumLength(10).WithMessage("Maximum: 10 characters");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Field Required.");
            RuleFor(x => x.LastName).MaximumLength(20).WithMessage("Maximum: 20 characters");
        }
    }
}
