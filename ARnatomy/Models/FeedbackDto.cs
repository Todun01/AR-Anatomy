using System.ComponentModel.DataAnnotations;

namespace ARnatomy.Models
{
    public class FeedbackDto
    {
        [Required]
        public int OrganModelId { get; set; }
        public OrganModel OrganModel { get; set; }
        public string? Comment { get; set; }

        [Required]
        public int Rating { get; set; }
    }
}
