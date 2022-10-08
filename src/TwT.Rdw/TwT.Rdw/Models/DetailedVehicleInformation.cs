using TwT.Rdw.Models.API;

namespace TwT.Rdw.Models
{
    internal class DetailedVehicleInformation
    {
        public VehicleInformationModel BasicInformation { get; set; }
        public List<VehicleAxleInformationModel> AxleInformation { get; set; }
        public VehicleFuelInformationModel FuelInformation { get; set; }
        public VehicleFuelInformationModel VehicleFuelInformationModel { get; set; }
        public List<VehicleTypeInformationModel> VehicleTypeInformation { get; set; }
        public List<VehicleBodyInformationModel> VehicleBodyInformation { get; set; }
    }
}