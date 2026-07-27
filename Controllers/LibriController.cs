using MiaApiLocale;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class LibriController : ControllerBase
{
    private readonly BibliotecaContext _context;

    public LibriController(BibliotecaContext context)
    {
        _context = context;
    }

    // GET /api/libri
    [HttpGet]
    public async Task<ActionResult<List<Libro>>> GetTutti()
    {
        return Ok(await _context.Libri.ToListAsync());
    }

    // GET /api/libri/3
    [HttpGet("{id}")]
    public async Task<ActionResult<Libro>> GetUno(int id)
    {
        var libro = await _context.Libri.FindAsync(id);
        if (libro == null) return NotFound();
        return Ok(libro);
    }

    // POST /api/libri
    [HttpPost]
    public async Task<ActionResult<Libro>> Crea(Libro nuovoLibro)
    {
        _context.Libri.Add(nuovoLibro);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetUno), new { id = nuovoLibro.Id }, nuovoLibro);
    }

    // PUT /api/libri/3
    [HttpPut("{id}")]
    public async Task<IActionResult> Modifica(int id, Libro libroModificato)
    {
        if (id != libroModificato.Id) return BadRequest();
        _context.Entry(libroModificato).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    // DELETE /api/libri/3
    [HttpDelete("{id}")]
    public async Task<IActionResult> Elimina(int id)
    {
        var libro = await _context.Libri.FindAsync(id);
        if (libro == null) return NotFound();
        _context.Libri.Remove(libro);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}