using DinkToPdf;
using DinkToPdf.Contracts;

namespace NetCorePdfRazorDemo.PdfReport.RenderingService
{
    public class HtmlToPdfConverter
    {
        private readonly IConverter pdfConverter;

        public HtmlToPdfConverter(IConverter pdfConverter)
        {
            this.pdfConverter = pdfConverter;
        }

        public byte[] ConvertToPdfReport(string htmlReport)
        {
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,

                Margins = new MarginSettings { Top = 20 }
            };

            var objectSettings = new ObjectSettings
            {
                PagesCount = true,

                HtmlContent = htmlReport,
                WebSettings = { DefaultEncoding = "utf-8" },
                HeaderSettings = { FontName = "Arial", FontSize = 9, Line = true, Spacing = 1.8, Center = "Test Report" },
                FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Right = "Trang [page] / [toPage]", Spacing = 1.8 }
            };

            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };

            return pdfConverter.Convert(pdf);
        }
    }
}
