using Application.Autores.Queries.Common;
using Application.Editoriales.Queries.Common;
using Application.Libros.Queries.Common;
using AutoMapper;
using Domain.Entities;
using System.Linq;

namespace Application.Common.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Autor, AutorDto>();

            CreateMap<Editorial, EditorialDto>();

            CreateMap<Libro, LibroDto>()
               .ForMember(dest => dest.Editorial, opt => opt.MapFrom(src => src.IdEditorialNavigation))
               .ForMember(dest => dest.Autores, opt => opt.MapFrom(src => src.autorLibro.Select(al => al.Autor)));
        }
    }
}
