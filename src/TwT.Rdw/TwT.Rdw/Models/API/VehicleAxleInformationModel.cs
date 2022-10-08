namespace TwT.Rdw.Models.API
{
    internal class VehicleAxleInformationModel
    {
        public string kenteken { get; set; }

        /// <summary>
        /// Het nummer van de (fysieke) as vanaf de voorzijde van het voertuig gerekend. Bij pendelassen wordt het nummer bepaald van links naar rechts, gezien vanuit de rijrichting.
        /// </summary>
        public string as_nummer { get; set; }

        /// <summary>
        /// Het aantal assen van een voertuig.
        /// </summary>
        public string aantal_assen { get; set; }

        /// <summary>
        /// Ja/Nee indicator die aangeeft of de betreffende as aangedreven is of niet. Dit gegeven is alleen van belang voor bedrijfsauto's en bussen met een wettelijk toegestane maximummassa boven de 3500 kg.
        /// </summary>
        public string aangedreven_as { get; set; }

        /// <summary>
        /// Indicator die aangeeft of een as geheven kan worden, d.w.z. zodanig omhoog bewogen dat de wielen tijdens het rijden het wegdek niet raken. Deze mag alleen de waarde 'J' bevatten - voor bedrijfsauto als AS-NR-VRTG > 1 en AANT-ASSEN >= 3 en - voor aanhangwagen als AS-NR-VRTG > 0 en AANT-ASSEN >= 2. In de andere gevallen moet de waarde 'N' zijn.
        /// </summary>
        public string hefas { get; set; }

        /// <summary>
        /// Codering die aangeeft of het voertuig een vooras of achteras heeft.
        /// </summary>
        public string plaatscode_as { get; set; }

        /// <summary>
        /// Dit is de spoorbreedte van een as van een voertuig.
        ///
        /// Met spoorbreedte van een as wordt de horizontale afstand tussen het hart van het linker- en rechterwiel van die as bedoeld, gemeten op het wegdek.
        ///
        /// Een samenstel van wielen die op 1 wielnaaf zijn gemonteerd (dubbellucht) wordt dit geval aangemerkt als 1 wiel.De RDW legt dit gegeven alleen vast bij personenauto's, bedrijfsauto's en bussen met een wettelijk toegestane maximummassa niet meer dan 3500 kg.
        /// </summary>
        public string spoorbreedte { get; set; }

        /// <summary>
        /// Code die aangeeft wat het weggedrag is van een aangedreven as. De volgende codes worden gebruikt: • L = Luchtvering • G = Gelijkwaardig aan luchtvering • A = Anders dan luchtvering Dit gegeven wordt alleen vastgelegd voor bedrijfsauto's en bussen met een wettelijk toegestane maximummassa hoger dan 3500 kg.
        /// </summary>
        public string weggedrag_code { get; set; }

        /// <summary>
        /// De wettelijk toegestane maximummassa op de as, afgeleid van de technisch toegestane maximummassa. Zo nodig is deze verminderd aan de hand van wettelijke bepalingen of op verzoek van de aanvrager van het kentekenbewijs.
        /// </summary>
        public string wettelijk_toegestane_maximum_aslast { get; set; }

        /// <summary>
        /// De technisch toegestane maximummassa van de as, opgegeven door de fabrikant van het voertuig.
        /// </summary>
        public string technisch_toegestane_maximum_aslast { get; set; }

        public string geremde_as_indicator { get; set; }

        public decimal afstand_tot_volgende_as_voertuig { get; set; }

        public decimal afstand_tot_volgende_as_voertuig_minimum { get; set; }

        public decimal afstand_tot_volgende_as_voertuig_maximum { get; set; }

        public decimal maximum_last_as_technisch_maximum { get; set; }

        public decimal maximum_last_as_technisch_minimum { get; set; }
    }
}