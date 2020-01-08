using NetCorePdfRazorDemo.PdfReport.Model;
using System.Collections.Generic;

namespace NetCorePdfRazorDemo.PdfReport.Template.ViewModels
{
    public class TestPdfReportViewModel
    {
        public List<TestModel> Data { get; set; }

        public TestPdfReportViewModel(List<TestModel> data)
        {
            Data = data;
        }
    }
}
