using APICinema.DTOS;
using APICinema.Model;
using APICinema.Model.Enums;
using AutoMapper;

namespace APICinema.Mappings
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile() 
        {
            CreateMap<Usuario, UsuarioDto>().ForMember(x=> x.Genero, opt => opt.MapFrom(src=> src.Genero == Genero.Masculino ? "M": "F" ));
            CreateMap<UsuarioCreateDto, Usuario>()
                .ForMember(x => x.Genero, opt => opt.MapFrom(src => src.Genero.ToUpper() == "M" ? Genero.Masculino : Genero.Feminino));
            CreateMap<EnderecoDto, Endereco>();
            CreateMap<Endereco, EnderecoDto>();
            CreateMap<Usuario, UsuarioEditarDto>();
            CreateMap<UsuarioEditarDto, Usuario>()
    .ForMember(dest => dest.Genero, opt => opt.MapFrom(src =>
        src.Genero == "M" ? Genero.Masculino :
        src.Genero == "F" ? Genero.Feminino :
        (Genero?)null
    ))
    .ForAllMembers(opt =>
        opt.Condition((src, dest, srcMember) =>
            srcMember != null &&
            !(srcMember is string s && string.IsNullOrWhiteSpace(s))
        )
    );
        }
    }
}
