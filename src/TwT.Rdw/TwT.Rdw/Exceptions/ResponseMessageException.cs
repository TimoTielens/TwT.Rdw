namespace TwT.Rdw.Exceptions
{
    /// <summary>
    /// Exception related to the response message coming from the RDW
    /// </summary>
    public class ResponseMessageException : RdwException
    {
        /// <inheritdoc cref="HttpException"/>
        /// <param name="message">Message that describes the exception event</param>
        /// <param name="exception">Exception from Newtonsoft</param>
        public ResponseMessageException(string message, Exception exception) : base(message, exception) { }
    }
}