using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using ReportEngine.Util;
using System;
using System.Diagnostics;
using System.Linq;

namespace ReportEngine.Service
{
    public class ExcelService
    {
        public void GenerateRewardCatalogue()
        {
            using var memoryStream = AssemblyUtil.GetExcelTemplate("RewardsCatalogueTemplate");
            using var document = SpreadsheetDocument.Open(memoryStream, true);
            var workbookPart = document.WorkbookPart;
            var workbook = workbookPart.Workbook;
            SharedStringTablePart sstpart = workbookPart.GetPartsOfType<SharedStringTablePart>().First();
            SharedStringTable sst = sstpart.SharedStringTable;
            var sheets = workbook.Descendants<Sheet>();

            var firstSheet = sheets.FirstOrDefault(s => s.Name == "Template gửi qua Shell");
            
            int rowCount = 1;
            foreach (var sheet in sheets)
            {
                var worksheetPart = (WorksheetPart)workbookPart.GetPartById(sheet.Id);
                var sharedStringPart = workbookPart.SharedStringTablePart;
                var rows = worksheetPart.Worksheet.Descendants<Row>();

                Trace.WriteLine($"Sheet {sheet.Name}");
                foreach (var row in rows)
                {
                    if (rowCount != 1)
                    {
                        foreach (Cell cell in row.Elements<Cell>())
                        {
                            if ((cell.DataType != null) && (cell.DataType == CellValues.SharedString))
                            {
                                int ssid = int.Parse(cell.CellValue.Text);
                                string str = sst.ChildElements[ssid].InnerText;
                                Trace.WriteLine($"Shared string {ssid}: {str}");
                            }
                            else if (cell.CellValue != null)
                            {
                                Trace.WriteLine($"Cell contents: {cell.CellValue.Text}");
                            }
                        }
                    }
                    rowCount++;
                }
            }
        }
    }
}
