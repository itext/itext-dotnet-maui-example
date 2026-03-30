using System.Text;
using iText.Html2pdf;
using iText.Kernel.Utils;

namespace itext_dotnet_maui_example;

public partial class MainPage : ContentPage
{
    int _count = 0;

    public MainPage()
    {
        InitializeComponent();
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        _count++;

        // Workaround for iOS to make PdfDocument functioning
        new RegisterDefaultDiContainer();
        // Similar workaround for iOS but for forms module
        new iText.Forms.Util.RegisterDefaultDiContainer();

        iTextLog.Text = Html2PdfTest(_count);
        CounterBtn.Text = $"iText was tested {_count} time(s)";


        SemanticScreenReader.Announce(CounterBtn.Text);
    }

    private static string Html2PdfTest(int counter)
    {
        StringBuilder sb = new StringBuilder("Start Html2Pdf test ").Append(counter).AppendLine();
        string pdfPath = Path.Combine(FileSystem.Current.AppDataDirectory, "res.pdf");
        string url = "https://example.com/";

        try
        {
            // 1. Download HTML content from the URL
            using (HttpClient client = new HttpClient())
            {
                string htmlContent = client.GetStringAsync(url).Result;

                // 2. Convert HTML to PDF
                using (FileStream pdfStream = new FileStream(pdfPath, FileMode.Create))
                {
                    ConverterProperties properties = new ConverterProperties();
                    // Optional: Set a base URI for the converter to correctly resolve relative paths for images/CSS
                    properties.SetBaseUri(url);

                    HtmlConverter.ConvertToPdf(htmlContent, pdfStream, properties);
                }

                sb.Append("Pdf was created by iText at ")
                    .Append(pdfPath)
                    .AppendLine();
            }
        }
        catch (Exception exc)
        {
            sb.Append("Exception: ")
                .Append(exc.Message)
                .AppendLine();
        }

        return sb.ToString();
    }
}