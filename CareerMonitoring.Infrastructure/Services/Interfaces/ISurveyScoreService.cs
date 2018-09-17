using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.Surveys;
using CareerMonitoring.Core.Domains.SurveyScore;

namespace CareerMonitoring.Infrastructure.Services.Interfaces {
    public interface ISurveyScoreService {
        Task<SurveyScore> CountScore (Survey survey);
    }
}