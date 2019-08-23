using Parsing_Service.Model;
using Parsing_Service.Parsing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.ServiceModel;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace Parsing_Service.View
{
    public partial class ReportParsingServiceUISingle : Form
    {
        private Boolean startStopButtonState = false;
        private List<String> toDisplayDirectoryList;
        private List<FileSystemWatcher> toWatchDirectories = new List<FileSystemWatcher>();
        private Dictionary<String, DateTime> updatedPairDirTime = new Dictionary<string, DateTime>();

        //JSON 
        private static JavaScriptSerializer jsSerializer = new JavaScriptSerializer();

        //Servizio API push su DB
        private static FCTDEWS.FCTDEWSSoapClient TestWS = new FCTDEWS.FCTDEWSSoapClient();



        public ReportParsingServiceUISingle()
        {
            InitializeComponent();
            Settings.ReadAllSettings();
            if (Settings.PARSING_DIRECTORIES.Count > 0)
                bindListbox();
            textBoxFilters.Text = Settings.FILTER_STRING;
            bindFilesFilterToSettings(textBoxFilters, new EventArgs());
            switch (Settings.PARSING_MODE)
            {
                case 1:
                    radioButton1.Checked = true;
                    break;
                case 2:
                    radioButton2.Checked = true;
                    break;
                case 3:
                    radioButton3.Checked = true;
                    break;
                default:
                    break;
            }

        }

        private void buttonpickDirectory_Click(object sender, EventArgs e)
        {
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                if (!Settings.PARSING_DIRECTORIES.ContainsKey(folderBrowser.SelectedPath))
                {
                    Settings.PARSING_DIRECTORIES.Add(folderBrowser.SelectedPath, new DateTime());
                    bindListbox();
                }
            }
        }
        private void ButtonRemoveDirectory_Click(object sender, EventArgs e)
        {
            if (listBoxDirectoriesList.SelectedIndex >= 0)
            {
                Settings.PARSING_DIRECTORIES.Remove(listBoxDirectoriesList.SelectedItem.ToString());
                bindListbox();
            }

        }

        private void ButtonResetAllDirectories_Click(object sender, EventArgs e)
        {
            Settings.PARSING_DIRECTORIES = new Dictionary<String, DateTime>();
            bindListbox();
        }

        private void ButtonStartStop_Click(object sender, EventArgs e)
        {

            if (this.startStopButtonState)
            {
                stopALL();
            }
            else
            {
                buttonStartStop.Text = "STOP";
                updatedPairDirTime = new Dictionary<string, DateTime>();
                executeParsing();
                this.startStopButtonState = true;
            }
        }

        private void stopALL()
        {
            buttonStartStop.Text = "START";
            parsingBackgroundWorker.CancelAsync();
            stopListenForNewFileInDirectories();
            this.startStopButtonState = false;
        }

        private void executeParsing()
        {
            if (updatedPairDirTime.Count == Settings.PARSING_DIRECTORIES.Count)
            {
                Settings.PARSING_DIRECTORIES = updatedPairDirTime;
                startlistenForNewFileInDirectories();
                return;
            }

            foreach (KeyValuePair<String, DateTime> entry in Settings.PARSING_DIRECTORIES)
            {
                if (!this.updatedPairDirTime.ContainsKey(entry.Key))
                {
                    Console.WriteLine(entry.Key);
                    this.newParsingBackGroundWorker();
                    parsingBackgroundWorker.RunWorkerAsync(entry.Key);
                    return;
                }
            }

        }
        private void ParsingBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            String directory = e.Argument as String;
            DateTime lastParse;
            Settings.PARSING_DIRECTORIES.TryGetValue(directory, out lastParse);

            Parser.setParserConfiguration(directory, Settings.PARSING_MODE, lastParse, Settings.FILTERS, sender as BackgroundWorker);
            e.Result = Parser.parseAll(directory);
        }


        private void ParsingBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar1.Value = e.ProgressPercentage;
            labelTotalParsed.Text = "Parsed: " + Parser.TotalCorrectlyParsed;
            labelTotalErrors.Text = "Parsed Errors: " + Parser.BadFilesList.Count;
            labelParsingProgress.Text = "Parsing Progress :" + e.ProgressPercentage + "%";

        }


        private void ParsingBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                long pushResult = this.pushReports((List<ParsedReport>)e.Result);
                textBoxParsingResultLog.Text = textBoxParsingResultLog.Text + "DIRECTORY PARSING LOG RESULT FOR :" + Environment.NewLine + Parser.CurrentDirectory + Environment.NewLine;
                textBoxParsingResultLog.Text = textBoxParsingResultLog.Text + Parser.getParsingReport();
                textBoxParsingResultLog.Text = textBoxParsingResultLog.Text + "Reports pushed:" + pushResult;
                textBoxParsingResultLog.Text = textBoxParsingResultLog.Text + Environment.NewLine + "------END DIRECTORY PARSING LOG RESULT------" + Environment.NewLine;
                this.updatedPairDirTime.Add(Parser.CurrentDirectory, DateTime.Now);
                executeParsing();
            }
            catch (Exception networkErrorException)
            {
                textBoxParsingResultLog.Text = textBoxParsingResultLog.Text + "Service Offline or Network Unreachable for:" + Environment.NewLine
                    + TestWS.Endpoint.Address + Environment.NewLine + networkErrorException.Message
                    + Environment.NewLine + "Parsing Stopped."
                    + Environment.NewLine;
                stopALL();
                return;
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            Settings.saveAllSettings();
        }

        private void RadioButton_NokiaFormat(object sender, EventArgs e)
        {
            Settings.PARSING_MODE = 1;
        }

        private void RadioButton_NtiFormat(object sender, EventArgs e)
        {
            Settings.PARSING_MODE = 2;
        }


        private void RadioButton_OtherFormat(object sender, EventArgs e)
        {
            Settings.PARSING_MODE = 3;
        }

        private void bindFilesFilterToSettings(object sender, EventArgs e)
        {
            Settings.FILTERS = new List<string>();

            foreach (String filterString in ((TextBox)sender).Text.Split(';'))
            {

                if (filterString != "" && filterString != null)
                    Settings.FILTERS.Add(filterString);
            }
            Settings.FILTER_STRING = ((TextBox)sender).Text;
        }

        private void bindListbox()
        {
            toDisplayDirectoryList = new List<string>();
            foreach (KeyValuePair<String, DateTime> entry in Settings.PARSING_DIRECTORIES)
                toDisplayDirectoryList.Add(entry.Key);

            listBoxDirectoriesList.DataSource = toDisplayDirectoryList;

        }

        private void startlistenForNewFileInDirectories()
        {
            this.toWatchDirectories = new List<FileSystemWatcher>();
            foreach (KeyValuePair<String, DateTime> entry in Settings.PARSING_DIRECTORIES)
            {
                FileSystemWatcher newWatcher = new FileSystemWatcher();
                newWatcher.Path = entry.Key;
                newWatcher.Created += onNewFileInDirectory;
                newWatcher.IncludeSubdirectories = false;
                newWatcher.NotifyFilter = ((System.IO.NotifyFilters)(((System.IO.NotifyFilters.FileName |
                    System.IO.NotifyFilters.LastWrite))));
                newWatcher.SynchronizingObject = this;
                newWatcher.EnableRaisingEvents = true;
                this.toWatchDirectories.Add(newWatcher);
            }
        }

        private void stopListenForNewFileInDirectories()
        {
            foreach (FileSystemWatcher w in this.toWatchDirectories)
            {
                w.EnableRaisingEvents = false;
                w.Dispose();
            }
            this.toWatchDirectories = new List<FileSystemWatcher>();
        }

        private void onNewFileInDirectory(object source, FileSystemEventArgs e)
        {
            long parseOneFeed = 0;
            try
            {
                parseOneFeed = pushReports(Parser.parseOne(e.FullPath));
            }
            catch (Exception networkErrorException)
            {
                textBoxParsingResultLog.Text = textBoxParsingResultLog.Text + "Service Offline or Network Unreachable for:" + Environment.NewLine
                    + TestWS.Endpoint.Address + Environment.NewLine + networkErrorException.Message
                    + Environment.NewLine + "Parsing Stopped."
                    + Environment.NewLine;
                stopALL();
                return;
            }

            textBoxParsingResultLog.Text = textBoxParsingResultLog.Text + Environment.NewLine + "New file detected in dir: " + Path.GetDirectoryName(e.FullPath);

            if (parseOneFeed == 1)
                textBoxParsingResultLog.Text = textBoxParsingResultLog.Text +
                    Environment.NewLine + Path.GetFileName(e.FullPath) + Environment.NewLine + " pushed succesfully!" +
                    Environment.NewLine;
            else if (parseOneFeed == 0)
                textBoxParsingResultLog.Text = textBoxParsingResultLog.Text +
                    Environment.NewLine + "Push failed or file malformed:" + Path.GetFileName(e.FullPath) +
                    Environment.NewLine;

            Settings.PARSING_DIRECTORIES[Path.GetDirectoryName(e.FullPath)] = DateTime.Now;
        }

        private long pushReports(List<ParsedReport> reports)
        {
            long pushResult = 0;

            pushResult = TestWS.UploadFCTDEParsedReport(jsSerializer.Serialize(reports));

            return pushResult;
        }

        private void newParsingBackGroundWorker()
        {
            this.parsingBackgroundWorker = new BackgroundWorker();
            this.parsingBackgroundWorker.WorkerReportsProgress = true;
            this.parsingBackgroundWorker.WorkerSupportsCancellation = true;
            this.parsingBackgroundWorker.DoWork += new DoWorkEventHandler(this.ParsingBackgroundWorker_DoWork);
            this.parsingBackgroundWorker.ProgressChanged += new ProgressChangedEventHandler(this.ParsingBackgroundWorker_ProgressChanged);
            this.parsingBackgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.ParsingBackgroundWorker_RunWorkerCompleted);
        }
    }
}
