using System;
using System.Web.Script.Serialization;

namespace Parsing_Service.Model

{
    class ParsedReport
    {
        String fileName;
        String stationID;
        String stationName;
        String aluPartNumber;
        String operationName;
        String serialNumber;
        DateTime dateTimeStart;
        DateTime dateTimeEnd;
        String operatorName;
        int executionTime;
        int numberOfResults;
        String uutResult;

        public ParsedReport() : base()
        {
        }

        public ParsedReport(string fileName, string stationID, string stationName, string aLUPartNumber, string operationName, string serialNumber, DateTime dateTimeStart, DateTime dateTimeEnd, string operatorName, int executionTime, int numberOfResults, string uUTResult)
        {
            this.fileName = fileName;
            StationID = stationID;
            this.stationName = stationName;
            ALUPartNumber = aLUPartNumber;
            OperationName = operationName;
            this.serialNumber = serialNumber;
            this.dateTimeStart = dateTimeStart;
            this.dateTimeEnd = dateTimeEnd;
            this.operatorName = operatorName;
            this.executionTime = executionTime;
            this.numberOfResults = numberOfResults;
            UUTResult = uUTResult;
        }

        public string FileName { get => fileName; set => fileName = value; }
        public string StationID { get => stationID; set => stationID = value; }
        public string StationName { get => stationName; set => stationName = value; }
        public string ALUPartNumber { get => aluPartNumber; set => aluPartNumber = value; }
        public string OperationName { get => operationName; set => operationName = value; }
        public string SerialNumber { get => serialNumber; set => serialNumber = value; }
        public DateTime DateTimeStart { get => dateTimeStart; set => dateTimeStart = value; }
        public DateTime DateTimeEnd { get =>  dateTimeEnd; set => dateTimeEnd = value; }
        public string OperatorName { get => operatorName; set => operatorName = value; }
        public int ExecutionTime { get => executionTime; set => executionTime = value; }
        public int NumberOfResults { get => numberOfResults; set => numberOfResults = value; }
        public string UUTResult { get => uutResult; set => uutResult = value; }

        public override bool Equals(object obj)
        {
            return this.fileName ==((ParsedReport)obj).fileName;
        }

        public string toJson()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Serialize(this);
        }

        public override string ToString()
        {
            return "fileName:" + fileName + "\r\nStationID:" + StationID + "\r\nstationName:" + stationName + "\r\naluPartNumber:" + aluPartNumber + "\r\noperationName:" + operationName + "\nserialNumber:" + serialNumber + "\r\ndateTimeStart:" + dateTimeStart + "\r\ndateTimeEnd:" + dateTimeEnd + "\r\noperatorName:" + operatorName + "\r\nexecutionTime:" + executionTime + "\r\nnumberOfResults:" + numberOfResults + "\r\nUUTResult:" + UUTResult + "\r\n";
        }
    }
}
