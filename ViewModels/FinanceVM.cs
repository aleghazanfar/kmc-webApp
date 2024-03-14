using KMCAA.Models;
using System.ComponentModel.DataAnnotations;

namespace KMCAA.ViewModels
{
    public class FinanceVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Select Payment Method Type")]
        public int? PaymentTypeId { get; set; }
        public int? PaymentYear { get; set; }
        public string? TypeName { get; set; }
        public List<LookUp>? PaymentMethod { get; set; }
        [Required(ErrorMessage = "Please Enter Receipt No")]
        public string? ReceiptNo { get; set; }
        [Required(ErrorMessage = "Please Select Payment Date")]
        public string? PaymentDate { get; set; }
    }
}
