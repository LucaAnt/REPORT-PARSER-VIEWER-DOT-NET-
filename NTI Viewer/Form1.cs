using Parsing_Service.Model;
using Parsing_Service.Parsing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;
using static NTI_Viewer.StatsUtil;

namespace NTI_Viewer
{
    public partial class Form1 : Form
    {
        private String parsingDir = "";
        private List<ParsedReport> reports = new List<ParsedReport>();
        private List<ParsedReport> filteredReports = new List<ParsedReport>();

        //UI Controls Data
        private Boolean dateFilterEnabled = false;
        private List<String> UUTResultListtoDisplay;
        public Form1()
        {
            InitializeComponent();
            updateUUTResultList(null, null);
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                this.parsingDir = toolStripLabel1.Text = folderBrowserDialog1.SelectedPath;
        }


        private void ToolStripButton2_Click(object sender, EventArgs e)
        {

            String[] argumentArray = new String[2];
            argumentArray[0] = this.parsingDir;
            argumentArray[1] = this.toolStripComboBoxStyleSheet.Text;
            backgroundWorker1.RunWorkerAsync(argumentArray);
        }

        private void bwDoWork(object sender, DoWorkEventArgs e)
        {
            String[] argumentArray = e.Argument as String[];
            String directory = argumentArray[0];
            String stylesheet = argumentArray[1];
            Parser.setParserConfiguration(this.parsingDir, 2, new DateTime(), new List<String>(), stylesheet, this.backgroundWorker1);
            e.Result = Parser.parseAll(directory);
        }

        private void bwProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.toolStripProgressBar1.Value = e.ProgressPercentage;
        }

        private void bwCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            reports = filteredReports = (List<ParsedReport>)e.Result;

            textBox1.AppendText(Parser.getParsingReport() + Environment.NewLine + "---------End Parsing Summary---------" + Environment.NewLine);

