namespace TwT.Rdw.Models.API
{
    internal class VehicleInspectionMessageModel
    {
        public string kenteken { get; set; }
        public string soort_erkenning_keuringsinstantie { get; set; }
        public string meld_datum_door_keuringsinstantie { get; set; }
        public string meld_tijd_door_keuringsinstantie { get; set; }
        public string soort_erkenning_omschrijving { get; set; }
        public string soort_melding_ki_omschrijving { get; set; }
        public string vervaldatum_keuring { get; set; }
        public DateTime meld_datum_door_keuringsinstantie_dt { get; set; }
        public DateTime vervaldatum_keuring_dt { get; set; }
    }
}