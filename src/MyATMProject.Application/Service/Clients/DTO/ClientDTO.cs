using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MyATMProject.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyATMProject.Service.DTO
{
    [AutoMapFrom(typeof(Client))]
    public class ClientDTO: EntityDto<Guid>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Pin { get; set; }
    }

    public class UpdateClientDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public class ChangePinDTO
    {
        public string OldPin { get; set; }
        public string NewPin { get; set; }
        public string ConfirmPin { get; set; }
    }
}
