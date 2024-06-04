using Teste_Vize.Dominio.MensagensConstantes;
using Teste_Vize.Dominio.Modelos;
using Teste_Vize.Infraestrutura.Data;
using Teste_Vize.Repositorios.Interfaces;

namespace Teste_Vize.Repositorios;

public class ProdutoRepositorio : IProdutoRepositorio
{
    private readonly DbContexto _contexto;

    public ProdutoRepositorio(DbContexto contexto)
    {
        _contexto = contexto;
    }

    public RespostasDeRetorno<Produto> ListarPorId(int id)
    {
        var produtoEncontrado = _contexto.Produtos.Find(id);

        try
        {
            if (produtoEncontrado == null)
            {
                return RespostasDeRetorno<Produto>.FalhaNoRetorno(MensagensDeErro.ProdutoNaoEncontrado);
            }
            else
            {
                return RespostasDeRetorno<Produto>.SucessoNoRetorno(produtoEncontrado, MensagensDeSucesso.ProdutoEncontrado);
            }
        }
        catch (Exception)
        {
            return RespostasDeRetorno<Produto>.FalhaNoRetorno(MensagensDeErro.ErroInterno);
        }
    }

    public IEnumerable<Produto> ListarTodos()
    {
        return _contexto.Produtos.ToList();
    }

    public RespostasDeRetorno<Produto> AdicionarProduto(Produto produto)
    {
        var idExiste = _contexto.Produtos
            .Any(p => p.Id == produto.Id);

        try
        {
            if (idExiste)
            {
                return RespostasDeRetorno<Produto>.FalhaNoRetorno(MensagensDeErro.IdUilizado);
            }
            else
            {
                _contexto.Produtos.Add(produto);
                _contexto.SaveChanges();

                return RespostasDeRetorno<Produto>.SucessoNoRetorno(produto, MensagensDeSucesso.ProdutoCadastrado);
            }
        }
        catch (Exception)
        {
            return RespostasDeRetorno<Produto>.FalhaNoRetorno(MensagensDeErro.ErroInterno);
        }
    }

    public RespostasDeRetorno<Produto> AtualizarProduto(Produto produto)
    {
        var idExiste = _contexto.Produtos
            .Any(p => p.Id == produto.Id);

        try
        {
            if (!idExiste)
            {
                return RespostasDeRetorno<Produto>.FalhaNoRetorno(MensagensDeErro.ProdutoNaoEncontrado);
            }
            else
            {
                _contexto.Produtos.Update(produto);
                _contexto.SaveChanges();
                return RespostasDeRetorno<Produto>.SucessoNoRetorno(produto, MensagensDeSucesso.ProdutoAtualizado);
            }
        }
        catch (Exception)
        {
            return RespostasDeRetorno<Produto>.FalhaNoRetorno(MensagensDeErro.ErroInterno);
        }
    }

    public RespostasDeRetorno<Produto> DeletarProduto(Produto produto)
    {
        var idExiste = _contexto.Produtos
            .Any(p => p.Id == produto.Id);

        try
        {
            if (!idExiste)
            {
                return RespostasDeRetorno<Produto>.FalhaNoRetorno(MensagensDeErro.ProdutoNaoEncontrado);
            }
            else
            {
                _contexto.Produtos.Remove(produto);
                _contexto.SaveChanges();
                return RespostasDeRetorno<Produto>.SucessoNoRetorno(produto, MensagensDeSucesso.ProdutoRemovido);
            }
        }
        catch (Exception)
        {
            return RespostasDeRetorno<Produto>.FalhaNoRetorno(MensagensDeErro.ErroInterno);
        }

    }

    public RetornoDashboard ExibirDashboard()
    {
        var dashboard = new RetornoDashboard();

        var dados = _contexto.Produtos
            .GroupBy(p => p.Tipo)
            .Select(g => new Dashboard
            {
                Tipo = g.Key,
                Quantidade = g.Count(),
                MediaPrecoUnitario = g.Average(p => p.PrecoUnitario)
            }).ToList();

        dashboard.Dados.AddRange(dados);

        return dashboard;
    }
}