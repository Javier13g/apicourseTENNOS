using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIcourse.Models;

namespace WebAPIcourse.Controllers
{
    [ApiController]
    [Route("api/libros")]
    public class LibrosController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public LibrosController(ApplicationDbContext context)
        {
            this.context = context;
        }
        
        // [HttpGet("{id:int}")]
        // public async Task<ActionResult<Libro>> Get (int id)
        // {
        //     return await context.Libros.Include( x => x.Autor).FirstOrDefaultAsync(x => x.Id_Libro == id);
        // }

        // [HttpPost]
        // public async Task<ActionResult> Post(Libro libro)
        // {
        //     var existeAutor = await context.Autores.AnyAsync(X => X.IdAutor == libro.AutorId);

        //     if (!existeAutor)
        //     {
        //         return BadRequest($"No existe el autor de Id: {libro.AutorId}");
        //     }

        //     context.Add(libro);
        //     await context.SaveChangesAsync();
        //     return Ok();
        // }
    }
}