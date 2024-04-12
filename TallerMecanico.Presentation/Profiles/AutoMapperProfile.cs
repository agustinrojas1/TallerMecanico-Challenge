using AutoMapper;
using TallerMecanico.Models.Dtos;
using TallerMecanico.Models.Models;

namespace TallerMecanico.Presentation.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AutomovilCreateDto, Automovil>();
            CreateMap<MotoCreateDto, Moto>();
            CreateMap<PresupuestoCreateDto, Presupuesto>()
                    .ForMember(dest => dest.Desperfectos, opt => opt.Ignore());

            CreateMap<DesperfectoCreateDto, Desperfecto>();
            CreateMap<RepuestoCreateDto, Repuesto>();

            CreateMap<Presupuesto, PresupuestoQueryDto>()
                .ForMember(dest => dest.Desperfectos, opt => opt.MapFrom(src => src.Desperfectos));

            CreateMap<Desperfecto, DesperfectoQueryDto>()
                .ForMember(dest => dest.Repuestos, opt => opt.MapFrom(src => src.DesperfectoRepuestos
                .Select(dr => dr.Repuesto).ToList().Select(r => new RepuestoQueryDto
                {
                    Id = r.Id,
                    Nombre = r.Nombre,
                    Precio = r.Precio
                })));
        }

    }

}

