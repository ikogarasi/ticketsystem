using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using TicketSystem.Utility;

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
}
