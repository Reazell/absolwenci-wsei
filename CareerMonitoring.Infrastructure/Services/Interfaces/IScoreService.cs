using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.Surveys;
using CareerMonitoring.Core.Domains.Surveys.Score;

namespace CareerMonitoring.Infrastructure.Services.Interfaces {
    public interface IScoreService {
        Task<SurveyScore> CountScore (Survey survey);
    }
}