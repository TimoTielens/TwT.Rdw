namespace TwT.Rdw.Models.API
{
    internal class VehicleFuelInformationModel
    {
        public string kenteken { get; set; }
        public string brandstof_volgnummer { get; set; }
        public string brandstof_omschrijving { get; set; }
        public string brandstofverbruik_buiten { get; set; }
        public string brandstofverbruik_gecombineerd { get; set; }
        public string brandstofverbruik_stad { get; set; }
        public string co2_uitstoot_gecombineerd { get; set; }
        public string co2_uitstoot_gewogen { get; set; }
        public string geluidsniveau_rijdend { get; set; }
        public string geluidsniveau_stationair { get; set; }
        public string emissiecode_omschrijving { get; set; }
        public string milieuklasse_eg_goedkeuring_licht { get; set; }
        public string milieuklasse_eg_goedkeuring_zwaar { get; set; }
        public string uitstoot_deeltjes_licht { get; set; }
        public string uitstoot_deeltjes_zwaar { get; set; }
        public string nettomaximumvermogen { get; set; }
        public string nominaal_continu_maximumvermogen { get; set; }
        public string roetuitstoot { get; set; }
        public string toerental_geluidsniveau { get; set; }
        public decimal emis_deeltjes_type1_wltp { get; set; }
        public decimal emissie_co2_gecombineerd_wltp { get; set; }
        public decimal emis_co2_gewogen_gecombineerd_wltp { get; set; }
        public decimal brandstof_verbruik_gecombineerd_wltp { get; set; }
        public decimal brandstof_verbruik_gewogen_gecombineerd_wltp { get; set; }
        public decimal elektrisch_verbruik_enkel_elektrisch_wltp { get; set; }
        public decimal actie_radius_enkel_elektrisch_wltp { get; set; }
        public decimal actie_radius_enkel_elektrisch_stad_wltp { get; set; }
        public decimal elektrisch_verbruik_extern_opladen_wltp { get; set; }
        public decimal actie_radius_extern_opladen_wltp { get; set; }
        public decimal actie_radius_extern_opladen_stad_wltp { get; set; }
        public decimal max_vermogen_15_minuten { get; set; }
        public decimal max_vermogen_60_minuten { get; set; }
        public decimal netto_max_vermogen_elektrisch { get; set; }
        public string klasse_hybride_elektrisch_voertuig { get; set; }
        public decimal opgegeven_maximum_snelheid { get; set; }
        public string uitlaatemissieniveau { get; set; }
    }
}