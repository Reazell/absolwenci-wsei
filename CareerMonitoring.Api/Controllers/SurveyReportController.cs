using System.Threading.Tasks;
using CareerMonitoring.Infrastructure.Commands.SurveyReport;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using CareerMonitoring.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CareerMonitoring.Api.Controllers
{
    //[Authorize]
    public class SurveyReportController : ApiUserController
    {
        private readonly ISurveyService _surveyService;
        private readonly ISurveyReportService _surveyReportService;
        private readonly ISurveyReportRepository _surveyReportRepository;

        public SurveyReportController(ISurveyService surveyService, ISurveyReportService surveyReportService,
            ISurveyReportRepository surveyReportRepository)
        {
            _surveyService = surveyService;
            _surveyReportService = surveyReportService;
            _surveyReportRepository = surveyReportRepository;
        }

        [HttpGet ("{surveyReportId}")]
        public async Task<JsonResult> GetSurveyReport(int surveyReportId)
        {
            var surveyReport = await _surveyReportRepository.GetByIdAsync(surveyReportId);
            return Json(surveyReport);
        }
    }
}