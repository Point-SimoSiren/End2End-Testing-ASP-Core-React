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
    
        /*

        // Haku id:llä
        [HttpGet]
        [Route("{id}")]
        public Kurssit GetOneById(int id)
        {
            try
            {
                Kurssit kurssi = db.Kurssit.Find(id);
                return kurssi;
            }
            finally
            {
                db.Dispose();
            }
        }

       
        // Uuden luonti
        [HttpPost]
        [Route("")]
        public ActionResult Create([FromBody] Kurssit kurssi)
        {
            try
            {
                db.Kurssit.Add(kurssi);
                db.SaveChanges();
                return Ok(kurssi.KurssiId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            finally
            {
                db.Dispose();
            }
        }

   
        //Poisto Id:llä
        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                Kurssit kurssi = db.Kurssit.Find(id);
                if (kurssi != null)
                {
                    db.Kurssit.Remove(kurssi);
                    db.SaveChanges();
                    return Ok("Kurssi id:llä " + id + " poistettiin");
                }
                else
                {
                    return NotFound("Kurssia id:llä" + id + " ei löydy");
                }
            }
            catch
            {
                return BadRequest();
            }
            finally
            {
                db.Dispose();
            }
        }
        */
        
    }
}

