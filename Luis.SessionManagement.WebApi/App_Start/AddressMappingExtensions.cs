using System.Collections.Generic;
using AutoMapper;
using M = Luis.SessionManagement.WebApi.Models;
using C = Luis.SessionManagement.WebApi.Contracts;

namespace Luis.SessionManagement.WebApi
{
    public static class AddressMappingExtensions
    {
        public static void Configure()
        {
            Mapper.CreateMap<M.Address, C.Address>()                
                ;
            Mapper.CreateMap<C.Address, M.Address>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.UpdateDate, opt => opt.Ignore())
                .ForMember(dest => dest.CreateDate, opt => opt.Ignore())
                ;
        }

        public static C.Address ToContract(this M.Address address)
        {
            return Mapper.Map<M.Address, C.Address>(address);
        }

        public static M.Address ToModel(this C.Address address)
        {
            return Mapper.Map<C.Address, M.Address>(address);
        }

        public static List<C.Address> ToContract(this List<M.Address> addresses)
        {
            return Mapper.Map<List<M.Address>, List<C.Address>>(addresses);
        }

        public static List<M.Address> ToModel(this List<C.Address> addresses)
        {
            return Mapper.Map<List<C.Address>, List<M.Address>>(addresses);
        }
    }
}