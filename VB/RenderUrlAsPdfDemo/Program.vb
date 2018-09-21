'========================================================================
' This conversion was produced by the Free Edition of
' Instant VB courtesy of Tangible Software Solutions.
' Order the Premium Edition at https://www.tangiblesoftwaresolutions.com
'========================================================================

Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports IronPdf

Namespace RenderUrlAsPdfDemo
	Friend Class Program
		Shared Sub Main(ByVal args() As String)
			Console.WriteLine("Hold on tight!")

			Example1()
			Example2()

			Console.WriteLine("Done. Please find results under '{0}' directory.", Directory.GetCurrentDirectory())
			Console.WriteLine("Press any key to continue.")
			Console.ReadKey()
		End Sub

		Public Shared Sub Example1()
			Dim uri = New Uri("http://localhost:51169/Static/TestInvoice1.html")

			Dim urlToPdf = New HtmlToPdf()
			Dim pdf = urlToPdf.RenderUrlAsPdf(uri)
			pdf.SaveAs(Path.Combine(Directory.GetCurrentDirectory(), "UrlToPdfExample1.Pdf"))
		End Sub

		Public Shared Sub Example2()
			Dim uri = New Uri("http://localhost:51169/Invoice")

			Dim urlToPdf = New HtmlToPdf With {
				.PrintOptions = New PdfPrintOptions() With {
					.MarginTop = 50,
					.MarginBottom = 50,
					.Header = New PdfPrintOptions.PdfHeaderFooter() With {
						.CenterText = "{pdf-title}",
						.DrawDividerLine = True,
						.FontSize = 16
					},
					.Footer = New PdfPrintOptions.PdfHeaderFooter() With {
						.LeftText = "{date} {time}",
						.RightText = "Page {page} of {total-pages}",
						.DrawDividerLine = True,
						.FontSize = 14
					},
					.CssMediaType = PdfPrintOptions.PdfCssMediaType.Print
				},
				.LoginCredentials = New HttpLoginCredentials() With {
					.NetworkUsername = "testUser",
					.NetworkPassword = "testPassword"
				}
			}

			Dim pdf = urlToPdf.RenderUrlAsPdf(uri)
			pdf.SaveAs(Path.Combine(Directory.GetCurrentDirectory(), "UrlToPdfExample2.Pdf"))
		End Sub
	End Class
End Namespace
