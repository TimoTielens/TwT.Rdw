namespace TwT.Rdw.Models.API
{
    internal class VehicleInspectionDefectsFindingModel
    {
        public string kenteken { get; set; }
        public string soort_erkenning_keuringsinstantie { get; set; }
        public decimal meld_datum_door_keuringsinstantie { get; set; }
        public decimal meld_tijd_door_keuringsinstantie { get; set; }
        public string gebrek_identificatie { get; set; }
        public string soort_erkenning_omschrijving { get; set; }
        public decimal aantal_gebreken_geconstateerd { get; set; }
        public DateTime meld_datum_door_keuringsinstantie_dt { get; set; }
    }
}