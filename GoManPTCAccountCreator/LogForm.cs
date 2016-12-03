using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using GoManPTCAccountCreator.Model;

namespace GoManPTCAccountCreator
{
    public partial class LogForm : Form
    {
        private readonly AccountModel _account;
        public LogForm(AccountModel account)
        {
            this._account = account;
            InitializeComponent();
            this._account.EventLogAdded += EventLogAdded;
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            objectListView1.BackColor = Color.FromArgb(43, 43, 43);
            objectListView1.ForeColor = Color.LightGray;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void objectListView1_DoubleClick(object sender, EventArgs e)
        {
            if (objectListView1.SelectedItems.Count == 0) return;

            LogModel log = (LogModel)objectListView1.SelectedObjects[0];
            using (var webDialog = new WebForm(log.Html))
            {
                webDialog.ShowDialog(this);
            }
        }

        private void EventLogAdded(LogModel log)
        {
            objectListView1.AddObject(log);
        }

        private void objectListView1_FormatCell(object sender, BrightIdeasSoftware.FormatCellEventArgs e)
        {
            LogModel log = (LogModel)e.Model;

             if (e.Column == olvMessage)
                {

                if (log == null)
                {
                    return;
                }

                e.SubItem.ForeColor = log.GetLogColor();
            }

        }

        private void LogForm_Load(object sender, EventArgs e)
        {
            objectListView1.SetObjects(_account.EventLog);
        }
        private void LogForm_Closing(object sender, EventArgs e)
        {
            this._account.EventLogAdded -= EventLogAdded;
        }
    }
}
