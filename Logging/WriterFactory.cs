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
                    //Implement XMLWriter
                //case WriterTypes.JsonWriter:
                //    //Implement JSONWriter
                default:
                    return new CsvWriter(fileName);
            }
               
        }
    }
}
