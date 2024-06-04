using Teste_Vize.Dominio.Modelos;

namespace Teste_Vize.Servico.Servicos.Interface;

public interface IProdutoServico
{
    IEnumerable<Produto> ListarTodos();
    RespostasDeRetorno<Produto> ListarPorId(int id);
    RespostasDeRetorno<Produto> AdicionarProduto(Produto produto);
    RespostasDeRetorno<Produto> AtualizarProduto(Produto produto);
    RespostasDeRetorno<Produto> DeletarProduto(Produto produto);
    RetornoDashboard ExibirDashboard();
}