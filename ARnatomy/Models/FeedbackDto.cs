using System.ComponentModel.DataAnnotations;

namespace ARnatomy.Models
{
    public class FeedbackDto
    {
        [Required]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        [Required]
        public int OrganModelId { get; set; }
        public OrganModel OrganModel { get; set; }
        public string? Comment { get; set; }

        [Required]
        public double Rating { get; set; }
    }
}
