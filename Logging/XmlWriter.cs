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
        /// <summary>
        /// This method transforms a message object into a comma separated string
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private string MessageToXml(LogMessage message)
        {
            XmlSerializer mySerializer = new XmlSerializer(typeof(LogMessage));
            using (var sw = new StringWriter())
            {
                mySerializer.Serialize(sw, message);
                return sw.ToString();
            }

            return string.Empty;


        }
        /// <summary>
        /// This method writes the message into the file
        /// </summary>
        /// <param name="message"></param>
        public override void WriteMessage(LogMessage message)
        {
            using (StreamWriter s = new StreamWriter(fileName, isStarted))
            {
                s.WriteLine(MessageToXml(message));
            }
            isStarted = true;
        }
    }



       
}

