using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ListaSpesa_BackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategorieController : ControllerBase
    {
        private readonly ListaSpesaContext _context;

        public CategorieController(ListaSpesaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Categoria>>> GetTutte()
        {
            return Ok(await _context.Categorie.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> GetUna(int id)
        {
            var categoria = await _context.Categorie.FindAsync(id);
            if (categoria == null) return NotFound();
            return Ok(categoria);
        }

        [HttpPost]
        public async Task<ActionResult<Categoria>> Crea(Categoria nuovaCategoria)
        {
            _context.Categorie.Add(nuovaCategoria);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUna), new { id = nuovaCategoria.IdCategoria }, nuovaCategoria);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Modifica(int id, Categoria categoriaModificata)
        {
            if (id != categoriaModificata.IdCategoria) return BadRequest();
            _context.Entry(categoriaModificata).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Elimina(int id)
        {
            var categoria = await _context.Categorie.FindAsync(id);
            if (categoria == null) return NotFound();
            _context.Categorie.Remove(categoria);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}