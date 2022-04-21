using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using MyATMProject.Domains;
using MyATMProject.Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyATMProject.Service.Transactions
{
    public class TransactionAppService : ApplicationService, ITransactionAppService
    {
        private readonly IRepository<Transaction, Guid> _transactionRepository;
        public TransactionAppService(IRepository<Transaction, Guid> transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public void DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<TransactionDTO> Deposit(TransactionDTO input)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResultDto<TransactionDTO>> GetAllAsync(PagedAndSortedResultRequestDto input)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResultDto<TransactionDTO>> GetAsync(PagedAndSortedResultRequestDto input, Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<TransactionDTO> Transfer(TransactionDTO input)
        {
            throw new NotImplementedException();
        }

        public Task<TransactionDTO> Withdraw(TransactionDTO input)
        {
            throw new NotImplementedException();
        }
    }
}