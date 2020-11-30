using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KurssiBackend.Models
{
    public class MockKurssitRepository : IKurssitRepository
    {
        private List<Kurssit> _kurssit;

        public MockKurssitRepository()
        {
            _kurssit = new List<Kurssit>()
            {
                new Kurssit() {KurssiId = 1, Nimi = "SQL peruskurssi", Laajuus = 2},
                new Kurssit() {KurssiId = 2, Nimi = "Javascript peruskurssi", Laajuus = 4},
                new Kurssit() {KurssiId = 3, Nimi = "HTML + CSS", Laajuus = 3}
            };
        }

        // Implementointi toi ao. metodit tänne: 

        public IEnumerable<Kurssit> HaeKurssit()
        {
            List<Kurssit> kurssit = _kurssit.ToList();
            return kurssit;
        }

        public Kurssit HaeYksiKurssi(int id)
        {
            Kurssit kurssi = _kurssit.FirstOrDefault(k => k.KurssiId == id);
            return kurssi;
        }

        public Kurssit LisaaKurssi(Kurssit kurssi)
        {
            _kurssit.Add(kurssi);
            return kurssi;
        }

        public Kurssit PoistaKurssi(int id)
        {
            Kurssit kurssi = _kurssit.FirstOrDefault(k => k.KurssiId == id);
            {
                if (kurssi != null)
                {
                    _kurssit.Remove(kurssi);
                }
                return kurssi;
            }
        }
    }
}
