using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using TwT.Rdw.Configuration;
using TwT.Rdw.Exceptions;
using TwT.Rdw.Models;
using TwT.Rdw.Models.API;
using TwT.Rdw.Repository;

namespace TwT.Rdw.Services
{
    /// <summary>
    /// Service that can be used to retrieve data from the RDW
    /// </summary>
    public class RdwService : IRdwService
    {
        private readonly ICompanyRepository _companyInformation;
        private readonly ILogger<RdwService> _logger;
        private readonly IVehicleInformationRepository _vehicleInformationRepository;

        /// <summary>
        /// Service that can be used to retrieve data from the RDW
        /// </summary>
        /// <param name="configuration">Configuration that holds information needed to be able to connect to the RDW data</param>
        /// <param name="loggerFactory">Factory that can be used to create loggers. Note null is allowed!</param>
        /// <exception cref="ConfigurationException">Occurs when one of the properties is not valid</exception>
        public RdwService(IRdwConfiguration configuration, ILoggerFactory loggerFactory)
        {
           _logger = loggerFactory?.CreateLogger<RdwService>();

            var client = new RdwClient(configuration, loggerFactory?.CreateLogger<RdwClient>());
            _companyInformation = new CompanyRepository(client, loggerFactory?.CreateLogger<CompanyRepository>());
            _vehicleInformationRepository = new VehicleInformationRepository(client, loggerFactory?.CreateLogger<VehicleInformationRepository>());
        }
        
        public async Task<IVehicleInformation> VehicleInformation(string licensePlate, CancellationToken cancellationToken)
        {
            try
            {
                var details = await _vehicleInformationRepository.GetDetailedInformation(licensePlate, cancellationToken);

             //   var basicInformation = await _vehicleInformationRepository.GetLicensedVehicleInformation(licensePlate, cancellationToken);
             //   var axleInformation = await _vehicleInformationRepository.GetLicensedVehicleAxleInformation(licensePlate, cancellationToken);
             //   var fuelInformation = await _vehicleInformationRepository.GetLicensedFuelInformation(licensePlate, cancellationToken);
             ////   var vehicleType = await _licensePlateRepository.GetLicensedVehicleTypeInformation(licensePlate, cancellationToken);
             //var bodyInformation = await _vehicleInformationRepository.GetLicensedCarBodyInformation(licensePlate, cancellationToken);

             return null;
            }
            catch (RdwException)
            {
                throw;
            }
            catch (Exception e)
            {
                _logger?.LogWarning("Catched an error although this was not expected");
                throw new UnexpectedException("Catched an error although this was not expected", e);
            }
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
        public async Task<ICompanyInformation> FindByFollowNumber(int followNumber, CancellationToken cancellationToken)
        {
            try
            {
                return await CreateCompanyInformation(await _companyInformation.FindByFollowNumber(followNumber, cancellationToken), cancellationToken);
            }
            catch (RdwException)
            {
                throw;
            }
            catch (Exception e)
            {
                _logger?.LogWarning("Catched an error although this was not expected");
                throw new UnexpectedException("Catched an error although this was not expected", e);
            }
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
        public async Task<ICompanyInformation> FindByName(string name, CancellationToken cancellationToken)
        {
            try
            {
                return await CreateCompanyInformation(await _companyInformation.FindByName(name, cancellationToken), cancellationToken);
            }
            catch (RdwException)
            {
                throw;
            }
            catch (Exception e)
            {
                _logger?.LogWarning("Catched an error although this was not expected");
                throw new UnexpectedException("Catched an error although this was not expected", e);
            }
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
        public async Task<ICompanyInformation> FindByAddress(string city, string streetName, int houseNumber, CancellationToken cancellationToken)
        {
            try
            {
                return await CreateCompanyInformation(await _companyInformation.FindByAddress(city, streetName, houseNumber, cancellationToken), cancellationToken);
            }
            catch (RdwException)
            {
                throw;
            }
            catch (Exception e)
            {
                _logger?.LogWarning("Catched an error although this was not expected");
                throw new UnexpectedException("Catched an error although this was not expected", e);
            }
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
        public async Task<List<ICompanyInformation>> FindByPlace(string city, CancellationToken cancellationToken)
        {
            try
            {
                var result = new List<ICompanyInformation>();
                var companies = await _companyInformation.FindByPlace(city, cancellationToken);
                companies.ForEach(async x => result.Add(await CreateCompanyInformation(x, cancellationToken)));

                return result;
            }
            catch (RdwException)
            {
                throw;
            }
            catch (Exception e)
            {
                _logger?.LogWarning("Catched an error although this was not expected");
                throw new UnexpectedException("Catched an error although this was not expected", e);
            }
        }

        /// <summary>
        /// Creates the public company information model
        /// </summary>
        /// <param name="model">Data the needs to be added to the new model</param>
        /// <param name="cancellationToken">Can be used to cancel this operation</param>
        /// <returns>Newly created company information model</returns>
        private async Task<ICompanyInformation> CreateCompanyInformation(CompanyInformationModel model, CancellationToken cancellationToken)
        {
            var authorities = await _companyInformation.FindAuthorityInformation(model.volgnummer, cancellationToken);
            return new CompanyInformation(model, authorities);
        }

        /// <summary>
        /// Disposes this implementation
        /// </summary>
        public void Dispose()
        {
            _companyInformation.Dispose();
            _vehicleInformationRepository.Dispose();
        }
    }
}