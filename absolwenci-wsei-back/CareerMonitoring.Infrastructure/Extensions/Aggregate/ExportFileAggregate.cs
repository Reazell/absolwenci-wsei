using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.SurveyReport;
using CareerMonitoring.Infrastructure.Extensions.Aggregate.Interfaces;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Primitives;
using OfficeOpenXml;
using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Information;
using OfficeOpenXml.Style;

namespace CareerMonitoring.Infrastructure.Extensions.Aggregate
{
    public class ExportFileAggregate : IExportFileAggregate
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private IConverter _converter;


        public ExportFileAggregate(IHostingEnvironment hostingEnvironment, IConverter converter)
        {
            _hostingEnvironment = hostingEnvironment;
            _converter = converter;
        }

        public async Task<FileStreamResult> ExportReportToTxt(SurveyReport surveyReport)
        {

            if (!Directory.Exists ("wwwroot")) {
                Directory.CreateDirectory ("wwwroot");
            }
            var path = Path.Combine(_hostingEnvironment.WebRootPath,"reports");
            if (!Directory.Exists (path)) {
                Directory.CreateDirectory (path);
            }

            var fullFileLocation = Path.Combine(path, surveyReport.Id + ".txt");
            if(File.Exists(fullFileLocation))
                File.Delete(fullFileLocation);

            string surveyReportTxt =
                "Nazwa ankiety: " + surveyReport.SurveyTitle + 
                Environment.NewLine + "Utworzona: "  + surveyReport.CreatedAt +
                Environment.NewLine +"Odpowiedzi: " + surveyReport.AnswersNumber +
                Environment.NewLine + "Pytania:" + Environment.NewLine;

            foreach (var questionReport in surveyReport.QuestionsReports)
            {
                surveyReportTxt += Environment.NewLine + "-" + questionReport.Content + Environment.NewLine
                    + "-ilość odpowiedzi: "+ questionReport.AnswersNumber + Environment.NewLine;
                switch (questionReport.Select)
                {
                    case "short-answer":
                    case "long-answer":
                        foreach (var reportDataSet in questionReport.DataSets)
                        {
                            foreach (var data in reportDataSet._data)
                            {
                                if(data!="")
                                    surveyReportTxt += "--" + data + Environment.NewLine;
                            }
                        }
                        break;
                    case "single-choice":
                    case "multiple-choice":
                    case "dropdown-menu":
                    case "linear-scale":
                        var array = new int[questionReport.Labels.Count];
                        foreach (var reportDataSet in questionReport.DataSets)
                        {
                            for (int i = 0; i < reportDataSet._data.Count; i++)
                            {
                                if(reportDataSet._data[i]=="1")
                                    array[i]++;
                            }
                        }

                        for (int i = 0; i < questionReport.Labels.Count; i++)
                            surveyReportTxt += "--" + questionReport.Labels.ElementAt(i) + ": liczba odpowiedzi: " +
                                           array[i] + Environment.NewLine;
                        break;
                    case "single-grid":
                    case "multiple-grid":
                        Dictionary<string,int[]> dictionary = new Dictionary<string, int[]>();
                        foreach (var reportDataSet in questionReport.DataSets)
                        {
                            if (dictionary.ContainsKey(reportDataSet.Label))
                            {
                                for (int i = 0; i < reportDataSet._data.Count; i++)
                                {
                                    if (reportDataSet._data[i] == "1")
                                        dictionary[reportDataSet.Label][i] += 1;
                                }
                            }
                            else
                            {
                                int[] ints = reportDataSet._data.Select(int.Parse).ToArray();
                                dictionary.Add(reportDataSet.Label,ints);
                            }
                                
                        }

                        for (int i = 0; i < questionReport.Labels.Count; i++)
                        {
                            surveyReportTxt += "--" + questionReport.Labels.ElementAt(i) + ": ";
                            foreach (var entry in dictionary)
                            {
                                surveyReportTxt += entry.Key + "x" + entry.Value[i] + " ";
                            }

                            surveyReportTxt += Environment.NewLine;
                        }
                        break;
                }
                
            }
            
            
            using (FileStream fs = File.Create(fullFileLocation))
            {
                Byte[] info = new UTF8Encoding(true).GetBytes(surveyReportTxt);
                fs.Write(info, 0, info.Length);
            }
            
            
            
            return new FileStreamResult(File.Open(fullFileLocation,FileMode.Open),"application/octet-stream")
            {
                FileDownloadName = "report.txt"
            };
        }

