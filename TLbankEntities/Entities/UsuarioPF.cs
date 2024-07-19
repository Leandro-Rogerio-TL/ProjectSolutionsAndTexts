using System.ComponentModel.DataAnnotations;

namespace TLbankEntities.Entities;

public class UsuarioPF : UsuarioBase
{
    [Required]
    [RegularExpression(@"^(\w{3,+})(\s\w{3,+})+$", ErrorMessage = "Digite o nome completo! Obs: Não pode ser curto ou conter apenas uma palavra.")]
    public string? NomeCompleto { get; set; }
    [Required]
    [RegularExpression(@"^(\d{11})$", ErrorMessage = "São permitidos apenas numeros e deve possuir 11 caracteres")]
    public string? CPF { get; set; }
}