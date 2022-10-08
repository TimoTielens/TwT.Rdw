using TwT.Rdw.Configuration;
using TwT.Rdw.Services;

namespace TwT.Rdw.Test.Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var config = new RdwConfiguration()
            {
                Token = "24Vysylhfpc8t5IhHLxlaEHBs",
            };

            var rdwService = new RdwService(config, null);

           // var HansHuibers = rdwService.FindByName("AUTOBEDRIJF HANS HUIJBERS", default).Result;

            var brutus = rdwService.VehicleInformation("0074ZZ", default).Result;

         //   var HansHuibers = rdwService.FindByName("AUTOBEDRIJF HANS HUIJBERS", default).Result;

         //   System.Console.WriteLine(HansHuibers.ToString());

            //var byNumber = rdwService.CompanyInformation.FindByFollowNumber(13716).Result;
            //var byName = rdwService.CompanyInformation.FindByName("AUTOBEDRIJF HANS HUIJBERS").Result;
            //var byPlace = rdwService.CompanyInformation.FindByPlace("Bemmel").Result;
            //var byStreetName = rdwService.CompanyInformation.FindByAddress("Bemmel", "Dijkstraat", 2).Result;

            //var foo = rdwService.CompanyInformation.FindAuthorityInformation(byName.First().volgnummer).Result;

            System.Console.Read();
        }
    }
}