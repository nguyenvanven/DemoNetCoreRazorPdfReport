using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using NetCorePdfRazorDemo.PdfReport.Model;
using NetCorePdfRazorDemo.PdfReport.RenderingService;
using NetCorePdfRazorDemo.PdfReport.Template.ViewModels;

namespace NetCorePdfRazorDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportController : Controller
    {
        private const string TEST_REPORT_TEMPLATE = "PdfReport/Template/Views/TestPdfReportView.cshtml";

        private readonly HtmlViewToStringRendererService htmlViewToStringRenderer;
        private readonly HtmlToPdfConverter pdfConverter;

        public ReportController(HtmlViewToStringRendererService htmlViewToStringRenderer, HtmlToPdfConverter pdfConverter)
        {
            this.htmlViewToStringRenderer = htmlViewToStringRenderer;
            this.pdfConverter = pdfConverter;
        }


        // GET: Report
        public IActionResult Index()
        {
            var viewModel = new TestPdfReportViewModel(BuildTestData());
            return File(pdfConverter.ConvertToPdfReport(RenderHtmlReport(viewModel, TEST_REPORT_TEMPLATE)), "application/pdf", "report.pdf");
        }

        private List<TestModel> BuildTestData()
        {
            var listOfRows = new List<TestModel>();
            for (int i = 0; i < 140; i++)
            {
                listOfRows.Add(new TestModel
                {
                    Id = i,
                    LastName = "LastName test " + i,
                    Name = "Name " + i,
                    Balance = i + 1000
                });
            }
            return listOfRows;
        }

        private string RenderHtmlReport(TestPdfReportViewModel viewModel, string viewPath)
        {
            return htmlViewToStringRenderer.RenderViewToStringAsync(viewPath, viewModel).Result;
        }
    }
}