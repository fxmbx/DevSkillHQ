using System.ComponentModel.DataAnnotations;

namespace DevSkillHQ_BE.Model;

public class Account
{
    public Guid AccountID { get; set; }
    public List<Transaction>? Transactions { get; set; }
}