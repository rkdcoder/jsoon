namespace Jsoon
{
    /// <summary>
    /// Exception thrown when JSON serialization or deserialization fails.
    /// </summary>
    public class JsonSerializerException : Exception
    {
        public JsonSerializerException(string message, Exception? inner = null)
            : base(message, inner) { }
    }
}