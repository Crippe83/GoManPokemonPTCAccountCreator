using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using GoManPTCAccountCreator.Controller;
using GoManPTCAccountCreator.Model;
using Newtonsoft.Json;
using Account = GoManPTCAccountCreator.Controller.Account;

namespace GoManPTCAccountCreator
{
    public partial class MainForm : Form
    {
        private static readonly Regex RegexUsername = new Regex("^[a-zA-Z0-9_]*$", RegexOptions.IgnoreCase);
        //private static readonly List<AccountModel> CreatedAccounts = new List<AccountModel>();
        private readonly ApplicationModel _settings = ApplicationModel.Settings();
       // private Proxy server;
        private Account _accountMaker;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tbCaptchaSettings);
            tabControl1.TabPages.Remove(tbLog);
            tabControl1.TabPages.Remove(tbEmailSettings);

            ServicePointManager.DefaultConnectionLimit = int.MaxValue;

            cbRandomDateOfBirth.Checked = _settings.RandomDateOfBirth;
            dtpDateOfBirth.Value = new DateTime(_settings.DateOfBirthYear, _settings.DateOfBirthMonth,
                _settings.DateOfBirthDay);

            cbCountry.DataSource = Enum.GetNames(typeof(CountryModel));
            cbCountry.SelectedItem = _settings.Country.ToString();
            cbRandomCountry.Checked = _settings.RandomCountry;

            txtUsername.Text = _settings.Username;
            cbRandomUsername.Checked = _settings.RandomUsername;

            txtPrefix.Text = _settings.UsernamePerfix;
            cbRandomPrefix.Checked = _settings.RandomPrefix;

            txtPostfix.Text = _settings.UsernamePostfix;
            cbRandomPostfix.Checked = _settings.RandomPostfix;

            txtPassword.Text = _settings.Password;
            cbRandomPassword.Checked = _settings.RandomPassword;
            udRandomPasswordLength.Value = _settings.RandomPasswordLength;

            txtProxyHostnameIP.Text = _settings.ProxyDomain;
            txtProxyPort.Text = _settings.ProxyPort.ToString();
            txtCaptchaKey.Text = _settings.CaptchaKey;

            txtEmailDomain.Text = _settings.EmailDomain;

            objectListView1.BackColor = Color.FromArgb(43, 43, 43);
            objectListView1.ForeColor = Color.LightGray;

            grpDateOfBirth.ForeColor = Color.LightGray;
            grpPassword.ForeColor = Color.LightGray;
            grpEmail.ForeColor = Color.LightGray;
            grpCountry.ForeColor = Color.LightGray;
            grpUsername.ForeColor = Color.LightGray;

            objectListView1.UseCellFormatEvents = true;
            _accountMaker = new Account(_settings.CaptchaKey);
            _accountMaker.EventAccountAdded += new Account.AccountAdded(AhhShitAdd);
            Account.EventRefreshAccount += new Account.RefreshAccount(AhhShitRefresh);

            EmailServerController.Start();
            _accountMaker.Start(_settings.MaxThreads);

