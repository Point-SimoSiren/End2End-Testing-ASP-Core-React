using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using KurssiBackend.Models;

namespace KurssiBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KurssitController : ControllerBase
    {

        private readonly IKurssitRepository _kurssitRepository;

        public KurssitController(IKurssitRepository kurssitRepository)
        {
            _kurssitRepository = kurssitRepository;
        }

        // Hae kaikki kurssit
        [HttpGet]
        [Route("")]
        public List<Kurssit> GetAll()
        {
            var kurssit = _kurssitRepository.HaeKurssit().ToList();
            if (kurssit != null)
            {
                return kurssit;
            }
            else
            {
                return null;
            }
        }

        // Haku id:llä
        [HttpGet]
        [Route("{id}")]
        public Kurssit GetOneById(int id)
        {
            var kurssi = _kurssitRepository.HaeYksiKurssi(id);
            if (kurssi != null)
            {
                return kurssi;
            }
            else
            {
                return null;
            }
        }

        // Uuden luonti
        [HttpPost]
        [Route("")]
        public IActionResult Create([FromBody] Kurssit kurssi)
        {
            if (ModelState.IsValid)
            {
                Kurssit uusiKurssi = _kurssitRepository.LisaaKurssi(kurssi);
            }
            return Ok(kurssi);
        }
        

        //Poisto Id:llä
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            {
                var kurssi = _kurssitRepository.PoistaKurssi(id);
                if (kurssi != null)
                {
                    return Ok(kurssi);
                }
                else
                {
                    return NotFound(id);
                }
            }

        }

    }
}

