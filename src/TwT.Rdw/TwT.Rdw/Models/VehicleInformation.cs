using TwT.Rdw.Models.API;

namespace TwT.Rdw.Models
{
    internal class VehicleInformation : IVehicleInformation
    {
        public string LicensePlate { get; set; }
        public string Brand { get; set; }

        public VehicleInformation(VehicleInformationModel basicModel ,List<VehicleAxleInformationModel> axleInformation)
        {
            LicensePlate = basicModel.kenteken;
            Brand = basicModel.merk;
        }
    }
}