            updateGui();
        }


        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

            this.dateFilterEnabled = !this.dateFilterEnabled;
            this.dateTimePicker1.Enabled = !this.dateTimePicker1.Enabled;
            this.dateTimePicker2.Enabled = !this.dateTimePicker2.Enabled;
        }

        private void updateGui()
        {

            dataGridView1.DataSource = this.filteredReports;

            StatsUtil statsCalculator = new StatsUtil(filteredReports);
            labelTotal.Text = "TOTAL: " + statsCalculator.Total;
            labelPassed.Text = "PASSED: " + statsCalculator.Passed;
            labelFailed.Text = "FAILED: " + statsCalculator.Failed;
            labelTerminated.Text = "TERMINATED: " + statsCalculator.Terminated;
            labelError.Text = "ERROR: " + statsCalculator.Error;

            labelPy.Text = "PASS YIELD : " + statsCalculator.PassYeld;
            labelYeld.Text = "YIELD: " + statsCalculator.Yeld;
            labelAvgT.Text = "AVARANGE EXECUTION TIME: " + statsCalculator.AvarangeTestingTime;
            labelFpy.Text = "FIRST PASS YIELD (passed,fail): " + statsCalculator.FirstPassYeldPassedFailed;
            labelFpyAll.Text = "FIRST PASS YIELD(all): " + statsCalculator.FirstPassYeldPassedFailedErrorTerminated;
            labelCapability.Text = "CAPABILITY: " + "?";

            this.chartFpy.Series["FPYPF"].Points.Clear();
            this.chartFpy.Series["FPYPFTE"].Points.Clear();
            foreach (FpyMonthChartEntry entry in statsCalculator.FpyPFMonthlyChart)
            {
                this.chartFpy.Series["FPYPF"].Points.AddXY(entry.YearMonth, entry.FPY);
                this.chartFpy.Series["FPYPFTE"].Points.AddXY(entry.YearMonth, entry.FPYPFTE);

                Console.WriteLine(entry.YearMonth + ":" + entry.FPY);
            }


        }
        private void updateUUTResultList(object sender, EventArgs e)
        {
            UUTResultListtoDisplay = new List<string>();
            if (checkBoxPassed.Checked)
                UUTResultListtoDisplay.Add("Passed");
            if (checkBoxFailed.Checked)
                UUTResultListtoDisplay.Add("Failed");
            if (checkBoxTerminated.Checked)
                UUTResultListtoDisplay.Add("Terminated");
            if (checkBoxError.Checked)
                UUTResultListtoDisplay.Add("Error");
        }

        private void ButtonFilter_Click(object sender, EventArgs e)
        {
            String toDisplayFilterResult = "";
            foreach (String s in UUTResultListtoDisplay)
                toDisplayFilterResult += " " + s;
            if (!checkBoxIncremental.Checked)
                filteredReports = reports;

            if (dateFilterEnabled)
            {
                this.filteredReports = FilterUtil.Filter(filteredReports, UUTResultListtoDisplay, comboBoxFilterField.Text, comboBoxFilterTune.Text, textBoxFilterValue.Text, dateTimePicker1.Value, dateTimePicker2.Value);
                labelFilterCriteria.Text = "CURRENT FILTER: " + "Showing" + toDisplayFilterResult + ((textBoxFilterValue.Text != "") ? " with " + comboBoxFilterField.Text + comboBoxFilterTune.Text + textBoxFilterValue.Text + " " : " ") + " between " + dateTimePicker1.Value + "and " + dateTimePicker2.Value;
            }
            else
            {
                this.filteredReports = FilterUtil.Filter(filteredReports, UUTResultListtoDisplay, comboBoxFilterField.Text, comboBoxFilterTune.Text, textBoxFilterValue.Text);
                labelFilterCriteria.Text = "CURRENT FILTER: " + "Showing" + toDisplayFilterResult + ((textBoxFilterValue.Text != "") ? " with " + comboBoxFilterField.Text + comboBoxFilterTune.Text + textBoxFilterValue.Text + " " : " ");
            }
            updateGui();
        }

        private void ButtonReset_Click(object sender, EventArgs e)
        {
            this.filteredReports = this.reports;
            updateGui();
            labelFilterCriteria.Text = "CURRENT FILTER: no filter";
            checkBoxPassed.Checked = checkBoxFailed.Checked = checkBoxTerminated.Checked = checkBoxError.Checked = true;
            checkBoxIncremental.Checked = false;
            comboBoxFilterField.Text = comboBoxFilterTune.Text = textBoxFilterValue.Text = "";
        }

        private void ContextMenuClickItemHandler(object sender, ToolStripItemClickedEventArgs e)
        {


            switch (e.ClickedItem.Text)
            {
                case "Display Selected Reports":
                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    {
                        displayFileInDefaultBrowser(((ParsedReport)row.DataBoundItem).FileName);
                        //Console.WriteLine(((ParsedReport)row.DataBoundItem).FileName);
                    }
                    break;
                case "Save Selected Reports to Csv":
                    contextMenuStrip1.Close();
                    String outPutCsv = filteredReports[0].getCsvHeader() + Environment.NewLine;
                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                        outPutCsv += ((ParsedReport)row.DataBoundItem).toCsvEntry() + Environment.NewLine;
                    if (saveFileDialogCsv.ShowDialog() == DialogResult.OK)
                        File.WriteAllText(saveFileDialogCsv.FileName, outPutCsv);
                    break;
                case "Save Files to Zip":
                    contextMenuStrip1.Close();
                    if (saveFileDialogZip.ShowDialog() == DialogResult.OK)
                    {
                        Console.WriteLine(saveFileDialogCsv.FileName);
                        ZipArchive zip = ZipFile.Open(saveFileDialogZip.FileName, ZipArchiveMode.Create);
                        foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                        {
                            String file = ((ParsedReport)row.DataBoundItem).FileName;
                            zip.CreateEntryFromFile(Path.Combine(parsingDir,file), Path.GetFileName(file), CompressionLevel.Optimal);
                        }
                        zip.Dispose();
                    }
                    break;
            }
        }

        private void displayFileInDefaultBrowser(String fileName)
        {
            String HtmlFileNameToDisplay = (Path.GetExtension(fileName) != ".html" ? Path.ChangeExtension(fileName, ".html") : fileName);
            String fullFilePath = Path.Combine(this.parsingDir, HtmlFileNameToDisplay);
            if (File.Exists(fullFilePath))
                System.Diagnostics.Process.Start(fullFilePath);
        }

    }
}
