using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using M = Luis.SessionManagement.WebApi.Models;
using C = Luis.SessionManagement.WebApi.Contracts;

namespace Luis.SessionManagement.WebApi
{
    public static class PresenterMappingExtensions
    {
        public static void Configure()
        {
            Mapper.CreateMap<M.Presenter, C.Presenter>()
                .ForMember(dest => dest.SessionIds,
                    opt => opt.ResolveUsing(src => src.SessionPresenters.Select(x => x.SessionId).ToList()))
                ;
            Mapper.CreateMap<C.Presenter, M.Presenter>()
                .ForMember(dest => dest.Address, opt => opt.Ignore())
                .ForMember(dest => dest.CreateDate, opt => opt.Ignore())
                .ForMember(dest => dest.UpdateDate, opt => opt.Ignore())
                .ForMember(dest => dest.SessionPresenters, opt => opt.Ignore())
                ;
        }

        public static C.Presenter ToContract(this M.Presenter presenter)
        {
            return Mapper.Map<M.Presenter, C.Presenter>(presenter);
        }

        public static M.Presenter ToModel(this C.Presenter presenter)
        {
            return Mapper.Map<C.Presenter, M.Presenter>(presenter);
        }

        public static List<C.Presenter> ToContract(this List<M.Presenter> presenters)
        {
            return Mapper.Map<List<M.Presenter>, List<C.Presenter>>(presenters);
        }

        public static List<M.Presenter> ToModel(this List<C.Presenter> presenters)
        {
            return Mapper.Map<List<C.Presenter>, List<M.Presenter>>(presenters);
        }
    }
}