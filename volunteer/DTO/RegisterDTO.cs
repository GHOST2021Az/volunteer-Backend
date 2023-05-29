using System.ComponentModel.DataAnnotations;

namespace volunteer.DTO
{
	public class RegisterDTO
	{
        [Required]
        [StringLength(50)]
        public string mobileNumber { get; set; }
        [Required]
        [StringLength(50,MinimumLength = 5)]
        public string Password { get; set; }
		[Required]
		[StringLength(50, MinimumLength = 5)]
		public string ConfirmPassword { get; set; }
    }
}
