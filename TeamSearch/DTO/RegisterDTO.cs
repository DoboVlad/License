using System.ComponentModel.DataAnnotations;

namespace TeamSearch.DTO
{
    public class RegisterDTO
    {
        [Required]
        public string firstName {get;set;}

        [Required]
        public string lastName { get; set; }

        [Required]
        public string email { get; set; }

        [Required]
        public string password { get; set; }
        
        [Required]
        public string ConfirmPassword { get; set; }
    }
}