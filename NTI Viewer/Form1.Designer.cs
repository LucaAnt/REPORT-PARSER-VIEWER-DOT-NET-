namespace NTI_Viewer
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartFpy = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripComboBoxStyleSheet = new System.Windows.Forms.ToolStripComboBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageSummary = new System.Windows.Forms.TabPage();
            this.tabPageFilterAndStats = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.labelFpyAll = new System.Windows.Forms.Label();
            this.labelTerminated = new System.Windows.Forms.Label();
            this.labelPy = new System.Windows.Forms.Label();
            this.labelCapability = new System.Windows.Forms.Label();
            this.labelAvgT = new System.Windows.Forms.Label();
            this.labelFpy = new System.Windows.Forms.Label();
            this.labelYeld = new System.Windows.Forms.Label();
            this.labelError = new System.Windows.Forms.Label();
            this.labelFailed = new System.Windows.Forms.Label();
            this.labelPassed = new System.Windows.Forms.Label();
            this.labelTotal = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBoxError = new System.Windows.Forms.CheckBox();
            this.checkBoxTerminated = new System.Windows.Forms.CheckBox();
            this.checkBoxFailed = new System.Windows.Forms.CheckBox();
            this.checkBoxPassed = new System.Windows.Forms.CheckBox();
            this.labelFilterCriteria = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.checkBoxDateTimeEnabler = new System.Windows.Forms.CheckBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.buttonReset = new System.Windows.Forms.Button();
            this.textBoxFilterValue = new System.Windows.Forms.TextBox();
            this.checkBoxIncremental = new System.Windows.Forms.CheckBox();
            this.comboBoxFilterField = new System.Windows.Forms.ComboBox();
            this.comboBoxFilterTune = new System.Windows.Forms.ComboBox();
            this.buttonFilter = new System.Windows.Forms.Button();
            this.tabPageTable = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.displaySelectedReportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSelectedReportsToCcsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.safeFilesToZipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPageFpyChart = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.saveFileDialogCsv = new System.Windows.Forms.SaveFileDialog();
            this.saveFileDialogZip = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.chartFpy)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageSummary.SuspendLayout();
            this.tabPageFilterAndStats.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabPageTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.tabPageFpyChart.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // chartFpy
            // 
            chartArea3.Name = "ChartArea1";
            this.chartFpy.ChartAreas.Add(chartArea3);
            this.chartFpy.Dock = System.Windows.Forms.DockStyle.Fill;
            legend3.Name = "Legend1";
            this.chartFpy.Legends.Add(legend3);
            this.chartFpy.Location = new System.Drawing.Point(3, 3);
            this.chartFpy.Name = "chartFpy";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.LegendText = "FPY (Pass,Fail)";
            series4.Name = "FPYPF";
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.LegendText = "FPY (Pass,Fail,Ter,Err)";
            series5.Name = "FPYPFTE";
            this.chartFpy.Series.Add(series4);
            this.chartFpy.Series.Add(series5);
            this.chartFpy.Size = new System.Drawing.Size(601, 359);
            this.chartFpy.TabIndex = 0;
            title2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title2.Name = "Title1";
            title2.Text = "Monthly First Pass Yeld On Filtered Reports";
            this.chartFpy.Titles.Add(title2);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(601, 359);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parsing Summary";
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(3, 16);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(595, 340);
            this.textBox1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripSeparator1,
            this.toolStripProgressBar1,
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripSeparator2,
            this.toolStripSeparator3,
            this.toolStripComboBoxStyleSheet});
            this.toolStrip1.Location = new System.Drawing.Point(0, 391);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(615, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(98, 22);
            this.toolStripLabel1.Text = "Reports Directory";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 22);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(49, 22);
            this.toolStripButton1.Text = "Browse";
            this.toolStripButton1.Click += new System.EventHandler(this.ToolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(82, 22);
            this.toolStripButton2.Text = "Parse Reports";
            this.toolStripButton2.ToolTipText = "Parse the currently selected  directory";
            this.toolStripButton2.Click += new System.EventHandler(this.ToolStripButton2_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripComboBoxStyleSheet
            // 
            this.toolStripComboBoxStyleSheet.Items.AddRange(new object[] {
            "report.xsl",
            "horizontal.xsl",
            "expand.xsl"});
            this.toolStripComboBoxStyleSheet.Name = "toolStripComboBoxStyleSheet";
            this.toolStripComboBoxStyleSheet.Size = new System.Drawing.Size(121, 25);
            this.toolStripComboBoxStyleSheet.Text = "report.xsl";
            this.toolStripComboBoxStyleSheet.ToolTipText = "Select the layout for the Html display";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwDoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwCompleted);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageSummary);
            this.tabControl1.Controls.Add(this.tabPageFilterAndStats);
            this.tabControl1.Controls.Add(this.tabPageTable);
            this.tabControl1.Controls.Add(this.tabPageFpyChart);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(615, 391);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPageSummary
            // 
            this.tabPageSummary.Controls.Add(this.groupBox1);
            this.tabPageSummary.Location = new System.Drawing.Point(4, 22);
            this.tabPageSummary.Name = "tabPageSummary";
            this.tabPageSummary.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSummary.Size = new System.Drawing.Size(607, 365);
            this.tabPageSummary.TabIndex = 0;
            this.tabPageSummary.Text = "Parsing Summary";
            this.tabPageSummary.UseVisualStyleBackColor = true;
            // 
            // tabPageFilterAndStats
            // 
            this.tabPageFilterAndStats.Controls.Add(this.groupBox3);
            this.tabPageFilterAndStats.Controls.Add(this.groupBox2);
            this.tabPageFilterAndStats.Location = new System.Drawing.Point(4, 22);
            this.tabPageFilterAndStats.Name = "tabPageFilterAndStats";
            this.tabPageFilterAndStats.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFilterAndStats.Size = new System.Drawing.Size(607, 365);
            this.tabPageFilterAndStats.TabIndex = 3;
            this.tabPageFilterAndStats.Text = "Filters & Stats";
            this.tabPageFilterAndStats.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labelFpyAll);
            this.groupBox3.Controls.Add(this.labelTerminated);
            this.groupBox3.Controls.Add(this.labelPy);
            this.groupBox3.Controls.Add(this.labelCapability);
            this.groupBox3.Controls.Add(this.labelAvgT);
            this.groupBox3.Controls.Add(this.labelFpy);
            this.groupBox3.Controls.Add(this.labelYeld);
            this.groupBox3.Controls.Add(this.labelError);
            this.groupBox3.Controls.Add(this.labelFailed);
            this.groupBox3.Controls.Add(this.labelPassed);
            this.groupBox3.Controls.Add(this.labelTotal);
            this.groupBox3.Location = new System.Drawing.Point(6, 193);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(591, 127);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Filtered Stats";
            // 
            // labelFpyAll
            // 
            this.labelFpyAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFpyAll.AutoSize = true;
            this.labelFpyAll.Location = new System.Drawing.Point(345, 52);
            this.labelFpyAll.Name = "labelFpyAll";
            this.labelFpyAll.Size = new System.Drawing.Size(46, 13);
            this.labelFpyAll.TabIndex = 6;
            this.labelFpyAll.Text = "FPYALL";
            // 
            // labelTerminated
            // 
            this.labelTerminated.AutoSize = true;
            this.labelTerminated.Location = new System.Drawing.Point(3, 78);
            this.labelTerminated.Name = "labelTerminated";
            this.labelTerminated.Size = new System.Drawing.Size(60, 13);
            this.labelTerminated.TabIndex = 2;
            this.labelTerminated.Text = "Terminated";
            // 
            // labelPy
            // 
            this.labelPy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPy.AutoSize = true;
            this.labelPy.Location = new System.Drawing.Point(345, 28);
            this.labelPy.Name = "labelPy";
            this.labelPy.Size = new System.Drawing.Size(21, 13);
            this.labelPy.TabIndex = 8;
            this.labelPy.Text = "PY";
            // 
            // labelCapability
            // 
            this.labelCapability.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCapability.AutoSize = true;
            this.labelCapability.Location = new System.Drawing.Point(345, 78);
            this.labelCapability.Name = "labelCapability";
            this.labelCapability.Size = new System.Drawing.Size(52, 13);
            this.labelCapability.TabIndex = 7;
            this.labelCapability.Text = "Capability";
            // 
            // labelAvgT
            // 
            this.labelAvgT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelAvgT.AutoSize = true;
            this.labelAvgT.Location = new System.Drawing.Point(345, 65);
            this.labelAvgT.Name = "labelAvgT";
            this.labelAvgT.Size = new System.Drawing.Size(52, 13);
            this.labelAvgT.TabIndex = 10;
            this.labelAvgT.Text = "Avg Time";
            // 
            // labelFpy
            // 
            this.labelFpy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFpy.AutoSize = true;
            this.labelFpy.Location = new System.Drawing.Point(345, 39);
            this.labelFpy.Name = "labelFpy";
            this.labelFpy.Size = new System.Drawing.Size(27, 13);
            this.labelFpy.TabIndex = 5;
            this.labelFpy.Text = "FPY";
            // 
            // labelYeld
            // 
            this.labelYeld.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelYeld.AutoSize = true;
            this.labelYeld.Location = new System.Drawing.Point(345, 15);
            this.labelYeld.Name = "labelYeld";
            this.labelYeld.Size = new System.Drawing.Size(28, 13);
            this.labelYeld.TabIndex = 4;
            this.labelYeld.Text = "Yeld";
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.Location = new System.Drawing.Point(6, 65);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(28, 13);
            this.labelError.TabIndex = 3;
            this.labelError.Text = "error";
            // 
            // labelFailed
            // 
            this.labelFailed.AutoSize = true;
            this.labelFailed.Location = new System.Drawing.Point(6, 52);
            this.labelFailed.Name = "labelFailed";
            this.labelFailed.Size = new System.Drawing.Size(32, 13);
            this.labelFailed.TabIndex = 2;
            this.labelFailed.Text = "failed";
            // 
            // labelPassed
            // 
            this.labelPassed.AutoSize = true;
            this.labelPassed.Location = new System.Drawing.Point(6, 39);
            this.labelPassed.Name = "labelPassed";
            this.labelPassed.Size = new System.Drawing.Size(41, 13);
            this.labelPassed.TabIndex = 1;
            this.labelPassed.Text = "passed";
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Location = new System.Drawing.Point(6, 26);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(27, 13);
            this.labelTotal.TabIndex = 0;
            this.labelTotal.Text = "total";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBoxError);
            this.groupBox2.Controls.Add(this.checkBoxTerminated);
            this.groupBox2.Controls.Add(this.checkBoxFailed);
            this.groupBox2.Controls.Add(this.checkBoxPassed);
            this.groupBox2.Controls.Add(this.labelFilterCriteria);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.buttonReset);
            this.groupBox2.Controls.Add(this.textBoxFilterValue);
            this.groupBox2.Controls.Add(this.checkBoxIncremental);
            this.groupBox2.Controls.Add(this.comboBoxFilterField);
            this.groupBox2.Controls.Add(this.comboBoxFilterTune);
            this.groupBox2.Controls.Add(this.buttonFilter);
            this.groupBox2.Location = new System.Drawing.Point(8, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(589, 181);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filter";
            // 
            // checkBoxError
            // 
            this.checkBoxError.AutoSize = true;
            this.checkBoxError.Checked = true;
            this.checkBoxError.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxError.Location = new System.Drawing.Point(224, 69);
            this.checkBoxError.Name = "checkBoxError";
            this.checkBoxError.Size = new System.Drawing.Size(48, 17);
            this.checkBoxError.TabIndex = 18;
            this.checkBoxError.Text = "Error";
            this.checkBoxError.UseVisualStyleBackColor = true;
            this.checkBoxError.CheckedChanged += new System.EventHandler(this.updateUUTResultList);
            // 
            // checkBoxTerminated
            // 
            this.checkBoxTerminated.AutoSize = true;
            this.checkBoxTerminated.Checked = true;
            this.checkBoxTerminated.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxTerminated.Location = new System.Drawing.Point(144, 69);
            this.checkBoxTerminated.Name = "checkBoxTerminated";
            this.checkBoxTerminated.Size = new System.Drawing.Size(79, 17);
            this.checkBoxTerminated.TabIndex = 17;
            this.checkBoxTerminated.Text = "Terminated";
            this.checkBoxTerminated.UseVisualStyleBackColor = true;
            this.checkBoxTerminated.CheckedChanged += new System.EventHandler(this.updateUUTResultList);
            // 
            // checkBoxFailed
            // 
            this.checkBoxFailed.AutoSize = true;
            this.checkBoxFailed.Checked = true;
            this.checkBoxFailed.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxFailed.Location = new System.Drawing.Point(80, 69);
            this.checkBoxFailed.Name = "checkBoxFailed";
            this.checkBoxFailed.Size = new System.Drawing.Size(54, 17);
            this.checkBoxFailed.TabIndex = 16;
            this.checkBoxFailed.Text = "Failed";
            this.checkBoxFailed.UseVisualStyleBackColor = true;
            this.checkBoxFailed.CheckedChanged += new System.EventHandler(this.updateUUTResultList);
            // 
            // checkBoxPassed
            // 
            this.checkBoxPassed.AutoSize = true;
            this.checkBoxPassed.Checked = true;
            this.checkBoxPassed.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxPassed.Location = new System.Drawing.Point(13, 69);
            this.checkBoxPassed.Name = "checkBoxPassed";
            this.checkBoxPassed.Size = new System.Drawing.Size(61, 17);
            this.checkBoxPassed.TabIndex = 15;
            this.checkBoxPassed.Text = "Passed";
            this.checkBoxPassed.UseVisualStyleBackColor = true;
            this.checkBoxPassed.CheckedChanged += new System.EventHandler(this.updateUUTResultList);
            // 
            // labelFilterCriteria
            // 
            this.labelFilterCriteria.AutoSize = true;
            this.labelFilterCriteria.Location = new System.Drawing.Point(10, 142);
            this.labelFilterCriteria.Name = "labelFilterCriteria";
            this.labelFilterCriteria.Size = new System.Drawing.Size(140, 13);
            this.labelFilterCriteria.TabIndex = 14;
            this.labelFilterCriteria.Text = "CURRENT FILTER: no filter";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(243, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Value to filter";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(130, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Filter Tune";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Filtered Field";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.dateTimePicker1);
            this.groupBox4.Controls.Add(this.checkBoxDateTimeEnabler);
            this.groupBox4.Controls.Add(this.dateTimePicker2);
            this.groupBox4.Location = new System.Drawing.Point(368, 19);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(215, 116);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Date Filter";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "END DATE";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "START DATE";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Location = new System.Drawing.Point(6, 50);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 4;
            // 
            // checkBoxDateTimeEnabler
            // 
            this.checkBoxDateTimeEnabler.AutoSize = true;
            this.checkBoxDateTimeEnabler.Location = new System.Drawing.Point(54, 14);
            this.checkBoxDateTimeEnabler.Name = "checkBoxDateTimeEnabler";
            this.checkBoxDateTimeEnabler.Size = new System.Drawing.Size(110, 17);
            this.checkBoxDateTimeEnabler.TabIndex = 3;
            this.checkBoxDateTimeEnabler.Text = "Enable Date Filter";
            this.checkBoxDateTimeEnabler.UseVisualStyleBackColor = true;
            this.checkBoxDateTimeEnabler.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Enabled = false;
            this.dateTimePicker2.Location = new System.Drawing.Point(6, 89);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker2.TabIndex = 5;
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(275, 101);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(75, 23);
            this.buttonReset.TabIndex = 8;
            this.buttonReset.Text = "RESET";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.ButtonReset_Click);
            // 
            // textBoxFilterValue
            // 
            this.textBoxFilterValue.Location = new System.Drawing.Point(195, 38);
            this.textBoxFilterValue.Name = "textBoxFilterValue";
            this.textBoxFilterValue.Size = new System.Drawing.Size(155, 20);
            this.textBoxFilterValue.TabIndex = 7;
            // 
            // checkBoxIncremental
            // 
            this.checkBoxIncremental.AutoSize = true;
            this.checkBoxIncremental.Location = new System.Drawing.Point(278, 69);
            this.checkBoxIncremental.Name = "checkBoxIncremental";
            this.checkBoxIncremental.Size = new System.Drawing.Size(81, 17);
            this.checkBoxIncremental.TabIndex = 6;
            this.checkBoxIncremental.Text = "Incremental";
            this.checkBoxIncremental.UseVisualStyleBackColor = true;
            // 
            // comboBoxFilterField
            // 
            this.comboBoxFilterField.FormattingEnabled = true;
            this.comboBoxFilterField.Items.AddRange(new object[] {
            "Station",
            "Serial",
            "Execution Time",
            "Number of Results",
            "Operator"});
            this.comboBoxFilterField.Location = new System.Drawing.Point(6, 38);
            this.comboBoxFilterField.Name = "comboBoxFilterField";
            this.comboBoxFilterField.Size = new System.Drawing.Size(121, 21);
            this.comboBoxFilterField.TabIndex = 2;
            // 
            // comboBoxFilterTune
            // 
            this.comboBoxFilterTune.FormattingEnabled = true;
            this.comboBoxFilterTune.Items.AddRange(new object[] {
            "=",
            ">",
            "<",
            "contain"});
            this.comboBoxFilterTune.Location = new System.Drawing.Point(133, 38);
            this.comboBoxFilterTune.Name = "comboBoxFilterTune";
            this.comboBoxFilterTune.Size = new System.Drawing.Size(44, 21);
            this.comboBoxFilterTune.TabIndex = 1;
            this.comboBoxFilterTune.Text = "=";
            // 
            // buttonFilter
            // 
            this.buttonFilter.Location = new System.Drawing.Point(6, 101);
            this.buttonFilter.Name = "buttonFilter";
            this.buttonFilter.Size = new System.Drawing.Size(75, 23);
            this.buttonFilter.TabIndex = 0;
            this.buttonFilter.Text = "FILTER";
            this.buttonFilter.UseVisualStyleBackColor = true;
            this.buttonFilter.Click += new System.EventHandler(this.ButtonFilter_Click);
            // 
            // tabPageTable
            // 
            this.tabPageTable.Controls.Add(this.dataGridView1);
            this.tabPageTable.Location = new System.Drawing.Point(4, 22);
            this.tabPageTable.Name = "tabPageTable";
            this.tabPageTable.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTable.Size = new System.Drawing.Size(607, 365);
            this.tabPageTable.TabIndex = 1;
            this.tabPageTable.Text = "Data Table";
            this.tabPageTable.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(601, 359);
            this.dataGridView1.TabIndex = 4;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.displaySelectedReportsToolStripMenuItem,
            this.saveSelectedReportsToCcsToolStripMenuItem,
            this.safeFilesToZipToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(225, 70);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ContextMenuClickItemHandler);
            // 
            // displaySelectedReportsToolStripMenuItem
            // 
            this.displaySelectedReportsToolStripMenuItem.Name = "displaySelectedReportsToolStripMenuItem";
            this.displaySelectedReportsToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.displaySelectedReportsToolStripMenuItem.Text = "Display Selected Reports";
            // 
            // saveSelectedReportsToCcsToolStripMenuItem
            // 
            this.saveSelectedReportsToCcsToolStripMenuItem.Name = "saveSelectedReportsToCcsToolStripMenuItem";
            this.saveSelectedReportsToCcsToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.saveSelectedReportsToCcsToolStripMenuItem.Text = "Save Selected Reports to Csv";
            // 
            // safeFilesToZipToolStripMenuItem
            // 
            this.safeFilesToZipToolStripMenuItem.Name = "safeFilesToZipToolStripMenuItem";
            this.safeFilesToZipToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.safeFilesToZipToolStripMenuItem.Text = "Save Files to Zip";
            // 
            // tabPageFpyChart
            // 
            this.tabPageFpyChart.Controls.Add(this.chartFpy);
            this.tabPageFpyChart.Location = new System.Drawing.Point(4, 22);
            this.tabPageFpyChart.Name = "tabPageFpyChart";
            this.tabPageFpyChart.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFpyChart.Size = new System.Drawing.Size(607, 365);
            this.tabPageFpyChart.TabIndex = 2;
            this.tabPageFpyChart.Text = "FPY";
            this.tabPageFpyChart.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chart1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(607, 365);
            this.tabPage1.TabIndex = 4;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // chart1
            // 
            chartArea4.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea4);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend4.Name = "Legend1";
            this.chart1.Legends.Add(legend4);
            this.chart1.Location = new System.Drawing.Point(3, 3);
            this.chart1.Name = "chart1";
            series6.ChartArea = "ChartArea1";
            series6.Legend = "Legend1";
            series6.Name = "Series";
            this.chart1.Series.Add(series6);
            this.chart1.Size = new System.Drawing.Size(601, 359);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // saveFileDialogCsv
            // 
            this.saveFileDialogCsv.DefaultExt = "csv";
            this.saveFileDialogCsv.Filter = "\"Csv files (*.csv)|*.csv|All files (*.*)|*.*\"";
            // 
            // saveFileDialogZip
            // 
            this.saveFileDialogZip.DefaultExt = "zip";
            this.saveFileDialogZip.Filter = "\"Zip files (*.zip)|*.zip|All files (*.*)|*.*\"";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 416);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NTI Reports Tool";
            ((System.ComponentModel.ISupportInitialize)(this.chartFpy)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPageSummary.ResumeLayout(false);
            this.tabPageFilterAndStats.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabPageTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabPageFpyChart.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartFpy;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageSummary;
        private System.Windows.Forms.TabPage tabPageTable;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabPage tabPageFpyChart;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.TabPage tabPageFilterAndStats;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.CheckBox checkBoxDateTimeEnabler;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.TextBox textBoxFilterValue;
        private System.Windows.Forms.CheckBox checkBoxIncremental;
        private System.Windows.Forms.ComboBox comboBoxFilterField;
        private System.Windows.Forms.ComboBox comboBoxFilterTune;
        private System.Windows.Forms.Button buttonFilter;
        private System.Windows.Forms.Label labelCapability;
        private System.Windows.Forms.Label labelAvgT;
        private System.Windows.Forms.Label labelFpy;
        private System.Windows.Forms.Label labelYeld;
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.Label labelFailed;
        private System.Windows.Forms.Label labelPassed;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Label labelPy;
        private System.Windows.Forms.Label labelTerminated;
        private System.Windows.Forms.Label labelFpyAll;
        private System.Windows.Forms.Label labelFilterCriteria;
        private System.Windows.Forms.CheckBox checkBoxError;
        private System.Windows.Forms.CheckBox checkBoxTerminated;
        private System.Windows.Forms.CheckBox checkBoxFailed;
        private System.Windows.Forms.CheckBox checkBoxPassed;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem displaySelectedReportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveSelectedReportsToCcsToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialogCsv;
        private System.Windows.Forms.ToolStripMenuItem safeFilesToZipToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialogZip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxStyleSheet;
    }
}

