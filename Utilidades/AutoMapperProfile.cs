using AutoMapper;
using apicourseTENNOS.DTOs;
using WebAPIcourse.Models;
namespace apicourseTENNOS.Utilidades
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AutorCreacionDTO, Autor>();
        }
    }
}