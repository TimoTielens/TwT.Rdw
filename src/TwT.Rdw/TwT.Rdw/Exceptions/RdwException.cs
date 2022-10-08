namespace TwT.Rdw.Exceptions
{
    /// <summary>
    /// BaseException that defines a message coming from the the RDW DLL
    /// </summary>
    public class RdwException : Exception
    {
        /// <inheritdoc cref="RdwException"/>
        public RdwException() { }

        /// <inheritdoc cref="RdwException"/>
        /// <param name="message">Message that describes the exception event</param>
        public RdwException(string message) : base(message) { }

        /// <inheritdoc cref="RdwException"/>
        /// <param name="message">Message that describes the exception event</param>
        /// <param name="inner">Exception that triggered this event</param>
        public RdwException(string message, Exception inner) : base(message, inner) { }
    }
}