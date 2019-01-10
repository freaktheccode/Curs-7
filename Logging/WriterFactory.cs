﻿namespace Logging
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
                case writertypes.csvwriter:
                    return new csvwriter(filename);
                case writertypes.xmlwriter:
                    return new XmlWriter(fileName);
                //case WriterTypes.JsonWriter:
                //    //Implement JSONWriter
                default:
                    return new CsvWriter(fileName);
            }
               
        }
    }
}
