using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.SurveyReport;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using CareerMonitoring.Infrastructure.Services.Interfaces;

namespace CareerMonitoring.Infrastructure.Services {
    public class SurveyReportService : ISurveyReportService {
        private readonly ISurveyReportRepository _surveyReportRepository;
        private readonly ISurveyRepository _surveyRepository;
        private readonly ISurveyAnswerRepository _surveyAnswerRepository;
        private readonly IQuestionReportRepository _questionReportRepository;
        private readonly IDataSetRepository _dataSetRepository;
        private readonly IChoiceOptionAnswerRepository _choiceOptionAnswerRepository;
        private readonly IQuestionAnswerRepository _questionAnswerRepository;

        public SurveyReportService (ISurveyReportRepository surveyReportRepository,
            ISurveyRepository surveyRepository,
            ISurveyAnswerRepository surveyAnswerRepository,
            IDataSetRepository dataSetRepository,
            IQuestionReportRepository questionReportRepository,
            IChoiceOptionAnswerRepository choiceOptionAnswerRepository,
            IQuestionAnswerRepository questionAnswerRepository) {
            _surveyReportRepository = surveyReportRepository;
            _surveyRepository = surveyRepository;
            _surveyAnswerRepository = surveyAnswerRepository;
            _dataSetRepository = dataSetRepository;
            _questionReportRepository = questionReportRepository;
            _choiceOptionAnswerRepository = choiceOptionAnswerRepository;
            _questionAnswerRepository = questionAnswerRepository;
        }

        //R E F A C T O R I N G
        public async Task<int> CreateAsync (int surveyId, string surveyTitle) {
            var surveyReport = new SurveyReport (surveyId, surveyTitle);
            await _surveyReportRepository.AddAsync (surveyReport);
            var survey = await _surveyRepository.GetByIdWithQuestionsAsync (surveyId);
            var surveyAnswersCount = await _surveyAnswerRepository.CountAllSurveyAnswersBySurveyIdAsync (surveyId);
            for (var i = 0; i < surveyAnswersCount; i++) {
                surveyReport.AddAnswer ();
            }
            foreach (var question in survey.Questions) {
                var questionReport = new QuestionReport (question.Content, question.Select, 0);
                surveyReport.AddQuestionReport (questionReport);
                await _questionReportRepository.AddAsync (questionReport);
                foreach (var fieldData in question.FieldData) {
                    switch (questionReport.Select) {
                        case "short-answer":
                        case "long-answer":
                            {
                                var dataSet = new DataSet ();
                                questionReport.AddDataSet (dataSet);
                                await _dataSetRepository.AddAsync (dataSet);
                                foreach(var label in questionReport.Labels)
                                {
                                    dataSet.AddData("0");
                                }
                            }
                            break;
                        case "dropdown-menu":
                            {
                                var dataSet = new DataSet ();
                                questionReport.AddDataSet (dataSet);
                                await _dataSetRepository.AddAsync (dataSet);
                                foreach(var label in questionReport.Labels)
                                {
                                    dataSet.AddData("0");
                                }
                            }
                            break;
                        case "linear-scale":
                        case "multiple-grid":
                        case "single-grid":
                            {
                                foreach (var row in fieldData.Rows) {
                                    var dataSet = new DataSet (row.Input);
                                    questionReport.AddDataSet (dataSet);
                                    await _dataSetRepository.AddAsync (dataSet);
                                    foreach(var label in questionReport.Labels)
                                    {
                                        dataSet.AddData("0");
                                    }
                                }
                            }
                            break;
                        case "single-choice":
                        case "multiple-choice":
                            {
                                var dataSet = new DataSet (question.Content);
                                questionReport.AddDataSet (dataSet);
                                await _dataSetRepository.AddAsync (dataSet);
                                foreach(var label in questionReport.Labels)
                                {
                                    dataSet.AddData("0");
                                }
                            }
                            break;
                    }

                    if (fieldData.ChoiceOptions == null)
                        return surveyReport.Id;
                    if (question.Select == "linear-scale") {
                        for (var i = 1; i <= fieldData.MaxValue; i++) {
                            questionReport.AddLabel (i.ToString ());
                        }
                    }
                    foreach (var choiceOption in fieldData.ChoiceOptions) {
                        questionReport.AddLabel (choiceOption.ViewValue);
                    }
                }
            }
            await AddDataSetValues (surveyId, surveyReport);
            return surveyReport.Id;
        }

    // R E F A C T O R I N G
    public async Task AddDataSetValues (int surveyId, SurveyReport surveyReport) {
        var surveyAnswers = await _surveyAnswerRepository.GetAllBySurveyIdWithQuestionsAsync(surveyId);
        foreach(var surveyAnswer in surveyAnswers){
            foreach(var questionAnswer in surveyAnswer.QuestionsAnswers)
            {
                switch(questionAnswer.Select)
                {
                    case "short-answer":
                    case "long-answer":
                    {
                        foreach(var fieldDataAnswer in questionAnswer.FieldDataAnswers)
                        {
                            var questionReport = await _questionReportRepository.GetBySurveyReportAsync(surveyReport.Id,
                                questionAnswer.Select, questionAnswer.Content);
                            foreach(var dataSet in questionReport.DataSets)
                            {
                                dataSet.AddData(fieldDataAnswer.Input);
                            }
                        }
                    }
                    break;
                    case "single-choice":
                    case "multiple-choice":
                    {
                        foreach(var fieldDataAnswer in questionAnswer.FieldDataAnswers)
                        {
                            var questionReport = await _questionReportRepository.GetBySurveyReportAsync(surveyReport.Id,
                                questionAnswer.Select, questionAnswer.Content);
                            foreach(var choiceOptionAnswer in fieldDataAnswer.ChoiceOptionAnswers){
                                foreach(var dataSet in questionReport.DataSets)
                                {
                                    if(choiceOptionAnswer.Value == true)
                                    {
                                        foreach(var data in dataSet._data)
                                        {
                                            var Data = dataSet._data.Where(i =>
                                                i.IndexOf(data) == choiceOptionAnswer.OptionPosition).Single();
                                            int counter = Int32.Parse(Data);
                                            counter++;
                                            Data = counter.ToString();
                                        }
                                    }
                                }
                            }
                        }
                    }
                    break;
                    case "linear-scale":
                    case "dropdown-menu":
                    case "single-grid":
                    case "multiple-grid":
                    {

                    }
                    break;
                }
            }
        }
    }

    public async Task<SurveyReport> GetByIdAsync (int id) {
        throw new System.NotImplementedException ();
    }

    public async Task UpdateAsync (int id) {
        throw new System.NotImplementedException ();
    }

    public async Task DeleteAsync (int id) {
        throw new System.NotImplementedException ();
    }
}
}