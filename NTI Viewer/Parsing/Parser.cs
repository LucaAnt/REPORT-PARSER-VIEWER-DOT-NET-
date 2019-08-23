using MSXML;
using Parsing_Service.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml;
using System.Xml.Xsl;


namespace Parsing_Service.Parsing
{
    static class Parser
    {
        //Parsing Options
        private static int _PARSEMODE = 1;
        private static DateTime _LASTPARSE = new DateTime();
        private static List<String> _FilterList = new List<String>();
        private static String MALFORMED_FIELD_PLACEHOLDER_STRING = "MALFORMED";
        private static int MALFORMED_PLACHEHOLDER_NUMERIC = -1;
        private static String _Stylesheet = "report.xsl";

        //Parsing Result feedback
        private static String currentDirectory = "";
        private static BackgroundWorker _bw;
        private static List<String> _badFilesList = new List<string>();
        private static Dictionary<String, int> _badFilesSummary = new Dictionary<String, int>();
        private static int _totalProgress = 0;
        private static int _totalReportFiles = 0;
        private static int _totalCorrectlyParsed = 0;
        private static int _totalSkipped = 0;


        //Parsing Result feed Getter 
        public static List<string> BadFilesList { get => _badFilesList; }
        public static int TotalProgress { get => _totalProgress; }
        public static int TotalReportFiles { get => _totalReportFiles; }
        public static Dictionary<string, int> BadFilesSummary { get => _badFilesSummary; }
        public static int TotalSkipped { get => _totalSkipped; }
        public static int TotalCorrectlyParsed { get => _totalCorrectlyParsed; set => _totalCorrectlyParsed = value; }
        public static string CurrentDirectory { get => currentDirectory; set => currentDirectory = value; }
        public static BackgroundWorker Bw { get => _bw; set => _bw = value; }



        //MAIN EXTERNAL API
        public static void setParserConfiguration(String directory,int mode, DateTime lastParse, List<String> filters,String stylesheet,BackgroundWorker bw)
        {
            reset();
            _PARSEMODE = mode;
            _LASTPARSE = lastParse;
            _FilterList = filters;
            currentDirectory = directory;
            _Stylesheet = stylesheet;
            Bw = bw;
        }

        public static List<ParsedReport> parseOne(String filePath)
        {
            if (containFilterTag(_FilterList, Path.GetFileName(filePath)))
                return new List<ParsedReport>();

            //Aspetta che il file appena creato venga rilasciato
            bool fileIsBusy = true;
            FileStream file;
            while (!fileIsBusy)
            {
                try
                {
                    file = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                    fileIsBusy = false;
                    file.Close();
                }
                catch (IOException)
                {
                    Thread.Sleep(2000);
                }
            }

            Thread.Sleep(500);
            List<ParsedReport> toRetReport = new List<ParsedReport>();
            toRetReport.Add(parseHeader(filePath));
            return toRetReport;
        }

        public static List<ParsedReport> parseAll(String dirPath)
        {
            List<ParsedReport> parsedReportList = new List<ParsedReport>();

            int fileCounter = 1, fileCount = Directory.GetFiles(dirPath).Length;
            _totalReportFiles = Directory.GetFiles(dirPath).Length;


            foreach (string fileName in Directory.GetFiles(dirPath))
            {
                if ((Path.GetExtension(fileName).CompareTo(".html") == 0) && (File.Exists(Path.ChangeExtension(fileName, ".xml"))))
                {
                    _totalSkipped++;
                    fileCounter++;
                    continue;
                }
                _totalProgress = (int)((float)fileCounter / fileCount * 100);
                if (File.GetLastWriteTimeUtc(fileName).CompareTo(_LASTPARSE) > 0 && !containFilterTag(_FilterList, Path.GetFileName(fileName)))
                {
                    
                    Console.WriteLine(string.Format("Parsing {0}%: " + fileName, _totalProgress) + Environment.NewLine);
                    
                    try
                    {
                        ParsedReport paTmp = parseHeader(fileName);
                        parsedReportList.Add(paTmp);
                        _totalCorrectlyParsed++;
                        Console.WriteLine(paTmp);
                    }
                    catch (Exception e)
                    {
                        String extension = Path.GetExtension(fileName);
                        _badFilesList.Add(Path.GetFileName(fileName));

                        if (_badFilesSummary.ContainsKey(extension))
                        {
                            int value;
                            _badFilesSummary.TryGetValue(extension, out value);
                            _badFilesSummary.Remove(extension);
                            value++;
                            _badFilesSummary.Add(extension, value);
                        }
                        else
                        {
                            _badFilesSummary.Add(extension, 1);
                        }
                    }
                }
                else
                    _totalSkipped++;

                fileCounter++;
                Bw.ReportProgress(_totalProgress);
                if (Bw.CancellationPending)
                    Thread.CurrentThread.Abort();
            }

            return parsedReportList;
        }

