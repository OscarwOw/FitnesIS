
using Beckend.DataLayer.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Database
{
    public class User 
    {

        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(20)]
        public string PhoneNumber { get; set; }
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public virtual ICollection<Training> Trainings { get; set; }
       


    }
}
