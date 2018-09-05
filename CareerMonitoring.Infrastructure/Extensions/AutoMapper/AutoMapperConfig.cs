using AutoMapper;
using CareerMonitoring.Core.Domains.Surveys;
using CareerMonitoring.Infrastructure.DTO;

namespace CareerMonitoring.Infrastructure.Extensions.AutoMapper
{
    public class AutoMapperConfig
    {
        public static IMapper Initialize () => new MapperConfiguration (cfg => {
                cfg.CreateMap<Survey, SurveyDto> ();
            })
            .CreateMapper ();
    }
}