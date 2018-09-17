using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CareerMonitoring.Core.Domains.Surveys;
using CareerMonitoring.Core.Domains.SurveysAnswers;
using CareerMonitoring.Core.Domains.SurveyScore;
using CareerMonitoring.Infrastructure.DTO;
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

        public async Task<SurveyDto> CountScore (Survey survey) {

            var surveyScore = _mapper.Map<SurveyDto> (survey);

            var questionsAnswer = await _questionAnswerRepository.GetAllBySurveyIdInOrderAsync (survey.Id);

            var questionsScore = (from x in surveyScore.Questions select x);

            foreach (var questionScore in questionsScore) {
                foreach (var question in questionsAnswer) {

                    switch (question.Select) {

                        case "short-answer":

                            if (questionScore.Select == "short-answer" && question.QuestionPosition == questionScore.QuestionPosition)
                                foreach (var fieldDataScore in questionScore.FieldData) {
                                    foreach (var fieldDataAnswer in question.FieldDataAnswers) {

                                        if (!string.IsNullOrEmpty (fieldDataAnswer.Input))
                                            fieldDataScore.IncrementInputValue ();
                                    }
                                }

                            break;

                        case "long-answer":

                            if (questionScore.Select == "long-answer" && question.QuestionPosition == questionScore.QuestionPosition)
                                foreach (var fieldDataScore in questionScore.FieldData) {
                                    foreach (var fieldDataAnswer in question.FieldDataAnswers) {

                                        if (!string.IsNullOrEmpty (fieldDataAnswer.Input))
                                            fieldDataScore.IncrementInputValue ();
                                    }
                                }

                            break;

                        case "single-choice":

                            if (questionScore.Select == "single-choice" && question.QuestionPosition == questionScore.QuestionPosition)
                                foreach (var fieldDataScore in questionScore.FieldData) {
                                    foreach (var fieldDataAnswer in question.FieldDataAnswers) {

                                        foreach (var choiceOptionScore in fieldDataScore.ChoiceOptions) {
                                            foreach (var choiceOptionAnswer in fieldDataAnswer.ChoiceOptionAnswers) {

                                                if (choiceOptionAnswer.ViewValue.ToLowerInvariant () == choiceOptionScore.ViewValue.ToLowerInvariant () && choiceOptionAnswer.Value == true)
                                                    choiceOptionScore.AddNumericalValue ();

                                            }
                                        }
                                    }
                                }

                            break;

                        case "multiple-choice":

                            if (questionScore.Select == "multiple-choice" && question.QuestionPosition == questionScore.QuestionPosition)
                                foreach (var fieldDataScore in questionScore.FieldData) {
                                    foreach (var fieldDataAnswer in question.FieldDataAnswers) {

                                        foreach (var choiceOptionScore in fieldDataScore.ChoiceOptions) {
                                            foreach (var choiceOptionAnswer in fieldDataAnswer.ChoiceOptionAnswers) {

                                                if (choiceOptionAnswer.ViewValue.ToLowerInvariant () == choiceOptionScore.ViewValue.ToLowerInvariant () && choiceOptionAnswer.Value == true)
                                                    choiceOptionScore.AddNumericalValue ();

                                            }
                                        }
                                    }
                                }

                            break;

                        case "dropdown-menu":

                            if (questionScore.Select == "dropdown-menu" && question.QuestionPosition == questionScore.QuestionPosition)
                                foreach (var fieldDataScore in questionScore.FieldData) {
                                    foreach (var fieldDataAnswer in question.FieldDataAnswers) {

                                        foreach (var choiceOptionAnswer in fieldDataAnswer.ChoiceOptionAnswers) {
                                            foreach (var choiceOptionScore in fieldDataScore.ChoiceOptions) {

                                                if (choiceOptionAnswer.OptionPosition == choiceOptionScore.OptionPosition && choiceOptionAnswer.Value == true)
                                                    choiceOptionScore.AddNumericalValue ();

                                            }
                                        }
                                    }
                                }

                            break;

                        case "linear-scale":

                            if (questionScore.Select == "linear-scale" && question.QuestionPosition == questionScore.QuestionPosition)
                                foreach (var fieldDataScore in questionScore.FieldData) {
                                    foreach (var fieldDataAnswer in question.FieldDataAnswers) {

                                        foreach (var choiceOptionAnswer in fieldDataAnswer.ChoiceOptionAnswers) {
                                            foreach (var choiceOptionScore in fieldDataScore.ChoiceOptions) {

                                                if (choiceOptionAnswer.OptionPosition == choiceOptionScore.OptionPosition && choiceOptionAnswer.Value == true)
                                                    choiceOptionScore.AddNumericalValue ();

                                            }
                                        }
                                    }
                                }

                            break;

                        case "single-grid":

                            if (questionScore.Select == "single-grid" && question.QuestionPosition == questionScore.QuestionPosition)
                                foreach (var fieldDataScore in questionScore.FieldData) {
                                    foreach (var fieldDataAnswer in question.FieldDataAnswers) {

                                        foreach (var rowAnswer in fieldDataAnswer.RowsAnswers) {

                                            foreach (var choiceOptionAnswer in fieldDataAnswer.ChoiceOptionAnswers) {
                                                foreach (var choiceOptionScore in fieldDataScore.ChoiceOptions) {

                                                    if (choiceOptionAnswer.OptionPosition == choiceOptionScore.OptionPosition && choiceOptionAnswer.Value == true)
                                                        choiceOptionScore.AddNumericalValue ();

                                                }
                                            }
                                        }
                                    }
                                }

                            break;

                        case "multiple-grid":

                            if (questionScore.Select == "multiple-grid" && question.QuestionPosition == questionScore.QuestionPosition)
                                foreach (var fieldDataScore in questionScore.FieldData) {
                                    foreach (var fieldDataAnswer in question.FieldDataAnswers) {

                                        foreach (var rowAnswer in fieldDataAnswer.RowsAnswers) {

                                            foreach (var choiceOptionAnswer in fieldDataAnswer.ChoiceOptionAnswers) {
                                                foreach (var choiceOptionScore in fieldDataScore.ChoiceOptions) {

                                                    if (choiceOptionAnswer.OptionPosition == choiceOptionScore.OptionPosition && choiceOptionAnswer.Value == true)
                                                        choiceOptionScore.AddNumericalValue ();

                                                }
                                            }
                                        }
                                    }
                                }

                            break;

                        default:
                            throw new Exception ("Something went wrong in loop.");

                    }
                }
            }

            // foreach (var questionScore in questionsScore) {
            //     foreach (var question in questionsAnswer) {

            //         if (question.Select == "short-answer" &&
            //             questionScore.Select == "short-answer" &&
            //             question.QuestionPosition == questionScore.QuestionPosition) {

            //             foreach (var fieldDataScore in questionScore.FieldData) {
            //                 foreach (var fieldDataAnswer in question.FieldDataAnswers) {

            //                     if (!string.IsNullOrEmpty (fieldDataAnswer.Input))
            //                         fieldDataScore.IncrementInputValue ();
            //                 }
            //             }
            //         }

            //         if (question.Select == "long-answer" &&
            //             questionScore.Select == "long-answer" &&
            //             question.QuestionPosition == questionScore.QuestionPosition) {

            //             foreach (var fieldDataScore in questionScore.FieldData) {
            //                 foreach (var fieldDataAnswer in question.FieldDataAnswers) {

            //                     if (!string.IsNullOrEmpty (fieldDataAnswer.Input))
            //                         fieldDataScore.IncrementInputValue ();
            //                 }
            //             }
            //         }

            //         if (question.Select == "single-choice" &&
            //             questionScore.Select == "single-choice" &&
            //             question.QuestionPosition == questionScore.QuestionPosition) {

            //             foreach (var fieldDataScore in questionScore.FieldData) {
            //                 foreach (var fieldDataAnswer in question.FieldDataAnswers) {

            //                     foreach (var choiceOptionScore in fieldDataScore.ChoiceOptions) {
            //                         foreach (var choiceOptionAnswer in fieldDataAnswer.ChoiceOptionAnswers) {

            //                             if (choiceOptionAnswer.OptionPosition == choiceOptionScore.OptionPosition && choiceOptionAnswer.Value == true)
            //                                 choiceOptionScore.AddNumericalValue ();

            //                         }
            //                     }
            //                 }
            //             }
            //         }

            //         if (question.Select == "multiple-choice" &&
            //             questionScore.Select == "multiple-choice" &&
            //             question.QuestionPosition == questionScore.QuestionPosition) {

            //             foreach (var fieldDataScore in questionScore.FieldData) {
            //                 foreach (var fieldDataAnswer in question.FieldDataAnswers) {

            //                     foreach (var choiceOptionScore in fieldDataScore.ChoiceOptions) {
            //                         foreach (var choiceOptionAnswer in fieldDataAnswer.ChoiceOptionAnswers) {

            //                             if (choiceOptionAnswer.OptionPosition == choiceOptionScore.OptionPosition && choiceOptionAnswer.Value == true)
            //                                 choiceOptionScore.AddNumericalValue ();

            //                         }
            //                     }
            //                 }
            //             }
            //         }

            //         if (question.Select == "dropdown-menu" &&
            //             questionScore.Select == "dropdown-menu" &&
            //             question.QuestionPosition == questionScore.QuestionPosition) {

            //             foreach (var fieldDataScore in questionScore.FieldData) {
            //                 foreach (var fieldDataAnswer in question.FieldDataAnswers) {

            //                     foreach (var choiceOptionScore in fieldDataScore.ChoiceOptions) {
            //                         foreach (var choiceOptionAnswer in fieldDataAnswer.ChoiceOptionAnswers) {

            //                             if (choiceOptionAnswer.OptionPosition == choiceOptionScore.OptionPosition && choiceOptionAnswer.Value == true)
            //                                 choiceOptionScore.AddNumericalValue ();

            //                         }
            //                     }
            //                 }
            //             }
            //         }

            //         if (question.Select == "linear-scale" &&
            //             questionScore.Select == "linear-scale" &&
            //             question.QuestionPosition == questionScore.QuestionPosition) {

            //             foreach (var fieldDataScore in questionScore.FieldData) {
            //                 foreach (var fieldDataAnswer in question.FieldDataAnswers) {

            //                     foreach (var choiceOptionScore in fieldDataScore.ChoiceOptions) {
            //                         foreach (var choiceOptionAnswer in fieldDataAnswer.ChoiceOptionAnswers) {

            //                             if (choiceOptionAnswer.OptionPosition == choiceOptionScore.OptionPosition && choiceOptionAnswer.Value == true)
            //                                 choiceOptionScore.AddNumericalValue ();

            //                         }
            //                     }
            //                 }
            //             }
            //         }

            //         if (question.Select == "single-grid" &&
            //             questionScore.Select == "single-grid" &&
            //             question.QuestionPosition == questionScore.QuestionPosition) {

            //             foreach (var fieldDataScore in questionScore.FieldData) {
            //                 foreach (var fieldDataAnswer in question.FieldDataAnswers) {

            //                     foreach (var rowAnswer in fieldDataAnswer.RowsAnswers) {

            //                         foreach (var choiceOptionScore in fieldDataScore.ChoiceOptions) {
            //                             foreach (var choiceOptionAnswer in fieldDataAnswer.ChoiceOptionAnswers) {

            //                                 if (choiceOptionAnswer.OptionPosition == choiceOptionScore.OptionPosition && choiceOptionAnswer.Value == true)
            //                                     choiceOptionScore.AddNumericalValue ();

            //                             }
            //                         }
            //                     }
            //                 }
            //             }
            //         }

            //         if (question.Select == "multiple-grid" &&
            //             questionScore.Select == "multiple-grid" &&
            //             question.QuestionPosition == questionScore.QuestionPosition) {

            //             foreach (var fieldDataScore in questionScore.FieldData) {
            //                 foreach (var fieldDataAnswer in question.FieldDataAnswers) {

            //                     foreach (var rowAnswer in fieldDataAnswer.RowsAnswers) {

            //                         foreach (var choiceOptionScore in fieldDataScore.ChoiceOptions) {
            //                             foreach (var choiceOptionAnswer in fieldDataAnswer.ChoiceOptionAnswers) {

            //                                 if (choiceOptionAnswer.OptionPosition == choiceOptionScore.OptionPosition && choiceOptionAnswer.Value == true)
            //                                     choiceOptionScore.AddNumericalValue ();

            //                             }
            //                         }
            //                     }
            //                 }
            //             }
            //         }
            //     }
            // }

            return surveyScore;

        }

    }
}