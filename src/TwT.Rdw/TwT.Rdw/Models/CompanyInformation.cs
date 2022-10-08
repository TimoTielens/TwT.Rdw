using TwT.Rdw.Extensions;
using TwT.Rdw.Models.API;

namespace TwT.Rdw.Models
{
    internal class CompanyInformation : ICompanyInformation
    {
        public int FollowNumber { get; set; }
        public string Name { get; set; }
        public string FacadeName { get; set; }
        public string StreetName { get; set; }
        public string HouseNummber { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }

        public IEnumerable<AuthorityDescription> Authorities { get; set; }

        public CompanyInformation(CompanyInformationModel infoModel, List<CompanyInfoAuthorityModel> authorityModel)
        {
            FollowNumber = infoModel.volgnummer;
            Name = infoModel.naam_bedrijf;
            FacadeName = infoModel.gevelnaam;
            StreetName = infoModel.straat;
            HouseNummber = infoModel.huisnummer;
            ZipCode = $"{infoModel.postcode_numeriek} {infoModel.postcode_alfanumeriek}";
            City = infoModel.plaats;

            var tempList = new List<AuthorityDescription>();
            authorityModel.ForEach(x => tempList.Add(x.erkenning.ToAuthorityDescription()));
            Authorities = tempList;
        }

        public override string ToString()
        {
            return $"{nameof(FollowNumber)}: {FollowNumber}|" +
                   $"{nameof(Name)}: {Name}|" +
                   $"{nameof(FacadeName)}: {FacadeName}|" +
                   $"{nameof(StreetName)}: {StreetName}|" +
                   $"{nameof(HouseNummber)}: {HouseNummber}|" +
                   $"{nameof(ZipCode)}: {ZipCode}|" +
                   $"{nameof(City)}: {City}|"+
                   $"Number of authorities: {Authorities.Count()}|";
        }
    }
}