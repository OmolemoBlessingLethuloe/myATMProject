using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using MyATMProject.Domains;
using MyATMProject.Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyATMProject.Service.Clients
{
    public class ClientAppService : ApplicationService
    {
        private readonly IRepository<Client, Guid> _clientRepository;
        public ClientAppService(IRepository<Client, Guid> clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public async Task<ClientDTO> CreateAsync(ClientDTO input)
        {
            var checkEmail = _clientRepository.FirstOrDefault(n => n.Email == input.Email);
            if (checkEmail != null)
            {
                throw new UserFriendlyException("Already Exists");
            }
            else
            {
                if (input.Pin.Length == 4)
                {
                    var mapped = ObjectMapper.Map<Client>(input);
                    var result = await _clientRepository.InsertAsync(mapped);
                    return ObjectMapper.Map<ClientDTO>(result);
                }
                else
                {
                    throw new UserFriendlyException("Invalid password length. Please ensure that your pin is 4 characters long.");
                }
            }

        }

        public void DeleteAsync(Guid id)
        {
            var foundClient = _clientRepository.FirstOrDefault(n => n.Id == id);
            if (foundClient != null)
            {
                _clientRepository.Delete(foundClient);
               
            }
            else
            {
                throw new UserFriendlyException("No data found.");
            }
        }

        public async Task<PagedResultDto<ClientDTO>> GetAllAsync(PagedAndSortedResultRequestDto input)
        {
            try
            {
                var select = _clientRepository.GetAll();
                var result = new PagedResultDto<ClientDTO>();
                result.TotalCount = select.Count();
                result.Items = ObjectMapper.Map<IReadOnlyList<ClientDTO>>(select);
                return await Task.FromResult(result);
            } catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            } 
        }

        public async Task<PagedResultDto<ClientDTO>> GetAsync(PagedAndSortedResultRequestDto input, Guid id)
        {
            try
            {
                var select = _clientRepository.GetAll();
                var res = select.Where(n => n.Id == id);
                var result = new PagedResultDto<ClientDTO>();
                result.Items = ObjectMapper.Map<IReadOnlyList<ClientDTO>>(res);
                return await Task.FromResult(result);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
        }

        public async Task<ClientDTO> UpdateClient(Guid id, UpdateClientDTO input)
        {
            try
            {
                var client = _clientRepository.FirstOrDefault(n => n.Id == id);
                if (client != null)
                {
                    client.Name = input.Name;
                    client.Email = input.Email;
                    client.Pin = client.Pin;

                    var result = await _clientRepository.UpdateAsync(client);
                    return ObjectMapper.Map<ClientDTO>(result);
                }
                else
                {
                    throw new UserFriendlyException("Data not found.");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<ClientDTO> UpdatePin(Guid id, ChangePinDTO input)
        {
            var client = _clientRepository.FirstOrDefault(n => n.Id == id);
            if (client != null)
            {
                if (input.OldPin == client.Pin && input.NewPin == input.ConfirmPin)
                {
                    client.Name = client.Name;
                    client.Email = client.Email;
                    client.Pin = input.ConfirmPin;

                    var result = await _clientRepository.UpdateAsync(client);
                    return ObjectMapper.Map<ClientDTO>(result);
                }
                else
                {
                    throw new UserFriendlyException("Passwords do not match.");
                }
            }
            else
            {
                throw new UserFriendlyException("Data not found.");
            }
        }
    }
}
