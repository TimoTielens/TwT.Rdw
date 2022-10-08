using TwT.Rdw.Exceptions;

namespace TwT.Rdw.Configuration
{
    /// <summary>
    /// Configuration that holds information needed to be able to connect to the RDW data
    /// </summary>
    public class RdwConfiguration : IRdwConfiguration
    {
        /// <summary>
        /// Host that where we should communicate with
        /// </summary>
        /// <remarks>Default set to https://opendata.rdw.nl</remarks>
        public string Host { get; set; } = "https://opendata.rdw.nl";

        /// <summary>
        /// Token to authenticate against the RDW server
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Verifies if the configuration is valid
        /// </summary>
        /// <exception cref="ConfigurationException">Occurs when one of the properties is not valid</exception>
        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(Host))
                throw new ConfigurationException(nameof(Host));

            if (!IsValidUri(Host))
                throw new ConfigurationException(nameof(Host), "Not a valid URI");

            if (string.IsNullOrWhiteSpace(Token))
                throw new ConfigurationException(nameof(Token));
        }

        /// <summary>
        /// Checks if an uri is valid
        /// </summary>
        /// <param name="uri">uri that needs to be validate</param>
        /// <returns>True if the uri is valid</returns>
        private static bool IsValidUri(string uri)
        {
            if (!Uri.IsWellFormedUriString(uri, UriKind.Absolute))
                return false;
            if (!Uri.TryCreate(uri, UriKind.Absolute, out var tmp))
                return false;
            return tmp.Scheme == Uri.UriSchemeHttp || tmp.Scheme == Uri.UriSchemeHttps;
        }
    }
}