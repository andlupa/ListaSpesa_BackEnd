using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MiaApiLocale.Controllers
{
    [ApiController]
    // Questo definisce l'indirizzo dell'API (sarà http://localhost:xxxx/api/prodotti)
    [Route("api/[controller]")]
    public class ProdottiController : ControllerBase
    {
        // Creiamo una lista fissa di prodotti inventati da te
        private static readonly List<Prodotto> ListaProdotti = new List<Prodotto>
        {
            new Prodotto { Id = 1, Nome = "Smartphone Pro 15", Categoria = "Elettronica", Prezzo = 899.99m, Disponibile = true },
            new Prodotto { Id = 2, Nome = "Cuffie Wireless ANC", Categoria = "Audio", Prezzo = 149.50m, Disponibile = true },
            new Prodotto { Id = 3, Nome = "Tastiera Meccanica RGB", Categoria = "Computer", Prezzo = 89.90m, Disponibile = false },
            new Prodotto { Id = 4, Nome = "Monitor 4K 27 pollici", Categoria = "Computer", Prezzo = 349.00m, Disponibile = true }
        };

        // Questo metodo risponde alle richieste HTTP GET
        [HttpGet]
        public ActionResult<IEnumerable<Prodotto>> GetTuttiIProdotti()
        {
            // Restituisce la lista intera in formato JSON automatizzato
            return Ok(ListaProdotti);
        }
    }
}
