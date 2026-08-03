using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ListaSpesa_BackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticoliController : ControllerBase
    {
        private readonly ListaSpesaContext _context;

        public ArticoliController(ListaSpesaContext context)
        {
            _context = context;
        }

        // GET /api/articoli
        [HttpGet]
        public async Task<ActionResult<List<Articolo>>> GetTutti()
        {
            return Ok(await _context.Articoli.Include(a => a.Categoria).ToListAsync());
        }

        // GET /api/articoli/damcomprare
        [HttpGet("damcomprare")]
        public async Task<ActionResult<List<Articolo>>> GetDaComprare()
        {
            var lista = await _context.Articoli
                .Include(a => a.Categoria)
                .Where(a => a.DaComprareSiNo)
                .ToListAsync();
            return Ok(lista);
        }

        // GET /api/articoli/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Articolo>> GetUno(int id)
        {
            var articolo = await _context.Articoli
                .Include(a => a.Categoria)
                .FirstOrDefaultAsync(a => a.IdArticolo == id);

            if (articolo == null) return NotFound();
            return Ok(articolo);
        }

        // POST /api/articoli
        [HttpPost]
        public async Task<ActionResult<Articolo>> Crea(Articolo nuovoArticolo)
        {
            if (nuovoArticolo.Priorita < -1 || nuovoArticolo.Priorita > 1)
                return BadRequest("La priorità deve essere -1, 0 o 1.");

            _context.Articoli.Add(nuovoArticolo);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUno), new { id = nuovoArticolo.IdArticolo }, nuovoArticolo);
        }

        // PUT /api/articoli/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Modifica(int id, Articolo articoloModificato)
        {
            if (id != articoloModificato.IdArticolo) return BadRequest();

            if (articoloModificato.Priorita < -1 || articoloModificato.Priorita > 1)
                return BadRequest("La priorità deve essere -1, 0 o 1.");

            _context.Entry(articoloModificato).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE /api/articoli/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Elimina(int id)
        {
            var articolo = await _context.Articoli.FindAsync(id);
            if (articolo == null) return NotFound();

            _context.Articoli.Remove(articolo);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
