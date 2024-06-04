using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Teste_Vize.Dominio.MensagensConstantes;

namespace Teste_Vize.Dominio.Modelos;

public enum TipoProduto
{
    Material = 0,
    Servico = 1,
}

public class Produto
{
    public int Id { get; set; }

    [Required(ErrorMessage = MensagensDeErro.CampoObrigatorio), 
        MaxLength(50, ErrorMessage = "Tamanho máximo: 50 caracteres.")]
    public string Nome { get; set; }

    [Required(ErrorMessage = MensagensDeErro.CampoObrigatorio),
        Range(0, 1, ErrorMessage = "O valor informado para o Tipo deve ser 0 para Material ou 1 para Serviço.")]
    public TipoProduto Tipo { get; set; }

    [Required(ErrorMessage = MensagensDeErro.CampoObrigatorio),
        Range(0, 9999999, ErrorMessage = "Tamanho máximo: 7 dígitos.")]
    public decimal PrecoUnitario { get; set; }

    public Produto() { }
    public Produto(int id, string nome, TipoProduto tipo, decimal precoUnitario)
    {
        Id = id;
        Nome = nome;
        Tipo = tipo;
        PrecoUnitario = precoUnitario;
    }
}