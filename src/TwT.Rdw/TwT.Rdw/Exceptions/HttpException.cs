namespace TwT.Rdw.Exceptions
{
    /// <summary>
    /// Exception related to HTTP requests
    /// </summary>
    public class HttpException : RdwException
    {
        /// <inheritdoc cref="HttpException"/>
        /// <param name="message">Message that describes the exception event</param>
        /// <param name="exception">Exception from the HTTP Client</param>
        public HttpException(string message, Exception exception) : base(message, exception) { }
    }
}