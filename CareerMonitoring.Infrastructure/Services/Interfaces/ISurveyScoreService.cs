using System.Collections.Generic;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.Surveys;
using CareerMonitoring.Core.Domains.SurveysAnswers;
using CareerMonitoring.Core.Domains.SurveyScore;
using CareerMonitoring.Infrastructure.DTO;

namespace CareerMonitoring.Infrastructure.Services.Interfaces {
    public interface ISurveyScoreService {
        Task<SurveyDto> CountScore (Survey survey);
    }
}