using System.ComponentModel.DataAnnotations;

namespace TLbankServices.DTOs;

public class CriarTransferenciaDTO
{
    [Required]
    public long PagadorContaNumero{ get; set; }
    [Required]
    public long BeneficiarioContaNumero { get; set; }
    [Required]
    [Range(1, long.MaxValue, ErrorMessage = "O Valor deve ser maior que 0")]
    public double Valor { get; set; }
}