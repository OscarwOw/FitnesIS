using Beckend.DataLayer.Models;
using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisProject.DataLayer.DTO.TrainingDTO
{
    public class ViewTraining
    {
        
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public DateTime Date { get; set; }
        public int Registred { get; set; }
        public int Capacity { get; set; }
        public int Duration { get; set; }
        
        public List<string> Tags { get; set; }

        public int CouchID { get; set; }
        public int RoomID { get; set; }
    }
}
