using System.ComponentModel.DataAnnotations;

namespace FunWebApi.Dtos
{
    public class UsersDto
    {
        [Required]
        public string  username { get; set; }
           [Required]
           [StringLength(10,MinimumLength=8,ErrorMessage ="your password length err ")]
        public string  password  { get; set; }
    }
}