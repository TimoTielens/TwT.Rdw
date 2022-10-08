namespace TwT.Rdw.Exceptions
{
    /// <summary>
    /// Exception that will be thrown when the provided arguments are not valid
    /// </summary>
    public class IncorrectArgumentException : RdwException
    {
        /// <summary>
        /// Name of the argument that is not valid
        /// </summary>
        public string ArgumentName { get; init; }

        /// <inheritdoc cref="RdwException"/>
        /// <param name="argumentName">Name of the property that is not valid</param>
        public IncorrectArgumentException(string argumentName) : base($"{argumentName} - Argument is empty")
        {
            ArgumentName = argumentName;
        }

        /// <inheritdoc cref="RdwException"/>
        /// <param name="argumentName">Name of the property that is not valid</param>
        /// <param name="message">Message that describes the exception event</param>
        public IncorrectArgumentException(string argumentName, string message) : base($"{argumentName} - {message}")
        {
            ArgumentName = argumentName;
        }
    }
}