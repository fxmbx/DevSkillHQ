using DevSkillHQ_BE.Dto;
using DevSkillHQ_BE.CustomException;
using DevSkillHQ_BE.Model;
using AutoMapper;

namespace DevSkillHQ_BE.Service;

public class AccountingService : IAccountingService
{

    private readonly IMapper _mapper;

    private static readonly List<Account> _accounts = new(){
        new Account { AccountID = Guid.NewGuid() },
        new Account { AccountID = Guid.NewGuid() },
        new Account { AccountID = Guid.NewGuid() },
        new Account { AccountID = Guid.NewGuid() },
    };

    private static readonly List<Transaction> _transactions = new(){
        new Transaction()
        {
            TransactionID = Guid.NewGuid(),
            TransactionType = TransactionType.DEPOSIT,
            Amount = 100000.00,
            Account = _accounts.ElementAt(0),
        },
        new Transaction()
        {
            TransactionID = Guid.NewGuid(),
            TransactionType = TransactionType.DEPOSIT,
            Amount = 20000.00,
            Account = _accounts.ElementAt(1),
        },
        new Transaction()
        {
            TransactionID = Guid.NewGuid(),
            TransactionType = TransactionType.DEPOSIT,
            Amount = 20000.00,
            Account = _accounts.ElementAt(3),
        },
    };

    public AccountingService(IMapper mapper)
    {
        _mapper = mapper;
    }

    public ServiceResponse<GetTransactionDto> CreateTransaction(CreateTransactionDto createTransactionDto)
    {
        var response = new ServiceResponse<GetTransactionDto>();
        var account = _accounts.FirstOrDefault(x => x.AccountID.ToString().Equals(createTransactionDto.AccountID));
        if (account == null)
        {
            throw new ReuseableCustomException("Account Not Found", 404);
        }
        var newTransaction = new Transaction
        {
            TransactionID = Guid.NewGuid(),
            TransactionType = createTransactionDto.TransactionType,
            Account = account,
            Amount = createTransactionDto.Amount
        };
        _transactions.Add(newTransaction);
        response.Data = _mapper.Map<GetTransactionDto>(newTransaction);
        return response;
    }

    public ServiceResponse<GetAccountDetailsDto> GetAccount(string accountID)
    {
        ServiceResponse<GetAccountDetailsDto> response = new();

        var account = _accounts.FirstOrDefault(x => x.AccountID.ToString().Equals(accountID));
        if (account == null)
        {
            throw new ReuseableCustomException("Account Not Found", 404);
        }
        var accountTransactions = _transactions.FindAll(x => x.Account?.AccountID == account.AccountID).ToList();
        double balance = 0;
        foreach (var a in accountTransactions)
        {
            switch (a.TransactionType)
            {
                case TransactionType.DEPOSIT:
                    balance += a.Amount;
                    break;
                case TransactionType.WITHDRAWAL:
                    balance -= a.Amount;
                    break;
            }
        }

        response.Data = new GetAccountDetailsDto()
        {
            AccountID = account.AccountID,
            AccountBalance = balance
        };

        return response;

    }

    public ServiceResponse<GetTransactionDto> GetTransactionByID(string transactionID)
    {
        ServiceResponse<GetTransactionDto> response = new();

        var transaction = _transactions.FirstOrDefault(x => x.TransactionID.ToString().Equals(transactionID));
        if (transaction == null)
        {
            throw new ReuseableCustomException("Transaction Not Found", 404);
        }
        response.Data = _mapper.Map<GetTransactionDto>(transaction);
        return response;

    }

    public ServiceResponse<IEnumerable<GetTransactionDto>> GetTransactions()
    {
        ServiceResponse<IEnumerable<GetTransactionDto>> response = new();

        response.Data = _transactions.Select(x => _mapper.Map<GetTransactionDto>(x));
        return response;
    }
}