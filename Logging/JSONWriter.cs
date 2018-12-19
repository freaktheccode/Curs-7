using Newtonsoft.Json;
using System.IO;

namespace Logging
{
    /// <summary>
    /// This class writes messages in a file using the JSON format and derrives from the AbstractWriter class
    /// </summary>
    internal class JSONWriter : AbstractWriter
    {
        /// <summary>
        /// The constructor uses the base class initialization logic and adds an initialization for knowing if the file has to be overwritten or not
        /// </summary>
        /// <param name="fileName">Thie file where the messages will be written</param>
        public JSONWriter(string fileName) : base(fileName)
        { }

        /// <summary>
        /// This method writes the message into the file
        /// </summary>
        /// <param name="message"></param>
        public override void WriteMessage(LogMessage message)
        {
            string output = JsonConvert.SerializeObject(message);
            using (StreamWriter s = new StreamWriter(fileName, true))
            {
                s.WriteLine(output);
            }
        }
    }
}
