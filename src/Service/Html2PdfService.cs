using DinkToPdf;

namespace ReportEngine.Service
{
    public class Html2PdfService
    {
        public byte[] ConvertHtml(string html)
        {
            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Landscape,
                PaperSize = PaperKind.A4Plus,
            },
                        Objects = {
                new ObjectSettings() {
                    PagesCount = true,
                    HtmlContent = html,
                    WebSettings = { DefaultEncoding = "utf-8" },
                    HeaderSettings = { FontSize = 9, Right = "", Line = false, Spacing = 2.812 }
                }
            }
            };
            var converter = new SynchronizedConverter(new PdfTools());
            return converter.Convert(doc);
        }
    }
}
