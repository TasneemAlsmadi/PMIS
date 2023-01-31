using AutoMapper;
using BMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMIS.DTOs
{
    public class MappingProfile :Profile
    {

        public MappingProfile() {
            CreateMap<InsertProjectDTO, Project>()
           // .ForMember(des => des.EndDate, opt => opt.MapFrom(s => s.StartDate))
            .ForMember(des => des.ContractFile, opt => opt.Ignore());
            CreateMap<InsertInvoiceDTO, Invoice>();
            CreateMap<EditProjectDTO, Invoice>();
            CreateMap<ViewDTO, Invoice>();


        }


    }
}
