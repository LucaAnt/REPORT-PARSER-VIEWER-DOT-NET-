using System.IO;

namespace Parsing_Service.View
{
    partial class ReportParsingServiceUISingle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportParsingServiceUISingle));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.textBoxParsingResultLog = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBoxFilters = new System.Windows.Forms.TextBox();
            this.labelParsingProgress = new System.Windows.Forms.Label();
            this.buttonStartStop = new System.Windows.Forms.Button();
            this.labelTotalErrors = new System.Windows.Forms.Label();
            this.labelTotalParsed = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.parsingBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonResetAllDirectories = new System.Windows.Forms.Button();
            this.buttonRemoveDirectory = new System.Windows.Forms.Button();
            this.listBoxDirectoriesList = new System.Windows.Forms.ListBox();
            this.buttonpickDirectory = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton3);
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Location = new System.Drawing.Point(413, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(118, 87);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Parsing Type";
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Enabled = false;
            this.radioButton3.Location = new System.Drawing.Point(6, 65);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(51, 17);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.Text = "Other";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.RadioButton_OtherFormat);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(6, 42);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(43, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "NTI";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.RadioButton_NtiFormat);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 19);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(53, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.Text = "Nokia";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.RadioButton_NokiaFormat);
            // 
            // textBoxParsingResultLog
            // 
            this.textBoxParsingResultLog.AcceptsReturn = true;
            this.textBoxParsingResultLog.AcceptsTab = true;
            this.textBoxParsingResultLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBoxParsingResultLog.Location = new System.Drawing.Point(0, 292);
            this.textBoxParsingResultLog.Multiline = true;
            this.textBoxParsingResultLog.Name = "textBoxParsingResultLog";
            this.textBoxParsingResultLog.ReadOnly = true;
            this.textBoxParsingResultLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxParsingResultLog.Size = new System.Drawing.Size(561, 191);
            this.textBoxParsingResultLog.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.labelParsingProgress);
            this.groupBox3.Controls.Add(this.buttonStartStop);
            this.groupBox3.Controls.Add(this.labelTotalErrors);
            this.groupBox3.Controls.Add(this.labelTotalParsed);
            this.groupBox3.Controls.Add(this.progressBar1);
            this.groupBox3.Location = new System.Drawing.Point(12, 164);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(537, 122);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Parsing status";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBoxFilters);
            this.groupBox4.Location = new System.Drawing.Point(295, 16);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(236, 48);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Exclude Parsing Tags(semicolon separated\';\')";
            // 
            // textBoxFilters
            // 
            this.textBoxFilters.Location = new System.Drawing.Point(6, 19);
            this.textBoxFilters.Name = "textBoxFilters";
            this.textBoxFilters.Size = new System.Drawing.Size(212, 20);
            this.textBoxFilters.TabIndex = 0;
            this.textBoxFilters.TextChanged += new System.EventHandler(this.bindFilesFilterToSettings);
            // 
            // labelParsingProgress
            // 
            this.labelParsingProgress.AutoSize = true;
            this.labelParsingProgress.Location = new System.Drawing.Point(3, 45);
            this.labelParsingProgress.Name = "labelParsingProgress";
            this.labelParsingProgress.Size = new System.Drawing.Size(92, 13);
            this.labelParsingProgress.TabIndex = 6;
            this.labelParsingProgress.Text = "Parsing Progress :";
            // 
            // buttonStartStop
            // 
            this.buttonStartStop.Location = new System.Drawing.Point(3, 67);
            this.buttonStartStop.Name = "buttonStartStop";
            this.buttonStartStop.Size = new System.Drawing.Size(185, 23);
            this.buttonStartStop.TabIndex = 5;
            this.buttonStartStop.Text = "START";
            this.buttonStartStop.UseVisualStyleBackColor = true;
            this.buttonStartStop.Click += new System.EventHandler(this.ButtonStartStop_Click);
            // 
            // labelTotalErrors
            // 
            this.labelTotalErrors.AutoSize = true;
            this.labelTotalErrors.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelTotalErrors.Location = new System.Drawing.Point(3, 29);
            this.labelTotalErrors.Name = "labelTotalErrors";
            this.labelTotalErrors.Size = new System.Drawing.Size(73, 13);
            this.labelTotalErrors.TabIndex = 4;
            this.labelTotalErrors.Text = "Parsed Errors:";
            // 
            // labelTotalParsed
            // 
            this.labelTotalParsed.AutoSize = true;
            this.labelTotalParsed.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelTotalParsed.Location = new System.Drawing.Point(3, 16);
            this.labelTotalParsed.Name = "labelTotalParsed";
            this.labelTotalParsed.Size = new System.Drawing.Size(43, 13);
            this.labelTotalParsed.TabIndex = 3;
            this.labelTotalParsed.Text = "Parsed:";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(3, 96);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(185, 23);
            this.progressBar1.Step = 1;
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonResetAllDirectories);
            this.groupBox1.Controls.Add(this.buttonRemoveDirectory);
            this.groupBox1.Controls.Add(this.listBoxDirectoriesList);
            this.groupBox1.Controls.Add(this.buttonpickDirectory);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(537, 146);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parsing Directories";
            // 
            // buttonResetAllDirectories
            // 
            this.buttonResetAllDirectories.Location = new System.Drawing.Point(478, 112);
            this.buttonResetAllDirectories.Name = "buttonResetAllDirectories";
            this.buttonResetAllDirectories.Size = new System.Drawing.Size(47, 23);
            this.buttonResetAllDirectories.TabIndex = 8;
            this.buttonResetAllDirectories.Text = "Reset";
            this.buttonResetAllDirectories.UseVisualStyleBackColor = true;
            this.buttonResetAllDirectories.Click += new System.EventHandler(this.ButtonResetAllDirectories_Click);
            // 
            // buttonRemoveDirectory
            // 
            this.buttonRemoveDirectory.Location = new System.Drawing.Point(443, 112);
            this.buttonRemoveDirectory.Name = "buttonRemoveDirectory";
            this.buttonRemoveDirectory.Size = new System.Drawing.Size(29, 23);
            this.buttonRemoveDirectory.TabIndex = 7;
            this.buttonRemoveDirectory.Text = "-";
            this.buttonRemoveDirectory.UseVisualStyleBackColor = true;
            this.buttonRemoveDirectory.Click += new System.EventHandler(this.ButtonRemoveDirectory_Click);
            // 
            // listBoxDirectoriesList
            // 
            this.listBoxDirectoriesList.FormattingEnabled = true;
            this.listBoxDirectoriesList.Location = new System.Drawing.Point(7, 19);
            this.listBoxDirectoriesList.Name = "listBoxDirectoriesList";
            this.listBoxDirectoriesList.Size = new System.Drawing.Size(400, 121);
            this.listBoxDirectoriesList.TabIndex = 6;
            // 
            // buttonpickDirectory
            // 
            this.buttonpickDirectory.Location = new System.Drawing.Point(413, 112);
            this.buttonpickDirectory.Name = "buttonpickDirectory";
            this.buttonpickDirectory.Size = new System.Drawing.Size(30, 23);
            this.buttonpickDirectory.TabIndex = 5;
            this.buttonpickDirectory.Text = "+";
            this.buttonpickDirectory.UseVisualStyleBackColor = true;
            this.buttonpickDirectory.Click += new System.EventHandler(this.buttonpickDirectory_Click);
            // 
            // ReportParsingServiceUISingle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(561, 483);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.textBoxParsingResultLog);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReportParsingServiceUISingle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report Parsing Service";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        public System.Windows.Forms.TextBox textBoxParsingResultLog;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button buttonStartStop;
        private System.Windows.Forms.Label labelTotalErrors;
        private System.Windows.Forms.Label labelTotalParsed;
        private System.Windows.Forms.FolderBrowserDialog folderBrowser;
        private System.ComponentModel.BackgroundWorker parsingBackgroundWorker;
        private System.Windows.Forms.Label labelParsingProgress;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonpickDirectory;
        private System.Windows.Forms.ListBox listBoxDirectoriesList;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textBoxFilters;
        private System.Windows.Forms.Button buttonResetAllDirectories;
        private System.Windows.Forms.Button buttonRemoveDirectory;
    }
}