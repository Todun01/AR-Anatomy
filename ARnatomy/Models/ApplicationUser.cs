using Microsoft.AspNetCore.Identity;

namespace ARnatomy.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email {  get; set; }
        public string? School { get; set; }
        public string? CourseOfStudy { get; set; }
    }
}
