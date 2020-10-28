using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.Common.ReportsEngine.Services
{
	public interface IPdfGenerationService
	{
		byte[] CreatePdf(string html, string css);
	}
}