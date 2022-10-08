//using System.Collections.Specialized;
//using TwT.Rdw.Models;

//namespace TwT.Rdw.Services
//{
//    internal class VehicleService
//    {
//        private readonly RdwClient _client;
//        private static string QUERY_LICENSE = "kenteken";

//        public VehicleService(RdwClient client)
//        {
//            _client = client;
//        }

//        #region Vehicle Information
//        /// <summary>
//        /// https://opendata.rdw.nl/Voertuigen/Open-Data-RDW-Gekentekende_voertuigen/m9d7-ebf2
//        /// </summary>
//        public Task<List<VehicleInformationModel>> GetLicensedVehicleInformation(string licensePlate)
//        {
//            var resourceToken = "m9d7-ebf2";
//            return _client.GetResourceFromRdw<List<VehicleInformationModel>>(resourceToken, GetQuerystring(QUERY_LICENSE, licensePlate));
//        }

//        /// <summary>
//        /// https://opendata.rdw.nl/Voertuigen/Open-Data-RDW-api_gekentekende_voertuigen_assen/3huj-srit
//        /// </summary>
//        public Task<List<VehicleAxleInformationModel>> GetLicensedVehicleAxleInformation(string licensePlate)
//        {
//            var resourceToken = "3huj-srit";
//            return _client.GetResourceFromRdw<List<VehicleAxleInformationModel>>(resourceToken, GetQuerystring(QUERY_LICENSE, licensePlate));
//        }

//        /// <summary>
//        /// https://opendata.rdw.nl/Voertuigen/Open-Data-RDW-api_gekentekende_voertuigen_brandstof/8ys7-d773
//        /// </summary>
//        public Task<List<VehicleFuelInformationModel>> GetLicensedFuelInformation(string licensePlate)
//        {
//            var resourceToken = "8ys7-d773";
//            return _client.GetResourceFromRdw<List<VehicleFuelInformationModel>>(resourceToken, GetQuerystring(QUERY_LICENSE, licensePlate));
//        }

//        /// <summary>
//        /// https://opendata.rdw.nl/Voertuigen/Open-Data-RDW-api_gekentekende_voertuigen_voertuigklasse/kmfi-hrps
//        /// </summary>
//        public Task<List<VehicleFuelInformationModel>> GetLicensedVehicleTypeInformation(string licensePlate)
//        {
//            var resourceToken = "kmfi-hrps";
//            return _client.GetResourceFromRdw<List<VehicleFuelInformationModel>>(resourceToken, GetQuerystring(QUERY_LICENSE, licensePlate));
//        }

//        /// <summary>
//        /// https://opendata.rdw.nl/Voertuigen/Open-Data-RDW-api_gekentekende_voertuigen_carrosserie/vezc-m2t6
//        /// </summary>
//        public Task<List<VehicleFuelInformationModel>> GetLicensedCarosserieInformation(string licensePlate)
//        {
//            var resourceToken = "vezc-m2t6";
//            throw new NotImplementedException();
//        }

//        /// <summary>
//        /// https://opendata.rdw.nl/Voertuigen/Open-Data-RDW-api_gekentekende_voertuigen_carrosserie_specifiek/jhie-znh9
//        /// </summary>
//        public Task<List<VehicleFuelInformationModel>> GetLicensedCarosserieSpecifcInformation(string licensePlate)
//        {
//            var resourceToken = "jhie-znh9";
//            throw new NotImplementedException();
//        }
//        #endregion

//        /// <summary>
//        /// https://opendata.rdw.nl/Keuringen/Open-Data-RDW-Meldingen-Keuringsinstantie/sgfe-77wx
//        /// </summary>
//        public Task<List<VehicleInspectionMessageModel>> GetVehicleInspectionMessages(string licensePlate)
//        {
//            var resourceToken = "sgfe-77wx";
//            return _client.GetResourceFromRdw<List<VehicleInspectionMessageModel>>(resourceToken, GetQuerystring(QUERY_LICENSE, licensePlate));
//        }

//        /// <summary>
//        /// https://opendata.rdw.nl/Keuringen/Open-Data-RDW-api_gebrek_constateringen/a34c-vvps
//        /// </summary>
//        public Task<List<VehicleInspectionDefectsFindingModel>> GetVehicleInspectionDefectsFindings(string licensePlate)
//        {
//            var resourceToken = "a34c-vvps";
//            return _client.GetResourceFromRdw<List<VehicleInspectionDefectsFindingModel>>(resourceToken, GetQuerystring(QUERY_LICENSE, licensePlate));
//        }

//        /// <summary>
//        /// https://opendata.rdw.nl/Keuringen/Open-Data-RDW-api_gebrek_beschrijving/hx2c-gt7k
//        /// </summary>
//        public async Task<VehicleInspectionDefectsDescriptionModel> GetVehicleInspectionDefectsDescription(string defectDescriptionIdentificationCode)
//        {
//            var resourceToken = "hx2c-gt7k";
//            return (await _client.GetResourceFromRdw<List<VehicleInspectionDefectsDescriptionModel>>(resourceToken, GetQuerystring("gebrek_identificatie", defectDescriptionIdentificationCode))).FirstOrDefault();
//        }

//        /// <summary>
//        /// https://opendata.rdw.nl/Terugroepacties/Open-Data-RDW-Terugroep_actie_status/t49b-isb7
//        /// </summary>
//        public async Task<VehicleInspectionDefectsDescriptionModel> GetVehicleRecallStatus(string licensePlate)
//        {
//            var resourceToken = "t49b-isb7";
//            return (await _client.GetResourceFromRdw<List<VehicleInspectionDefectsDescriptionModel>>(resourceToken, GetQuerystring(QUERY_LICENSE, licensePlate))).FirstOrDefault();
//        }

//        private NameValueCollection GetQuerystring(string queryName, string queryValue)
//        {
//            var queryString = System.Web.HttpUtility.ParseQueryString(string.Empty);
//            queryString.Add(queryName, queryValue);

//            return queryString;
//        }
//    }
//}
