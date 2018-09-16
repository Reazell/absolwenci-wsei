using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CareerMonitoring.Core.Domains.Surveys;
using CareerMonitoring.Core.Domains.Surveys.Score;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using CareerMonitoring.Infrastructure.Services.Interfaces;

namespace CareerMonitoring.Infrastructure.Services {
    public class ScoreService : IScoreService {
        private readonly ISurveyRepository _surveyRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly IScoreRepository _scoreRepository;
        private readonly IMapper _mapper;

        public ScoreService (ISurveyRepository surveyRepository,
            IQuestionRepository questionRepository,
            IMapper mapper, IScoreRepository scoreRepository) {
            _surveyRepository = surveyRepository;
            _questionRepository = questionRepository;
            _mapper = mapper;
            _scoreRepository = scoreRepository;
        }

        public async Task<SurveyScore> CountScore (Survey survey) {

            var surveyScore = _mapper.Map<SurveyScore> (survey);
            await _scoreRepository.AddAsync (surveyScore);

            var questions = await _questionRepository.GetAllBySurveyIdInOrderAsync (survey.Id);

            var questionsScore = await _scoreRepository.GetAllBySurveyScoreIdInOrderAsync (surveyScore.Id); // get only questions from db

            foreach (var question in questions) {
                foreach (var questionScore in questionsScore) {

                    switch (question.Select) {

                        case "single-choice":

                            foreach (var choiceOption in question.FieldData.ChoiceOptions) {
                                foreach (var choiceScore in questionScore.FieldData.ChoiceOptions) {

                                    if (choiceOption.ViewValue == choiceScore.ViewValue && choiceOption.Value == true)
                                        choiceScore.AddNumericalValue ();
                                }
                            }

                            break;

                        case "multiple-choice":

                            foreach (var choiceOption in question.FieldData.ChoiceOptions) {
                                foreach (var choiceScore in questionScore.FieldData.ChoiceOptions) {

                                    if (choiceOption.ViewValue == choiceScore.ViewValue && choiceOption.Value == true)
                                        choiceScore.AddNumericalValue ();
                                }
                            }

                            break;

                        case "short-answer":

                            if (string.IsNullOrEmpty (question.FieldData.Input))
                                questionScore.FieldData.IncrementInputValue ();

                            break;

                        case "long-answer":

                            if (string.IsNullOrEmpty (question.FieldData.Input))
                                questionScore.FieldData.IncrementInputValue ();
                                
                            break;
                    }
                }
            }

            return surveyScore;

            // var surveys = await _surveyRepository.GetAllWithQuestionsFieldDataAndChoiceOptionsByTitleAsync (survey.Title);
            // Survey surveyScore = new Survey (survey.Title);

            // foreach (var s in surveys) {

            //     foreach (var question in s.Questions) {
            //         Question questionScore = new Question (question.QuestionPosition, question.Content,
            //             question.Select);
            //         surveyScore.AddQuestion (questionScore);

            //         switch (question.Select) {

            //             case "single-choice":

            //                 foreach (var choiceOption in question.FieldData.ChoiceOptions) {

            //                     for (int i = 0; i < question.FieldData.ChoiceOptions.Count; i++) {
            //                         if (choiceOption.OptionPosition == i && choiceOption.Value == true)
            //                             choiceScore.AddViewValue (choiceOption.ViewValue);
            //                         choiceScore.AddNumericalValue ();
            //                     }

            //                 }

            //                 break;

            //         } // switch

            //     } //question loop

            // } //survey loop

        }

    }
}