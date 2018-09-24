using System.Collections.Generic;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.SurveyReport;
using CareerMonitoring.Core.Domains.SurveysAnswers;
using CareerMonitoring.Infrastructure.Repositories;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using CareerMonitoring.Infrastructure.Services.Interfaces;

namespace CareerMonitoring.Infrastructure.Services {
    public class SurveyReportService : ISurveyReportService {
        private readonly ISurveyReportRepository _surveyReportRepository;
        private readonly ISurveyAnswerRepository _surveyAnswerRepository;
        private readonly IQuestionReportRepository _questionReportRepository;
        private readonly IDataSetRepository _dataSetRepository;
        private readonly IQuestionAnswerRepository _questionAnswerRepository;

        public SurveyReportService (ISurveyReportRepository surveyReportRepository,
            ISurveyAnswerRepository surveyAnswerRepository,
            IDataSetRepository dataSetRepository,
            IQuestionAnswerRepository questionAnswerRepository) {
            _surveyReportRepository = surveyReportRepository;
            _surveyAnswerRepository = surveyAnswerRepository;
            _dataSetRepository = dataSetRepository;
            _questionAnswerRepository = questionAnswerRepository;
        }


        public async Task<int> CreateAsync(int surveyId, string surveyTitle)
        {
            var surveyAnswersCount = _surveyAnswerRepository.CountAllSurveyAnswersBySurveyIdAsync(surveyId);
            var surveyReport = new SurveyReport(surveyId, surveyTitle);
            await _surveyReportRepository.AddAsync(surveyReport);
            for (var i = 0; i < surveyAnswersCount; i++){
                surveyReport.AddAnswer();
            }
            return surveyReport.Id;
        }

        public async Task<int> AddQuestionReport(int surveyReportId, int surveyAnswerId, int questionAnswerId,
            string content, string select, ICollection<string> labels)
        {
            var surveyReport = await _surveyReportRepository.GetByIdAsync(surveyReportId);
            var questionReport = new QuestionReport(content, select, labels);
            var questionAnswersCount = _questionAnswerRepository.
                CountAllQuestionAnswersByQuestionId(surveyAnswerId,questionAnswerId);
            surveyReport.AddQuestionReport(questionReport);
            await _questionReportRepository.AddAsync(questionReport);
            for (var i = 0; i < questionAnswersCount; i++){
                questionReport.AddAnswer();
            }

            return questionReport.Id;
        }

        public async Task AddDataSetToQuestionReportAsync(int questionReportId)
        {
            //var question 
        }

        public async Task GetByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task UpdateAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}