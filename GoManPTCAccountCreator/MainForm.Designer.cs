using System;
using System.Windows.Forms;
using BrightIdeasSoftware;
using GoManPTCAccountCreator.Model;

namespace GoManPTCAccountCreator
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.grpDateOfBirth = new System.Windows.Forms.GroupBox();
            this.dtpDateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.cbRandomDateOfBirth = new System.Windows.Forms.CheckBox();
            this.grpUsername = new System.Windows.Forms.GroupBox();
            this.txtPrefix = new System.Windows.Forms.TextBox();
            this.cbRandomUsername = new System.Windows.Forms.CheckBox();
            this.txtPostfix = new System.Windows.Forms.TextBox();
            this.cbRandomPostfix = new System.Windows.Forms.CheckBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.cbRandomPrefix = new System.Windows.Forms.CheckBox();
            this.grpPassword = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.udRandomPasswordLength = new System.Windows.Forms.NumericUpDown();
            this.cbRandomPassword = new System.Windows.Forms.CheckBox();
            this.txtCaptchaKey = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.runningLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.pendingLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.createdLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.failedLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.grpCountry = new System.Windows.Forms.GroupBox();
            this.cbCountry = new System.Windows.Forms.ComboBox();
            this.cbRandomCountry = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbCreatedAccounts = new System.Windows.Forms.TabPage();
            this.objectListView1 = new BrightIdeasSoftware.ObjectListView();
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn7 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn4 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn5 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn6 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.tbAccountSettings = new System.Windows.Forms.TabPage();
            this.grpEmail = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEmailDomain = new System.Windows.Forms.TextBox();
            this.tbCaptchaSettings = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblCaptchaError = new System.Windows.Forms.Label();
            this.btnCaptchaTestPort = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtProxyPort = new System.Windows.Forms.TextBox();
            this.txtProxyHostnameIP = new System.Windows.Forms.TextBox();
            this.tbEmailSettings = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.tbLog = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.mappedImageRenderer1 = new BrightIdeasSoftware.MappedImageRenderer();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.verifyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grpDateOfBirth.SuspendLayout();
            this.grpUsername.SuspendLayout();
            this.grpPassword.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udRandomPasswordLength)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.grpCountry.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tbCreatedAccounts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).BeginInit();
            this.tbAccountSettings.SuspendLayout();
            this.grpEmail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tbCaptchaSettings.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tbEmailSettings.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tbLog.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(7, 18);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(2);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(129, 20);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.Text = "GoManP@ssw0rd";
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            // 
            // grpDateOfBirth
            // 
            this.grpDateOfBirth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDateOfBirth.Controls.Add(this.dtpDateOfBirth);
            this.grpDateOfBirth.Controls.Add(this.cbRandomDateOfBirth);
            this.grpDateOfBirth.Location = new System.Drawing.Point(6, 6);
            this.grpDateOfBirth.Margin = new System.Windows.Forms.Padding(2);
            this.grpDateOfBirth.Name = "grpDateOfBirth";
            this.grpDateOfBirth.Padding = new System.Windows.Forms.Padding(2);
            this.grpDateOfBirth.Size = new System.Drawing.Size(792, 52);
            this.grpDateOfBirth.TabIndex = 0;
            this.grpDateOfBirth.TabStop = false;
            this.grpDateOfBirth.Text = "Date Of Birth";
            // 
            // dtpDateOfBirth
            // 
            this.dtpDateOfBirth.Location = new System.Drawing.Point(7, 21);
            this.dtpDateOfBirth.Name = "dtpDateOfBirth";
            this.dtpDateOfBirth.Size = new System.Drawing.Size(200, 20);
            this.dtpDateOfBirth.TabIndex = 1;
            this.dtpDateOfBirth.ValueChanged += new System.EventHandler(this.dtpDateOfBirth_ValueChanged);
            // 
            // cbRandomDateOfBirth
            // 
            this.cbRandomDateOfBirth.AutoSize = true;
            this.cbRandomDateOfBirth.Location = new System.Drawing.Point(212, 24);
            this.cbRandomDateOfBirth.Margin = new System.Windows.Forms.Padding(2);
            this.cbRandomDateOfBirth.Name = "cbRandomDateOfBirth";
            this.cbRandomDateOfBirth.Size = new System.Drawing.Size(130, 17);
            this.cbRandomDateOfBirth.TabIndex = 0;
            this.cbRandomDateOfBirth.Text = "Random Date Of Birth";
            this.cbRandomDateOfBirth.UseVisualStyleBackColor = true;
            this.cbRandomDateOfBirth.CheckedChanged += new System.EventHandler(this.cbRandomDateOfBirth_CheckedChanged);
            // 
            // grpUsername
            // 
            this.grpUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpUsername.Controls.Add(this.txtPrefix);
            this.grpUsername.Controls.Add(this.cbRandomUsername);
            this.grpUsername.Controls.Add(this.txtPostfix);
            this.grpUsername.Controls.Add(this.cbRandomPostfix);
            this.grpUsername.Controls.Add(this.txtUsername);
            this.grpUsername.Controls.Add(this.cbRandomPrefix);
            this.grpUsername.Location = new System.Drawing.Point(6, 117);
            this.grpUsername.Margin = new System.Windows.Forms.Padding(2);
            this.grpUsername.Name = "grpUsername";
            this.grpUsername.Padding = new System.Windows.Forms.Padding(2);
            this.grpUsername.Size = new System.Drawing.Size(792, 92);
            this.grpUsername.TabIndex = 1;
            this.grpUsername.TabStop = false;
            this.grpUsername.Text = "Username";
            // 
            // txtPrefix
            // 
            this.txtPrefix.Location = new System.Drawing.Point(7, 42);
            this.txtPrefix.Margin = new System.Windows.Forms.Padding(2);
            this.txtPrefix.Name = "txtPrefix";
            this.txtPrefix.Size = new System.Drawing.Size(130, 20);
            this.txtPrefix.TabIndex = 7;
            this.txtPrefix.Text = "GoMan";
            this.txtPrefix.TextChanged += new System.EventHandler(this.txtPrefix_TextChanged);
            // 
            // cbRandomUsername
            // 
            this.cbRandomUsername.AutoSize = true;
            this.cbRandomUsername.Location = new System.Drawing.Point(141, 21);
            this.cbRandomUsername.Margin = new System.Windows.Forms.Padding(2);
            this.cbRandomUsername.Name = "cbRandomUsername";
            this.cbRandomUsername.Size = new System.Drawing.Size(117, 17);
            this.cbRandomUsername.TabIndex = 2;
            this.cbRandomUsername.Text = "Random Username";
            this.cbRandomUsername.UseVisualStyleBackColor = true;
            this.cbRandomUsername.CheckedChanged += new System.EventHandler(this.cbRandomUsername_CheckedChanged);
            // 
            // txtPostfix
            // 
            this.txtPostfix.Location = new System.Drawing.Point(7, 64);
            this.txtPostfix.Margin = new System.Windows.Forms.Padding(2);
            this.txtPostfix.Name = "txtPostfix";
            this.txtPostfix.Size = new System.Drawing.Size(130, 20);
            this.txtPostfix.TabIndex = 6;
            this.txtPostfix.Text = "q";
            this.txtPostfix.TextChanged += new System.EventHandler(this.txtPostfix_TextChanged);
            // 
            // cbRandomPostfix
            // 
            this.cbRandomPostfix.AutoSize = true;
            this.cbRandomPostfix.Location = new System.Drawing.Point(141, 65);
            this.cbRandomPostfix.Margin = new System.Windows.Forms.Padding(2);
            this.cbRandomPostfix.Name = "cbRandomPostfix";
            this.cbRandomPostfix.Size = new System.Drawing.Size(100, 17);
            this.cbRandomPostfix.TabIndex = 1;
            this.cbRandomPostfix.Text = "Random Postfix";
            this.cbRandomPostfix.UseVisualStyleBackColor = true;
            this.cbRandomPostfix.CheckedChanged += new System.EventHandler(this.cbRandomPostfix_CheckedChanged);
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(7, 19);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(2);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(130, 20);
            this.txtUsername.TabIndex = 5;
            this.txtUsername.Text = "Username";
            this.txtUsername.TextChanged += new System.EventHandler(this.txtUsername_TextChanged);
            // 
            // cbRandomPrefix
            // 
            this.cbRandomPrefix.AutoSize = true;
            this.cbRandomPrefix.Location = new System.Drawing.Point(140, 44);
            this.cbRandomPrefix.Margin = new System.Windows.Forms.Padding(2);
            this.cbRandomPrefix.Name = "cbRandomPrefix";
            this.cbRandomPrefix.Size = new System.Drawing.Size(95, 17);
            this.cbRandomPrefix.TabIndex = 0;
            this.cbRandomPrefix.Text = "Random Prefix";
            this.cbRandomPrefix.UseVisualStyleBackColor = true;
            this.cbRandomPrefix.CheckedChanged += new System.EventHandler(this.cbRandomPrefix_CheckedChanged);
            // 
            // grpPassword
            // 
            this.grpPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpPassword.Controls.Add(this.label1);
            this.grpPassword.Controls.Add(this.udRandomPasswordLength);
            this.grpPassword.Controls.Add(this.txtPassword);
            this.grpPassword.Controls.Add(this.cbRandomPassword);
            this.grpPassword.Location = new System.Drawing.Point(6, 214);
            this.grpPassword.Margin = new System.Windows.Forms.Padding(2);
            this.grpPassword.Name = "grpPassword";
            this.grpPassword.Padding = new System.Windows.Forms.Padding(2);
            this.grpPassword.Size = new System.Drawing.Size(792, 46);
            this.grpPassword.TabIndex = 3;
            this.grpPassword.TabStop = false;
            this.grpPassword.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(268, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Length: ";
            // 
            // udRandomPasswordLength
            // 
            this.udRandomPasswordLength.Location = new System.Drawing.Point(320, 18);
            this.udRandomPasswordLength.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.udRandomPasswordLength.Minimum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.udRandomPasswordLength.Name = "udRandomPasswordLength";
            this.udRandomPasswordLength.Size = new System.Drawing.Size(42, 20);
            this.udRandomPasswordLength.TabIndex = 12;
            this.udRandomPasswordLength.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.udRandomPasswordLength.ValueChanged += new System.EventHandler(this.udRandomPasswordLength_ValueChanged);
            // 
            // cbRandomPassword
            // 
            this.cbRandomPassword.AutoSize = true;
            this.cbRandomPassword.Location = new System.Drawing.Point(140, 21);
            this.cbRandomPassword.Margin = new System.Windows.Forms.Padding(2);
            this.cbRandomPassword.Name = "cbRandomPassword";
            this.cbRandomPassword.Size = new System.Drawing.Size(115, 17);
            this.cbRandomPassword.TabIndex = 2;
            this.cbRandomPassword.Text = "Random Password";
            this.cbRandomPassword.UseVisualStyleBackColor = true;
            this.cbRandomPassword.CheckedChanged += new System.EventHandler(this.cbRandomPassword_CheckedChanged);
            // 
            // txtCaptchaKey
            // 
            this.txtCaptchaKey.Location = new System.Drawing.Point(110, 45);
            this.txtCaptchaKey.Margin = new System.Windows.Forms.Padding(2);
            this.txtCaptchaKey.Name = "txtCaptchaKey";
            this.txtCaptchaKey.Size = new System.Drawing.Size(422, 20);
            this.txtCaptchaKey.TabIndex = 4;
            this.txtCaptchaKey.TextChanged += new System.EventHandler(this.txtCaptchaKey_TextChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runningLabel,
            this.toolStripStatusLabel2,
            this.pendingLabel,
            this.toolStripStatusLabel1,
            this.createdLabel,
            this.toolStripStatusLabel3,
            this.failedLabel,
            this.toolStripStatusLabel4,
            this.toolStripProgressBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 432);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip1.Size = new System.Drawing.Size(812, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // runningLabel
            // 
            this.runningLabel.ActiveLinkColor = System.Drawing.Color.Red;
            this.runningLabel.ForeColor = System.Drawing.Color.Green;
            this.runningLabel.Name = "runningLabel";
            this.runningLabel.Size = new System.Drawing.Size(64, 17);
            this.runningLabel.Text = "Running: 0";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.ForeColor = System.Drawing.Color.LightGray;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel2.Text = "|";
            // 
            // pendingLabel
            // 
            this.pendingLabel.ActiveLinkColor = System.Drawing.Color.Red;
            this.pendingLabel.ForeColor = System.Drawing.Color.LightGreen;
            this.pendingLabel.Name = "pendingLabel";
            this.pendingLabel.Size = new System.Drawing.Size(63, 17);
            this.pendingLabel.Text = "Pending: 0";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.LightGray;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel1.Text = "|";
            // 
            // createdLabel
            // 
            this.createdLabel.ActiveLinkColor = System.Drawing.Color.Red;
            this.createdLabel.ForeColor = System.Drawing.Color.DodgerBlue;
            this.createdLabel.Name = "createdLabel";
            this.createdLabel.Size = new System.Drawing.Size(60, 17);
            this.createdLabel.Text = "Created: 0";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.ForeColor = System.Drawing.Color.LightGray;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel3.Text = "|";
            // 
            // failedLabel
            // 
            this.failedLabel.ActiveLinkColor = System.Drawing.Color.Red;
            this.failedLabel.ForeColor = System.Drawing.Color.Yellow;
            this.failedLabel.Name = "failedLabel";
            this.failedLabel.Size = new System.Drawing.Size(50, 17);
            this.failedLabel.Text = "Failed: 0";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.ForeColor = System.Drawing.Color.LightGray;
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel4.Text = "|";
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(400, 16);
            // 
            // grpCountry
            // 
            this.grpCountry.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpCountry.Controls.Add(this.cbCountry);
            this.grpCountry.Controls.Add(this.cbRandomCountry);
            this.grpCountry.Location = new System.Drawing.Point(6, 63);
            this.grpCountry.Margin = new System.Windows.Forms.Padding(2);
            this.grpCountry.Name = "grpCountry";
            this.grpCountry.Padding = new System.Windows.Forms.Padding(2);
            this.grpCountry.Size = new System.Drawing.Size(792, 49);
            this.grpCountry.TabIndex = 5;
            this.grpCountry.TabStop = false;
            this.grpCountry.Text = "Country";
            // 
            // cbCountry
            // 
            this.cbCountry.DisplayMember = "Value";
            this.cbCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCountry.FormattingEnabled = true;
            this.cbCountry.Location = new System.Drawing.Point(7, 19);
            this.cbCountry.Margin = new System.Windows.Forms.Padding(2);
            this.cbCountry.Name = "cbCountry";
            this.cbCountry.Size = new System.Drawing.Size(130, 21);
            this.cbCountry.TabIndex = 6;
            this.cbCountry.ValueMember = "Key";
            this.cbCountry.SelectedIndexChanged += new System.EventHandler(this.cbCountry_SelectedIndexChanged);
            // 
            // cbRandomCountry
            // 
            this.cbRandomCountry.AutoSize = true;
            this.cbRandomCountry.Location = new System.Drawing.Point(141, 23);
            this.cbRandomCountry.Margin = new System.Windows.Forms.Padding(2);
            this.cbRandomCountry.Name = "cbRandomCountry";
            this.cbRandomCountry.Size = new System.Drawing.Size(105, 17);
            this.cbRandomCountry.TabIndex = 2;
            this.cbRandomCountry.Text = "Random Country";
            this.cbRandomCountry.UseVisualStyleBackColor = true;
            this.cbRandomCountry.CheckedChanged += new System.EventHandler(this.cbRandomCountry_CheckedChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControl1.Controls.Add(this.tbCreatedAccounts);
            this.tabControl1.Controls.Add(this.tbAccountSettings);
            this.tabControl1.Controls.Add(this.tbCaptchaSettings);
            this.tabControl1.Controls.Add(this.tbEmailSettings);
            this.tabControl1.Controls.Add(this.tbLog);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(812, 389);
            this.tabControl1.TabIndex = 10;
            // 
            // tbCreatedAccounts
            // 
            this.tbCreatedAccounts.Controls.Add(this.objectListView1);
            this.tbCreatedAccounts.Location = new System.Drawing.Point(4, 25);
            this.tbCreatedAccounts.Name = "tbCreatedAccounts";
            this.tbCreatedAccounts.Size = new System.Drawing.Size(804, 360);
            this.tbCreatedAccounts.TabIndex = 4;
            this.tbCreatedAccounts.Text = "Created Accounts";
            this.tbCreatedAccounts.UseVisualStyleBackColor = true;
            // 
            // objectListView1
            // 
            this.objectListView1.AllColumns.Add(this.olvColumn1);
            this.objectListView1.AllColumns.Add(this.olvColumn7);
            this.objectListView1.AllColumns.Add(this.olvColumn2);
            this.objectListView1.AllColumns.Add(this.olvColumn3);
            this.objectListView1.AllColumns.Add(this.olvColumn4);
            this.objectListView1.AllColumns.Add(this.olvColumn5);
            this.objectListView1.AllColumns.Add(this.olvColumn6);
            this.objectListView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.objectListView1.CellEditUseWholeCell = false;
            this.objectListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn1,
            this.olvColumn7,
            this.olvColumn2,
            this.olvColumn3,
            this.olvColumn4,
            this.olvColumn5,
            this.olvColumn6});
            this.objectListView1.ContextMenuStrip = this.contextMenuStrip2;
            this.objectListView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.objectListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objectListView1.FullRowSelect = true;
            this.objectListView1.Location = new System.Drawing.Point(0, 0);
            this.objectListView1.Margin = new System.Windows.Forms.Padding(2);
            this.objectListView1.Name = "objectListView1";
            this.objectListView1.ShowGroups = false;
            this.objectListView1.Size = new System.Drawing.Size(804, 360);
            this.objectListView1.TabIndex = 1;
            this.objectListView1.UseCellFormatEvents = true;
            this.objectListView1.UseCompatibleStateImageBehavior = false;
            this.objectListView1.UseFilterIndicator = true;
            this.objectListView1.UseFiltering = true;
            this.objectListView1.View = System.Windows.Forms.View.Details;
            this.objectListView1.FormatCell += new System.EventHandler<BrightIdeasSoftware.FormatCellEventArgs>(this.objectListView1_FormatCell);
            this.objectListView1.DoubleClick += new System.EventHandler(this.objectListView1_DoubleClick);
            // 
            // olvColumn1
            // 
            this.olvColumn1.AspectName = "Status";
            this.olvColumn1.Text = "Status";
            this.olvColumn1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn1.Width = 56;
            // 
            // olvColumn7
            // 
            this.olvColumn7.AspectName = "TosAccepted";
            this.olvColumn7.Text = "TOS Accepted";
            this.olvColumn7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn7.Width = 86;
            // 
            // olvColumn2
            // 
            this.olvColumn2.AspectName = "Username";
            this.olvColumn2.Text = "Username";
            this.olvColumn2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn2.Width = 100;
            // 
            // olvColumn3
            // 
            this.olvColumn3.AspectName = "Password";
            this.olvColumn3.Text = "Password";
            this.olvColumn3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn3.Width = 86;
            // 
            // olvColumn4
            // 
            this.olvColumn4.AspectName = "Country";
            this.olvColumn4.Text = "Country";
            this.olvColumn4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn4.Width = 54;
            // 
            // olvColumn5
            // 
            this.olvColumn5.AspectName = "DateOfBirth";
            this.olvColumn5.Text = "Date Of Birth";
            this.olvColumn5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn5.Width = 82;
            // 
            // olvColumn6
            // 
            this.olvColumn6.AspectName = "Log";
            this.olvColumn6.Text = "Log";
            this.olvColumn6.Width = 334;
            // 
            // tbAccountSettings
            // 
            this.tbAccountSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.tbAccountSettings.Controls.Add(this.grpDateOfBirth);
            this.tbAccountSettings.Controls.Add(this.grpEmail);
            this.tbAccountSettings.Controls.Add(this.grpCountry);
            this.tbAccountSettings.Controls.Add(this.grpPassword);
            this.tbAccountSettings.Controls.Add(this.grpUsername);
            this.tbAccountSettings.ForeColor = System.Drawing.Color.LightGray;
            this.tbAccountSettings.Location = new System.Drawing.Point(4, 25);
            this.tbAccountSettings.Name = "tbAccountSettings";
            this.tbAccountSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tbAccountSettings.Size = new System.Drawing.Size(804, 360);
            this.tbAccountSettings.TabIndex = 0;
            this.tbAccountSettings.Text = "Account Settings";
            // 
            // grpEmail
            // 
            this.grpEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpEmail.Controls.Add(this.pictureBox1);
            this.grpEmail.Controls.Add(this.label5);
            this.grpEmail.Controls.Add(this.label4);
            this.grpEmail.Controls.Add(this.txtCaptchaKey);
            this.grpEmail.Controls.Add(this.txtEmailDomain);
            this.grpEmail.Location = new System.Drawing.Point(6, 265);
            this.grpEmail.Name = "grpEmail";
            this.grpEmail.Size = new System.Drawing.Size(792, 88);
            this.grpEmail.TabIndex = 7;
            this.grpEmail.TabStop = false;
            this.grpEmail.Text = "Other Settings";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GoManPTCAccountCreator.Properties.Resources._1475918266_button_cross_red;
            this.pictureBox1.Location = new System.Drawing.Point(537, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.LightGray;
            this.label5.Location = new System.Drawing.Point(8, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "2Captcha API Key:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Domain Name:";
            // 
            // txtEmailDomain
            // 
            this.txtEmailDomain.Location = new System.Drawing.Point(110, 21);
            this.txtEmailDomain.Margin = new System.Windows.Forms.Padding(2);
            this.txtEmailDomain.Name = "txtEmailDomain";
            this.txtEmailDomain.Size = new System.Drawing.Size(422, 20);
            this.txtEmailDomain.TabIndex = 6;
            this.txtEmailDomain.Text = "chancity.hopto.org";
            this.txtEmailDomain.TextChanged += new System.EventHandler(this.txtEmailDomain_TextChanged);
            // 
            // tbCaptchaSettings
            // 
            this.tbCaptchaSettings.Controls.Add(this.groupBox7);
            this.tbCaptchaSettings.Controls.Add(this.groupBox4);
            this.tbCaptchaSettings.Location = new System.Drawing.Point(4, 25);
            this.tbCaptchaSettings.Name = "tbCaptchaSettings";
            this.tbCaptchaSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tbCaptchaSettings.Size = new System.Drawing.Size(804, 360);
            this.tbCaptchaSettings.TabIndex = 1;
            this.tbCaptchaSettings.Text = "Captcha Settings";
            this.tbCaptchaSettings.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.richTextBox3);
            this.groupBox7.Location = new System.Drawing.Point(6, 153);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(735, 115);
            this.groupBox7.TabIndex = 6;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Notes";
            // 
            // richTextBox3
            // 
            this.richTextBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox3.Location = new System.Drawing.Point(3, 16);
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.ReadOnly = true;
            this.richTextBox3.Size = new System.Drawing.Size(729, 96);
            this.richTextBox3.TabIndex = 0;
            this.richTextBox3.Text = "Register at https://www.noip.com, make sure you configure a MX record for your DN" +
    "S entry.  If you\'re behind a firewall you need to port forward all port 1080 tra" +
    "ffic to this computer.";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblCaptchaError);
            this.groupBox4.Controls.Add(this.btnCaptchaTestPort);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.txtProxyPort);
            this.groupBox4.Controls.Add(this.txtProxyHostnameIP);
            this.groupBox4.Location = new System.Drawing.Point(5, 5);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(736, 117);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Proxy Settings (DISABLED)";
            // 
            // lblCaptchaError
            // 
            this.lblCaptchaError.AutoSize = true;
            this.lblCaptchaError.Location = new System.Drawing.Point(197, 92);
            this.lblCaptchaError.Name = "lblCaptchaError";
            this.lblCaptchaError.Size = new System.Drawing.Size(0, 13);
            this.lblCaptchaError.TabIndex = 10;
            // 
            // btnCaptchaTestPort
            // 
            this.btnCaptchaTestPort.Enabled = false;
            this.btnCaptchaTestPort.Location = new System.Drawing.Point(116, 87);
            this.btnCaptchaTestPort.Name = "btnCaptchaTestPort";
            this.btnCaptchaTestPort.Size = new System.Drawing.Size(75, 23);
            this.btnCaptchaTestPort.TabIndex = 4;
            this.btnCaptchaTestPort.Text = "Test Port";
            this.btnCaptchaTestPort.UseVisualStyleBackColor = true;
            this.btnCaptchaTestPort.Click += new System.EventHandler(this.btnCaptchaTestPort_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Proxy Port:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Proxy Hostname/IP:";
            // 
            // txtProxyPort
            // 
            this.txtProxyPort.Enabled = false;
            this.txtProxyPort.Location = new System.Drawing.Point(116, 61);
            this.txtProxyPort.Name = "txtProxyPort";
            this.txtProxyPort.Size = new System.Drawing.Size(612, 20);
            this.txtProxyPort.TabIndex = 1;
            this.txtProxyPort.Text = "1080";
            this.txtProxyPort.TextChanged += new System.EventHandler(this.txtProxyPort_TextChanged);
            // 
            // txtProxyHostnameIP
            // 
            this.txtProxyHostnameIP.Enabled = false;
            this.txtProxyHostnameIP.Location = new System.Drawing.Point(116, 35);
            this.txtProxyHostnameIP.Name = "txtProxyHostnameIP";
            this.txtProxyHostnameIP.Size = new System.Drawing.Size(612, 20);
            this.txtProxyHostnameIP.TabIndex = 0;
            this.txtProxyHostnameIP.Text = "chancity.hopto.org";
            this.txtProxyHostnameIP.TextChanged += new System.EventHandler(this.txtProxyHostnameIP_TextChanged);
            // 
            // tbEmailSettings
            // 
            this.tbEmailSettings.Controls.Add(this.groupBox6);
            this.tbEmailSettings.Location = new System.Drawing.Point(4, 25);
            this.tbEmailSettings.Name = "tbEmailSettings";
            this.tbEmailSettings.Size = new System.Drawing.Size(804, 360);
            this.tbEmailSettings.TabIndex = 2;
            this.tbEmailSettings.Text = "Email Settings";
            this.tbEmailSettings.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.richTextBox2);
            this.groupBox6.Location = new System.Drawing.Point(5, 128);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(736, 143);
            this.groupBox6.TabIndex = 8;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Notes";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox2.Location = new System.Drawing.Point(3, 16);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.Size = new System.Drawing.Size(730, 124);
            this.richTextBox2.TabIndex = 0;
            this.richTextBox2.Text = "Register at https://www.noip.com, make sure you configure a MX record for your DN" +
    "S entry.  If you\'re behind a firewall you need to port forward all port 25 traff" +
    "ic to this computer.";
            // 
            // tbLog
            // 
            this.tbLog.Controls.Add(this.richTextBox1);
            this.tbLog.Location = new System.Drawing.Point(4, 25);
            this.tbLog.Name = "tbLog";
            this.tbLog.Size = new System.Drawing.Size(804, 360);
            this.tbLog.TabIndex = 5;
            this.tbLog.Text = "Proxy Log";
            this.tbLog.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(804, 360);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(635, 395);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(61, 32);
            this.button1.TabIndex = 14;
            this.button1.Text = "Create";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(705, 403);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(46, 20);
            this.textBox1.TabIndex = 16;
            this.textBox1.Text = "1";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.LightGray;
            this.label7.Location = new System.Drawing.Point(757, 406);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Accounts";
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verifyToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(143, 26);
            // 
            // verifyToolStripMenuItem
            // 
            this.verifyToolStripMenuItem.Name = "verifyToolStripMenuItem";
            this.verifyToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.verifyToolStripMenuItem.Text = "Import Verify";
            this.verifyToolStripMenuItem.Click += new System.EventHandler(this.verifyToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.ClientSize = new System.Drawing.Size(812, 454);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.ForeColor = System.Drawing.Color.LightGray;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GoMan Account Creator";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.grpDateOfBirth.ResumeLayout(false);
            this.grpDateOfBirth.PerformLayout();
            this.grpUsername.ResumeLayout(false);
            this.grpUsername.PerformLayout();
            this.grpPassword.ResumeLayout(false);
            this.grpPassword.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udRandomPasswordLength)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.grpCountry.ResumeLayout(false);
            this.grpCountry.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tbCreatedAccounts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).EndInit();
            this.tbAccountSettings.ResumeLayout(false);
            this.grpEmail.ResumeLayout(false);
            this.grpEmail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tbCaptchaSettings.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tbEmailSettings.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.tbLog.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.GroupBox grpPassword;
        private System.Windows.Forms.CheckBox cbRandomPassword;
        private System.Windows.Forms.GroupBox grpUsername;
        private System.Windows.Forms.CheckBox cbRandomUsername;
        private System.Windows.Forms.CheckBox cbRandomPostfix;
        private System.Windows.Forms.CheckBox cbRandomPrefix;
        private System.Windows.Forms.GroupBox grpDateOfBirth;
        private System.Windows.Forms.CheckBox cbRandomDateOfBirth;
        private System.Windows.Forms.TextBox txtPrefix;
        private System.Windows.Forms.TextBox txtPostfix;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtCaptchaKey;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.GroupBox grpCountry;
        private System.Windows.Forms.CheckBox cbRandomCountry;
        private ComboBox cbCountry;
        private TabControl tabControl1;
        private TabPage tbAccountSettings;
        private TabPage tbCaptchaSettings;
        private TabPage tbEmailSettings;
        private TabPage tbCreatedAccounts;
        private GroupBox groupBox4;
        private Label label3;
        private Label label2;
        private TextBox txtProxyPort;
        private TextBox txtProxyHostnameIP;
        private GroupBox grpEmail;
        private TextBox txtEmailDomain;
        private Label label4;
        private GroupBox groupBox7;
        private RichTextBox richTextBox3;
        private GroupBox groupBox6;
        private RichTextBox richTextBox2;
        private DateTimePicker dtpDateOfBirth;
        private Timer timer1;
        private Label label1;
        private NumericUpDown udRandomPasswordLength;
        private Button button1;
        private ToolStripStatusLabel runningLabel;
        private ToolStripStatusLabel pendingLabel;
        private Label label5;
        private Label lblCaptchaError;
        private Button btnCaptchaTestPort;
        private TabPage tbLog;
        private RichTextBox richTextBox1;
        private TextBox textBox1;
        private Label label7;
        private BrightIdeasSoftware.ObjectListView objectListView1;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private BrightIdeasSoftware.OLVColumn olvColumn2;
        private BrightIdeasSoftware.OLVColumn olvColumn3;
        private BrightIdeasSoftware.OLVColumn olvColumn4;
        private BrightIdeasSoftware.OLVColumn olvColumn5;
        private BrightIdeasSoftware.OLVColumn olvColumn6;
        private BrightIdeasSoftware.MappedImageRenderer mappedImageRenderer1;
        private BrightIdeasSoftware.OLVColumn olvColumn7;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel createdLabel;
        private ToolStripStatusLabel failedLabel;
        private PictureBox pictureBox1;
        private ToolStripStatusLabel toolStripStatusLabel4;
        private ToolStripProgressBar toolStripProgressBar;
        private ToolStripStatusLabel toolStripStatusLabel3;
        private ContextMenuStrip contextMenuStrip2;
        private ToolStripMenuItem verifyToolStripMenuItem;
    }
}

