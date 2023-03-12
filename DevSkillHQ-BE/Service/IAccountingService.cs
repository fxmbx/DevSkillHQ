using DevSkillHQ_BE.Dto;
using DevSkillHQ_BE.Model;

namespace DevSkillHQ_BE.Service;

public interface IAccountingService
{
    ServiceResponse<IEnumerable<GetTransactionDto>> GetTransactions();

    ServiceResponse<GetTransactionDto> GetTransactionByID(string transactionID);
    ServiceResponse<GetAccountDetailsDto> GetAccount(string accountID);

    ServiceResponse<GetTransactionDto> CreateTransaction(CreateTransactionDto createTransactionDto);

}