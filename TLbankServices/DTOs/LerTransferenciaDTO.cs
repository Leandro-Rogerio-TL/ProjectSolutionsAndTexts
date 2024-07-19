using TLbankEntities.Entities;

namespace TLbankServices.DTOs;

public class LerTransferenciaDTO
{
    public long PagadorContaNumero{ get; }
    public ContaBase? contaPagador {get;}
    public long BeneficiarioContaNumero { get; }
    public ContaBase? ContaBeneficiario {get;}
    public double Valor { get; set; }
}