using System.ComponentModel.DataAnnotations;

namespace TLbankEntities.Entities;

public class UsuarioPJ : UsuarioBase
{
    [Required]
    [RegularExpression(@"^(\w{3,+})(\s.+)+$", ErrorMessage = "Informar Razão Socia completa! Obs: Não pode conter apenas uma palavra.")]
    public string? RazaoSocial { get; set; }
    [Required]
    [RegularExpression(@"^(\d{14})$", ErrorMessage = "São permitidos apenas numeros e deve possuir 11 caracteres")]
    public string? CNPJ { get; set; }
}