# Nca Report Engine
1.Render http : using Razor engine
2.Http to pdf : using DinkToPdf
```
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
    }	
```

*Note : libwkhtmltox.dll = version 64 bit 