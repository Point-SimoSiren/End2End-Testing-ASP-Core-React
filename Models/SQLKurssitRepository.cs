using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KurssiBackend.Models
{
    public class SQLKurssitRepository : IKurssitRepository
    {
        private readonly KurssiDBContext db = new KurssiDBContext();

        public IEnumerable<Kurssit> HaeKurssit()
        {
            List<Kurssit> kurssit = db.Kurssit.ToList();
            return kurssit;
        }

        public Kurssit HaeYksiKurssi(int id)
        {
            Kurssit kurssi = db.Kurssit.Find(id);
            return kurssi;
        }

        public Kurssit LisaaKurssi(Kurssit kurssi)
        {
            db.Kurssit.Add(kurssi);
            db.SaveChanges();
            return kurssi;
        }

        public Kurssit PoistaKurssi(int id)
        {
            Kurssit kurssi = db.Kurssit.Find(id);
            if (kurssi != null)
            {
                db.Kurssit.Remove(kurssi);
                db.SaveChanges();
            }
            return kurssi;
        }
    }
}
