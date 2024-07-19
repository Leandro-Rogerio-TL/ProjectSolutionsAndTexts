using System.ComponentModel.DataAnnotations;

namespace TLbankEntities.Entities;

public class UsuarioBase : MyEntityBase
{
    [Required]
    [DataType(DataType.EmailAddress)]
    public string? email { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string? Senha { get; set; }
    [Required]
    [MaxLength(2)]
    public string? Tipo { get; set; }
}