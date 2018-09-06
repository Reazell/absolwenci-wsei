using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CareerMonitoring.Core.Domains.Surveys;
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
        public async Task AddLinearScaleQuestionAsync(int surveyId, string content, int minValue, int maxValue, string minLabel, string maxLabel)
        {
            var survey = await _surveyRepository.GetByIdAsync (surveyId);
            survey.AddLinearScale (new LinearScale (content, minValue, maxValue, minLabel, maxLabel));
            await _surveyRepository.UpdateAsync (survey);
        }

        public async Task AddMultipleChoiceQuestionAsync(int surveyId, string content)
        {
            var survey = await _surveyRepository.GetByIdAsync(surveyId);
            survey.AddMultipleChoice (new MultipleChoice (content));
            await _surveyRepository.UpdateAsync (survey);
        }

        public async Task AddOpenQuestionAsync(int surveyId, string content)
        {
            var survey = await _surveyRepository.GetByIdAsync (surveyId);
            survey.AddOpenQuestion (new OpenQuestion (content));
            await _surveyRepository.UpdateAsync (survey);
        }

        public async Task AddSingleChoiceQuestionAsync(int surveyId, string content)
        {
            var survey = await _surveyRepository.GetByIdAsync (surveyId);
            survey.AddSingleChoice (new SingleChoice (content));
            await _surveyRepository.UpdateAsync (survey);
        }

        public async Task CreateAsync(string title)
        {
            var survey = new Survey(title);
            await _surveyRepository.AddAsync(survey);
        }

        public async Task DeleteAsync(int id)
        {
            var survey = await _surveyRepository.GetByIdWithQuestionsAsync (id);
            await _surveyRepository.DeleteAsync (survey);
        }

        public async Task<IEnumerable<SurveyDto>> GetAllAsync()
        {
            var survey = await _surveyRepository.GetAllWithQuestionsAsync ();
            return _mapper.Map<IEnumerable<SurveyDto>> (survey);
        }

        public async Task<SurveyDto> GetByIdAsync(int id)
        {
            var survey = await _surveyRepository.GetByIdWithQuestionsAsync (id);
            return _mapper.Map<SurveyDto> (survey);
        }

        public async Task<SurveyDto> GetByTitleAsync(string title)
        {
            var survey = await _surveyRepository.GetByTitleWithQuestionsAsync (title);
            return _mapper.Map<SurveyDto> (survey);
        }

        public async Task UpdateAsync(int id)
        {
            var survey = await _surveyRepository.GetByIdWithQuestionsAsync (id);
            await _surveyRepository.UpdateAsync (survey);
        }
    }
}