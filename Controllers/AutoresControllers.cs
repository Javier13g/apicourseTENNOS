using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using apicourseTENNOS.DTOs;
using AutoMapper;
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
        private readonly IMapper mapper;

        public AutoresController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        /*public AutoresController(ApplicationDbContext context)
        {
            this.context = context;
        }*/

        
        [HttpGet]
        public async Task<List<Autor>> Get()
        {
            return await context.Autores.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Autor>> Get(int id)
        {
            var autor =  await context.Autores.FirstOrDefaultAsync(autorBD => autorBD.IdAutor == id);
            if(autor == null)
            {
                return NotFound();
            }
            return autor;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody]AutorCreacionDTO autorCreacionDTO)
        {
            var existeAutor = await context.Autores.AnyAsync(x => x.Nombre_Autor == autorCreacionDTO.Nombre_Autor);

            if(existeAutor)
            {
                return BadRequest($"Ya existe autor con el mismo nombre {autorCreacionDTO.Nombre_Autor}");
            }

            var autor = mapper.Map<Autor>(autorCreacionDTO);
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