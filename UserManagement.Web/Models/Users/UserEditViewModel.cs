using System.ComponentModel.DataAnnotations;
using System;

namespace UserManagement.Web.Models.Users;

public class UserEditViewModel
{
    [Required]
    public long Id { get; set;  }  

    [Required]
    public string? Forename { get; set; }

    [Required]
    public string? Surname { get; set; }

    [Required]
    [EmailAddress]
    public string? Email { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime? DateOfBirth { get; set; }

    public bool IsActive { get; set; }

}
