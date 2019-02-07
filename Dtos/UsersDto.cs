using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FunWebApi.Models;

namespace FunWebApi.Dtos
{
    public class UsersDto
    {
        [Required]
        public string username { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 8, ErrorMessage = "your password length err ")]
        public string password { get; set; }
    }
    public class UserLoginDto
    {
        [Required]
        public string username { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 8, ErrorMessage = "your password length err ")]
        public string password { get; set; }
    }

    public class UserForListDto
    {

        public int Id { get; set; }

        public string Username { get; set; }

        public string Gender { get; set; }
        public int Age { get; set; }
        public string knownAs { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PhotoUrl { get; set; }
    }

    public class UserForDetailedDto
    {

        public int Id { get; set; }

        public string Username { get; set; }

        public string Gender { get; set; }
        public int Age { get; set; }
        public string knownAs { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PhotoUrl { get; set; }
        public ICollection<PhotoForDetailedDto> Photos { get; set; }


    }

}