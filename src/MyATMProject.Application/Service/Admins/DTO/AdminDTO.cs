using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyATMProject.Service.DTO
{
    public class AdminDTO: EntityDto<Guid>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Pin { get; set; }
    }
}
