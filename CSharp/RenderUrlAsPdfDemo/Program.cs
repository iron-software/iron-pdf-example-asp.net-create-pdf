using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronPdf;

namespace RenderUrlAsPdfDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hold on tight!");

            Example1();
            Example2();

            Console.WriteLine("Done. Please find results under '{0}' directory.", Directory.GetCurrentDirectory());
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        public static void Example1()
        {
            var uri = new Uri("http://localhost:51169/Static/TestInvoice1.html");

            var urlToPdf = new HtmlToPdf();
            var pdf = urlToPdf.RenderUrlAsPdf(uri);
            pdf.SaveAs(Path.Combine(Directory.GetCurrentDirectory(), "UrlToPdfExample1.Pdf"));
        }

        public static void Example2()
        {
            var uri = new Uri("http://localhost:51169/Invoice");

            var urlToPdf = new HtmlToPdf
            {
                PrintOptions = new PdfPrintOptions()
                {
                    MarginTop = 50,
                    MarginBottom = 50,
                    Header = new PdfPrintOptions.PdfHeaderFooter()
                    {
                        CenterText = "{pdf-title}",
                        DrawDividerLine = true,
                        FontSize = 16
                    },
                    Footer = new PdfPrintOptions.PdfHeaderFooter()
                    {
                        LeftText = "{date} {time}",
                        RightText = "Page {page} of {total-pages}",
                        DrawDividerLine = true,
                        FontSize = 14
                    },
                    CssMediaType = PdfPrintOptions.PdfCssMediaType.Print
                },
                // setting login credentials to bypass basic authentication
                LoginCredentials = new HttpLoginCredentials()
                {
                    NetworkUsername = "testUser",
                    NetworkPassword = "testPassword"
                }
            };

            var pdf = urlToPdf.RenderUrlAsPdf(uri);
            pdf.SaveAs(Path.Combine(Directory.GetCurrentDirectory(), "UrlToPdfExample2.Pdf"));
        }
    }
}