        private static ParsedReport parseHeader(String filePath)
        {
            ParsedReport toReturnParsedReport = null;

            switch (_PARSEMODE)
            {
                //Nokia format
                case 1:
                    toReturnParsedReport = nokiaFormat(filePath);
                    break;
                //NTI format
                case 2:
                    toReturnParsedReport = ntiFormat(filePath);
                    if ((Path.GetExtension(filePath) == ".xml") && (!File.Exists(Path.ChangeExtension(filePath, ".html"))))
                        Parser.TransformXMLToHTML(filePath);
                    break;
                default:
                    break;
            }
            return toReturnParsedReport;
        }

        //PARSING LOGIC

        //NOKIA HEADER PARSE
        private static ParsedReport nokiaFormat(string filePath)
        {
            ParsedReport newReport = new ParsedReport();
            string htmlText = File.ReadAllText(filePath, Encoding.Default);
            string HtmlHeaderText = extractHeader(htmlText);
            const string dateFormatterStringNokiaItFormat = "d MMMM yyyy H:mm:ss";
            const string dateFormatterStringNokiaEnFormat = "MMMM d, yyyy h:mm:ss tt";

            //FILE NAME
            newReport.FileName = Path.GetFileName(filePath);

            //STATION ID
            newReport.StationID = extractField(HtmlHeaderText, "Station ID: </B><TD><B>");

            //STATION NAME
            if (HtmlHeaderText.Contains("Station Name:</B><TD><B>"))
                newReport.StationName = extractField(HtmlHeaderText, "Station Name:</B><TD><B>");
            else
                newReport.StationName = "Not present";

            //ALU Part Number
            newReport.ALUPartNumber = extractField(HtmlHeaderText, "ALU Part Number:</B><TD><B>");

            //Operation Name
            if (HtmlHeaderText.Contains("Operation</B><TD><B>"))
                newReport.OperationName = extractField(HtmlHeaderText, "Operation</B><TD><B>");
            else if (HtmlHeaderText.Contains("Operation Name:</B><TD><B>"))
                newReport.OperationName = extractField(HtmlHeaderText, "Operation Name:</B><TD><B>");
            else
                newReport.OperationName = "Not present";

            //SERIAL
            newReport.SerialNumber = extractField(HtmlHeaderText, "Serial Number: </B><TD><B>");

            //OPERATOR
            newReport.OperatorName = extractField(HtmlHeaderText, "Operator: </B><TD><B>");

            //NUMBER OF RESULTS
            if (int.TryParse(extractField(HtmlHeaderText, "Number of Results: </B><TD><B>").Trim(), out int nos))
            {
                newReport.NumberOfResults = nos;
            }
            else
            {
                //Console.WriteLine("NUMBER OF RESULTS String could not be parsed.");
                newReport.NumberOfResults = MALFORMED_PLACHEHOLDER_NUMERIC;
            }
            //TEST SEQUENCE FINAL RESULT
            newReport.UUTResult = extractField(HtmlHeaderText, "UUT Result: </B><TD><B>").Split('>')[1].Split('<')[0].Trim();

            //EXECUTION TIME SECONDS
            if (int.TryParse(extractField(HtmlHeaderText, "Execution Time: </B><TD><B>").Split('.')[0].Trim(), out int ext))
            {
                newReport.ExecutionTime = ext;
            }
            else
            {
                Console.WriteLine("EXECUTION TIME String could not be parsed.");
                newReport.ExecutionTime = MALFORMED_PLACHEHOLDER_NUMERIC;
            }

            //PARSING START DATE TIME & END DATE TIME
            string extractedStringDate = "";
            string extractedStringTime = "";
            string toParseDateTime = "";
            try
            {
                extractedStringDate = extractField(HtmlHeaderText, "Date: </B><TD><B>");
                extractedStringDate = extractedStringDate.Substring(extractedStringDate.IndexOf(" ")).Trim();
                extractedStringTime = extractField(HtmlHeaderText, "Time: </B><TD><B>");
                toParseDateTime = (extractedStringDate + " " + extractedStringTime).Trim().ToLowerInvariant();


                if (isDateEnFormat(toParseDateTime))//En Format
                {
                    //Console.WriteLine("en format");
                    System.Globalization.CultureInfo cultureinfo = new System.Globalization.CultureInfo("en-US");
                    newReport.DateTimeStart = DateTime.ParseExact(toParseDateTime, dateFormatterStringNokiaEnFormat, System.Globalization.CultureInfo.InvariantCulture);
                }
                else //Italian format
                {
                    System.Globalization.CultureInfo cultureinfo = new System.Globalization.CultureInfo("it-IT");
                    if (toParseDateTime.Contains(":"))//Italian format 1
                    {
                        //Console.WriteLine("Italian format 1: :");
                    }
                    else if (toParseDateTime.Contains("."))//Italian format 2
                    {
                        //Console.WriteLine("Italian format 1: .");
                        toParseDateTime = toParseDateTime.Replace('.', ':');
                    }
                    //Console.WriteLine(toParseDateTime);
                    //Console.WriteLine(dateFormatterStringNokiaItFormat);
                    newReport.DateTimeStart = DateTime.ParseExact(toParseDateTime, dateFormatterStringNokiaItFormat, cultureinfo);
                }

                newReport.DateTimeEnd = newReport.DateTimeStart.AddSeconds(newReport.ExecutionTime);
            }
            catch (Exception e)
            {
                newReport.DateTimeStart = new DateTime(0, 0, 0, 0, 0, 0);
                Console.Out.WriteLine("Date Parsing Error :" + filePath);
            }

            return newReport;
        }

