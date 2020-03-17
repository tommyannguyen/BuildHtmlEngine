using Xunit;
using System.Threading.Tasks;
using ReportEngine.Service;
using ReportEngine.ViewModel;

namespace ReportEngine.Test.TestSuites
{
    public class RenderingServiceTestSuite
    {
        [Fact]
        public async Task Test()
        {
            var reportService = new ReportService();
            var viewModel = new StandardViewModel
            {
                Title = "RazorLight rendered Html",
                Name = "RazorLight"
            };
            var rendered = await reportService.RenderStandardReportAsync(viewModel);

            Assert.NotNull(rendered);
        }
    }
}
