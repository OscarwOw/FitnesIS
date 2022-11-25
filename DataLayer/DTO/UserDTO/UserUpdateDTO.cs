using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beckend.DataLayer.DTO
{
    public class UserUpdateDTO
    {
        public string FirstName { get; set; }
        public string Surename { get; set; }
        public string mail { get; set; }
        public string Password { get; set; }
        public string BirthDate { get; set; }
    }
}
