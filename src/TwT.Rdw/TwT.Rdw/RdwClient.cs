using Newtonsoft.Json;
using System.Collections.Specialized;
using Microsoft.Extensions.Logging;
using TwT.Rdw.Configuration;
using TwT.Rdw.Exceptions;

namespace TwT.Rdw
{
    /// <summary>
    /// Client that does the actual communication with the RDW
    /// </summary>
    internal class RdwClient : IDisposable
    {
        private readonly ILogger<RdwClient> _logger;
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Client that does the actual communication with the RDW
        /// </summary>
        /// <param name="configuration">Configuration that holds information needed to be able to connect to the RDW data</param>
        /// <param name="logger">Logger that logs what is going on in this service</param>
        /// <exception cref="ConfigurationException">Occurs when one of the properties is not valid</exception>
        public RdwClient(IRdwConfiguration configuration, ILogger<RdwClient> logger)
        {
            _logger = logger;
            configuration.Validate();

            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("x-auth-token", configuration.Token);
            _httpClient.BaseAddress = new Uri(configuration.Host);
        }

        /// <summary>
        /// Call the resource API from the RDW and retrieves the data
        /// </summary>
        /// <typeparam name="T">Type of the class the the response should be converted to</typeparam>
        /// <param name="resourceCode">Code that identifies the resource that should be retrieved</param>
        /// <param name="queryString">String with all the query parameters</param>
        /// <param name="cancellationToken">Can be used to cancel this operation</param>
        /// <returns>Response from the RDW</returns>
        /// <exception cref="HttpException">Received error while calling the RDW</exception>
        /// <exception cref="UnexpectedException">Response is empty, this should not happen</exception>
        /// <exception cref="ResponseMessageException">Received error while deserializing JSON to object</exception>
        /// <exception cref="IncorrectArgumentException">Argument is empty</exception>
        /// <exception cref="NoDataException">RDW did not have data for the request</exception>
        public Task<T> GetResourceFromRdw<T>(string resourceCode, NameValueCollection? queryString, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(resourceCode))
            {
                _logger?.LogDebug("{Code} cannot be empty", nameof(resourceCode));
                throw new IncorrectArgumentException(nameof(resourceCode));
            }

            if (queryString == null)
            {
                _logger?.LogDebug("{Query} cannot be empty", nameof(queryString));
                throw new IncorrectArgumentException(nameof(queryString));
            }

            if (cancellationToken == null)
            {
                _logger?.LogDebug("{Token} cannot be empty", nameof(cancellationToken));
                throw new IncorrectArgumentException(nameof(cancellationToken));
            }

            var uri = $"/resource/{resourceCode}.json";

            if (queryString is { Count: > 0 })
                uri += $"?{queryString}";

            return CallRdw<T>(uri, cancellationToken);
        }

        /// <summary>
        /// Calls the RDW and tries to convert the answer into an object
        /// </summary>
        /// <typeparam name="T">Type of the class the the response should be converted to</typeparam>
        /// <param name="uri">Uri (excluding the base url) that should be called</param>
        /// <param name="cancellationToken">Can be used to cancel this operation</param>
        /// <returns>Response from the RDW</returns>
        /// <exception cref="HttpException">Received error while calling the RDW</exception>
        /// <exception cref="UnexpectedException">Response is empty, this should not happen</exception>
        /// <exception cref="ResponseMessageException">Received error while deserializing JSON to object</exception>
        /// <exception cref="NoDataException">RDW did not have data for the request</exception>
        private async Task<T> CallRdw<T>(string uri, CancellationToken cancellationToken)
        {
            _logger?.LogInformation("Calling RDW, {Uri}", uri);

            string responseMessage;
            T responseObject;

            try
            {
                responseMessage = await _httpClient.GetStringAsync(uri, cancellationToken);
            }
            catch (Exception e)
            {
                _logger?.LogError(e, "Received error while calling the RDW");
                throw new HttpException("Received error while calling the RDW", e);
            }

            if (responseMessage == "[]\n")
            {
                _logger?.LogWarning("RDW did not have data for the request");
                throw new NoDataException(uri);
            }

            if (string.IsNullOrWhiteSpace(responseMessage))
            {
                _logger?.LogWarning("Response message is empty, this should not happen");
                throw new UnexpectedException("Response message from the RDW is empty, this should not happen");
            }

            try
            {
                responseObject = JsonConvert.DeserializeObject<T>(responseMessage);
            }
            catch (Exception e)
            {
                _logger?.LogError(e, "Received error while deserializing JSON to {T}", typeof(T).Name);
                throw new ResponseMessageException($"Received error while deserializing JSON to {typeof(T).Name}", e);
            }

            if (responseObject != null) return responseObject;

            _logger?.LogError("Response object is empty, this should not happen");
            throw new UnexpectedException("Response object is empty, this should not happen");
        }

        /// <summary>
        /// Disposes this implementation
        /// </summary>
        public void Dispose()
        {
            _logger?.LogInformation("Disposing {client}", nameof(RdwClient));
            _httpClient.Dispose();
        }
    }
}