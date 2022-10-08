using Microsoft.Extensions.Logging;
using System.Collections.Specialized;
using TwT.Rdw.Exceptions;

namespace TwT.Rdw.Repository
{
    /// <summary>
    /// Base that can be used by all the repositories
    /// </summary>
    internal abstract class RepositoryBase: IDisposable
    {
        private readonly RdwClient _client;
        public readonly ILogger Logger;

        /// <summary>
        /// Base that can be used by all the repositories
        /// </summary>
        /// <param name="client">Client that can be used to communication with the RDW</param>
        /// <param name="logger">Logger that logs what is going on in this service</param>
        /// <exception cref="IncorrectArgumentException">Argument is empty</exception>
        protected RepositoryBase(RdwClient client, ILogger logger)
        {
            if (client == null)
            {
                Logger?.LogDebug("{client} is null.", nameof(client));
                throw new IncorrectArgumentException(nameof(client));
            }

            _client = client;
            Logger = logger;
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
        public Task<T> GetResourceFromRdw<T>(string resourceCode, NameValueCollection? queryString, CancellationToken cancellationToken)
        {
            return _client.GetResourceFromRdw<T>(resourceCode, queryString, cancellationToken);
        }

        /// <summary>
        /// Creates a new NameValueCollection with already one query attribute added.
        /// </summary>
        /// <param name="queryName">Name of the query</param>
        /// <param name="queryValue">Value of the query</param>
        /// <returns></returns>
        public NameValueCollection GetQuerystring(string queryName, string queryValue)
        {
            var queryString = System.Web.HttpUtility.ParseQueryString(string.Empty);
            queryString.Add(queryName, queryValue);

            return queryString;
        }

        /// <summary>
        /// Disposes this implementation
        /// </summary>
        public void Dispose()
        {
            _client.Dispose();
        }
    }
}