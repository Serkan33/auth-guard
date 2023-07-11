
using System.ComponentModel.DataAnnotations;
using EmployeeApi.Data;
using EmployeeApi.Enums;
using EmployeeApi.Models;
using FluentValidation;

namespace EmployeeApi.Validator
{
	public class EmployeeValidator: AbstractValidator<EmployeeRequest>
    {
        private readonly EmployeeDbContext _dbContext;
        public EmployeeValidator(EmployeeDbContext dbContext)
		{
			_dbContext = dbContext;
			RuleFor(x=>x.Email)
				.NotNull()
				.Must(IsUniqueEmail)
                .WithMessage("Email must be unique.")
                .Must(ValidateUsingEmailAddressAttribute)
                .WithMessage("Invalid email address."); 

      
              

            RuleFor(x => x.Phone)
                .NotNull()
                .Must(IsUniquePhone)
                .WithMessage("Phone must be unique.")
                .Must(ValidateUsingPhoneAttribute)
                .WithMessage("Invalid phone.");

            RuleFor(x => x.Gender)
               .NotNull()
               .Must(ValidateGender)
               .WithMessage("Gender must be Male, Female or Other.");


        }

        private  bool IsUniqueEmail(string email)
        {
            Employee employee = _dbContext.Employees.FirstOrDefault(e => e.Email.Equals(email));
            return employee==null;
        }

        private bool IsUniquePhone(string phone)
        {
            Employee employee = _dbContext.Employees.FirstOrDefault(e => e.Phone.Equals(phone));
            return employee == null;
        }
        private bool ValidateUsingEmailAddressAttribute(string emailAddress)
        {
            var emailValidation = new EmailAddressAttribute();
            return emailValidation.IsValid(emailAddress);
        }
        private bool ValidateUsingPhoneAttribute(string phone)
        {
            var phoneAttribute = new PhoneAttribute();
            return phoneAttribute.IsValid(phone);
        }

        private bool ValidateGender(string gender)
        {
           return Enum.IsDefined(typeof(GenderTypes), gender); 
        }
    }
}

