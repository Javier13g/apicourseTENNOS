using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIcourse.DTOs;
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
        public async Task<List<AutorDTO>> Get()
        {
            var autores = await context.Autores.ToListAsync();
            return mapper.Map<List<AutorDTO>>(autores);
        }

        [HttpGet("{id:int}", Name = "obtenerAutor")]
        public async Task<ActionResult<AutorDTOConLibros>> Get(int id)
        {
            var autor = await context.Autores
                .Include(autorDB => autorDB.AutoresLibros)
                .ThenInclude(autorLibroDB => autorLibroDB.Libro)
                .FirstOrDefaultAsync(autorBD => autorBD.Id == id);

            if (autor == null)
            {
                return NotFound();
            }

            return mapper.Map<AutorDTOConLibros>(autor);
        }

        [HttpGet("{nombre}")]
        public async Task<ActionResult<List<AutorDTO>>> Get([FromRoute] string nombre)
        {
            var autores = await context.Autores.Where(autorBD => autorBD.Nombre_Autor.Contains(nombre)).ToListAsync();

            return mapper.Map<List<AutorDTO>>(autores);

        }

        [HttpPost]
        public async Task<ActionResult<Autor>> Post([FromBody] AutorCreacionDTO autorCreacionDTO)
        {
            var existeAutorNombre = await context.Autores.AnyAsync(x => x.Nombre_Autor == autorCreacionDTO.Nombre_Autor);

            if (existeAutorNombre)
            {
                return BadRequest($"Existe autor con el nombre {autorCreacionDTO.Nombre_Autor}");
            }

            var autor = mapper.Map<Autor>(autorCreacionDTO);
            context.Add(autor);
            await context.SaveChangesAsync();

            var autorDTO = mapper.Map<AutorDTO>(autor);

            return CreatedAtRoute("obtenerAutor", new {id = autor.Id}, autorDTO);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put (AutorCreacionDTO autorCreacionDTO, int id)
        {
            var existe = await context.Autores.AnyAsync(x => x.Id == id);

            if (!existe)
            {
                return NotFound();
            }

            var autor = mapper.Map<Autor>(autorCreacionDTO);
            autor.Id = id;

            context.Update(autor);
            await context.SaveChangesAsync();
            return NoContent();
        }

    }
}