        //NTI HEADER PARSE
        private static ParsedReport ntiFormat(string filePath)
        {
            ParsedReport newReport = new ParsedReport();
            string htmlText = File.ReadAllText(filePath, Encoding.Default);
            string HtmlHeaderText = "";
            string fileType = Path.GetExtension(filePath);
            XmlDocument xmlDoc = new XmlDocument();


            //Taglia la parte malformata dell'html per il parsing xpath
            if (fileType.Equals(".html"))
                HtmlHeaderText = extractHeader(htmlText);
            else if ((fileType.Equals(".xml")))
                HtmlHeaderText = htmlText;



            xmlDoc.LoadXml(HtmlHeaderText);

            //Stringhe Query Xpath XML/HTML
            String xpathStationId = (fileType == ".xml" ? "//Prop[@Name='StationID']/Value" : "(/table/tbody/tr/td[@class='hdr_value']/b)[1]");
            String xpathTestSocketIndex = (fileType == ".xml" ? "//Prop[@Name='TestSocketIndex']/Value" : "(/table/tbody/tr/td[@class='hdr_value']/b)[2]");
            String xpathSerial = (fileType == ".xml" ? "//Prop[@Name='SerialNumber']/Value" : "(/table/tbody/tr/td[@class='hdr_value']/b)[3]");
            String xpathOperator = (fileType == ".xml" ? "//Prop[@Name='LoginName']/Value" : "(/table/tbody/tr/td[@class='hdr_value']/b)[6]");
            String xpathNumberOfResults = (fileType == ".xml" ? "//Report[@Type='UUT']/@StepCount" : "(/table/tbody/tr/td[@class='hdr_value']/b)[8]/text()");
            String xpathFinalResult = (fileType == ".xml" ? "//Report[@Type='UUT']/@UUTResult" : "(/table/tbody/tr/td[@class='hdr_value']/b/span)[1]/text()");
            String xpathExecutionTime = (fileType == ".xml" ? "//Reports/Report/Prop[@Type='TEResult']/Prop[@Name='TS']/Prop[@Name='TotalTime']/Value" : "(/table/tbody/tr/td[@class='hdr_value']/b)[7]");
            String xpathStartDate = (fileType == ".xml" ? "//Prop[@Name='StartDate']/Prop[@Name='ShortText']/Value" : "(/table/tbody/tr/td[@class='hdr_value']/b)[4]");
            String xpathStartTime = (fileType == ".xml" ? "//Prop[@ Name='StartTime']/Prop[@Name='Text']/Value" : "(/table/tbody/tr/td[@class='hdr_value']/b)[5]");
            String dateFormatterString = (fileType == ".xml" ? "M/d/yyyy h:m:s tt" : "MMMM d, yyyy h:m:s tt");

            //File Name
            newReport.FileName = Path.GetFileName(filePath);

            //Operation Name
            newReport.OperationName = "Not Present";

            //Station Name
            newReport.StationName = "Not Present";


            //ALU PART NUMBER
            newReport.ALUPartNumber = Path.GetFileName(filePath).Split('[')[0].Trim();

            //STATION ID
            try
            {
                var node = xmlDoc.SelectNodes(xpathStationId);
                newReport.StationID = node.Item(0).InnerText.Trim();
            }
            catch (Exception e)
            {
                Console.WriteLine("Errore Parsing Station ID");
                newReport.StationID = MALFORMED_FIELD_PLACEHOLDER_STRING;
            }

            //SERIAL
            try
            {
                var node = xmlDoc.SelectNodes(xpathSerial);
                newReport.SerialNumber = node.Item(0).InnerText.Trim();
            }
            catch (Exception e)
            {
                Console.WriteLine("Errore Parsing SERIAL");
                newReport.SerialNumber = MALFORMED_FIELD_PLACEHOLDER_STRING;
            }

            //OPERATOR
            try
            {
                var node = xmlDoc.SelectNodes(xpathOperator);
                newReport.OperatorName = node.Item(0).InnerText.Trim();
            }
            catch (Exception e)
            {
                Console.WriteLine("Errore Parsing OPERATOR");
                newReport.OperatorName = MALFORMED_FIELD_PLACEHOLDER_STRING;
            }

            //NUMBER OF RESULTS 
            try
            {
                var node = xmlDoc.SelectNodes(xpathNumberOfResults);
                newReport.NumberOfResults = Int32.Parse(node.Item(0).InnerText.Trim());
            }
            catch (Exception e)
            {
                Console.WriteLine("Errore Parsing NUMBER OF RESULTS");
                newReport.NumberOfResults = MALFORMED_PLACHEHOLDER_NUMERIC;
            }

            //TEST SEQUENCE FINAL RESULT
            try
            {
                var node = xmlDoc.SelectNodes(xpathFinalResult);
                newReport.UUTResult = node.Item(0).InnerText.Trim();

            }
            catch (Exception e)
            {
                Console.WriteLine("Errore Parsing UUT Final Result");
                newReport.UUTResult = MALFORMED_FIELD_PLACEHOLDER_STRING;
            }

            //PARSING START TIME E TEST DURATION SECONDS

            //TOTAL TEST EXECUTION SECONDS

            try
            {
                var node = xmlDoc.SelectNodes(xpathExecutionTime);
                newReport.ExecutionTime = Int32.Parse(node.Item(0).InnerText.Trim().Split('.')[0]);
            }
            catch (Exception e)
            {
                Console.WriteLine("Errore Parsing TEST EXECUTION SECONDS");
                newReport.ExecutionTime = MALFORMED_PLACHEHOLDER_NUMERIC;
            }


            //START DATE TIME & END DATE TIME
            System.Globalization.CultureInfo cultureinfo = new System.Globalization.CultureInfo("en-US");
            String timeText, dateText, timeToParse;
            try
            {
                var node = xmlDoc.SelectNodes(xpathStartDate);
                dateText = node.Item(0).InnerText.Trim();

                if (fileType.Equals(".html"))
                    dateText = dateText.Substring(dateText.IndexOf(",") + 2);

                node = xmlDoc.SelectNodes(xpathStartTime);
                timeText = node.Item(0).InnerText.Trim();

                timeToParse = dateText + " " + timeText;

                newReport.DateTimeStart = DateTime.ParseExact(timeToParse, dateFormatterString, System.Globalization.CultureInfo.InvariantCulture);


                newReport.DateTimeEnd = newReport.DateTimeStart.AddSeconds(newReport.ExecutionTime);

            }
            catch (Exception e)
            {
                Console.WriteLine("Errore Parsing START DATE TIME ");
                newReport.DateTimeStart = new DateTime();
                newReport.DateTimeEnd = new DateTime();
            }

            return newReport;
        }

