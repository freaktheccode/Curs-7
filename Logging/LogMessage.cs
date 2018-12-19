using System;
using System.Diagnostics;

namespace Logging
{
    /// <summary>
    /// this class molds a Log message
    /// </summary>
    [Serializable]
    public class LogMessage
    {
        public DateTime MessageDate { get; set; }
        public TraceLevel MessageLevel { get; set; }
        public string MessageToLog { get; set; }

        public LogMessage()
        {
            MessageDate = new DateTime();
            MessageLevel = TraceLevel.Info;
            MessageToLog = string.Empty;
        }

        public LogMessage(DateTime messageDate, TraceLevel messageLevel, string messageToLog)
        {
            MessageDate = messageDate;
            MessageLevel = messageLevel;
            MessageToLog = messageToLog;
        }
    }

}
