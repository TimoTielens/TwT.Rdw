using TwT.Rdw.Exceptions;

namespace TwT.Rdw.Configuration;

/// <summary>
/// Configuration that holds information needed to be able to connect to the RDW data
/// </summary>
public interface IRdwConfiguration
{
    /// <summary>
    /// Host that where we should communicate with
    /// </summary>
    /// <remarks>Default set to https://opendata.rdw.nl</remarks>
    string Host { get; set; }

    /// <summary>
    /// Token to authenticate against the RDW server
    /// </summary>
    string? Token { get; set; }

    /// <summary>
    /// Verifies if the configuration is valid
    /// </summary>
    /// <exception cref="ConfigurationException">Occurs when one of the properties is not valid</exception>
    public void Validate();
}