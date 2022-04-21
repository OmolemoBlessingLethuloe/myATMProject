using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using Microsoft.EntityFrameworkCore;
using MyATMProject.Domains;
using MyATMProject.Service.Withdrawals.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyATMProject.Service.Withdrawals
{
    public class WithdrawAppService : ApplicationService
    {
        private readonly IRepository<Withdraw, Guid> _withdrawRepository;
        private readonly IRepository<BankAccount, Guid> _bankAccountRepository;
        private readonly IRepository<Client, Guid> _clientRepository;
        private readonly IRepository<BankAccount_Transaction, Guid> _joinRepository;

        public WithdrawAppService(IRepository<Withdraw, Guid> withdrawRepository, IRepository<BankAccount, Guid> bankAccountRepository, IRepository<Client, Guid> clientRepository, IRepository<BankAccount_Transaction, Guid> joinRepository)
        {
            _withdrawRepository = withdrawRepository;
            _bankAccountRepository = bankAccountRepository;
            _clientRepository = clientRepository;
            _joinRepository = joinRepository;
        }
        public async Task<WithdrawDTO> CreateAsync(string accountNumber, WithdrawDTO input)
        {
            try
            {
                var account = await _bankAccountRepository.GetAll().Where(n => n.AccountNumber == accountNumber).FirstOrDefaultAsync();
                var withdraw = ObjectMapper.Map<Withdraw>(input);
                if (withdraw.Amount < account.AvailableBalance)
                {
                    withdraw.Amount = input.Amount;
                    withdraw.CurrentBalance = account.AvailableBalance - input.Amount;
                    var res = await _withdrawRepository.InsertAsync(withdraw);

                    account.AccountNumber = account.AccountNumber;
                    account.AvailableBalance = account.AvailableBalance - input.Amount;

                    var test = new BankAccount_Transaction()
                    {
                        BankAccount = account,
                        Transaction = withdraw
                    };

                    await _joinRepository.InsertAsync(test);

                    var result = await _bankAccountRepository.UpdateAsync(account);
                    CurrentUnitOfWork.SaveChanges();

                    return ObjectMapper.Map<WithdrawDTO>(res);

                }
                else
                {
                    throw new UserFriendlyException("Insufficient Funds");
                }
                
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
