using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using Microsoft.EntityFrameworkCore;
using MyATMProject.Domains;
using MyATMProject.Service.DTO;
using MyATMProject.Service.Transactions.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyATMProject.Service.BankAccounts
{
    public class BankAccountAppService : ApplicationService
    {
        private readonly IRepository<BankAccount, Guid> _bankAccountRepository;
        private readonly IRepository<Client, Guid> _clientRepository;
        private readonly IRepository<BankAccount_Transaction, Guid> _joinRepository;

        public BankAccountAppService(IRepository<BankAccount, Guid> bankAccountRepository, IRepository<Client, Guid> clientRepository, IRepository<BankAccount_Transaction, Guid> joinRepository)
        {
            _bankAccountRepository = bankAccountRepository;
            _clientRepository = clientRepository;
            _joinRepository = joinRepository;
        }
        public async Task<BankAccountDTO> CreateAsync(BankAccountDTO input)
        {
            var checkClient = _clientRepository.GetAll().Where(x=>x.Id==input.ClientId).FirstOrDefault();
            var account = ObjectMapper.Map<BankAccount>(input);
            account.Client = checkClient;
            account.AvailableBalance = 0;
            account.AccountNumber = new Random().Next(1000000000, 2000000000).ToString();
            var checkAccount = _bankAccountRepository.GetAll().Where(x => x.Client.Id == account.Client.Id).FirstOrDefault();
            if (checkAccount != null)
            {

                throw new UserFriendlyException("User already has account");

            }
            else
            {
                var res = await _bankAccountRepository.InsertAsync(account);
                CurrentUnitOfWork.SaveChanges();
                return ObjectMapper.Map<BankAccountDTO>(res);
            }

        }

        public void DeleteAsync(Guid id)
        {
            var account = _bankAccountRepository.FirstOrDefault(n => n.Id == id);
            if (account != null)
            {
                _bankAccountRepository.Delete(account);
            } 
            else
            {
                throw new UserFriendlyException("Data not found.");
            }
        }

        public async Task<PagedResultDto<BankAccountDTO>> GetAllAsync(PagedAndSortedResultRequestDto input)
        {
            try
            {
                var select = _bankAccountRepository.GetAllIncluding(n => n.Client);
                var result = new PagedResultDto<BankAccountDTO>();
                result.TotalCount = select.Count();
                result.Items = ObjectMapper.Map<IReadOnlyList<BankAccountDTO>>(select);
                return await Task.FromResult(result);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
        }

        public async Task<PagedResultDto<BankAccountDTO>> GetAsync(PagedAndSortedResultRequestDto input, Guid id)
        {
            try
            {
                var select = _bankAccountRepository.GetAllIncluding(n => n.Client);
                var res = select.Where(n => n.Id == id);
                var result = new PagedResultDto<BankAccountDTO>();
                result.Items = ObjectMapper.Map<IReadOnlyList<BankAccountDTO>>(res);
                return await Task.FromResult(result);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
        }

        public Task<BankAccountDTO> UpdateBalance(BankAccountDTO input)
        {
            throw new NotImplementedException();
        }


        public async Task<PagedResultDto<TransactionHistoryDTO>> GetTransactionHistory(PagedAndSortedResultRequestDto input, Guid clientId)
        {
            //try
            //{
            //    var result = new PagedResultDto<TransactionHistoryDTO>();
            //    var _clientData = _clientRepository.GetAllIncluding(n => n.Id);


            //}
            //catch (Exception exception)
            //{
            //    throw new Exception(exception.Message, exception);
            //}
            try
            {
                var result = new PagedResultDto<TransactionHistoryDTO>();

                var _clientData = _clientRepository.GetAll().Where(n => n.Id == clientId)
                                                    .Select(n => new TransactionHistoryDTO()
                                                    {
                                                        ClientName = n.Name,
                                                        BankTransactions = n.BankAccounts.Select(n => new BankAccountTransactionDTO()
                                                        {
                                                            AccountNumber = n.AccountNumber,

                                                            BankTransactions = _joinRepository.GetAll().Where(x => x.BankAccount.Id == n.Id).Select(t => t.Transaction.Amount).ToList()
                                                        }).ToList()
                                                    });
                result.TotalCount = _clientData.Count();
                result.Items = ObjectMapper.Map<IReadOnlyList<TransactionHistoryDTO>>(_clientData);
                return await Task.FromResult(result);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }

        }
    }
    }
