using FluentValidation;
using Employees.Core.Dtos;

namespace Employees.ServiceInterface.Validators
{
    public class BaseValidator : AbstractValidator<BaseDto<int>>
    {
        public BaseValidator()
        {

        }
    }
}
