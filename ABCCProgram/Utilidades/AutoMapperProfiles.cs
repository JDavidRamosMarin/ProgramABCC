using ABCCProgram.DTOs;
using ABCCProgram.Entidades;
using AutoMapper;

namespace ABCCProgram.Utilidades
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<ProductosCreacionDTO, Productos>();
            CreateMap<Productos, ProductosDTO>();
            CreateMap<ProductosActualizacionDTO, Productos>();
        }
    }
}
