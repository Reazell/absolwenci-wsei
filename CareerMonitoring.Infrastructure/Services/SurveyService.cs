using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CareerMonitoring.Infrastructure.DTO;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using CareerMonitoring.Infrastructure.Services.Interfaces;

namespace CareerMonitoring.Infrastructure.Services
{
    public class SurveyService : ISurveyService
    {
        private readonly IMapper _mapper;
        private readonly IOpenQuestionRepository _openQuestionRepository;
        private readonly ILinearScaleRepository _linearScaleRepository;
        private readonly ISingleChoiceRepository _singleChoiceRepository;
        private readonly IMultipleChoiceRepository _multipleChoiceRepository;
        private readonly ISurveyRepository _surveyRepository;

        public SurveyService (IMapper mapper,
        IOpenQuestionRepository openQuestionRepository,
        ILinearScaleRepository linearScaleRepository,
        ISingleChoiceRepository singleChoiceRepository,
        IMultipleChoiceRepository multipleChoiceRepository,
        ISurveyRepository surveyRepository)
        {
            _mapper = mapper;
            _openQuestionRepository = openQuestionRepository;
            _linearScaleRepository = linearScaleRepository;
            _singleChoiceRepository = singleChoiceRepository;
            _multipleChoiceRepository = multipleChoiceRepository;
            _surveyRepository = surveyRepository;
        }
        public Task AddLinearScaleQuestionAsync(int surveyId, string content, int minValue, int maxValue, string minLabel, string maxLabel)
        {
            throw new System.NotImplementedException();
        }

        public Task AddMultipleChoiceQuestionAsync(int surveyId, string content)
        {
            throw new System.NotImplementedException();
        }

        public Task AddOpenQuestionAsync(int surveyId, string content)
        {
            throw new System.NotImplementedException();
        }

        public Task AddSingleChoiceQuestionAsync(int surveyId, string content)
        {
            throw new System.NotImplementedException();
        }

        public Task CreateAsync(string title)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<SurveyDto>> GetAllAsync(bool isTracking = true)
        {
            throw new System.NotImplementedException();
        }

        public Task<SurveyDto> GetByIdAsync(int id, bool isTracking = true)
        {
            throw new System.NotImplementedException();
        }

        public Task<SurveyDto> GetByTitleAsync(string title, bool isTracking = true)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}