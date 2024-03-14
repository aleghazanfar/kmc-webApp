using System.ComponentModel.DataAnnotations;

namespace KMCAA.Models
{
    public class MemberDetail
    {
        public int Id { get; set; }
        public int? MembershipTypeId { get; set; }
        public int? MemberResideIn { get; set; }
        public string? FullName { get; set; }
        public string? Gender { get; set; }
       
        public string? GraduationFrom { get; set; }
        public string? YearOfGraduation { get; set; }
        public string? PresendWorkPlance { get; set; }
        public string? MailingAddress { get; set; }
        public string? PermanentAddress { get; set; }
        public string? OfficeNumber { get; set; }
        public string? ClinicNumber { get; set; }
        public string? MobileNumber { get; set; }
        public string? Email { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? EnteredDate { get; set; }
    }
}
