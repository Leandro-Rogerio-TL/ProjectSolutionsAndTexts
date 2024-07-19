using TLbankEntities.Entities;

namespace TLbankServices.DTOs;

public class ContaTransferenciaDTO
{
    public long Numero { get; set; }
    public UsuarioBase? Usuario{ get; set; } 
}