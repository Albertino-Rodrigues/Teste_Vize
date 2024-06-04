using Teste_Vize.Dominio.Modelos;

namespace Teste_Vize.Repositorios.Interfaces;

public interface IProdutoRepositorio
{
    IEnumerable<Produto> ListarTodos();
    RespostasDeRetorno<Produto> ListarPorId(int id);
    RespostasDeRetorno<Produto> AdicionarProduto(Produto produto);
    RespostasDeRetorno<Produto> AtualizarProduto(Produto produto);
    RespostasDeRetorno<Produto> DeletarProduto(Produto produto);
    RetornoDashboard ExibirDashboard();
}
