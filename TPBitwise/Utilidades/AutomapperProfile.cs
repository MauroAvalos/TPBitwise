using AutoMapper;
using TPBitwise.DTO;
using TPBitwise.Models;

namespace TPBitwise.Utilidades
{
    public class  AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<ProyectoCreacionDTO, Proyecto>().ReverseMap();
            CreateMap<ProyectoDTO, Proyecto>().ReverseMap();

            CreateMap<UsuarioDTO, Usuario>().ReverseMap();
            CreateMap<UsuarioLoginDTO, Usuario>()
                .ForMember(dest => dest.UsuarioId, opt => opt.Ignore());
            CreateMap<Usuario, UsuarioRegistroDTO>().ReverseMap();

            CreateMap<Tarea, TareaDTO>().ReverseMap();
            CreateMap<Tarea, TareaCreacionDTO>().ReverseMap();

            CreateMap<Etiqueta, EtiquetaCreacionDTO>().ReverseMap();
            CreateMap<EtiquetaDTO, Etiqueta>()
            .ForMember(dest => dest.EtiquetaId, opt => opt.Ignore());

            CreateMap<TareaEtiqueta, TareaEtiquetaDTO>().ReverseMap();

            CreateMap<AppUsuario, UsuarioDatosDTO>().ReverseMap();
            CreateMap<AppUsuario, UsuarioDTO>().ReverseMap();
        }
        
    }
}
