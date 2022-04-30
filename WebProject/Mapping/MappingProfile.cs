using AutoMapper;
using Core.Dtos;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProject.Models;

namespace WebProject.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Loan, LoanDetailDto>()
               .ForMember(x=>x.ClientFullName,opt=>opt.MapFrom(x=>$"{x.Client.Name} {x.Client.Surname}"))
               .ForMember(x=>x.LoanAmount,opt=>opt.MapFrom(x=>x.Amount))
               .ForMember(x => x.LoanID, opt => opt.MapFrom(x => x.Id));
            CreateMap<CalculateDto, Loan>()
                .ForMember(x=>x.Amount , opt=>opt.MapFrom(x=>x.LoanAmount));
        }
    }
}
