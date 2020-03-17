using Xunit;

namespace RenderingService.Test.TestSuites
{
    public class RenderingServiceTestSuite
    {
        [Fact]
        public void Test()
        {
            var rendered = Service.RenderingService.Render();

            Assert.NotNull(rendered);
        }
    }
}