            //server = new Proxy(_settings.ProxyPort, 4096);
            //server.LocalConnect += new ConnectEventHandler(server_LocalConnect);
            //server.RemoteConnect += new ConnectEventHandler(server_RemoteConnect);
            //server.Start();

        }

        private async void AhhShitRefresh(AccountModel account)
        {
           // objectListView1.RefreshObject(account);
           await Task.Run(delegate { objectListView1.RefreshObject(account); });

        }


        private async void AhhShitAdd(AccountModel account)
        {
            objectListView1.AddObject(account);
           // await Task.Run(delegate { objectListView1.AddObject(account); });
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_settings.CaptchaKey))
            {
                MessageBox.Show(this, "Please configure a 2Captcha API key before creating accounts.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            await _accountMaker.CreateAccounts(int.Parse(textBox1.Text));

        }

        private void Save()
        {
            _settings.SaveSetting();
        }

        private void server_RemoteConnect(object sender, IPEndPoint iep)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(delegate { richTextBox1.AppendText("Connecting to " + iep + "\r\n"); }));
            }
        }

        private void server_LocalConnect(object sender, IPEndPoint iep)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(delegate { richTextBox1.AppendText("Connection from " + iep + "\r\n"); }));
            }
        }

        #region Date Of Birth

        private void dtpDateOfBirth_ValueChanged(object sender, EventArgs e)
        {
            _settings.DateOfBirthDay = dtpDateOfBirth.Value.Day;
            _settings.DateOfBirthMonth = dtpDateOfBirth.Value.Month;
            _settings.DateOfBirthYear = dtpDateOfBirth.Value.Year;
        }

        private void cbRandomDateOfBirth_CheckedChanged(object sender, EventArgs e)
        {
            _settings.RandomDateOfBirth = cbRandomDateOfBirth.Checked;
        }

        #endregion

        #region Country

        private void cbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            _settings.Country = cbCountry.Text.ToEnum();
            Save();
        }

        private void cbRandomCountry_CheckedChanged(object sender, EventArgs e)
        {
            _settings.RandomCountry = cbRandomCountry.Checked;
            Save();
        }

        #endregion

        #region Username

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            var m = RegexUsername.Match(txtUsername.Text);
            if (!m.Success)
            {
                cbRandomUsername.Checked = true;
                txtUsername.BackColor = Color.Red;
            }
            else
            {
                cbRandomUsername.Checked = false;
                txtUsername.BackColor = SystemColors.Window;
                _settings.Username = txtUsername.Text;
            }

            if (string.IsNullOrEmpty(txtUsername.Text))
                cbRandomUsername.Checked = true;

            Save();
        }

        private void cbRandomUsername_CheckedChanged(object sender, EventArgs e)
        {
            _settings.RandomUsername = cbRandomUsername.Checked;
            Save();
        }

        private void txtPrefix_TextChanged(object sender, EventArgs e)
        {
            var m = RegexUsername.Match(txtPrefix.Text);
            if (!m.Success)
            {
                cbRandomPrefix.Checked = true;
                txtPrefix.BackColor = Color.Red;
            }
            else
            {
                cbRandomPrefix.Checked = false;
                txtPrefix.BackColor = SystemColors.Window;
                _settings.UsernamePerfix = txtPrefix.Text;
            }

            if (string.IsNullOrEmpty(txtPrefix.Text))
                cbRandomPrefix.Checked = true;
            Save();
        }

        private void cbRandomPrefix_CheckedChanged(object sender, EventArgs e)
        {
            _settings.RandomPrefix = cbRandomPrefix.Checked;
            Save();
        }

        private void txtPostfix_TextChanged(object sender, EventArgs e)
        {
            var m = RegexUsername.Match(txtPostfix.Text);
            if (!m.Success)
            {
                cbRandomPostfix.Checked = true;
                txtPostfix.BackColor = Color.Red;
            }
            else
            {
                cbRandomPostfix.Checked = false;
                txtPostfix.BackColor = SystemColors.Window;
                _settings.UsernamePostfix = txtPostfix.Text;
            }

            if (string.IsNullOrEmpty(txtPostfix.Text))
                cbRandomPostfix.Checked = true;
            Save();
        }

        private void cbRandomPostfix_CheckedChanged(object sender, EventArgs e)
        {
            _settings.RandomPostfix = cbRandomPostfix.Checked;
            Save();
        }


        #endregion

        #region Password

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text.Length > 16)
            {
                cbRandomPassword.Checked = true;
                txtPassword.BackColor = Color.Red;
            }
            else
            {
                cbRandomPassword.Checked = false;
                txtPassword.BackColor = SystemColors.Window;
                _settings.Password = txtPassword.Text;
            }
            Save();
        }

        private void cbRandomPassword_CheckedChanged(object sender, EventArgs e)
        {
            _settings.RandomPassword = cbRandomPassword.Checked;
            Save();
        }

        private void udRandomPasswordLength_ValueChanged(object sender, EventArgs e)
        {
            _settings.RandomPasswordLength = (int) udRandomPasswordLength.Value;
            Save();
        }

        #endregion

        #region Captcha Settings

        private async void btnCaptchaTestPort_Click(object sender, EventArgs e)
        {
            if (await PortTesterController.IsPortOpen(_settings.ProxyDomain, _settings.ProxyPort.ToString()))
                lblCaptchaError.Text = _settings.ProxyDomain + " port " + _settings.ProxyPort + " is open!";
            else
                lblCaptchaError.Text = _settings.ProxyDomain + " port " + _settings.ProxyPort + " is closed!";
        }

        private void txtProxyHostnameIP_TextChanged(object sender, EventArgs e)
        {
            _settings.ProxyDomain = txtProxyHostnameIP.Text;
            Save();
        }

        private void txtCaptchaKey_TextChanged(object sender, EventArgs e)
        {
            _settings.CaptchaKey = txtCaptchaKey.Text;
            Save();
        }

        private void txtProxyPort_TextChanged(object sender, EventArgs e)
        {
            var port = 1080;
            if (int.TryParse(txtProxyPort.Text, out port))
                _settings.ProxyPort = port;

            Save();
        }

        #endregion

        #region Email Settings

        private async void txtEmailDomain_TextChanged(object sender, EventArgs e)
        {
            _settings.EmailDomain = txtEmailDomain.Text;

            pictureBox1.Image = Properties.Resources.PROCESS_PROCESSING;
            if (await PortTesterController.IsPortOpen(_settings.EmailDomain, "25"))
            {
                pictureBox1.Image = Properties.Resources._1475917959_button_check_green;
                Save();
            }
            else
            {
                pictureBox1.Image = Properties.Resources._1475918266_button_cross_red;
            }
        }

        #endregion

        private void objectListView1_DoubleClick(object sender, EventArgs e)
        {
            if (objectListView1.SelectedItems.Count == 0) return;

            AccountModel account = (AccountModel)objectListView1.SelectedObjects[0];
            using (var logDialog = new LogForm(account))
            {
                logDialog.ShowDialog(this);
            }
        }

        private void objectListView1_FormatCell(object sender, BrightIdeasSoftware.FormatCellEventArgs e)
        {
            AccountModel account = (AccountModel)e.Model;

             if (e.Column == olvColumn7)
            {
                switch (account.TosAccepted.Equals("True"))
                {
                    case false:
                        e.SubItem.ForeColor = Color.Red;
                        break;
                    case true:
                        e.SubItem.ForeColor = Color.Green;
                        break;
                }
            }
            else if (e.Column == olvColumn1)
            {
                e.SubItem.ForeColor = account.GetLogColor();
            }
            else if (e.Column == olvColumn6)
            {
                LogModel log = account.EventLog.LastOrDefault();

                if (log == null)
                {
                    return;
                }

                e.SubItem.ForeColor = log.GetLogColor();
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            runningLabel.Text = $"Running: {AccountModel.RunningCount}";
            createdLabel.Text = $"Created: {AccountModel.CreatedCount}";
            pendingLabel.Text = $"Pending: {AccountModel.PendingCount}";
            failedLabel.Text = $"Failed: {AccountModel.FailedCount}";

            double done = AccountModel.CreatedCount + AccountModel.FailedCount;
            var total = AccountModel.PendingCount + AccountModel.RunningCount + AccountModel.CreatedCount + AccountModel.FailedCount;

            if (total <= 0) return;
            done /= total;
            done *= 100;
            toolStripProgressBar.Value = (int) done;
        }
        private async void verifyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog { InitialDirectory = "." };
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                await _accountMaker.ImportAccounts(openFileDialog.FileName);
            }
        }
    }
}