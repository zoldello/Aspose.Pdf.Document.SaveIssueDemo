using System;
using System.IO;
using System.Windows.Forms;

namespace Aspose.Pdf.TextInImageIssue
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*Add license*/
           // var licence = new Aspose.Pdf.License();
            //licence.SetLicense(Add YOUR LICENCE HERE);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var imageWidth = 77;
            var imageHeight = 109;
            var resolution = new Aspose.Pdf.Devices.Resolution(300);
            var imageDevice = new Aspose.Pdf.Devices.PngDevice(imageWidth, imageHeight, resolution);
            var path = Path.GetDirectoryName(Application.ExecutablePath).Replace("bin\\Debug", string.Empty);
            var testFile = path + @"TestImages\Superheros.pdf";
            var imageLocation = path + "GeneratedImages\\Superheros.png";
            var dummypath = path + "DummyFolder\\Superheroes.pdf";
            var pdfDocument = new Aspose.Pdf.Document(testFile);

            imageDevice.RenderingOptions.SystemFontsNativeRendering = true;


            //Having this line results in  "GeneratedImages\\Superheros.png"; being empty. Not having it makes the said png have the text from the source-pdf
            pdfDocument.Save(dummypath);

            if (imageDevice != null) {
                using (var imageStream = new FileStream(imageLocation, FileMode.OpenOrCreate))
                {
                    imageDevice.Process(pdfDocument.Pages[1], imageStream);
                    imageStream.Close();
                }
            }
        }
    }
}
