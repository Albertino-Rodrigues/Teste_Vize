using Teste_Vize.Dominio.MensagensConstantes;
using Teste_Vize.Dominio.Modelos;
using Teste_Vize.Repositorios.Interfaces;
using Teste_Vize.Servico.Servicos.Interface;

namespace Teste_Vize.Servico.Servicos;

public class ProdutoServico : IProdutoServico
{
    private readonly IProdutoRepositorio _produtoRepositorio;

    public ProdutoServico(IProdutoRepositorio produtoRepositorio)
    {
        _produtoRepositorio = produtoRepositorio;
    }

    public IEnumerable<Produto> ListarTodos()
    {
        return _produtoRepositorio.ListarTodos();
    }

    public RespostasDeRetorno<Produto> ListarPorId(int id)
    {
        try
        {
            var produtoEncontrado = _produtoRepositorio.ListarPorId(id);
            if (produtoEncontrado.Sucesso)
            {
                return RespostasDeRetorno<Produto>.SucessoNoRetorno(produtoEncontrado.Dados, produtoEncontrado.Mensagem);
            }
            else
            {
                return RespostasDeRetorno<Produto>.FalhaNoRetorno(produtoEncontrado.Mensagem);
            }
        }
        catch (Exception)
        {
            return RespostasDeRetorno<Produto>.FalhaNoRetorno(MensagensDeErro.ErroInterno);
        }
    }

    public RespostasDeRetorno<Produto> AdicionarProduto(Produto produto)
    {
        var produtoAdicionado = _produtoRepositorio.AdicionarProduto(produto);
        try
        {
            if (produtoAdicionado.Sucesso)
            {
                return RespostasDeRetorno<Produto>.SucessoNoRetorno(produtoAdicionado.Dados, produtoAdicionado.Mensagem);
            }
            else
            {
                return RespostasDeRetorno<Produto>.FalhaNoRetorno(produtoAdicionado.Mensagem);
            }

        }
        catch (Exception)
        {
            return RespostasDeRetorno<Produto>.FalhaNoRetorno(MensagensDeErro.ErroInterno);
        }
    }

    public RespostasDeRetorno<Produto> AtualizarProduto(Produto produto)
    {
        var produtoAtualizado = _produtoRepositorio.AtualizarProduto(produto);

        try
        {
            if (produtoAtualizado.Sucesso)
            {
                return RespostasDeRetorno<Produto>.SucessoNoRetorno(produto, produtoAtualizado.Mensagem);
            }
            else
            {
                return RespostasDeRetorno<Produto>.FalhaNoRetorno(produtoAtualizado.Mensagem);
            }
        }
        catch (Exception)
        {
            return RespostasDeRetorno<Produto>.FalhaNoRetorno(MensagensDeErro.ErroInterno);
        }
    }

    public RespostasDeRetorno<Produto> DeletarProduto(Produto produto)
    {
        var produtoRemovido = _produtoRepositorio.DeletarProduto(produto);

        try
        {
            if (produtoRemovido.Sucesso)
            {
                return RespostasDeRetorno<Produto>.SucessoNoRetorno(produtoRemovido.Dados, produtoRemovido.Mensagem);
            }
            else
            {
                return RespostasDeRetorno<Produto>.FalhaNoRetorno(produtoRemovido.Mensagem);
            }
        }
        catch (Exception)
        {
            return RespostasDeRetorno<Produto>.FalhaNoRetorno(MensagensDeErro.ErroInterno);
        }
    }

    public RetornoDashboard ExibirDashboard()
    {
        return _produtoRepositorio.ExibirDashboard();
    }
}