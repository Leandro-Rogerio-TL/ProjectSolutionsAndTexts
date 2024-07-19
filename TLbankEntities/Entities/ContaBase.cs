using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TLbankEntities.Entities;

public class ContaBase : MyEntityBase
{
    [Required]
    public long Numero { get; set; }
    [Required]
    [DataType(DataType.Currency)]
    public double Saldo { get; set; }
    [Required]
    public List<string>? Funcoes { get; set; }
    [Required]
    [ForeignKey(nameof (Usuario))]
    public Guid UsuarioId { get; set; }
    public UsuarioBase? Usuario{ get; set; }
    public IEnumerable<Transferencia>? TransacaoCredito { get; set; }
    public IEnumerable<Transferencia>? TransacaoDebito { get; set; }
}