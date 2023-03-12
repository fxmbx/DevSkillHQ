using DevSkillHQ_BE.Model;
namespace DevSkillHQ_BE.Dto;
public class GetTransactionDto
{
    public Guid TransactionID { get; set; }
    public TransactionType TransactionType { get; set; }
    public GetAccountDto? Account { get; set; }
    public double Amount { get; set; }
    public DateTime CreatedAt { get; set; }
}

public class GetAccountDto
{
    public Guid AccountID { get; set; }

}