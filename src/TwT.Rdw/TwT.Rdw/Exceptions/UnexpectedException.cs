namespace TwT.Rdw.Exceptions
{
    /// <summary>
    /// Exception that was not expected to happen
    /// </summary>
    public class UnexpectedException : RdwException
    {
        /// <inheritdoc cref="HttpException"/>
        /// <param name="message">Message that describes the exception event</param>
        public UnexpectedException(string message) : base(message) { }

        /// <inheritdoc cref="HttpException"/>
        /// <param name="message">Message that describes the exception event</param>
        /// <param name="exception">Exception that was caught</param>
        public UnexpectedException(string message, Exception exception) : base(message, exception) { }
    }
}