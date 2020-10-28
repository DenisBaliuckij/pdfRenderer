using System.IO;
using System.Text;
using Encoding = System.Text.Encoding;
using iText.Html2pdf;
using System;
using iText.StyledXmlParser.Css.Media;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Kernel.Events;

namespace RMS.Common.ReportsEngine.Services
{
    public class PdfGenerationService : IPdfGenerationService
    {
        protected int MARGIN_TOP = 20;
        protected int MARGIN_BOTTOM = 20;
        protected int MARGIN_LEFT = 20;
        protected int MARGIN_RIGHT = 20;
        protected int MARGIN_TOP_PAGE_NUMBER = 20;
        protected int ContentPositionX = 0;
        protected int ContentPositionY = 0;

        public byte[] CreatePdf(string html, string css)
        {
            using (var stream = new MemoryStream())
            {
                WritePdfDocument(html, css, stream);
                return stream.ToArray();
            }
        }

        private void WritePdfDocument(string html, string css, Stream outputStream)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            MediaDeviceDescription deviceDescription = new MediaDeviceDescription(MediaType.ALL)
                    .SetWidth(PageSize.A4.GetWidth())
                    .SetHeight(PageSize.A4.GetHeight());

            ConverterProperties converterProperties = new ConverterProperties().SetMediaDeviceDescription(deviceDescription);
            PdfDocument pdfDoc = new PdfDocument(new PdfWriter(outputStream));
            var doc = new Document(pdfDoc, PageSize.A4, true);

            HtmlConverter.ConvertToPdf(html, doc.GetPdfDocument(), converterProperties);
        }
    }
}