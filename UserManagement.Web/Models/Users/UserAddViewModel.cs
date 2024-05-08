using System.ComponentModel.DataAnnotations;
using System;

namespace UserManagement.Web.Models.Users;

public class UserAddViewModel
{
    [Required]
    public string? Forename { get; set; }

    [Required]
    public string? Surname { get; set; }

    [Required]
    [EmailAddress]
    public string? Email { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
    public DateTime DateOfBirth { get; set; }

}
