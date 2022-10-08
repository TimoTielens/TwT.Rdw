namespace TwT.Rdw.Models.API
{
    internal class CompanyInformationModel
    {
        public int volgnummer { get; set; }
        public string naam_bedrijf { get; set; }
        public string gevelnaam { get; set; }
        public string straat { get; set; }
        public string huisnummer { get; set; }
        public int postcode_numeriek { get; set; }
        public string postcode_alfanumeriek { get; set; }
        public string plaats { get; set; }
    }
}