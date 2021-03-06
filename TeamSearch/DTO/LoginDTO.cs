using System.ComponentModel.DataAnnotations;

namespace TeamSearch.DTO
{
    public class LoginDTO
    {
        [Required]
        public string email { get; set; }

        [Required]
        public string password { get; set; }
    }
}