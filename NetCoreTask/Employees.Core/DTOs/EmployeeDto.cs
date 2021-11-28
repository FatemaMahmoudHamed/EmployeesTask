using Employees.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Employees.Core.Dtos
{
    /// <summary>
    /// Employee to display the user in a list.
    /// </summary>
    public class EmployeeListItemDto
    {

    }

    /// <summary>
    /// Employee to display the user information in the details view.
    /// </summary>
    public class EmployeeDetailsDto
    {
    }

    /// <summary>
    /// Employee to create or edit user.
    /// </summary>
    public class EmployeeDto
    {
        public int? Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Employee Name")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Employee Email")]
        public string Email { get; set; }

        [Required]
        [RegularExpression("^01[0125][0-9]{8}$")]
        [Display(Name = "Employee Phone")]
        public string Phone { get; set; }

        [Required]
        [Display(Name = "Employee Address")]
        public string Address { get; set; }
    }

}