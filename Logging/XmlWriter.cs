using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Logging
{
    class XmlWriter : AbstractWriter
    {
        private bool isStarted;

        public XmlWriter(string fileName) : base(fileName)
        {
            isStarted = false;
        }

        private string MessageToXml(LogMessage myMessage)
        {
            XmlSerializer serial = new XmlSerializer(typeof(LogMessage));
            // XmlElement myXmlElement = new XmlDocument().CreateElement("myXmlElement", "ns");
            // myXmlElement

            // serial.Serialize(/*myMessage.MessageLevel.ToString(), myMessage.MessageToLog*/);
            var xml = "";
            using (var sww = new StringWriter())
            {
                using (XmlTextWriter writer = new XmlTextWriter(sww) { Formatting = Formatting.Indented })
                {
                    serial.Serialize(writer, myMessage);
                    xml = sww.ToString(); // Your XML
                }
            }
            return xml;
        }

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
