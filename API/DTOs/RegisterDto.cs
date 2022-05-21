using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class RegisterDto
    {
        [Required]
        public string Username {get; set;}

        // Here we require the user to have a password of a minimum length of 4 chars and a maximum of 8
        [Required]
        [StringLength(8, MinimumLength =4)]
        public string Password {get; set;}
    }
}