        public async Task<FileStreamResult> ExportReportToExcel(SurveyReport surveyReport)
        {
            if (!Directory.Exists ("wwwroot")) {
                Directory.CreateDirectory ("wwwroot");
            }
            var path = Path.Combine(_hostingEnvironment.WebRootPath,"reports");
            if (!Directory.Exists (path)) {
                Directory.CreateDirectory (path);
            }

            var fullFileLocation = Path.Combine(path, surveyReport.Id + ".xlsx");
            if(File.Exists(fullFileLocation))
                File.Delete(fullFileLocation);

            
            FileInfo fileInfo = new FileInfo(fullFileLocation);
            using (ExcelPackage package = new ExcelPackage(fileInfo))
            {
                var worksheet = package.Workbook.Worksheets.Add("Ankieta");
                worksheet.Cells.AutoFitColumns();
                worksheet.Cells.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                
                worksheet.Cells[1, 1].Value = "Nazwa ankiety";
                worksheet.Cells[1, 2].Value = surveyReport.SurveyTitle;
                
                worksheet.Cells[2, 1].Value = "Ilość odpowiedzi";
                worksheet.Cells[2, 2].Value = surveyReport.AnswersNumber;
                
                worksheet.Cells[3, 1].Value = "Utworzona";
                worksheet.Cells[3, 2].Value = ""+surveyReport.CreatedAt;

                foreach (var questionReport in surveyReport.QuestionsReports)
                {
                    worksheet = package.Workbook.Worksheets.Add(questionReport.Content);
                    worksheet.Cells.AutoFitColumns();
                    worksheet.Cells.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    
                    
                    worksheet.Cells[1, 1].Value = "Ilość odpowiedzi";
                    worksheet.Cells[1, 2].Value = questionReport.AnswersNumber;

                    switch (questionReport.Select)
                    {
                        case "short-answer":
                        case "long-answer":
                            for (int i = 0; i < questionReport.DataSets.Count; i++)
                            {
                                for (int j = 0; j < questionReport.DataSets.ElementAt(i)._data.Count; j++)
                                {
                                    if(questionReport.DataSets.ElementAt(i)._data[j]=="")
                                        continue;
                                    worksheet.Cells[3+i, 1].Value = questionReport.DataSets.ElementAt(i)._data[j];
                                }
                            }
                            break;
                        case "single-choice":
                        case "multiple-choice":
                        case "dropdown-menu":
                        case "linear-scale":
                            var array = new int[questionReport.Labels.Count];
                            foreach (var reportDataSet in questionReport.DataSets)
                            {
                                for (int i = 0; i < reportDataSet._data.Count; i++)
                                {
                                    if(reportDataSet._data[i]=="1")
                                        array[i]++;
                                }
                            }

                            for (int i = 0; i < questionReport.Labels.Count; i++)
                            {
                                worksheet.Cells[3,i+1].Value = questionReport.Labels.ElementAt(i);
                                worksheet.Cells[4,i+1].Value = array[i];
                            }

                            break;
                        case "single-grid":
                        case "multiple-grid":
                            Dictionary<string,int[]> dictionary = new Dictionary<string, int[]>();
                            foreach (var reportDataSet in questionReport.DataSets)
                            {
                                if (dictionary.ContainsKey(reportDataSet.Label))
                                {
                                    for (int i = 0; i < reportDataSet._data.Count; i++)
                                    {
                                        if (reportDataSet._data[i] == "1")
                                            dictionary[reportDataSet.Label][i] += 1;
                                    }
                                }
                                else
                                {
                                    int[] ints = reportDataSet._data.Select(int.Parse).ToArray();
                                    dictionary.Add(reportDataSet.Label,ints);
                                }
                                    
                            }
    
                            for (int i = 0; i < dictionary.Count; i++)
                            {
                                worksheet.Cells[3, i + 2].Value = dictionary.ElementAt(i).Key;
                            }
                            
                            for (int i = 0; i < questionReport.Labels.Count; i++)
                            {
                                worksheet.Cells[4 + i, 1].Value = questionReport.Labels.ElementAt(i);
                                for (int j = 0; j < dictionary.Count; j++)
                                {
                                    worksheet.Cells[4 + i, 2 + j].Value = dictionary.ElementAt(j).Value[i];
                                }
                            }
                        break;
                    }
                    
                }
                
                
                package.Save();
            }
            
            
            return new FileStreamResult(File.Open(fullFileLocation,FileMode.Open),"application/octet-stream")
            {
                FileDownloadName = "report.xlsx"
            };
        }

