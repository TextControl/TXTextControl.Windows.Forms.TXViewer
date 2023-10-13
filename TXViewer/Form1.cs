using System.Text.Encodings.Web;

namespace TXViewer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void menuItemLoad_Click(object sender, EventArgs e)
        {
            // set filter to tx and pdf
            openFileDialog1.Filter = "TX Text Control Documents (*.tx)|*.tx|PDF Documents (*.pdf)|*.pdf";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // load the document into a byte array
                var bytes = File.ReadAllBytes(openFileDialog1.FileName);
                // get the filename
                string filename = Path.GetFileName(openFileDialog1.FileName);
                // convert the byte array to a Base64 string
                var stringBase64 = Convert.ToBase64String(bytes);
                // create a JavaScript string that calls the loadDocument() function
                string loadSettings = "{ pdfjs: { basePath: 'https://cdnjs.cloudflare.com/ajax/libs/pdf.js/3.2.146' } }";
                string js = "TXDocumentViewer.loadDocument('" + stringBase64 + "', '" + filename + "', null, " + loadSettings + ");";
                // execute the JavaScript string
                webView21.ExecuteScriptAsync(js);
            }
        }
    }
}