using Domein.Wandel.Interfaces;
using Domein.Wandel.Model;

namespace Domein.Wandel; 

public class DomeinManager {

    private readonly ITochtRepository _tochtRepository;

    public DomeinManager(ITochtRepository tochtRepository) {
        _tochtRepository = tochtRepository;
    }

    public List<string> GeefAlleTochten() {
        return TochtenToString(_tochtRepository.GeefAlleTochten());
    }

    public List<string> ZoekTochten(string zoekterm) {
        return TochtenToString(_tochtRepository.ZoekTochten(zoekterm));
    }

    public string GeefBeschrijving(int referentie) {
        return _tochtRepository.ZoekTocht(referentie).UitegebreideBeschrijving;
    }

    private List<string> TochtenToString(List<Tocht> tochten) {
        List<string> result = new List<string>();

        foreach (Tocht item in tochten) {
             result.Add(item.ToString());
        }

        return result;
    }
}