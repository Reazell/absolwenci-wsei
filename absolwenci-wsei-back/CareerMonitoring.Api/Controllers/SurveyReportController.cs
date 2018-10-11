using System;
using System.Threading.Tasks;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CareerMonitoring.Api.Controllers {
    [Authorize]
    public class SurveyReportController : ApiUserController {
        private readonly ISurveyReportRepository _surveyReportRepository;

        public SurveyReportController (ISurveyReportRepository surveyReportRepository) {
            _surveyReportRepository = surveyReportRepository;
        }

        [HttpGet ("surveyReports/{surveyId}")]
        public async Task<JsonResult> GetSurveyReport (int surveyId) {
            var surveyReport = await _surveyReportRepository.GetBySurveyIdAsync (surveyId);
            return Json (surveyReport);
        }
    }
}