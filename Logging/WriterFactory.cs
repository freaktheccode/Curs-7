using System.Xml;

namespace Logging
{
    /// <summary>
    /// This class is used for generating writer instances based on a desired type
    /// </summary>
    public class WriterFactory
    {
        public IWriter GetWriter(WriterTypes type, string fileName)
        {
            switch (type)
            {
                case WriterTypes.CsvWriter: return new CsvWriter(fileName);
                case WriterTypes.XmlWriter: return new XMLWriter(fileName);
                
                default:
                    return new CsvWriter(fileName);
            }
               
        }
    }
}
