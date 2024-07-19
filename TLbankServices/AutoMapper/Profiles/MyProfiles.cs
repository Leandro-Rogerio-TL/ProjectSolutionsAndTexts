using AutoMapper;
using TLbankServices.DTOs;
using TLbankEntities.Entities;

namespace TLbankServices.AutoMapper.Profiles;

public class MyProfiles : Profile
{
    public MyProfiles()
    {
        CreateMap<Transferencia, CriarTransferenciaDTO>().ReverseMap();
        CreateMap<Transferencia, LerTransferenciaDTO>().ReverseMap();
        CreateMap<ContaBase, ContaTransferenciaDTO>().ReverseMap();
        CreateMap<UsuarioPF, UsuarioTransferenciaDTO>()
            .ForMember(dest => dest.Nome, opt => opt.MapFrom(orig => orig.NomeCompleto))
            .ForMember(dest => dest.Documento, opt => opt.MapFrom(orig => orig.CPF))
            .ReverseMap();
        CreateMap<UsuarioPJ, UsuarioTransferenciaDTO>()
            .ForMember(dest => dest.Nome, opt => opt.MapFrom(orig => orig.RazaoSocial))
            .ForMember(dest => dest.Documento, opt => opt.MapFrom(orig => orig.CNPJ))
            .ReverseMap();
    }
}