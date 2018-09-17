using AutoMapper;
using CareerMonitoring.Core.Domains.Surveys;
using CareerMonitoring.Core.Domains.SurveyScore;
using CareerMonitoring.Infrastructure.DTO;

namespace CareerMonitoring.Infrastructure.Extensions.AutoMapper {
    public class AutoMapperConfig {
        public static IMapper Initialize () => new MapperConfiguration (cfg => {
                cfg.CreateMap<Survey, SurveyDto> ();
                cfg.CreateMap<Survey, SurveyScore> ();
            })
            .CreateMapper ();
    }
}