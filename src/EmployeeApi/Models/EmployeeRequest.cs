using System;
using EmployeeApi.Enums;
using System.ComponentModel.DataAnnotations;

namespace EmployeeApi.Models
{
	public class EmployeeRequest
	{
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string Phone { get; set; }
        [Range(25, 60)]
        public int Age { get; set; }
        public string Gender { get; set; }
    }
}

