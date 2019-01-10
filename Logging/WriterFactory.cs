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
                case WriterTypes.CsvWriter:
                    return new CsvWriter(fileName);
                case WriterTypes.XmlWriter:
                    return new XmlWriter(fileName);
                case WriterTypes.JsonWriter:
                    return new JsonWriter(fileName);
                default:
                    return new CsvWriter(fileName);
            }
               
        }
    }
}
