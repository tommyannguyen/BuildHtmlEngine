using RazorLight;
using ReportEngine.Util;
using ReportEngine.ViewModel;
using System.Threading.Tasks;

namespace ReportEngine.Service
{
    public class ReportService
    {
        private readonly RazorLightEngine _engine;
        public ReportService()
        {
            _engine = new RazorLightEngineBuilder()
                .UseMemoryCachingProvider()
                .Build();

        }
        public async Task<string> RenderStandardReportAsync(StandardViewModel viewModel)
        {
            return await RenderAsync("Standard", viewModel);
        }
        private async Task<string> RenderAsync(string templateName, object viewModel)
        {
            var template = AssemblyUtil.GetTemplateByName(templateName);
            return await _engine.CompileRenderAsync(templateName, template, viewModel);
        }
    }
}
