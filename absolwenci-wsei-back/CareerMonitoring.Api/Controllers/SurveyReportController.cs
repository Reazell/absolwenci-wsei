using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using CareerMonitoring.Infrastructure.Extensions.Aggregate.Interfaces;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CareerMonitoring.Api.Controllers {
    //[Authorize(Policy = "master")]
    public class SurveyReportController : ApiUserController {
        private readonly ISurveyReportRepository _surveyReportRepository;
        private readonly IExportFileAggregate _exportFileAggregate;

        public SurveyReportController (ISurveyReportRepository surveyReportRepository,
            IExportFileAggregate exportFileAggregate) {
            _surveyReportRepository = surveyReportRepository;
            _exportFileAggregate = exportFileAggregate;
        }

        [HttpGet ("surveyReports/{surveyId}")]
        public async Task<IActionResult> GetSurveyReport (int surveyId) {
            try{
                var surveyReport = await _surveyReportRepository.GetBySurveyIdAsync (surveyId);
                return Json (surveyReport);
            }
            catch(Exception e){
                return BadRequest (e.Message);
            }
        }
        
        [HttpGet ("surveyReports/{surveyId}.{fileType}")]
        public async Task<IActionResult> GetSurveyReportFile (int surveyId, string fileType) {
            try{
                var surveyReport = await _surveyReportRepository.GetBySurveyIdAsync (surveyId);

                switch (fileType.ToLower())
                {
                    case "txt":
                        return await _exportFileAggregate.ExportReportToTxt(surveyReport);
                    case "xlsx":
                        return await _exportFileAggregate.ExportReportToExcel(surveyReport);
                    case "csv":
                        return await _exportFileAggregate.ExportReportToCsv(surveyReport);
                    case "pdf":
                        return await _exportFileAggregate.ExportReportToPdf(surveyReport);
                    default:
                        return BadRequest("file type not supported");
                        break;
                }
                
                return Json (surveyReport);
            }
            catch(Exception e){
                return BadRequest (e.Message);
            }
        }
    }
}