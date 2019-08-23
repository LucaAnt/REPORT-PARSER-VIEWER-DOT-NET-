using Parsing_Service.Model;
using System;
using System.Collections.Generic;

namespace NTI_Viewer
{
    static class FilterUtil
    {
        public static List<ParsedReport> Filter(List<ParsedReport> reports, List<String> UUTResultListtoDisplay, String filterField, String filterTuning, String filteredValue)
        {
            List<ParsedReport> fileteredReports = new List<ParsedReport>();

            foreach (ParsedReport report in reports)
            {

                if (!UUTResultListtoDisplay.Contains(report.UUTResult))
                    continue;

                if (filteredValue != "")
                    switch (filterField)
                    {
                        case "Station":
                                if(CompareStringField(report.StationID, filteredValue, filterTuning))
                                    fileteredReports.Add(report);
                            break;
                        case "Operator":
                            if (CompareStringField(report.OperatorName, filteredValue, filterTuning))
                                fileteredReports.Add(report);
                            break;
                        case "Serial":
                            if (CompareStringField(report.SerialNumber, filteredValue, filterTuning))
                                fileteredReports.Add(report);
                            break;
                        case "Execution Time":
                            if (CompareNumberField(report.ExecutionTime,Int32.Parse(filteredValue), filterTuning))
                                fileteredReports.Add(report);
                            break;
                        case "Number of Results":
                            if (CompareNumberField(report.NumberOfResults, Int32.Parse(filteredValue), filterTuning))
                                fileteredReports.Add(report);
                            break;
                        default:
                            break;
                    }
                else
                    fileteredReports.Add(report);

            }
            return fileteredReports;
        }

        public static List<ParsedReport> Filter(List<ParsedReport> reports, List<String> UUTResultListtoDisplay, String filterField, String filterTuning, String filteredValue,DateTime start,DateTime end)
        {
            List<ParsedReport> fileteredReports = new List<ParsedReport>();
            foreach (ParsedReport report in reports)
                if ((report.DateTimeStart.CompareTo(start) > 0) && (report.DateTimeStart.CompareTo(end) < 0))
                    fileteredReports.Add(report);

            return FilterUtil.Filter(fileteredReports, UUTResultListtoDisplay, filterField, filterTuning, filteredValue) ;
        }

        private static bool CompareStringField(String reportValue, String toCompareValue, String filterTune)
        {
            switch (filterTune)
            {
                case "=":
                    return reportValue.CompareTo(toCompareValue) == 0;
                    break;
                case "<":
                    return reportValue.CompareTo(toCompareValue) < 0;
                    break;
                case ">":
                    return reportValue.CompareTo(toCompareValue) > 0;
                    break;
                case "contain":
                    return reportValue.Contains(toCompareValue);
                    break;
                default:
                    break;
            }
            return false;
        }

        private static bool CompareNumberField(int reportValue, int toCompareValue, String filterTune)
        {
            switch (filterTune)
            {
                case "=":
                    return reportValue == toCompareValue;
                    break;
                case "<":
                    return reportValue < toCompareValue;
                    break;
                case ">":
                    return reportValue > toCompareValue;
                    break;
                case "contain":
                    return reportValue == toCompareValue;
                    break;
                default:
                    break;
            }
            return false;
        }

    }

}