        //Utility Functions 
        private static string extractHeader(string htmlText)
        {
            int cutStart;
            int cutEnd;
            if (htmlText.Contains("<TABLE"))
            {
                cutStart = htmlText.IndexOf("<TABLE");
                cutEnd = htmlText.IndexOf("</TABLE>") + 8;
                return htmlText.Substring(cutStart, cutEnd - cutStart);
            }
            else if (htmlText.Contains("<table"))
            {
                cutStart = htmlText.IndexOf("<table");
                cutEnd = htmlText.IndexOf("</table>") + 8;
                return htmlText.Substring(cutStart, cutEnd - cutStart);
            }

            return "MALFORMED";
        }

        private static string extractField(string htmlText, string toSearchString)
        {
            int start = htmlText.IndexOf(toSearchString) + toSearchString.Length;
            int size = htmlText.Substring(start).IndexOf("</B>");
            return htmlText.Substring(start, size);
        }

        private static bool isDateEnFormat(string dateString)
        {
            return Regex.IsMatch(dateString.ToLower(), @"\b" + "am" + "\\b") || Regex.IsMatch(dateString.ToLower(), @"\b" + "pm" + "\\b"); ;
        }
        private static Boolean containFilterTag(List<String> filteredTags, String fileName)
        {
            if (filteredTags != null)
                foreach (String s in filteredTags)
                    if (fileName.Contains(s))
                        return true;
            return false;
        }