        public async Task<FileStreamResult> ExportReportToCsv(SurveyReport surveyReport)
        {
             if (!Directory.Exists ("wwwroot")) {
                Directory.CreateDirectory ("wwwroot");
            }
            var path = Path.Combine(_hostingEnvironment.WebRootPath,"reports");
            if (!Directory.Exists (path)) {
                Directory.CreateDirectory (path);
            }

            var fullFileLocation = Path.Combine(path, surveyReport.Id + ".csv");
            if(File.Exists(fullFileLocation))
                File.Delete(fullFileLocation);
            
            string surveyReportTxt = "Nazwa ankiety,Utworzona,Liczba odpowiedzi" + Environment.NewLine +
                                     surveyReport.SurveyTitle + "," + surveyReport.CreatedAt + "," +
                                     surveyReport.AnswersNumber + Environment.NewLine;

            foreach (var questionReport in surveyReport.QuestionsReports)
            {
                surveyReportTxt += Environment.NewLine + "Pytanie,Liczba odpowiedzi"+Environment.NewLine 
                                   + questionReport.Content + "," + questionReport.AnswersNumber +  Environment.NewLine + Environment.NewLine + 
                                   "odpowiedzi" + Environment.NewLine;
                switch (questionReport.Select)
                {
                    case "short-answer":
                    case "long-answer":
                        foreach (var reportDataSet in questionReport.DataSets)
                        {
                            foreach (var data in reportDataSet._data)
                            {
                                if(data!="")
                                    surveyReportTxt += data + Environment.NewLine;
                            }
                        }
                        break;
                    case "single-choice":
                    case "multiple-choice":
                    case "dropdown-menu":
                    case "linear-scale":
                        var array = new int[questionReport.Labels.Count];
                        foreach (var reportDataSet in questionReport.DataSets)
                        {
                            for (int i = 0; i < reportDataSet._data.Count; i++)
                            {
                                if(reportDataSet._data[i]=="1")
                                    array[i]++;
                            }
                        }

                        surveyReportTxt += "Etykieta,Liczba odpowiedzi" + Environment.NewLine;

                        for (int i = 0; i < questionReport.Labels.Count; i++)
                            surveyReportTxt += questionReport.Labels.ElementAt(i) + "," + array[i] + Environment.NewLine;
                        break;
                    case "single-grid":
                    case "multiple-grid":
                        Dictionary<string,int[]> dictionary = new Dictionary<string, int[]>();
                        foreach (var reportDataSet in questionReport.DataSets)
                        {
                            if (dictionary.ContainsKey(reportDataSet.Label))
                            {
                                for (int i = 0; i < reportDataSet._data.Count; i++)
                                {
                                    if (reportDataSet._data[i] == "1")
                                        dictionary[reportDataSet.Label][i] += 1;
                                }
                            }
                            else
                            {
                                int[] ints = reportDataSet._data.Select(int.Parse).ToArray();
                                dictionary.Add(reportDataSet.Label,ints);
                            }
                                
                        }
                        
                        foreach (var entry in dictionary)
                        {
                            surveyReportTxt += "," + entry.Key;
                        }

                        surveyReportTxt += Environment.NewLine;

                        for (int i = 0; i < questionReport.Labels.Count; i++)
                        {
                            surveyReportTxt += questionReport.Labels.ElementAt(i);
                            for (int j = 0; j < dictionary.Count; j++)
                            {
                                surveyReportTxt += "," + dictionary.ElementAt(j).Value[i];
                            }

                            surveyReportTxt += Environment.NewLine;
                        }
                        break;
                }
                
            }
            
            
            using (FileStream fs = File.Create(fullFileLocation))
            {
                Byte[] info = new UTF8Encoding(true).GetBytes(surveyReportTxt);
                fs.Write(info, 0, info.Length);
            }
            
            
            
            return new FileStreamResult(File.Open(fullFileLocation,FileMode.Open),"application/octet-stream")
            {
                FileDownloadName = "report.csv"
            };
        }

