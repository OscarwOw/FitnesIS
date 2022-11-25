using Beckend.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beckend.DataLayer.DTO.UserDTO
{
    public class UserDTO
    {
        
        public int Id { get; set; }
        
        public string UserName { get; set; }
        
        public string Password { get; set; }
        
        public string Email { get; set; }
        
        public string FirstName { get; set; }
        
        public string PhoneNumber { get; set; }

        public DateTime BirthDate { get; set; }
        public List<String> Trainings { get; set; }
    }
}
