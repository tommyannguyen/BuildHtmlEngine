using RazorLight;
using RenderingService.Util;
using RenderingService.ViewModel;

namespace RenderingService.Service
{
    public class RenderingService
    {
        public static string Render()
        {
            var template = AssemblyUtil.GetTemplateByName("Standard");
            var viewModel = new StandardViewModel
            {
                Title = "RazorLight rendered Html",
                Name = "RazorLight"
            };

            var engine = new RazorLightEngineBuilder()
                // .SetOperatingAssembly(typeof(RenderingService).Assembly)
                .UseMemoryCachingProvider()
                .Build();

            var rendered = engine.CompileRenderAsync("Standard", template, viewModel).Result;

            return rendered;
        }
    }
}
