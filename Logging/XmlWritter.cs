using System.IO;

namespace Logging
{
    /// <summary>
    /// This class writes messages in a file using the XML format and derrives from the AbstractWriter class
    /// </summary>
    class XMLWriter : AbstractWriter
    {
        /// <summary>
        /// The constructor uses the base class initialization logic and adds an initialization for knowing if the file has to be overwritten or not
        /// </summary>
        /// <param name="fileName">Thie file where the messages will be written</param>
        public XMLWriter(string fileName) : base(fileName)
        { }

        /// <summary>
        /// This method writes the message into the file
        /// </summary>
        /// <param name="message"></param>
        public override void WriteMessage(LogMessage message)
        {
            System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(LogMessage));
            using (FileStream file = File.Open(fileName, FileMode.Append))
            {
                writer.Serialize(file, message);
            }
        }
    }
}