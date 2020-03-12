using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebshopGraphicsCard.Models;
using WebshopGraphicsCard.Persistence;
using Microsoft.AspNetCore.Http;

namespace WebshopGraphicsCard.Controllers
{
    public class HomeController : Controller
    {
        
        PersistenceCode PC = new PersistenceCode();

        [HttpGet]
        public IActionResult Index()
        {
            Klant klant = new Klant();
            HttpContext.Session.SetString("KlantNr", "1");
            ArtikelRepository ArtRepo = new ArtikelRepository();
            ArtRepo.Artikels = PC.loadArtikels();
            return View(ArtRepo);
        }

        [HttpGet]
       public IActionResult Toevoegen(int ArtNr)
       {
            VMToevoegen vMToevoegen = new VMToevoegen();
            vMToevoegen.artikel= PC.loadArtikel(ArtNr);
            HttpContext.Session.SetString("ArtNr", ArtNr.ToString());
            return View(vMToevoegen);
        }

        
        [HttpPost]
        public IActionResult Toevoegen(VMToevoegen vMToevoegen)
        {
            Winkelmand winkelmand = new Winkelmand();
            vMToevoegen.artikel = PC.loadArtikel(vMToevoegen.artikel.ArtNr);
            winkelmand.KlantNr = Convert.ToInt32(HttpContext.Session.GetString("KlantNr"));
            winkelmand.Aantal = vMToevoegen.Aantal;
            winkelmand.ArtNr = Convert.ToInt32(HttpContext.Session.GetString("ArtNr"));

            if (ModelState.IsValid)
            {
                if ((winkelmand.Aantal > 0) && (winkelmand.Aantal <= vMToevoegen.artikel.Voorraad))
                {
                    PC.PasMandjeAan(winkelmand);
                    return View(vMToevoegen);
                }
                else
                {
                    return View(vMToevoegen);
                }
            }
            else
            {
                return View(vMToevoegen);
            }           
        }
    }
}
