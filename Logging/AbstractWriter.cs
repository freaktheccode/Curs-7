namespace Logging
{
    /// <summary>
    /// This abstract class represents the base for all the writers and implements common code
    /// </summary>
    abstract class AbstractWriter:IWriter
    {
        protected string fileName;
        /// <summary>
        /// This method contains all the common initializations for the writer classes
        /// </summary>
        /// <param name="fileName">This is the file where the messages will be written</param>
        public AbstractWriter(string fileName)
        {
            this.fileName = fileName;
        }
        /// <summary>
        /// This method will be implemented by every derrived class based on their purpose 
        /// </summary>
        /// <param name="message">The message to be logged</param>
        public abstract void WriteMessage(LogMessage message);
    }
}
