using Microsoft.AspNetCore.Identity;

namespace ARnatomy.Models
{
    // users
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Feedback> Feedback { get; set; } = new List<Feedback>();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email {  get; set; }
        public string? School { get; set; }
        public string? CourseOfStudy { get; set; }
        
        public string Role { get; set; }


    }

    // 3d models table
    public class OrganModel
    {
        public ICollection<Feedback> Feedback { get; set; } = new List<Feedback>();
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string FilePath { get; set; }
    }
    
    // feedback table
    public class Feedback
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int OrganModelId { get; set; }
        public OrganModel OrganModel { get; set; }
        public string? Comment { get; set; }
        public double Rating { get; set; }
    }



}
