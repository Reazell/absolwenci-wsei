using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CareerMonitoring.Core.Domains.SurveysAnswers;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using CareerMonitoring.Infrastructure.Services.Interfaces;

namespace CareerMonitoring.Infrastructure.Services
{
    public class SurveyAnswerService : ISurveyAnswerService
    {
        private IMapper _mapper;
        private readonly ISurveyAnswerRepository _surveyAnswerRepository;
        private readonly IQuestionAnswerRepository _questionAnswerRepository;
        private readonly IFieldDataAnswerRepository _fieldDataAnswerRepository;
        private readonly IChoiceOptionAnswerRepository _choiceOptionAnswerRepository;
        private readonly IRowAnswerRepository _rowAnswerRepository;
        private readonly IRowChoiceOptionAnswerRepository _rowChoiceOptionAnswerRepository;


        public SurveyAnswerService (IMapper mapper,
        ISurveyAnswerRepository surveyAnswerRepository,
        IQuestionAnswerRepository questionAnswerRepository,
        IFieldDataAnswerRepository fieldDataAnswerRepository,
        IChoiceOptionAnswerRepository choiceOptionAnswerRepository,
        IRowAnswerRepository rowAnswerRepository,
        IRowChoiceOptionAnswerRepository rowChoiceOptionAnswerRepository)
        {
            _mapper = mapper;
            _surveyAnswerRepository = surveyAnswerRepository;
            _questionAnswerRepository = questionAnswerRepository;
            _fieldDataAnswerRepository = fieldDataAnswerRepository;
            _choiceOptionAnswerRepository = choiceOptionAnswerRepository;
            _rowAnswerRepository = rowAnswerRepository;
            _rowChoiceOptionAnswerRepository = rowChoiceOptionAnswerRepository;
        }

        public async Task<int> CreateAsync(string surveyTitle, int surveyId)
        {
            var surveyAnswer = new SurveyAnswer (surveyTitle, surveyId);
            await _surveyAnswerRepository.AddAsync (surveyAnswer);
            return surveyAnswer.Id;
        }

        public async Task<int> AddQuestionAnswerToSurveyAnswerAsync (int surveyAnswerId, int questionPosition, string content, string select)
        {
            var surveyAnswer = await _surveyAnswerRepository.GetByIdAsync (surveyAnswerId);
            var questionAnswer = new QuestionAnswer (questionPosition, content, select);
            surveyAnswer.AddQuestionAnswer (questionAnswer);
            await _questionAnswerRepository.AddAsync (questionAnswer);
            return questionAnswer.Id;
        }

        public async Task<int> AddFieldDataAnswerToQuestionAnswerAsync (int questionAnswerId, string input, string minLabel, string maxLabel)
        {
            var questionAnswer = await _questionAnswerRepository.GetByIdAsync (questionAnswerId);
            switch(questionAnswer.Select)
            {
                case "short-answer":
                {
                    var fieldDataAnswer = new FieldDataAnswer(input);
                    questionAnswer.AddFieldDataAnswer(fieldDataAnswer);
                    await _fieldDataAnswerRepository.AddAsync (fieldDataAnswer);
                    return fieldDataAnswer.Id;
                }
                case "long-answer":
                {
                    var fieldDataAnswer = new FieldDataAnswer(input);
                    questionAnswer.AddFieldDataAnswer(fieldDataAnswer);
                    await _fieldDataAnswerRepository.AddAsync (fieldDataAnswer);
                    return fieldDataAnswer.Id;
                }
                case "single-choice":
                {
                    var fieldDataAnswer = new FieldDataAnswer();
                    questionAnswer.AddFieldDataAnswer(fieldDataAnswer);
                    await _fieldDataAnswerRepository.AddAsync (fieldDataAnswer);
                    return fieldDataAnswer.Id;
                }
                case "multiple-choice":
                {
                    var fieldDataAnswer = new FieldDataAnswer();
                    questionAnswer.AddFieldDataAnswer(fieldDataAnswer);
                    await _fieldDataAnswerRepository.AddAsync (fieldDataAnswer);
                    return fieldDataAnswer.Id;
                }
                case "dropdown-menu":
                {
                    var fieldDataAnswer = new FieldDataAnswer();
                    questionAnswer.AddFieldDataAnswer(fieldDataAnswer);
                    await _fieldDataAnswerRepository.AddAsync (fieldDataAnswer);
                    return fieldDataAnswer.Id;
                }
                case "linear-scale":
                {
                    var fieldDataAnswer = new FieldDataAnswer(minLabel, maxLabel);
                    questionAnswer.AddFieldDataAnswer(fieldDataAnswer);
                    await _fieldDataAnswerRepository.AddAsync (fieldDataAnswer);
                    return fieldDataAnswer.Id;
                }
                case "single-grid":
                {
                    var fieldDataAnswer = new FieldDataAnswer();
                    questionAnswer.AddFieldDataAnswer(fieldDataAnswer);
                    await _fieldDataAnswerRepository.AddAsync (fieldDataAnswer);
                    return fieldDataAnswer.Id;
                }
                case "multiple-grid":
                {
                    var fieldDataAnswer = new FieldDataAnswer();
                    questionAnswer.AddFieldDataAnswer(fieldDataAnswer);
                    await _fieldDataAnswerRepository.AddAsync (fieldDataAnswer);
                    return fieldDataAnswer.Id;
                }
                default:
                    throw new System.Exception("invalid select value");
            }
        }

