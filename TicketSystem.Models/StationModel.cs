using System.ComponentModel.DataAnnotations;

namespace TicketSystem.Models
{
    public class StationModel
    {
        [Key]
        public Guid Id { get; set; }        
        [Required]
        public string Name { get; set; }
    }
}
