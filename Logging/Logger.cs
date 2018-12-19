using System;
using System.Diagnostics;

namespace Logging
{
    /// <summary>
    /// This class is used for logging messages from anywhere
    /// It uses the Singleton pattern in order to make sure that the same logger instance is used everywhere.
    /// </summary>
    public class Logger
    {
        private static Logger instance;
        private IWriter LogWriter;
        private TraceLevel level;
        private bool isInitialized;
        /// <summary>
        /// Private constructor that can be used only from inside the class
        /// </summary>
        private Logger()
        {
            isInitialized = false;
        }
        /// <summary>
        /// This is the single instance that will be used everywhere 
        /// </summary>
        public static Logger  Instance
        {
            get
            {
                if(instance==null)
                {
                    instance = new Logger();
                }
                return instance;
            }
        }
        /// <summary>
        /// Initializing method 
        /// </summary>
        /// <param name="fileName">The file where the messages will be logged</param>
        /// <param name="level">The level of logging (see System.Diagnostics.TraceLevel enum)</param>
        /// <param name="logType">The format in which the messages will be logged</param>
        public void InitializeLogger(string fileName, TraceLevel level, WriterTypes logType)
        {
            WriterFactory writerFactory = new WriterFactory();
            LogWriter = writerFactory.GetWriter(logType, fileName);
            this.level = level;
            isInitialized = true;            
        }

        public void LogInfoMessage(string message)
        {
            LogMessage(message, TraceLevel.Info);
        }
        public void LogWarningMessage(string message)
        {
            LogMessage(message, TraceLevel.Warning);
        }
        public void LogErrorMessage(string message)
        {
            LogMessage(message, TraceLevel.Error);
        }
        private void LogMessage(string message, TraceLevel level)
        {
            
            if(isInitialized && level<= this.level)
            {
                try
                {
                    LogWriter.WriteMessage(new LogMessage(DateTime.Now, level, message));
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Message write failed:{0}",ex.Message);
                }
            }
            
        }
    }
}