        public static String getParsingReport()
        {
            String badFilesList = "";
            String badFilesDetails = "";
            foreach (KeyValuePair<String, int> entry in _badFilesSummary)
                badFilesDetails += entry.Key + ":" + entry.Value + Environment.NewLine;
            foreach (String entry in _badFilesList)
                badFilesList += entry + Environment.NewLine;
            return
                Environment.NewLine + "Total Files:" + _totalReportFiles +
                Environment.NewLine + "Correctly Parsed files:" + _totalCorrectlyParsed +
                Environment.NewLine + "Skipped files:" + _totalSkipped +
                Environment.NewLine + "Total Bad Files:" + _badFilesList.Count +
                Environment.NewLine + "Bad Files:" + Environment.NewLine + badFilesList +
                Environment.NewLine + "Bad Files Summary:" + Environment.NewLine + badFilesDetails;
        }

        private static void reset()
        {
            _badFilesList = new List<string>();
            _badFilesSummary = new Dictionary<String, int>();
            _totalProgress = 0;
            _totalReportFiles = 0;
            _totalCorrectlyParsed = 0;
            _totalSkipped = 0;
        }

        private static void TransformXMLToHTML(string XmlPath)
        {

            Assembly assembly = Assembly.GetExecutingAssembly();
            DOMDocument xml = new DOMDocument();
            xml.load(XmlPath);

            DOMDocument xslt = new DOMDocument();
            StreamReader streamReader = new StreamReader(assembly.GetManifestResourceStream("NTI_Viewer.Resources."+ _Stylesheet), Encoding.Default);
            string embeddedXSLT = streamReader.ReadToEnd();
            xslt.loadXML(embeddedXSLT);
            File.WriteAllText(Path.ChangeExtension(XmlPath, ".html"), xml.transformNode(xslt)); ;

        }

    }
}
