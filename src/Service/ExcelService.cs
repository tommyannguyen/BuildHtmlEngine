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

            var sheets = workbook.Descendants<Sheet>();

            var firstSheet = sheets.FirstOrDefault(s => s.Name == "Template gửi qua Shell");
            
            int rowCount = 1;
            foreach (var sheet in sheets)
            {
                var worksheetPart = (WorksheetPart)workbookPart.GetPartById(sheet.Id);
                var sharedStringPart = workbookPart.SharedStringTablePart;
                var rows = worksheetPart.Worksheet.Descendants<Row>();

                foreach (var row in rows)
                {
                    if (rowCount != 1)
                    {
                        //int count = row.Elements<Cell>().Count();

                        foreach (Cell c in row.Elements<Cell>())
                        {
                            if (c.CellValue != null)
                            {
                                Trace.WriteLine(c.CellValue.InnerText);
                            }
                        }
                    }
                    rowCount++;
                }
            }
        }
    }
}
