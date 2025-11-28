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
            CreateMap<Usuario, UsuarioDto>().ForMember(x => x.Genero, opt => opt.MapFrom(src => MapGeneroSaida(src.Genero)));
            CreateMap<UsuarioCreateDto, Usuario>()
                .ForMember(x => x.Genero, opt => opt.MapFrom(src => MapGeneroEntrada(src.Genero)));
            CreateMap<EnderecoDto, Endereco>();
            CreateMap<Endereco, EnderecoDto>();
            CreateMap<Usuario, UsuarioEditarDto>();
            CreateMap<UsuarioEditarDto, Usuario>()
    .ForMember(dest => dest.Genero, opt => opt.MapFrom(src =>
        src.Genero == "M" ? Genero.Masculino :
        src.Genero == "F" ? Genero.Feminino :
        src.Genero == "B" ? Genero.NaoBinario :
        src.Genero == "N" ? Genero.PrefiroNaoInformar : 
         (Genero?)null
    ))
    .ForAllMembers(opt =>
        opt.Condition((src, dest, srcMember) =>
            srcMember != null &&
            !(srcMember is string s && string.IsNullOrWhiteSpace(s))
        )
    );
        }
        public static Genero MapGeneroEntrada(string genero)
        {
            if (string.IsNullOrWhiteSpace(genero))
                return Genero.PrefiroNaoInformar;

            return genero.ToUpper() switch
            {
                "M" => Genero.Masculino,
                "F" => Genero.Feminino,
                "B" => Genero.NaoBinario,
                "N" => Genero.PrefiroNaoInformar,
                _ => Genero.PrefiroNaoInformar
            };
        }

        public static string MapGeneroSaida(Genero genero)
        {
            return genero switch
            {
                Genero.Masculino => "M",
                Genero.Feminino => "F",
                Genero.NaoBinario => "B",
                Genero.PrefiroNaoInformar => "N",
                _ => "N"
            };
        }
    }
}
