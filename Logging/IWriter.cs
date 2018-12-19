namespace Logging
{
    /// <summary>
    /// This interface has to be implemented by all the writers and declares the functionality that will be exposed by them
    /// </summary>
    public interface IWriter
    {
        void WriteMessage(LogMessage message);
    }
}
