using Xunit;
using System.Threading.Tasks;
using ReportEngine.Service;
using ReportEngine.ViewModel;
using System.IO;

namespace ReportEngine.Test.TestSuites
{
    public class RenderingServiceTestSuite
    {
        [Fact]
        public async Task Test()
        {
            var reportService = new RenderingHtmlService();
            var html2PdfService = new Html2PdfService();
            var viewModel = new StandardViewModel
            {
                Title = "RazorLight rendered Html",
                Name = "RazorLight"
            };
            var html = await reportService.RenderStandardReportAsync(viewModel);

            var pdfData = html2PdfService.ConvertHtml(html);
            File.WriteAllBytes("output.pdf", pdfData);
            Assert.NotNull(html);
        }

        [Fact]
        public async Task TestWriteTemplate()
        {
            var excelService = new ExcelService();
            excelService.GenerateRewardCatalogue();
            Assert.True(true);
        }
    }
}
