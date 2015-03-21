
using AutoMapper;

namespace Luis.SessionManagement.WebApi
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            SessionMapperExtensions.Configure();
            AddressMappingExtensions.Configure();            
            PresenterMappingExtensions.Configure();

            Mapper.AssertConfigurationIsValid();
        }        
    }
}