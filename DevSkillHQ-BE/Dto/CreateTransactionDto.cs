using System.ComponentModel.DataAnnotations;
using DevSkillHQ_BE.Model;

namespace DevSkillHQ_BE.Dto
{
    public class CreateTransactionDto
    {
        [Required(ErrorMessage = "AccountID is required")]
        public string? AccountID { get; set; }
        [Required(ErrorMessage = "Transaction Type is requred")]
        public TransactionType TransactionType { get; set; }

        [Required(ErrorMessage = "Amount Required")]
        [Range(1, double.MaxValue, ErrorMessage = "Amount must be between {1} and {2}.")]
        public double Amount { get; set; }
    }
}