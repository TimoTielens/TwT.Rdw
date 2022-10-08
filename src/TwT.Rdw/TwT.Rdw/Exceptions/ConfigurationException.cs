namespace TwT.Rdw.Exceptions
{
    /// <summary>
    /// Exception for specifying that the configuration is valid
    /// </summary>
    public class ConfigurationException : RdwException
    {
        /// <summary>
        /// Name of the property that is not valid
        /// </summary>
        public string PropertyName { get; init; }
        
        /// <inheritdoc cref="RdwException"/>
        /// <param name="propertyName">Name of the property that is not valid</param>
        public ConfigurationException(string propertyName) : base($"{propertyName} - Empty value")
        {
            PropertyName = propertyName;
        }
        
        /// <inheritdoc cref="RdwException"/>
        /// <param name="propertyName">Name of the property that is not valid</param>
        /// <param name="message">Message that describes the exception event</param>
        public ConfigurationException(string propertyName, string message) : base($"{propertyName} - {message}")
        {
            PropertyName = propertyName;
        }
    }
}