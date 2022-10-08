namespace TwT.Rdw.Models;

public interface ICompanyInformation
{
    int FollowNumber { get; }
    string Name { get; }
    string FacadeName { get; }
    string StreetName { get; }
    string HouseNummber { get; }
    string ZipCode { get; }
    string City { get; }
    IEnumerable<AuthorityDescription> Authorities { get; }
}

public enum AuthorityDescription
{
    Unknown =0,
    VehicleInspection_LightVehicles, //APK Lichte voertuigen
    VehicleInspection_Heavy_Vehicles, //APK Zware voertuigen
    VehicleInspection_Agriculture, // APK Landbouw
    CompanyStock, // Bedrijfsvoorraad
    TraderLicensePlate, //Handelaarskenteken
    AssignmentOwnerShip, //Tenaamstellen
    AcceleratedAssignmentOwnerShip, //Versnelde inschrijving
    ControlDevices, //Controleapparaten
    Export, //Uitvoer
    ExportServices, //Export dienstverlening
    Disassembly, // Demontage
    Commitee, //Verplichtingennemer
    GasInstallations, //Gasinstallaties
    OnboardComputerTaxi, // Boordcomputertaxi
    LicensePlateManufacturer, //Kentekenplaatfabrikant
    Investigator, //Onderzoeksgerechtigde
    Laminator, //Lamineerder
    PhotographerUnmanned, //Fotograaf onbemand
    PhotographerStaffed, //Fotograaf bemand
    LicensePlateCounter //Kentekenloket
}