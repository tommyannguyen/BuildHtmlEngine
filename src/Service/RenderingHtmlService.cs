using RazorLight;
using ReportEngine.Util;
using ReportEngine.ViewModel;
using System.Threading.Tasks;

namespace ReportEngine.Service
{
    public class RenderingHtmlService
    {
        private readonly RazorLightEngine _engine;
        public RenderingHtmlService()
        {
            _engine = new RazorLightEngineBuilder()
                .UseEmbeddedResourcesProject(typeof(RenderingHtmlService))
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
            return await _engine.CompileRenderStringAsync(templateName, template, viewModel);
        }
    }
}
