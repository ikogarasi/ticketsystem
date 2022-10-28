using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
