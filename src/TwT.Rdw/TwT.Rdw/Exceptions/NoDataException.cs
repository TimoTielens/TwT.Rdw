using System.Dynamic;

namespace TwT.Rdw.Exceptions
{
    /// <summary>
    /// Exception that occurs when the RDW doesn't have data for the specified argument
    /// </summary>
    internal class NoDataException : RdwException
    {
        /// <summary>
        /// Uri that has been called
        /// </summary>
        public string Uri { get; init; }

        /// <summary>
        /// Exception that occurs when the RDW doesn't have data for the specified argument
        /// </summary>
        /// <param name="uri">Uri that has been called</param>
        public NoDataException(string uri)
        {
            Uri = uri;
        }
    }
}