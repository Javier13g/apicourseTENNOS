using AutoMapper;
using WebAPIcourse.DTOs;
using WebAPIcourse.Models;

namespace WebAPIcourse.Utilidades
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AutorCreacionDTO, Autor>();
            CreateMap<Autor, AutorDTO>();
            CreateMap<Autor, AutorDTOConLibros>()
                 .ForMember(autorDTO => autorDTO.Libros, opciones => opciones.MapFrom(MapAutorDTOLibros));

            CreateMap<LibroCreacionDTO, Libro>()
                 .ForMember(LibroDTO => LibroDTO.AutoresLibros, opciones => opciones.MapFrom(MapAutoresLibros));
            CreateMap<Libro, LibroDTO>();
            CreateMap<Libro, LibroDTOConAutores>()
                 .ForMember(LibroDTO => LibroDTO.autores, opciones => opciones.MapFrom(MapLibroDTOAutores));
            CreateMap<LibroPatchDTO, Libro>().ReverseMap();


            CreateMap<ComentarioCreacionDTO, Comentario>();
            CreateMap<Comentario, ComentarioDTO>();

        }

        private List<AutoresLibro> MapAutoresLibros(LibroCreacionDTO libroCreacionDTO, Libro libro)
        {
            var resultado = new List<AutoresLibro>();

            if (libroCreacionDTO.AutoresIds == null) { return resultado; }

            foreach (var autorId in libroCreacionDTO.AutoresIds)
            {
                resultado.Add(new AutoresLibro() { AutorId = autorId });
            }

            return resultado;
        }

        private List<AutorDTO> MapLibroDTOAutores(Libro libro, LibroDTO libroDTO)
        {
            var resultado = new List<AutorDTO>();

            if (libro.AutoresLibros == null) { return resultado; }

            foreach (var autorLibro in libro.AutoresLibros)
            {
                resultado.Add(new AutorDTO()
                {
                    Id = autorLibro.AutorId,
                    Nombre_Autor = autorLibro.Autor.Nombre_Autor
                });
            }
            return resultado;
        }

        private List<LibroDTO> MapAutorDTOLibros(Autor autor, AutorDTO autorDTO)
        {
            var resultado = new List<LibroDTO>();

            if (autor.AutoresLibros == null) { return resultado; }

            foreach (var autorLibro in autor.AutoresLibros)
            {
                resultado.Add(new LibroDTO()
                {
                    Id = autorLibro.LibroId,
                    Titulo = autorLibro.Libro.Titulo
                });
            }
            return resultado;
        }
    }
}