        public async Task<FileStreamResult> ExportReportToPdf(SurveyReport surveyReport)
        {
            if (!Directory.Exists ("wwwroot")) {
                Directory.CreateDirectory ("wwwroot");
            }
            var path = Path.Combine(_hostingEnvironment.WebRootPath,"reports");
            if (!Directory.Exists (path)) {
                Directory.CreateDirectory (path);
            }

            var fullFileLocation = Path.Combine(path, surveyReport.Id + ".pdf");
            if(File.Exists(fullFileLocation))
                File.Delete(fullFileLocation);
            
            
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = surveyReport.SurveyTitle,
                Out = fullFileLocation
            };
 
            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = generateHtmlReport(surveyReport),
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet =  Path.Combine(Directory.GetCurrentDirectory(), "assets", "styles.css") },
                HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
                FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Raport Created: "+DateTime.Now }
            };
 
            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };
 
            _converter.Convert(pdf);
 
            return new FileStreamResult(File.Open(fullFileLocation,FileMode.Open),"application/pdf")
            {
                FileDownloadName = "report.pdf"
            };
        }

        private string generateHtmlReport(SurveyReport surveyReport)
        {
            var sb = new StringBuilder();
            sb.Append(@"
                        <html>
                            <head>
                                <style>
                                    .header{
                                        text-align:center;
                                        padding-top:50px;
                                    } 
                                    .question{
                                        width:100%;
                                        margin-top:50px;
                                        position:relative;
                                        page-break-inside: avoid;
                                    } 
                                    .question h2{
                                        width:700px;
                                    }
                                    .odp{
                                        position:absolute;
                                        right:0;
                                        top:0;
                                    }
                                    .textAnswerHead{
                                        width:100%;
                                        height:20px;
                                        background-color:#c2e697;
                                        position:relative;
                                    }
                                    .textAnswer{
                                        background-color:#8bc34a;
                                        padding:10px;
                                    }
                                    .columnChart{
                                        width:100%;
                                        height:300px;
                                        position:relative;
                                    }
                                    .singleColumn{
                                        position:absolute;
                                        bottom:0;
                                        left:0;
                                        width:50px;
                                        height:50%;
                                        background-color:#8bc34a;
                                        text-align:center;
                                    }
                                    .colLabel{
                                        position:absolute;
                                        text-align:center;
                                        bottom:-20px;
                                        white-space: nowrap;
                                    }
                                    .repTable{
                                        border:1px solid;
                                        width:100%;
                                        height:300px;
                                        border-collapse: collapse;
                                    }
                                    .repTable th{
                                        border:1px solid;
                                    }
                                </style>
                            </head>
                            <body>
                                <div class='header'><h1>" + surveyReport.SurveyTitle + @"</h1>"+
                                "Liczba odpowiedzi: "+surveyReport.AnswersNumber+@"</div>
            ");

            foreach (var questionReport in surveyReport.QuestionsReports)
            {
                
                
                sb.Append(@"<div class='question'>
                                <h2>" + questionReport.Content + @"</h2><span class='odp'>Liczba odpowiedzi: "+questionReport.AnswersNumber+@"</span>");

                switch (questionReport.Select)
                {
                    case "short-answer":
                    case "long-answer":
                        foreach (var reportDataSet in questionReport.DataSets)
                        {
                            foreach (var data in reportDataSet._data)
                            {
                                if (data != "")
                                {
                                    sb.Append(@"<div class='textAnswerHead'></div>");
                                    sb.Append(@"<div class='textAnswer'>" + data + @"</div>");
                                }
                            }
                        }
                        break;
                    
                    
                    case "single-choice":
                    case "multiple-choice":
                    case "linear-scale":
                    case "dropdown-menu":
                        var array = new int[questionReport.Labels.Count];
                        foreach (var reportDataSet in questionReport.DataSets)
                        {
                            for (int i = 0; i < reportDataSet._data.Count; i++)
                            {
                                if(reportDataSet._data[i]=="1")
                                    array[i]++;
                            }
                        }

                        sb.Append(@"<div class='columnChart'>");
                                
                        for (int i = 0; i < questionReport.Labels.Count; i++)
                        {
                            sb.Append(@"
                                <div class='singleColumn' style='left:"+100*(1+i)/(questionReport.Labels.Count+2)+@"%;height:"+100*array[i]/array.Max()+@"%'>
                                    <span class='colLabel'>"+array[i]+" x "+questionReport.Labels.ElementAt(i)+@"</span>
                                </div>");
                        }
                        sb.Append(@"</div>
                        ");

                        break;
                    case "single-grid":
                    case "multiple-grid":
                        Dictionary<string,int[]> dictionary = new Dictionary<string, int[]>();
                        foreach (var reportDataSet in questionReport.DataSets)
                        {
                            if (dictionary.ContainsKey(reportDataSet.Label))
                            {
                                for (int i = 0; i < reportDataSet._data.Count; i++)
                                {
                                    if (reportDataSet._data[i] == "1")
                                        dictionary[reportDataSet.Label][i] += 1;
                                }
                            }
                            else
                            {
                                int[] ints = reportDataSet._data.Select(int.Parse).ToArray();
                                dictionary.Add(reportDataSet.Label,ints);
                            }
                                
                        }

                        sb.Append(@"<table class='repTable'>");
                        sb.Append(@"<tr style='background-color:#8bc34a'><th></th>");
                        foreach (var entry in dictionary)
                        {
                            sb.Append(@"<th>"+entry.Key+@"</th>");
                        }
                        sb.Append(@"</tr>");

                        
                        for (int i = 0; i < questionReport.Labels.Count; i++)
                        {
                            sb.Append(@"<tr><th style='background-color:#8bc34a'>"+questionReport.Labels.ElementAt(i)+@"</th>");
                            
                            for (int j = 0; j < dictionary.Count; j++)
                            {
                                sb.Append(@"<th style='background-color:#c2e697'>"+dictionary.ElementAt(j).Value[i]+@"</th>");
                            }

                            sb.Append(@"</tr>");
                        }
                        
                        sb.Append(@"</table>");
                        break;
                }
                
                sb.Append(@"</div>");
            }
            
            sb.Append(@"
                            </body>
                        </html>");
            return sb.ToString();
        }
        
    }
}