        public async Task AddChoiceOptionsAnswerToFieldDataAnswerAsync (int fieldDataAnswerId, int optionPosition, bool value, string viewValue)
        {
            var fieldDataAnswer = await _fieldDataAnswerRepository.GetByIdAsync (fieldDataAnswerId);
            var choiceOptionAnswer = new ChoiceOptionAnswer(optionPosition, value, viewValue);
            fieldDataAnswer.AddChoiceOptionAnswer (choiceOptionAnswer);
            await _choiceOptionAnswerRepository.AddAsync (choiceOptionAnswer);
        }

        public async Task AddChoiceOptionAnswerToRowAnswerAsync (int rowAnswerId, int optionPosition, bool value, string viewValue)
        {
            var rowAnswer = await _rowAnswerRepository.GetByIdAsync (rowAnswerId);
            var rowChoiceOptionAnswer = new RowChoiceOptionAnswer(optionPosition, value, viewValue);
            rowAnswer.AddChoiceOptionAnswer (rowChoiceOptionAnswer);
            await _rowChoiceOptionAnswerRepository.AddAsync (rowChoiceOptionAnswer);
        }

        public async Task<int> AddRowAnswerAsync (int fieldDataId, int rowPosition, string input)
        {
            var fieldDataAnswer = await _fieldDataAnswerRepository.GetByIdAsync (fieldDataId);
            var rowAnswer = new RowAnswer(rowPosition, input);
            fieldDataAnswer.AddRow (rowAnswer);
            await _rowAnswerRepository.AddAsync (rowAnswer);
            return rowAnswer.Id;
        }

        public async Task<IEnumerable<SurveyAnswer>> GetAllAsync()
        {
            IEnumerable<SurveyAnswer> surveyAnswers = await _surveyAnswerRepository.GetAllWithQuestionsAsync ();
            return surveyAnswers;
        }

        public async Task<SurveyAnswer> GetBySurveyIdAsync(int surveyId)
        {
            var surveyAnswer = await _surveyAnswerRepository.GetByIdWithQuestionsAsync (surveyId);
            return surveyAnswer;
        }

        public async Task<SurveyAnswer> GetBySurveyTitleAsync(string surveyTitle)
        {
            var surveyAnswer = await _surveyAnswerRepository.GetByTitleWithQuestionsAsync (surveyTitle);
            return surveyAnswer;
        }

        public async Task DeleteAsync(int surveyAnswerId)
        {
            var surveyAnswer = await _surveyAnswerRepository.GetByIdAsync (surveyAnswerId);
            await _surveyAnswerRepository.DeleteAsync (surveyAnswer);
        }
    }
}