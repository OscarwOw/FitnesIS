using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Beckend.DataLayer.DTO
{
    public class UserCreateDTO
    {
        
        
        public string Email { get; set; }        
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        
        public string Name { get; set; }

        
    }
}
