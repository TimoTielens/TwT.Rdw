using TwT.Rdw.Exceptions;
using TwT.Rdw.Models.API;

namespace TwT.Rdw.Repository;

internal interface ICompanyRepository : IDisposable
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
    /// <exception cref="NoDataException">RDW did not have data for the request</exception>
    Task<CompanyInformationModel> FindByFollowNumber(int followNumber, CancellationToken cancellationToken);

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
    public Task<CompanyInformationModel> FindByName(string name, CancellationToken cancellationToken);

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
    public Task<CompanyInformationModel> FindByAddress(string city, string streetName, int houseNumber, CancellationToken cancellationToken);

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
    Task<List<CompanyInformationModel>> FindByPlace(string city, CancellationToken cancellationToken);

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
    public Task<List<CompanyInfoAuthorityModel>> FindAuthorityInformation(int followNumber, CancellationToken cancellationToken);
}