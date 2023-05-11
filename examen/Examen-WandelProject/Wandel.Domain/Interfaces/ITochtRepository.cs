using Domein.Wandel.Model;

namespace Domein.Wandel.Interfaces; 

public interface ITochtRepository {

    List<Tocht> GeefAlleTochten();
    Tocht ZoekTocht(int referentie);
    List<Tocht> ZoekTochten(string zoekterm);
}