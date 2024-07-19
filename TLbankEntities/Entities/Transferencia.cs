using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TLbankEntities.Entities;

public class Transferencia : MyEntityBase
{
    [Required]
    public long PagadorContaNumero{ get; set; }
    [ForeignKey("PagadorContaNumero")]
    public ContaBase? PagadorConta { get; }
    [Required]
    public long BeneficiarioContaNumero { get; set; }
    [ForeignKey("BeneficiarioContaNumero")]
    public ContaBase? BeneficiarioConta { get;}
    [Required]
    [DataType(DataType.Currency)]
    public double Valor { get; set; }
    [Required]
    [DataType(DataType.DateTime)]
    public DateTime DataHora { get; set; } = DateTime.Now;
    public void Transferir()
    {

    }
}