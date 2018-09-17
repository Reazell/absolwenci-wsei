using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CareerMonitoring.Core.Domains.Surveys;
using CareerMonitoring.Core.Domains.SurveyScore;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using CareerMonitoring.Infrastructure.Services.Interfaces;

namespace CareerMonitoring.Infrastructure.Services {
    public class SurveyScoreService : ISurveyScoreService {
        private readonly IQuestionScoreRepository _questionScoreRepository;
        private readonly IQuestionAnswerRepository _questionAnswerRepository;
        private readonly ISurveyScoreRepository _surveyScoreRepository;
        private readonly IMapper _mapper;

        public SurveyScoreService (IQuestionScoreRepository questionScoreRepository,
            IQuestionAnswerRepository questionAnswerRepository,
            IMapper mapper, ISurveyScoreRepository surveyScoreRepository) {
            _questionScoreRepository = questionScoreRepository;
            _questionAnswerRepository = questionAnswerRepository;
            _mapper = mapper;
            _surveyScoreRepository = surveyScoreRepository;
        }

        public async Task<SurveyScore> CountScore (Survey survey) {

            var surveyScore = _mapper.Map<SurveyScore> (survey);
            await _surveyScoreRepository.AddAsync (surveyScore);

            var questionsAnswer = await _questionAnswerRepository.GetAllBySurveyIdInOrderAsync (survey.Id);

            var questionsScore = await _questionScoreRepository.GetAllBySurveyScoreIdInOrderAsync (surveyScore.Id);

            foreach (var question in questionsAnswer) {
                foreach (var questionScore in questionsScore) {

                    switch (question.Select) {

                        case "short-answer":

                            foreach (var fieldDataAnswer in question.FieldDataAnswers) {
                                foreach (var fieldDataScore in questionScore.FieldData) {

                                    if (!string.IsNullOrEmpty (fieldDataAnswer.Input))
                                        fieldDataScore.IncrementInputValue ();
                                }
                            }

                            break;

                        case "long-answer":

                            foreach (var fieldDataAnswer in question.FieldDataAnswers) {
                                foreach (var fieldDataScore in questionScore.FieldData) {

                                    if (!string.IsNullOrEmpty (fieldDataAnswer.Input))
                                        fieldDataScore.IncrementInputValue ();
                                }
                            }

                            break;

                        case "single-choice":

                            foreach (var fieldDataAnswer in question.FieldDataAnswers) {
                                foreach (var fieldDataScore in questionScore.FieldData) {

                                    foreach (var choiceOptionAnswer in fieldDataAnswer.ChoiceOptionAnswers) {
                                        foreach (var choiceOptionScore in fieldDataScore.ChoiceOptions) {

                                            if (choiceOptionAnswer.ViewValue == choiceOptionScore.ViewValue && choiceOptionAnswer.Value == true)
                                                choiceOptionScore.AddNumericalValue ();

                                        }
                                    }
                                }
                            }

                            break;

                        case "multiple-choice":

                            foreach (var fieldDataAnswer in question.FieldDataAnswers) {
                                foreach (var fieldDataScore in questionScore.FieldData) {

                                    foreach (var choiceOptionAnswer in fieldDataAnswer.ChoiceOptionAnswers) {
                                        foreach (var choiceOptionScore in fieldDataScore.ChoiceOptions) {

                                            if (choiceOptionAnswer.ViewValue == choiceOptionScore.ViewValue && choiceOptionAnswer.Value == true)
                                                choiceOptionScore.AddNumericalValue ();

                                        }
                                    }
                                }
                            }

                            break;

                        case "dropdown-menu":

                            foreach (var fieldDataAnswer in question.FieldDataAnswers) {
                                foreach (var fieldDataScore in questionScore.FieldData) {

                                    foreach (var choiceOptionAnswer in fieldDataAnswer.ChoiceOptionAnswers) {
                                        foreach (var choiceOptionScore in fieldDataScore.ChoiceOptions) {

                                            if (choiceOptionAnswer.ViewValue == choiceOptionScore.ViewValue && choiceOptionAnswer.Value == true)
                                                choiceOptionScore.AddNumericalValue ();

                                        }
                                    }
                                }
                            }

                            break;

                        case "linear-scale":

                            foreach (var fieldDataAnswer in question.FieldDataAnswers) {
                                foreach (var fieldDataScore in questionScore.FieldData) {

                                    foreach (var choiceOptionAnswer in fieldDataAnswer.ChoiceOptionAnswers) {
                                        foreach (var choiceOptionScore in fieldDataScore.ChoiceOptions) {

                                            if (choiceOptionAnswer.ViewValue == choiceOptionScore.ViewValue && choiceOptionAnswer.Value == true)
                                                choiceOptionScore.AddNumericalValue ();

                                        }
                                    }
                                }
                            }

                            break;

                        case "single-grid":

                            foreach (var fieldDataAnswer in question.FieldDataAnswers) {
                                foreach (var fieldDataScore in questionScore.FieldData) {

                                    foreach (var rowAnswer in fieldDataAnswer.RowsAnswers) {

                                        foreach (var choiceOptionAnswer in rowAnswer.ChoiceOptionAnswers)

                                            foreach (var choiceOptionScore in fieldDataScore.ChoiceOptions) {

                                                if (choiceOptionAnswer.ViewValue == choiceOptionScore.ViewValue && choiceOptionAnswer.Value == true)
                                                    choiceOptionScore.AddNumericalValue ();

                                            }
                                    }
                                }
                            }

                            break;

                        case "multiple-grid":

                            foreach (var fieldDataAnswer in question.FieldDataAnswers) {
                                foreach (var fieldDataScore in questionScore.FieldData) {

                                    foreach (var choiceOptionAnswer in fieldDataAnswer.ChoiceOptionAnswers) {
                                        foreach (var choiceOptionScore in fieldDataScore.ChoiceOptions) {

                                            if (choiceOptionAnswer.ViewValue == choiceOptionScore.ViewValue && choiceOptionAnswer.Value == true)
                                                choiceOptionScore.AddNumericalValue ();

                                        }
                                    }
                                }
                            }

                            break;

                    }
                }
            }
            await _surveyScoreRepository.UpdateAsync (surveyScore);
            return surveyScore;

        }

    }
}