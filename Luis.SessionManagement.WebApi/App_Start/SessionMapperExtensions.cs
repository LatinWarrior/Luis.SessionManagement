using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using M = Luis.SessionManagement.WebApi.Models;
using C = Luis.SessionManagement.WebApi.Contracts;

namespace Luis.SessionManagement.WebApi
{
    public static class SessionMapperExtensions
    {
        public static void Configure()
        {
            Mapper.CreateMap<M.Session, C.Session>()
                .ForMember(dest => dest.SessionCategoryId, opt => opt.ResolveUsing(src => src.SessionCategoryId))
                .ForMember(dest => dest.SessionCategoryName, opt => opt.ResolveUsing(src => src.SessionCategory.Name))
                .ForMember(dest => dest.SessionLevelId, opt => opt.ResolveUsing(src => src.SessionLevelId))
                .ForMember(dest => dest.SessionLevelName, opt => opt.ResolveUsing(src => src.SessionLevel.Name))                
                .ForMember(dest => dest.PresenterIds,
                    opt => opt.ResolveUsing(src => src.SessionPresenters.Select(x => x.PresenterId).ToList()))
                ;
            Mapper.CreateMap<C.Session, M.Session>()
                .ForMember(dest => dest.SessionPresenters, opt => opt.Ignore())
                .ForMember(dest => dest.SessionLevel, opt => opt.Ignore())
                .ForMember(dest => dest.SessionCategory, opt => opt.Ignore())
                .ForMember(dest => dest.UpdateDate, opt => opt.Ignore())
                .ForMember(dest => dest.CreateDate, opt => opt.Ignore())
                ;
        }

        public static C.Session ToContract(this M.Session session)
        {
            return Mapper.Map<M.Session, C.Session>(session);
        }

        public static M.Session ToModel(this C.Session session)
        {
            return Mapper.Map<C.Session, M.Session>(session);
        }

        public static List<C.Session> ToContract(this List<M.Session> sessions)
        {
            return Mapper.Map<List<M.Session>, List<C.Session>>(sessions);
        }

        public static List<M.Session> ToModel(this List<C.Session> sessions)
        {
            return Mapper.Map<List<C.Session>, List<M.Session>>(sessions);
        }
    }
}