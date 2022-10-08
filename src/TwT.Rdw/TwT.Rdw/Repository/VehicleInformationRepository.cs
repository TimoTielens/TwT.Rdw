using Microsoft.Extensions.Logging;
using System.Threading;
using TwT.Rdw.Exceptions;
using TwT.Rdw.Models;
using TwT.Rdw.Models.API;

namespace TwT.Rdw.Repository
{
    /// <summary>
    /// Repository that can be used to retrieve data about a license plate
    /// </summary>
    internal class VehicleInformationRepository : RepositoryBase, IVehicleInformationRepository
    {
        private static string RESOURCE_General_INFO = "m9d7-ebf2";
        private static string RESOURCE_AXLE_INFO = "3huj-srit";
        private static string RESOURCE_FUEL_INFO = "8ys7-d773";
        private static string RESOURCE_VEHICLE_TYPE_INFO = "kmfi-hrps";
        private static string RESOURCE_CAR_BODY_INFO = "vezc-m2t6";
        private static string QUERY_LICENSE = "kenteken";

        /// <summary>
        /// Repository that can be used to retrieve data about a license plate
        /// </summary>
        /// <param name="client">Client that does the actual communication with the RDW</param>
        /// <param name="logger">Logger that logs what is going on in this service</param>
        public VehicleInformationRepository(RdwClient client, ILogger<VehicleInformationRepository> logger) : base(client, logger)
        {
        }

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
        public async Task<DetailedVehicleInformation> GetDetailedInformation(string licensePlate, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(licensePlate))
                throw new IncorrectArgumentException(nameof(licensePlate));

            licensePlate = ToApiLicensePlateFormat(licensePlate);

            //Possible to receive NoDataException. If so throw it!
            var response = new DetailedVehicleInformation
            {
                BasicInformation = (await GetResourceFromRdw<List<VehicleInformationModel>>(RESOURCE_General_INFO, GetQuerystring(QUERY_LICENSE, licensePlate), cancellationToken)).FirstOrDefault()
            };

            try
            {
                response.AxleInformation = await GetResourceFromRdw<List<VehicleAxleInformationModel>>(RESOURCE_AXLE_INFO, GetQuerystring(QUERY_LICENSE, licensePlate), cancellationToken);
            }
            catch (NoDataException) { //Ignore, any other exception should be throw up!
            }

            try
            {
                response.FuelInformation = (await GetResourceFromRdw<List<VehicleFuelInformationModel>>(RESOURCE_FUEL_INFO, GetQuerystring(QUERY_LICENSE, licensePlate), cancellationToken)).FirstOrDefault();
            }
            catch (NoDataException)
            { //Ignore, any other exception should be throw up!
            }

            try
            {
                response.VehicleTypeInformation= await GetResourceFromRdw<List<VehicleTypeInformationModel>>(RESOURCE_VEHICLE_TYPE_INFO, GetQuerystring(QUERY_LICENSE, licensePlate), cancellationToken);
            }
            catch (NoDataException)
            { //Ignore, any other exception should be throw up!
            }

            try
            {
                response.VehicleBodyInformation = await GetResourceFromRdw<List<VehicleBodyInformationModel>>(RESOURCE_CAR_BODY_INFO, GetQuerystring(QUERY_LICENSE, licensePlate), cancellationToken);
            }
            catch (NoDataException)
            { //Ignore, any other exception should be throw up!
            }
            
            return response;
        }

        /// <summary>
        /// Gets basic infor=mation about a vehicle
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
        public async Task<VehicleInformationModel> GetLicensedVehicleInformation(string licensePlate, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(licensePlate))
                throw new IncorrectArgumentException(nameof(licensePlate));

            return (await GetResourceFromRdw<List<VehicleInformationModel>>(RESOURCE_General_INFO, GetQuerystring(QUERY_LICENSE, ToApiLicensePlateFormat(licensePlate)), cancellationToken)).FirstOrDefault();
        }

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
        public Task<List<VehicleAxleInformationModel>> GetLicensedVehicleAxleInformation(string licensePlate, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(licensePlate))
                throw new IncorrectArgumentException(nameof(licensePlate));

            return GetResourceFromRdw<List<VehicleAxleInformationModel>>(RESOURCE_AXLE_INFO, GetQuerystring(QUERY_LICENSE, ToApiLicensePlateFormat(licensePlate)), cancellationToken);
        }

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
        public async Task<VehicleFuelInformationModel> GetLicensedFuelInformation(string licensePlate, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(licensePlate))
                throw new IncorrectArgumentException(nameof(licensePlate));

            return (await GetResourceFromRdw<List<VehicleFuelInformationModel>>(RESOURCE_FUEL_INFO, GetQuerystring(QUERY_LICENSE, ToApiLicensePlateFormat(licensePlate)), cancellationToken)).FirstOrDefault();
        }

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
        public Task<List<VehicleTypeInformationModel>> GetLicensedVehicleTypeInformation(string licensePlate, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(licensePlate))
                throw new IncorrectArgumentException(nameof(licensePlate));

            return GetResourceFromRdw<List<VehicleTypeInformationModel>>(RESOURCE_VEHICLE_TYPE_INFO, GetQuerystring(QUERY_LICENSE, ToApiLicensePlateFormat(licensePlate)), cancellationToken);
        }

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
        public Task<List<VehicleBodyInformationModel>> GetLicensedCarBodyInformation(string licensePlate, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(licensePlate))
                throw new IncorrectArgumentException(nameof(licensePlate));

            return GetResourceFromRdw<List<VehicleBodyInformationModel>>(RESOURCE_CAR_BODY_INFO, GetQuerystring(QUERY_LICENSE, ToApiLicensePlateFormat(licensePlate)), cancellationToken);
        }

        /// <summary>
        /// Transforms te data of a licensePlate in such an format that the RDW can work with it.
        /// </summary>
        /// <param name="licensePlate">License plate that needs to be converted</param>
        /// <returns>Formatted to all caps and without the '-' symbol.</returns>
        private string ToApiLicensePlateFormat(string licensePlate)
        {
            return licensePlate.Replace("-", string.Empty).ToUpper();
        }
    }
}