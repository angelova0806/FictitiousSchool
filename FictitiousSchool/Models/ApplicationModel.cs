using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FictitiousSchool.Models
{
    public class Application
    {
        [Key]
        public int ApplicationId { get; set; }
        public int CourseId { get; set; }
        public DateTime CourseDate { get; set; }
        public string? CompanyName { get; set; }
        public string? CompanyPhone { get; set; }
        public string? CompanyEmail { get; set; }
        [NotMapped]
        public List<Participants>? lstParticipants { get; set; }
    }

    public class Participants
    {
        [Key]
        public int ParticipantId { get; set; }
        public int ApplicationId { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
    }
}
