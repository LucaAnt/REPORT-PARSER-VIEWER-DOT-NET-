using Parsing_Service.Model;
using System;
using System.Collections.Generic;

namespace NTI_Viewer
{
    class StatsUtil
    {
        private int _total = 0, _passed = 0, _failed = 0, _terminated = 0, _error = 0;
        private float _yeld = 0, _passYeld = 0, _firstPassYeldPassedFailed = 0, _firstPassYeldPassedFailedErrorTerminated = 0, _avarangeTestingTime = 0, _capability = 0;
        private List<FpyMonthChartEntry> _FpyPFMonthlyChart;

        public StatsUtil(List<ParsedReport> list)
        {
            calcStats(list);
        }

        public int Total { get => _total; }
        public int Passed { get => _passed; }
        public int Failed { get => _failed; }
        public int Terminated { get => _terminated; }
        public int Error { get => _error; }
        public float Yeld { get => _yeld; }
        public float PassYeld { get => _passYeld; }
        public float FirstPassYeldPassedFailed { get => _firstPassYeldPassedFailed; }
        public float FirstPassYeldPassedFailedErrorTerminated { get => _firstPassYeldPassedFailedErrorTerminated; }
        public float AvarangeTestingTime { get => _avarangeTestingTime; }
        public float Capability { get => _capability; }
        internal List<FpyMonthChartEntry> FpyPFMonthlyChart { get => _FpyPFMonthlyChart;}

        private void calcStats(List<ParsedReport> list)
        {

            int totalValidTested = 0;
            Dictionary<string, ParsedReport> fpyDic = new Dictionary<string, ParsedReport>();
            Dictionary<string, ParsedReport> fpyDicPfet = new Dictionary<string, ParsedReport>();
            foreach (ParsedReport report in list)
            {
                _total++;
                switch (report.UUTResult.ToLower().Trim())
                {
                    case "passed":
                        _passed++;
                        _avarangeTestingTime += report.ExecutionTime;
                        break;
                    case "failed":
                        _failed++;
                        _avarangeTestingTime += report.ExecutionTime;
                        break;
                    case "terminated":
                        _terminated++;
                        _avarangeTestingTime += report.ExecutionTime;
                        break;
                    case "error":
                        _error++;
                        break;
                    default:
                        break;
                }
            }
            totalValidTested = _passed + _failed + _terminated;
            _avarangeTestingTime /= totalValidTested;
            _passYeld = (float)_passed / (float)totalValidTested;
            _yeld = (float)_failed / (float)totalValidTested;
            calculateFpyOnReports(list, ref _firstPassYeldPassedFailed, ref _firstPassYeldPassedFailedErrorTerminated);
            _FpyPFMonthlyChart = getMonthlyFpyArray(list);
        }

        private void calculateFpyOnReports(List<ParsedReport> reports,ref float FPY_PF,ref float FPY_PFET)
        {
            FPY_PF = 0;
            FPY_PFET = 0;
            Dictionary<string, ParsedReport> fpyDic = new Dictionary<string, ParsedReport>();
            Dictionary<string, ParsedReport> fpyDicPfet = new Dictionary<string, ParsedReport>();
            foreach (ParsedReport report in reports)
            {
                switch (report.UUTResult.ToLower().Trim())
                {
                    case "passed":
                        fpyCompare(report, ref fpyDic);
                        break;
                    case "failed":
                        fpyCompare(report, ref fpyDic);
                        break;

                    default:
                        break;
                }
                fpyCompare(report, ref fpyDicPfet);
            }
            foreach (KeyValuePair<String, ParsedReport> pair in fpyDic)
                if (pair.Value.UUTResult.ToLower().Trim().CompareTo("passed") == 0)
                    FPY_PF++;

            foreach (KeyValuePair<String, ParsedReport> pair in fpyDicPfet)
                if (pair.Value.UUTResult.ToLower().Trim().CompareTo("passed") == 0)
                    FPY_PFET++;

            if (FPY_PF != 0)
                FPY_PF /= fpyDic.Count;
            if (FPY_PFET != 0)
                FPY_PFET /= fpyDicPfet.Count;
        }

