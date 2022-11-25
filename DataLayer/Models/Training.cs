using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Beckend.DataLayer.Models;
using System.ComponentModel.DataAnnotations;

namespace Beckend.DataLayer.Models
{
    public class Training
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }
        public int Capacity { get; set; }
        public int Duration { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        
        public int CouchID { get; set; }
        public int RoomID { get; set; }

    }
}


