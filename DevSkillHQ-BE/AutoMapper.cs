using AutoMapper;
using DevSkillHQ_BE.Dto;
using DevSkillHQ_BE.Model;

namespace DevSkillHQ_BE
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Transaction, GetTransactionDto>();
            CreateMap<Account, GetAccountDto>();
        }

    }
}