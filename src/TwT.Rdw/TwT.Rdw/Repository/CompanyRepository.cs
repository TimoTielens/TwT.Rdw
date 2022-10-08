using System.Collections.Generic;
using System.Collections.Specialized;
using Microsoft.Extensions.Logging;
using TwT.Rdw.Exceptions;
using TwT.Rdw.Models.API;

namespace TwT.Rdw.Repository
{
    /// <summary>
    /// Repository that can be used to retrieve one or more Companies that are known  by the RDW
    /// </summary>
    internal class CompanyRepository : RepositoryBase, ICompanyRepository
    {
        public static string RESOURCE_COMPANY_INFO = "5k74-3jha";
        public static string RESOURCE_COMPANY_AUTHORITY = "nmwb-dqkz";

        /// <summary>
        /// Repository that can be used to retrieve one or more Companies that are known  by the RDW
        /// </summary>
        /// <param name="client">Client that does the actual communication with the RDW</param>
        /// <param name="logger">Logger that logs what is going on in this service</param>
        public CompanyRepository(RdwClient client, ILogger<CompanyRepository> logger) : base(client, logger)
        {
        }

        /// <summary>
        /// Searches for a company based on it's followNumber
        /// </summary>
        /// <param name="followNumber">Number that the company should match to</param>
        /// <param name="cancellationToken">Can be used to cancel this operation</param>
        /// <returns>Details of the company or an exception</returns>
        /// <remarks>Data comes from https://opendata.rdw.nl/Erkende-bedrijven/Open-Data-RDW-Erkende-Bedrijven/5k74-3jha</remarks>
        /// <exception cref="HttpException">Received error while calling the RDW</exception>
        /// <exception cref="UnexpectedException">Response is empty, this should not happen</exception>
        /// <exception cref="ResponseMessageException">Received error while deserializing JSON to object</exception>
        /// <exception cref="IncorrectArgumentException">Argument is empty</exception>
        /// <exception cref="NoDataException">RDW did not have data for the request</exception>
        public async Task<CompanyInformationModel> FindByFollowNumber(int followNumber, CancellationToken cancellationToken)
        {
            if (followNumber < 1)
                throw new IncorrectArgumentException(nameof(followNumber));

            return (await GetResourceFromRdw<List<CompanyInformationModel>>(RESOURCE_COMPANY_INFO, GetQuerystring("volgnummer", followNumber.ToString()), cancellationToken)).FirstOrDefault();
        }

        /// <summary>
        /// Searches for a company based on it's Name
        /// </summary>
        /// <param name="name">Name that the company should match to</param>
        /// <param name="cancellationToken">Can be used to cancel this operation</param>
        /// <returns>Details of the company or an exception</returns>
        /// <remarks>Data comes from https://opendata.rdw.nl/Erkende-bedrijven/Open-Data-RDW-Erkende-Bedrijven/5k74-3jha</remarks>
        /// <exception cref="HttpException">Received error while calling the RDW</exception>
        /// <exception cref="UnexpectedException">Response is empty, this should not happen</exception>
        /// <exception cref="ResponseMessageException">Received error while deserializing JSON to object</exception>
        /// <exception cref="IncorrectArgumentException">Argument is empty</exception>
        /// <exception cref="NoDataException">RDW did not have data for the request</exception>
        public async Task<CompanyInformationModel> FindByName(string name, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new IncorrectArgumentException(nameof(name));

            return (await GetResourceFromRdw<List<CompanyInformationModel>>(RESOURCE_COMPANY_INFO, GetQuerystring("naam_bedrijf", name), cancellationToken)).FirstOrDefault();
        }

        /// <summary>
        /// Searches for a company based on it's location
        /// </summary>
        /// <param name="city">City that the company should match to</param>
        /// <param name="streetName">Street name that the company should match to</param>
        /// <param name="houseNumber">House number that the company should match to</param>
        /// <param name="cancellationToken">Can be used to cancel this operation</param>
        /// <returns>Details of the company or an exception</returns>
        /// <remarks>Data comes from https://opendata.rdw.nl/Erkende-bedrijven/Open-Data-RDW-Erkende-Bedrijven/5k74-3jha</remarks>
        /// <exception cref="HttpException">Received error while calling the RDW</exception>
        /// <exception cref="UnexpectedException">Response is empty, this should not happen</exception>
        /// <exception cref="ResponseMessageException">Received error while deserializing JSON to object</exception>
        /// <exception cref="IncorrectArgumentException">Argument is empty</exception>
        /// <exception cref="NoDataException">RDW did not have data for the request</exception>
        public async Task<CompanyInformationModel> FindByAddress(string city, string streetName, int houseNumber, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(city))
                throw new IncorrectArgumentException(nameof(city));

            if (string.IsNullOrWhiteSpace(streetName))
                throw new IncorrectArgumentException(nameof(streetName));

            if (houseNumber < 1)
                throw new IncorrectArgumentException(nameof(houseNumber));

            var query = GetQuerystring("plaats", city.ToUpper());
            query.Add("straat", streetName.ToUpper());
            query.Add("huisnummer", houseNumber.ToString());

            return (await GetResourceFromRdw<List<CompanyInformationModel>>(RESOURCE_COMPANY_INFO, query, cancellationToken)).FirstOrDefault();
        }

        /// <summary>
        /// Searches for companies that are located in the specified city
        /// </summary>
        /// <param name="city">City that the companies should match to</param>
        /// <param name="cancellationToken">Can be used to cancel this operation</param>
        /// <returns>Details of the company or an exception</returns>
        /// <remarks>Data comes from https://opendata.rdw.nl/Erkende-bedrijven/Open-Data-RDW-Erkende-Bedrijven/5k74-3jha</remarks>
        /// <exception cref="HttpException">Received error while calling the RDW</exception>
        /// <exception cref="UnexpectedException">Response is empty, this should not happen</exception>
        /// <exception cref="ResponseMessageException">Received error while deserializing JSON to object</exception>
        /// <exception cref="IncorrectArgumentException">Argument is empty</exception>
        /// <exception cref="NoDataException">RDW did not have data for the request</exception>
        public Task<List<CompanyInformationModel>> FindByPlace(string city, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(city))
                throw new IncorrectArgumentException(nameof(city));

            return GetResourceFromRdw<List<CompanyInformationModel>>(RESOURCE_COMPANY_INFO, GetQuerystring("plaats", city.ToUpper()), cancellationToken);
        }

        /// <summary>
        /// Searches for authorities that a company has
        /// </summary>
        /// <param name="followNumber">Follow number of the company that we want the authorities for</param>
        /// <param name="cancellationToken">Can be used to cancel this operation</param>
        /// <returns>Authorities that are linked to the provided company or an exception</returns>
        /// <remarks>Data comes from https://opendata.rdw.nl/Erkende-bedrijven/Open-Data-RDW-Erkenningen/nmwb-dqkz</remarks>
        /// <exception cref="HttpException">Received error while calling the RDW</exception>
        /// <exception cref="UnexpectedException">Response is empty, this should not happen</exception>
        /// <exception cref="ResponseMessageException">Received error while deserializing JSON to object</exception>
        /// <exception cref="IncorrectArgumentException">Argument is empty</exception>
        /// <exception cref="NoDataException">RDW did not have data for the request</exception>
        public Task<List<CompanyInfoAuthorityModel>> FindAuthorityInformation(int followNumber, CancellationToken cancellationToken)
        {
            return GetResourceFromRdw<List<CompanyInfoAuthorityModel>>(RESOURCE_COMPANY_AUTHORITY, GetQuerystring("volgnummer", followNumber.ToString()), cancellationToken);
        }
    }
}