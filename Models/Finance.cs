using System.ComponentModel.DataAnnotations;

namespace KMCAA.Models
{
    public class Finance
    {
        [Key]
        public int Id { get; set; }
        public int MemberId { get; set; }
        public int? PaymentTypeId { get; set; }
        public int? PaymentYear { get; set; }
        public string? ReceiptNo { get; set; }
        public DateTime? PaymentDate { get; set; }

    }
}
