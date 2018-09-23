using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CareerMonitoring.Core.Domains;
using CareerMonitoring.Core.Domains.Surveys;
using CareerMonitoring.Infrastructure.DTO;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using CareerMonitoring.Infrastructure.Services.Interfaces;

namespace CareerMonitoring.Infrastructure.Services
{
    public class SurveyService : ISurveyService
    {
        private IMapper _mapper;
        private readonly ISurveyRepository _surveyRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly IFieldDataRepository _fieldDataRepository;
        private readonly IChoiceOptionRepository _choiceOptionRepository;
        private readonly IRowRepository _rowRepository;

        public SurveyService (IMapper mapper,
        ISurveyRepository surveyRepository,
        IQuestionRepository questionRepository,
        IFieldDataRepository fieldDataRepository,
        IChoiceOptionRepository choiceOptionRepository,
        IRowRepository rowRepository)
        {
            _mapper = mapper;
            _surveyRepository = surveyRepository;
            _questionRepository = questionRepository;
            _fieldDataRepository = fieldDataRepository;
            _choiceOptionRepository = choiceOptionRepository;
            _rowRepository = rowRepository;
        }

        public async Task<int> CreateAsync(string title)
        {
            var survey = new Survey (title);
            await _surveyRepository.AddAsync (survey);
            return survey.Id;
        }

        public async Task<int> AddQuestionToSurveyAsync (int surveyId, int questionPosition, string content, string select)
        {
            var survey = await _surveyRepository.GetByIdAsync (surveyId);
            var question = new Question (questionPosition, content, select);
            survey.AddQuestion (question);
            await _questionRepository.AddAsync (question);
            return question.Id;
        }

        public async Task<int> AddFieldDataToQuestionAsync (int questionId, string input, int minValue, int maxValue, string minLabel, string maxLabel)
        {
            var question = await _questionRepository.GetByIdAsync (questionId);
            switch(question.Select)
            {
                case "short-answer":
                {
                    var fieldData = new FieldData(input);
                    question.AddFieldData(fieldData);
                    await _fieldDataRepository.AddAsync (fieldData);
                    return fieldData.Id;
                }
                case "long-answer":
                {
                    var fieldData = new FieldData(input);
                    question.AddFieldData(fieldData);
                    await _fieldDataRepository.AddAsync (fieldData);
                    return fieldData.Id;
                }
                case "single-choice":
                {
                    var fieldData = new FieldData();
                    question.AddFieldData(fieldData);
                    await _fieldDataRepository.AddAsync (fieldData);
                    return fieldData.Id;
                }
                case "multiple-choice":
                {
                    var fieldData = new FieldData();
                    question.AddFieldData(fieldData);
                    await _fieldDataRepository.AddAsync (fieldData);
                    return fieldData.Id;
                }
                case "dropdown-menu":
                {
                    var fieldData = new FieldData();
                    question.AddFieldData(fieldData);
                    await _fieldDataRepository.AddAsync (fieldData);
                    return fieldData.Id;
                }
                case "linear-scale":
                {
                    var fieldData = new FieldData(minValue, maxValue, minLabel, maxLabel);
                    question.AddFieldData(fieldData);
                    await _fieldDataRepository.AddAsync (fieldData);
                    return fieldData.Id;
                }
                case "single-grid":
                {
                    var fieldData = new FieldData();
                    question.AddFieldData(fieldData);
                    await _fieldDataRepository.AddAsync (fieldData);
                    return fieldData.Id;
                }
                case "multiple-grid":
                {
                    var fieldData = new FieldData();
                    question.AddFieldData(fieldData);
                    await _fieldDataRepository.AddAsync (fieldData);
                    return fieldData.Id;
                }
                default:
                    throw new System.Exception("invalid select value");
            }
        }

        public async Task AddChoiceOptionsAsync (int fieldDataId, int optionPosition, bool value, string viewValue)
        {
            var fieldData = await _fieldDataRepository.GetByIdAsync (fieldDataId);
            var choiceOption = new ChoiceOption(optionPosition, value, viewValue);
            fieldData.AddChoiceOption (choiceOption);
            await _choiceOptionRepository.AddAsync (choiceOption);
        }

        public async Task AddRowAsync (int fieldDataId, int rowPosition, string input)
        {
            var fieldData = await _fieldDataRepository.GetByIdAsync (fieldDataId);
            var row = new Row(rowPosition, input);
            fieldData.AddRow (row);
            await _rowRepository.AddAsync (row);
        }

        public async Task<IEnumerable<Survey>> GetAllAsync()
        {
            IEnumerable<Survey> surveys = await _surveyRepository.GetAllWithQuestionsAsync ();
            return surveys;
        }

        public async Task<Survey> GetByIdAsync(int surveyId)
        {
            var survey = await _surveyRepository.GetByIdWithQuestionsAsync (surveyId);
            return survey;
        }

        public async Task<Survey> GetByTitleAsync(string title)
        {
            var survey = await _surveyRepository.GetByTitleWithQuestionsAsync (title);
            return survey;
        }

        public async Task<int> UpdateAsync (int surveyId, string title)
        {
            await DeleteAsync (surveyId);
            var survey = new Survey (title);
            survey.SetId(surveyId);
            await _surveyRepository.AddAsync (survey);
            return survey.Id;
        }

        public async Task DeleteAsync(int surveyId)
        {
            var survey = await _surveyRepository.GetByIdAsync (surveyId);
            if(survey == null)
                throw new System.Exception("survey with given Id does not exist");
            await _surveyRepository.DeleteAsync (survey);
        }
    }
}