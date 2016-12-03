using System.Windows.Forms;
using System.Drawing;

namespace GoManPTCAccountCreator
{
    public partial class WebForm : Form
    {
        public WebForm(string html)
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            webBrowser1.ScriptErrorsSuppressed = true;
            webBrowser1.DocumentText = html;

        }
    }
}
