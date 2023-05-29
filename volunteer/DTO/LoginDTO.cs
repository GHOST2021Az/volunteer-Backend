using System.ComponentModel.DataAnnotations;

namespace volunteer.DTO
{
	public class LoginDTO
	{
        [Required]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
