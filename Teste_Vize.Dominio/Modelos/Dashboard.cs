using System.ComponentModel.DataAnnotations;

namespace Teste_Vize.Dominio.Modelos;

public class Dashboard
{
    public TipoProduto Tipo { get; set; }
    public int Quantidade { get; set; }
    public decimal MediaPrecoUnitario { get; set; }
}