using System.Threading.Channels;
using BusStops.Domain;

namespace BusStops.Presentation
{
    public class BusStopsApplication
    {
        private DomainController _domainController;
                                                                                       
        private const string GemeenteQuestion = "Muncicpality: ";
        public BusStopsApplication(DomainController domainController)
        {
            _domainController = domainController;
            Start();
        }

        private void Start() {
            PrintData(_domainController.GetDistinctStopAccessibilities());
            //Console.Write("Please enter a number: ");
            //int.TryParse(Console.ReadLine(), out int result);

            /*switch (result) {
               case 1: 
                   Console.WriteLine(_domainController.GetBusStopCount());
                   break; 
               case 2:
                   PrintData(_domainController.GetBusStopNames());
                   break;
               case 3: 
                   PrintData(_domainController.GetListMunicipalityOrder());
                   break;
               case 4: 
                   
                   PrintData(_domainController.GetHaltesByMunicpality(AskForInput(GemeenteQuestion)));
                   break;
               case 5: 
                   PrintData(_domainController.GetHaltesWithNonAccessibilities());
                   break;
               case 6:
                   Console.WriteLine(_domainController.GetMunicipalityWithMaxHaltes());
                   break;
               case 7:
                   Console.WriteLine(_domainController.GetCountHaltesOfMunicipality());
                   break;
            }         */
        }

        private void PrintData(List<string> data) {
            //Console.WriteLine(string.Join("\n", data));
            data.ForEach(s => Console.WriteLine(s));
        }

        private string AskForInput(string prompt) {
            Console.WriteLine(prompt);
            return Console.ReadLine();
        }
    }
}