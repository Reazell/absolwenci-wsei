using System.IO;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.SurveyReport;
using Microsoft.AspNetCore.Mvc;

namespace CareerMonitoring.Infrastructure.Extensions.Aggregate.Interfaces
{
    public interface IExportFileAggregate
    {
        Task<FileStreamResult> ExportReportToTxt(SurveyReport surveyReport);
        Task<FileStreamResult> ExportReportToExcel(SurveyReport surveyReport);
        Task<FileStreamResult> ExportReportToCsv(SurveyReport surveyReport);
        Task<FileStreamResult> ExportReportToPdf(SurveyReport surveyReport);
    }
}