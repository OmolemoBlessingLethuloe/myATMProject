using AutoMapper;
using MyATMProject.Domains;
using MyATMProject.Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyATMProject.Service.Clients.DTO
{
    public class ClientMappingProfile: Profile
    {
        public ClientMappingProfile()
        {
            CreateMap<Client, ClientDTO>();
            CreateMap<ClientDTO, Client>();
        }
    }
}
