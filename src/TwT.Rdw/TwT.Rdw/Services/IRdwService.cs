using TwT.Rdw.Exceptions;
using TwT.Rdw.Models;

namespace TwT.Rdw.Services
{
    public interface IRdwService: IDisposable
    {
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
        Task<ICompanyInformation> FindByFollowNumber(int followNumber, CancellationToken cancellationToken);

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
        Task<ICompanyInformation> FindByName(string name, CancellationToken cancellationToken);

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
        Task<ICompanyInformation> FindByAddress(string city, string streetName, int houseNumber, CancellationToken cancellationToken);

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
        Task<List<ICompanyInformation>> FindByPlace(string city, CancellationToken cancellationToken);
    }
}