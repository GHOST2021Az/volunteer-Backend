using System.ComponentModel.DataAnnotations;

namespace volunteer.DTO
{
    public class AprovedDTO
    {
        [Required]
        public int ApprovedPostId { get; set; }
        public string? Postname { get; set; }
        [Required]
        public string? Approvedby { get; set; }
        public string? Postdescribtion { get; set; }

    }
}
