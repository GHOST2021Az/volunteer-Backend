using System.ComponentModel.DataAnnotations;

namespace volunteer.DTO
{
    public class pendingDTO
    {
        [Required]
        public int PendingpostId { get; set; }
        public string PostName { get; set; } = null!;
        [Required]
        public string? UserName { get; set; }
        public string? Postdescribtion { get; set; }
        public int UserId { get; set; }
    }
}
