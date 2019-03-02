using iTextSharp.text;
using iTextSharp.text.pdf;

namespace SGCM.AppData.Infraestrutura.PDFEstrutura {
    public class PDFEstrutura : PdfPageEventHelper {

        public static PdfPTable HeaderPdf(Document pdfDocument, PdfWriter pdfWriter) {
            PdfPTable pdfPTable = new PdfPTable(1);
            pdfPTable.TotalWidth = pdfDocument.PageSize.Width - pdfDocument.LeftMargin - pdfDocument.RightMargin;

            PdfPCell cell = new PdfPCell(new Phrase("Header spanning 3 columns"));
            cell.Colspan = 3;

            cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
            pdfPTable.AddCell(cell);
            pdfPTable.AddCell("Col 1 Row 1");
            pdfPTable.AddCell("Col 2 Row 1");
            pdfPTable.AddCell("Col 3 Row 1");
            pdfPTable.AddCell("Col 1 Row 2");
            pdfPTable.AddCell("Col 2 Row 2");
            pdfPTable.AddCell("Col 3 Row 2");
            return pdfPTable;
        }
    }
}
