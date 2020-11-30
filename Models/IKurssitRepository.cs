using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KurssiBackend.Models
{
    public interface IKurssitRepository
    {
        IEnumerable<Kurssit> HaeKurssit();
        Kurssit HaeYksiKurssi(int id);
        Kurssit LisaaKurssi(Kurssit kurssi);
        Kurssit PoistaKurssi(int id);

    }
}
