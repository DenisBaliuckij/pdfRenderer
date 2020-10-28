using System;
using System.IO;
using RMS.Common.ReportsEngine.Services;

namespace ReportRenderer
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			var html = File.ReadAllText(args[0]);
			var service = new PdfGenerationService();
			var pdfByted = service.CreatePdf(html, string.Empty);
			File.WriteAllBytes("rendered.pdf", pdfByted);
			Console.WriteLine("Hello World!");
		}
	}
}