        private void fpyCompare(ParsedReport report, ref Dictionary<string, ParsedReport> fpyDic)
        {
            ParsedReport tmpReport;
            if (fpyDic.ContainsKey(report.SerialNumber))
            {
                fpyDic.TryGetValue(report.SerialNumber, out tmpReport);
                if (tmpReport.DateTimeStart.CompareTo(report.DateTimeStart) > 0)
                {
                    fpyDic.Remove(report.SerialNumber);
                    fpyDic.Add(report.SerialNumber, report);
                }
            }
            else
                fpyDic.Add(report.SerialNumber, report);
        }

        private List<FpyMonthChartEntry> getMonthlyFpyArray(List<ParsedReport> reports)
        {
            List < FpyMonthChartEntry > toDrawChartArray = new List<FpyMonthChartEntry>();
            if (reports.Count < 1)
                return toDrawChartArray;

            int minYear = reports[0].DateTimeStart.Year, maxYear = reports[0].DateTimeStart.Year;
            int minMonth, MaxMonth;
            List<ParsedReport> reportsbyYear;
            reports.ForEach((report) =>
            {
                if (report.DateTimeStart.Year < minYear)
                    minYear = report.DateTimeStart.Year;
                if (report.DateTimeStart.Year > maxYear)
                    maxYear = report.DateTimeStart.Year;
            });

            reportsbyYear = getReportsByYear(reports, minYear);
            minMonth = reportsbyYear[0].DateTimeStart.Month;
            foreach (ParsedReport report in reportsbyYear)
                if (report.DateTimeStart.Month < minMonth)
                    minMonth = report.DateTimeStart.Month;

            reportsbyYear = getReportsByYear(reports, maxYear);
            MaxMonth = reportsbyYear[0].DateTimeStart.Month;
            foreach (ParsedReport report in reportsbyYear)
                if (report.DateTimeStart.Month > MaxMonth)
                    MaxMonth = report.DateTimeStart.Month;

            for(int year=minYear;year<=maxYear;year++)
            {
                int endMonth = (year == maxYear ? MaxMonth : 12);
                int startMonth = (year == minYear ? minMonth : 1);
                for(int month = startMonth; month <= endMonth; month++)
                {
                    float monthlyFpyPF=0, monthlyFpyPFTE=0;
                    calculateFpyOnReports(getReportsByYearAndMonth(reports, year, month), ref monthlyFpyPF, ref monthlyFpyPFTE);
                    toDrawChartArray.Add(new FpyMonthChartEntry(month+"/"+year, monthlyFpyPF, monthlyFpyPFTE));
                }
            }

            return toDrawChartArray;
        }

        private List<ParsedReport> getReportsByYear(List<ParsedReport> reports, int year)
        {
            return reports.FindAll((report) => { return report.DateTimeStart.Year == year; });
        }

        private List<ParsedReport> getReportsByMonth(List<ParsedReport> reports, int Month)
        {
            return reports.FindAll((report) => { return report.DateTimeStart.Month == Month; });
        }

        private List<ParsedReport> getReportsByYearAndMonth(List<ParsedReport> reports, int year, int Month)
        {
            return reports.FindAll((report) => { return (report.DateTimeStart.Year == year) && (report.DateTimeStart.Month == Month); });
        }


        public class FpyMonthChartEntry
        {
            private string _YearMonth = "";
            private float _fpyValue = 0;
            private float _fpyValuePFTE = 0;
            public string YearMonth { get => _YearMonth; set => _YearMonth = value; }
            public float FPY { get => _fpyValue; set => _fpyValue = value; }
            public float FPYPFTE { get => _fpyValuePFTE; set => _fpyValuePFTE = value; }

            public FpyMonthChartEntry(String YM,float fpypf, float fpypfte)
            {
                _YearMonth = YM;
                _fpyValue = fpypf;
                _fpyValuePFTE = fpypfte;
            }

        }

    }
}
