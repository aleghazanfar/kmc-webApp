using KMCAA.Models;
using System.ComponentModel.DataAnnotations;

namespace KMCAA.ViewModels
{
    public class MemberVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Select Membership Type")]

        public int? MembershipTypeId { get; set; }
        public string? TypeName { get; set; }
        public List<LookUp>? MembershipTypes { get; set; }
        public List<LookUp>? MemberReside { get; set; }
        [Required(ErrorMessage = "Please Select Member Reside In")]
        public string? MemberResideIn { get; set; }
        public int? MemberResideInId { get; set; }
        [Required(ErrorMessage = "Please Enter Full Name")]

        public string? FullName { get; set; }
        [Required(ErrorMessage = "Please Select Gender")]

        public string? Gender { get; set; }
        public string? GraduationFrom { get; set; }
        public string? YearOfGraduation { get; set; }
        [Required(ErrorMessage = "Please Enter Persent Work Place")]

        public string? PresendWorkPlance { get; set; }
        public string? MailingAddress { get; set; }
        public string? PermanentAddress { get; set; }
        public string? OfficeNumber { get; set; }
        public string? ClinicNumber { get; set; }
        public string? MobileNumber { get; set; }
        [Required]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string? Email { get; set; }
        public int? PaymentTypeId { get; set; }
        public List<LookUp>? PaymentMethod { get; set; }
        public string? ReceiptNo { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string? ImageUrl { get; set; }
    }
}
