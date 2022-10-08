using TwT.Rdw.Models;

namespace TwT.Rdw.Extensions
{
    /// <summary>
    /// Extensions that are related to AuthorityDescription
    /// </summary>
    internal static class AuthoritiesExtension
    {
        public static AuthorityDescription ToAuthorityDescription(this string description)
        {

            if(description == "APK Lichte voertuigen")
                return AuthorityDescription.VehicleInspection_LightVehicles;
            if (description == "APK Zware voertuigen")
                return AuthorityDescription.VehicleInspection_Heavy_Vehicles;
            if (description == "APK Landbouw")
                return AuthorityDescription.VehicleInspection_Agriculture;
            if (description == "Bedrijfsvoorraad")
                return AuthorityDescription.CompanyStock;
            if (description == "Handelaarskenteken")
                return AuthorityDescription.TraderLicensePlate;
            if (description == "Tenaamstellen")
                return AuthorityDescription.AssignmentOwnerShip;
            if (description == "Versnelde inschrijving")
                return AuthorityDescription.AcceleratedAssignmentOwnerShip;
            if (description == "Controleapparaten")
                return AuthorityDescription.ControlDevices;
            if (description == "Uitvoer")
                return AuthorityDescription.Export;
            if (description == "Export dienstverlening")
                return AuthorityDescription.ExportServices;
            if (description == "Demontage")
                return AuthorityDescription.Disassembly;
            if (description == "Verplichtingennemer")
                return AuthorityDescription.Commitee;
            if (description == "Gasinstallaties")
                return AuthorityDescription.GasInstallations;
            if (description == "Boordcomputertaxi")
                return AuthorityDescription.OnboardComputerTaxi;
            if (description == "Kentekenplaatfabrikant")
                return AuthorityDescription.LicensePlateManufacturer;
            if (description == "Onderzoeksgerechtigde")
                return AuthorityDescription.Investigator;
            if (description == "Lamineerder")
                return AuthorityDescription.Laminator;
            if (description == "Fotograaf onbemand")
                return AuthorityDescription.PhotographerUnmanned;
            if (description == "Fotograaf bemand")
                return AuthorityDescription.PhotographerStaffed;
            if (description == "Kentekenloket")
                return AuthorityDescription.LicensePlateCounter;

            return AuthorityDescription.Unknown;
        }
    }
}