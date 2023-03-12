using DevSkillHQ_BE.CustomException;
using DevSkillHQ_BE.Dto;
using DevSkillHQ_BE.Service;

namespace DevSkillHQ_BE.Test.System
{
    public class AccountServiceTest
    {
        private readonly IFixture _fixture;
        private readonly Mock<IAccountingService> _sut;

        public AccountServiceTest()
        {
            _sut = new Mock<IAccountingService>();
            _fixture = new Fixture();
        }

        [Fact]
        public void GetTransaction_ShouldReturnTransaction_WhenTransactionsExist()
        {
            _sut.Setup(x => x.GetTransactions()).Returns(
                new Model.ServiceResponse<IEnumerable<GetTransactionDto>>()
                {
                    Data = _fixture.Create<IEnumerable<GetTransactionDto>>(),
                }
            );

            var result = _sut.Object.GetTransactions();
            Assert.NotNull(result);
        }
        [Fact]
        public void GetTransactionByID_ShouldReturnTransaction_WhenTransactionsExist()
        {
            _sut.Setup(x => x.GetTransactionByID(It.IsAny<string>())).Returns(
                new Model.ServiceResponse<GetTransactionDto>()
                {
                    Data = _fixture.Create<GetTransactionDto>(),
                }
            );

            var result = _sut.Object.GetTransactionByID(It.IsAny<string>());
            Assert.NotNull(result);
        }
        [Fact]
        public void GetTransactoinByID_ShouldThrowException_WhenTransactionsNotFound()
        {
            _sut.Setup(x => x.GetTransactionByID(It.IsAny<string>())).Throws(
                new ReuseableCustomException("Not Found", 404)
            );

            Assert.Throws<ReuseableCustomException>(() => _sut.Object.GetTransactionByID(It.IsAny<string>()));
        }

        [Fact]
        public void GetAccount_ShouldReturnAccount_WhenAccountExist()
        {
            _sut.Setup(x => x.GetAccount(It.IsAny<string>())).Returns(
                new Model.ServiceResponse<GetAccountDetailsDto>()
                {
                    Data = _fixture.Create<GetAccountDetailsDto>(),
                }
            );

            var result = _sut.Object.GetAccount(It.IsAny<string>());
            Assert.NotNull(result);
        }
        [Fact]
        public void GetAccount_ShouldThrowNotFound_WhenAccountNotFound()
        {
            _sut.Setup(x => x.GetAccount(It.IsAny<string>())).Throws(
                new ReuseableCustomException("Not Found", 404)

            );
            Assert.Throws<ReuseableCustomException>(() => _sut.Object.GetAccount(It.IsAny<string>()));
        }

        [Fact]
        public void CreateTransaction_ShouldReturnCreatedTransaction_WhenSuccessful()
        {
            CreateTransactionDto req = new()
            {
                AccountID = "1",
                Amount = 200,
                TransactionType = Model.TransactionType.DEPOSIT
            };
            _sut.Setup(x => x.CreateTransaction(req)).Returns(
                new Model.ServiceResponse<GetTransactionDto>()
                {
                    Data = new GetTransactionDto()
                    {
                        TransactionID = It.IsAny<Guid>(),
                        TransactionType = req.TransactionType,
                        Account = It.IsAny<GetAccountDto>(),
                        Amount = req.Amount,
                    }
                }
            );

            var result = _sut.Object.CreateTransaction(req);
            Assert.NotNull(result);
            Assert.Equal(result.Data!.Amount, req.Amount);
        }
        [Fact]
        public void CreateTransaction_ShouldThrowNotFound_WhenAccountDoestExist()
        {
            _sut.Setup(x => x.CreateTransaction(It.IsAny<CreateTransactionDto>())).Throws(
                new ReuseableCustomException("Not Found", 404)
            );

            Assert.Throws<ReuseableCustomException>(() => _sut.Object.CreateTransaction(It.IsAny<CreateTransactionDto>()));

        }

    }
}