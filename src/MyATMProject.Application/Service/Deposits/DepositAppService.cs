using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using MyATMProject.Domains;
using MyATMProject.Service.Deposits.DTO;
using MyATMProject.Service.Transactions.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyATMProject.Service.Deposits
{
    public class DepositAppService: ApplicationService
    {
        private readonly IRepository<Deposit, Guid> _depositRepository;
        private readonly IRepository<BankAccount, Guid> _bankAccountRepository;
        private readonly IRepository<Client, Guid> _clientRepository;
        private readonly IRepository<BankAccount_Transaction, Guid> _joinRepository;

        public DepositAppService(IRepository<Deposit, Guid> depositRepository, IRepository<BankAccount, Guid> bankAccountRepository, IRepository<Client, Guid> clientRepository, IRepository<BankAccount_Transaction, Guid> joinRepository)
        {
            _depositRepository = depositRepository;
            _bankAccountRepository = bankAccountRepository;
            _clientRepository = clientRepository;
            _joinRepository = joinRepository;
        }

        public async Task<DepositDTO> CreateAsync(string accountNumber, DepositDTO input)
        {
            try
            {
                var account = await _bankAccountRepository.GetAll().Where(n => n.AccountNumber == accountNumber).FirstOrDefaultAsync();
                var deposit = ObjectMapper.Map<Deposit>(input);
                deposit.Amount = input.Amount;
                deposit.CurrentBalance = account.AvailableBalance + input.Amount;
                var res = await _depositRepository.InsertAsync(deposit);

                account.AccountNumber = account.AccountNumber;
                account.AvailableBalance = account.AvailableBalance + input.Amount;

                var test = new BankAccount_Transaction()
                {
                    BankAccount = account,
                    Transaction = deposit
                };

                await _joinRepository.InsertAsync(test);

                var result = await _bankAccountRepository.UpdateAsync(account);
                CurrentUnitOfWork.SaveChanges();

                return ObjectMapper.Map<DepositDTO>(res);
            }
                catch (Exception ex)
            {
                throw;
            }
        }
    }
}
