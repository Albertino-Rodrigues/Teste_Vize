using System.ComponentModel.DataAnnotations;
using Teste_Vize.Dominio.MensagensConstantes;

namespace Teste_Vize.Dominio.Modelos;

public class AcessoAPI
{
    public int AcessoId { get; set; }

    [Required(ErrorMessage = MensagensDeErro.CampoObrigatorio), 
        MaxLength(15, ErrorMessage = "Tamanho máximo: 15 caracteres.")]
    public string Login { get; set; }

    [Required(ErrorMessage = MensagensDeErro.CampoObrigatorio), 
        MaxLength(8, ErrorMessage = "Tamanho máximo: 8 caracteres."), 
        DataType(DataType.Password)]
    public string Senha { get; set; }
    
}