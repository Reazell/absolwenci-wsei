using AutoMapper;
using CareerMonitoring.Core.Domains.ImportFile;
using CareerMonitoring.Core.Domains.Surveys;
using CareerMonitoring.Infrastructure.DTO;
using CareerMonitoring.Infrastructure.DTO.ImportFile;
using CareerMonitoring.Infrastructure.DTO.Survey;

namespace CareerMonitoring.Infrastructure.Extensions.AutoMapper {
    public class AutoMapperConfig {
        public static IMapper Initialize () => new MapperConfiguration (cfg => {
                cfg.CreateMap<Survey, SurveyDto> ();
                cfg.CreateMap<Question, QuestionDto> ();
                cfg.CreateMap<FieldData, FieldDataDto> ();
                cfg.CreateMap<ChoiceOption, ChoiceOptionDto> ();
                cfg.CreateMap<Row, RowDto> ();
                cfg.CreateMap<ImportData, ImportDataDto> ();
            })
            .CreateMapper ();
    }
}