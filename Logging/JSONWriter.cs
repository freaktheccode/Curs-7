using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging
{
    internal class JSONWriter : AbstractWriter
    {
        private bool isStarted = false;
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
                if (!isStarted) {
                    sw
                }
                else
                {
                    s.WriteLine(output);

                }
            }

            isStarted = true;
        }
    }
}
