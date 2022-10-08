namespace TwT.Rdw.Models.API
{
    internal class VehicleInspectionDefectsDescriptionModel
    {
        public string gebrek_identificatie { get; set; }
        public decimal ingangsdatum_gebrek { get; set; }
        public decimal einddatum_gebrek { get; set; }
        public decimal gebrek_paragraaf_nummer { get; set; }
        public string gebrek_artikel_nummer { get; set; }
        public string gebrek_omschrijving { get; set; }
        public DateTime ingangsdatum_gebrek_dt { get; set; }
        public DateTime einddatum_gebrek_dt { get; set; }

    }
}