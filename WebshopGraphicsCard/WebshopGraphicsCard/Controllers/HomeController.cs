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

        public IActionResult Index()
        {
            Klant klant = new Klant();
            HttpContext.Session.SetString("KlantNr", "1");
            ArtikelRepository ArtRepo = new ArtikelRepository();
            ArtRepo.Artikels = PC.loadArtikels();
            return View(ArtRepo);
        }

       public IActionResult Toevoegen(int ArtNr)
       {
            VMToevoegen vMToevoegen = new VMToevoegen();
            vMToevoegen.artikel= PC.loadArtikel(ArtNr);
            return View(vMToevoegen);
        }
    }
}
