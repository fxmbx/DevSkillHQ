using System.Security.AccessControl;

namespace DevSkillHQ_BE.Model;
public class Transaction
{

    public Guid TransactionID { get; set; }
    public TransactionType TransactionType { get; set; }
    public Account? Account { get; set; }
    public double Amount { get; set; }
    public DateTime CreatedAt { get; set; }
}