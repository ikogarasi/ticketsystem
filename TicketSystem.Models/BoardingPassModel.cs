using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.Utility;

namespace TicketSystem.Models
{
    public class BoardingPassModel
    {
        [Key]
        public Guid Id { get; set; }
        
        [Required]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        [ValidateNever]
        public UserModel User { get; set; }

        [Required]
        public string PassengerFirstName { get; set; }
        
        [Required]
        public string PassengerSecondName { get; set; }
        
        [Required]
        public Gender PassengerGender { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d/M/yyyy}",
            ApplyFormatInEditMode = true)]
        [Display(Name = "Date of birth")]
        public DateTime BirthDate { get; set; }
        
        public SittingPlace Seat { get; set; }

        [Required]
        public Guid RouteId { get; set; }
        [ForeignKey("RouteId")]
        [ValidateNever]
        public RouteModel Route { get; set; }
    }
}
