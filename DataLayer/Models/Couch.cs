using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Beckend.DataLayer.Models
{
    public class Couch
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [MaxLength(20)]
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public virtual List<Training> Trainings { get; set; }

    }
}
