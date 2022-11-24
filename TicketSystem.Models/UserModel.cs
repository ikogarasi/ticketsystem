using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.Models
{
    public class UserModel : IdentityUser
    {
        [Required]
        public string FullName { get; set; }
        [ValidateNever]
        public Gender Sex { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Nationality { get; set; }
    }

    public enum Gender
    { 
        Mr,
        Mrs,
        Ms
    }

}
