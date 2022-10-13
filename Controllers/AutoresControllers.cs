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
    [Route("api/autores")]
    public class AutoresController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public AutoresController(ApplicationDbContext context)
        {
            this.context = context;
        }
        /*public AutoresController(ApplicationDbContext context)
        {
            this.context = context;
        }*/

        
        [HttpGet]
        public async Task<ActionResult<List<Autor>>> Get()
        {
            return await context.Autores.Include(x => x.Libros).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Autor autor)
        {
            context.Add(autor);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")] //api/autores/1
        public async Task<ActionResult> Put(Autor autor, int id)
        {
            if (autor.IdAutor != id)
            {
                return NotFound("El id del autor no coincide con el id de la URL");
            }

            context.Update(autor);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existencia = await context.Autores.AnyAsync(x => x.IdAutor == id);

            if (!existencia)
            {
                return NotFound();
            }

            context.Remove(new Autor() { IdAutor = id });
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}