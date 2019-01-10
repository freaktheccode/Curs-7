using System.IO;
using System.Xml.Serialization;

namespace Logging
{
    /// <summary>
    /// This class writes messages in a file using the CSV format and derrives from the AbstractWriter class
    /// </summary>
    class XmlWriter : AbstractWriter
    {
        private bool isStarted;
        /// <summary>
        /// The constructor uses the base class initialization logic and adds an initialization for knowing if the file has to be overwritten or not
        /// </summary>
        /// <param name="fileName">Thie file where the messages will be written</param>
        public XmlWriter(string fileName) : base(fileName)
        {
            isStarted = false;
        }
 
        public string MessageToXML(LogMessage message)
        {
            var stringwriter = new System.IO.StringWriter();
            var serializer = new XmlSerializer(typeof(LogMessage));
            serializer.Serialize(stringwriter, message);
            return stringwriter.ToString();
        }

        /// <summary>
        /// This method writes the message into the file
        /// </summary>
        /// <param name="message"></param>
        public override void WriteMessage(LogMessage message)
        {
            using (StreamWriter s = new StreamWriter(fileName, isStarted))
            {
                s.WriteLine(MessageToXML(message));
            }
            isStarted = true;
        }
    }
}