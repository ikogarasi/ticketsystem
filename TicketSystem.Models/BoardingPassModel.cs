using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public UserModel UserModel { get; set; }
        [Required]
        public string PassengerFirstName { get; set; }
        [Required]
        public string PassengerSecondName { get; set; }
        [Required]
        [EnumDataType(typeof(Gender))]
        public Gender PassengerGender { get; set; }
        [ValidateNever]
        [NotMapped]
        public string? GenderString { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d/M/yyyy}",
            ApplyFormatInEditMode = true)]
        [Display(Name = "Date of birth")]
        public DateTime BirthDate { get; set; }
        [Required]
        [EnumDataType(typeof(SittingPlace))]
        public SittingPlace Seat { get; set; }
        [ValidateNever]
        [NotMapped]
        public string? SeatString { get; set; }

        [Required]
        public Guid RouteId { get; set; }
        [ForeignKey("RouteId")]
        [ValidateNever]
        public RouteModel Route { get; set; }
    }
}
