using System;
using System.ComponentModel.DataAnnotations;
using EmployeeApi.Enums;

namespace EmployeeApi.Models
{
	public class Employee
	{
		public Guid Id { get; set; }
        [Required]
		public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }


    }
}

