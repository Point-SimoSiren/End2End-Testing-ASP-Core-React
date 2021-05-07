using Xunit;
using Alba;
using System.Threading.Tasks;
using System.Collections.Generic;
using KurssiBackend.Models;
using System.Linq;

namespace XUnitTestiProjekti
{
    public class UnitTestKurssit
    {

        [Fact]
        public async Task HaeKaikki()
        {
            var hostBuilder = KurssiBackend.Program.CreateHostBuilder(new string[0]);

            using (var system = new SystemUnderTest(hostBuilder))
            {
                await system.Scenario(s =>
                {
                    s.Get.Url("/api/kurssit");
                    s.StatusCodeShouldBeOk();
                });
                var results = await system.GetAsJson<IEnumerable<Kurssit>>("/api/kurssit");

                Assert.NotEmpty(results);
                //Assert.Equal(8, results.Count()); // Jos lukumäärä on tiedossa.
            }
        }


        [Fact]
        public async Task HaeYksi()
        {
            var hostBuilder = KurssiBackend.Program.CreateHostBuilder(new string[0]);

            using (var system = new SystemUnderTest(hostBuilder))
            {
                await system.Scenario(s =>
                {
                    s.Get.Url("/api/kurssit/2");
                    s.StatusCodeShouldBe(200);

                    s.Get.Url("/api/kurssit/21234");
                    s.StatusCodeShouldBe(204);

                    s.Get.Url("/api/murssikka/2"); // Väärä polku tarkoituksella
                    s.StatusCodeShouldBe(404);
                });
            }
        }


        [Fact]
        public async Task LisääUusiIlmanBodya()
        {
            var hostBuilder = KurssiBackend.Program.CreateHostBuilder(new string[0]);

            using (var system = new SystemUnderTest(hostBuilder))
            {
                await system.Scenario(s =>
                {
                    s.Post.Url("/api/kurssit"); // Lähetetään ilman bodyä
                    s.StatusCodeShouldBe(415); // odotetaan unsupported mediatype
                });
            }
        }


        [Fact]
        public async Task LisääUusi()
        {
            var hostBuilder = KurssiBackend.Program.CreateHostBuilder(new string[0]);

            using (var system = new SystemUnderTest(hostBuilder))
            {
                //Tarkistetaan kurssien lukumäärä ennen lisäystä
                var results1 = await system.GetAsJson<IEnumerable<Kurssit>>("/api/kurssit");
                var count1 = results1.Count();

                // Lisätään kurssi, ja poistetaan se seuraavassa testissä.
                var kurssi = new Kurssit { Nimi = "TestiKurssi", Laajuus = 4 };
                await system.Scenario(s =>
                {
                    s.Post.Json<Kurssit>(kurssi).ToUrl("/api/kurssit");
                    s.StatusCodeShouldBe(200);
                });

                // Tarkistetaan kurssien lukumäärä lisäyksen jälkeen
                var results2 = await system.GetAsJson<IEnumerable<Kurssit>>("/api/kurssit");
                Assert.Equal(count1 + 1, results2.Count()); // Pitää olla +1 vrt. edelliseen tarkistukseen
            }
        }


        [Fact]
        public async Task PoistaViimeisin()
        {
            var hostBuilder = KurssiBackend.Program.CreateHostBuilder(new string[0]);

            using (var system = new SystemUnderTest(hostBuilder))
            {
                //Tarkistetaan kurssien lukumäärä ennen poistoa
                var results1 = await system.GetAsJson<IEnumerable<Kurssit>>("/api/kurssit");
                var count1 = results1.Count();

                // Etsitään suurin Id linq:lla ja Max metodilla
                int suurinId = (from r in results1 select r.KurssiId).ToArray().Max();


                // Poistetaan kurssi jolla on suurin id
                await system.Scenario(s =>
                {
                    s.Delete.Url("/api/kurssit/" + suurinId);
                    s.StatusCodeShouldBe(200);
                });

                // Tarkistetaan kurssien lukumäärä poiston jälkeen
                var results2 = await system.GetAsJson<IEnumerable<Kurssit>>("/api/kurssit");
                Assert.Equal(count1 - 1, results2.Count()); // Pitää olla alkuperäinen määrä kursseja

            }
        }
    }
}
