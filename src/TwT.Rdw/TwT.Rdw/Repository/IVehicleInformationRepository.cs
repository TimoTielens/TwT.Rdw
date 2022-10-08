using TwT.Rdw.Exceptions;
using TwT.Rdw.Models;
using TwT.Rdw.Models.API;

namespace TwT.Rdw.Repository;

internal interface IVehicleInformationRepository
{
    /// <summary>
    /// Gets all detailed information about a vehicle
    /// </summary>
    /// <param name="licensePlate">licensePlate of the vehicle that we want the data from</param>
    /// <param name="cancellationToken">Can be used to cancel this operation</param>
    /// <returns>Details of the vehicle or an exception</returns>
    /// <remarks>Data comes from https://opendata.rdw.nl/Voertuigen/Open-Data-RDW-Gekentekende_voertuigen/m9d7-ebf2</remarks>
    /// <exception cref="HttpException">Received error while calling the RDW</exception>
    /// <exception cref="UnexpectedException">Response is empty, this should not happen</exception>
    /// <exception cref="ResponseMessageException">Received error while deserializing JSON to object</exception>
    /// <exception cref="IncorrectArgumentException">Argument is empty</exception>
    /// <exception cref="NoDataException">RDW did not have data for the request</exception>
    Task<DetailedVehicleInformation> GetDetailedInformation(string licensePlate, CancellationToken cancellationToken);

    /// <summary>
    /// Gets basic information about a vehicle
    /// </summary>
    /// <param name="licensePlate">licensePlate of the vehicle that we want the data from</param>
    /// <param name="cancellationToken">Can be used to cancel this operation</param>
    /// <returns>Details of the vehicle or an exception</returns>
    /// <remarks>Data comes from https://opendata.rdw.nl/Voertuigen/Open-Data-RDW-Gekentekende_voertuigen/m9d7-ebf2</remarks>
    /// <exception cref="HttpException">Received error while calling the RDW</exception>
    /// <exception cref="UnexpectedException">Response is empty, this should not happen</exception>
    /// <exception cref="ResponseMessageException">Received error while deserializing JSON to object</exception>
    /// <exception cref="IncorrectArgumentException">Argument is empty</exception>
    /// <exception cref="NoDataException">RDW did not have data for the request</exception>
    Task<VehicleInformationModel> GetLicensedVehicleInformation(string licensePlate, CancellationToken cancellationToken);

    /// <summary>
    /// Gets information about the axles of a vehicle
    /// </summary>
    /// <param name="licensePlate">licensePlate of the vehicle that we want the data from</param>
    /// <param name="cancellationToken">Can be used to cancel this operation</param>
    /// <returns>Details of the vehicle or an exception</returns>
    /// <remarks>Data comes from https://opendata.rdw.nl/Voertuigen/Open-Data-RDW-api_gekentekende_voertuigen_assen/3huj-srit</remarks>
    /// <exception cref="HttpException">Received error while calling the RDW</exception>
    /// <exception cref="UnexpectedException">Response is empty, this should not happen</exception>
    /// <exception cref="ResponseMessageException">Received error while deserializing JSON to object</exception>
    /// <exception cref="IncorrectArgumentException">Argument is empty</exception>
    /// <exception cref="NoDataException">RDW did not have data for the request</exception>
    Task<List<VehicleAxleInformationModel>> GetLicensedVehicleAxleInformation(string licensePlate, CancellationToken cancellationToken);

    /// <summary>
    /// Gets information about the fuel usage of a vehicle
    /// </summary>
    /// <param name="licensePlate">licensePlate of the vehicle that we want the data from</param>
    /// <param name="cancellationToken">Can be used to cancel this operation</param>
    /// <returns>Details of the vehicle or an exception</returns>
    /// <remarks>Data comes from https://opendata.rdw.nl/Voertuigen/Open-Data-RDW-api_gekentekende_voertuigen_brandstof/8ys7-d773</remarks>
    /// <exception cref="HttpException">Received error while calling the RDW</exception>
    /// <exception cref="UnexpectedException">Response is empty, this should not happen</exception>
    /// <exception cref="ResponseMessageException">Received error while deserializing JSON to object</exception>
    /// <exception cref="IncorrectArgumentException">Argument is empty</exception>
    /// <exception cref="NoDataException">RDW did not have data for the request</exception>
    Task<VehicleFuelInformationModel> GetLicensedFuelInformation(string licensePlate, CancellationToken cancellationToken);

    /// <summary>
    /// Gets information about the type of the vehicle
    /// </summary>
    /// <param name="licensePlate">licensePlate of the vehicle that we want the data from</param>
    /// <param name="cancellationToken">Can be used to cancel this operation</param>
    /// <returns>Details of the vehicle or an exception</returns>
    /// <remarks>Data comes from https://opendata.rdw.nl/Voertuigen/Open-Data-RDW-api_gekentekende_voertuigen_voertuigklasse/kmfi-hrps</remarks>
    /// <exception cref="HttpException">Received error while calling the RDW</exception>
    /// <exception cref="UnexpectedException">Response is empty, this should not happen</exception>
    /// <exception cref="ResponseMessageException">Received error while deserializing JSON to object</exception>
    /// <exception cref="IncorrectArgumentException">Argument is empty</exception>
    /// <exception cref="NoDataException">RDW did not have data for the request</exception>
    Task<List<VehicleTypeInformationModel>> GetLicensedVehicleTypeInformation(string licensePlate, CancellationToken cancellationToken);

    /// <summary>
    /// Gets information about the body of a vehicle
    /// </summary>
    /// <param name="licensePlate">licensePlate of the vehicle that we want the data from</param>
    /// <param name="cancellationToken">Can be used to cancel this operation</param>
    /// <returns>Details of the vehicle or an exception</returns>
    /// <remarks>Data comes from https://opendata.rdw.nl/Voertuigen/Open-Data-RDW-api_gekentekende_voertuigen_carrosserie/vezc-m2t6</remarks>
    /// <exception cref="HttpException">Received error while calling the RDW</exception>
    /// <exception cref="UnexpectedException">Response is empty, this should not happen</exception>
    /// <exception cref="ResponseMessageException">Received error while deserializing JSON to object</exception>
    /// <exception cref="IncorrectArgumentException">Argument is empty</exception>
    /// <exception cref="NoDataException">RDW did not have data for the request</exception>
    Task<List<VehicleBodyInformationModel>> GetLicensedCarBodyInformation(string licensePlate, CancellationToken cancellationToken);

    /// <summary>
    /// Disposes this implementation
    /// </summary>
    void Dispose();
}