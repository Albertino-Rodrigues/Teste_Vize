using Microsoft.AspNetCore.Mvc;
using Teste_Vize.API.Autenticacao;
using Teste_Vize.Dominio.MensagensConstantes;
using Teste_Vize.Dominio.Modelos;
using Teste_Vize.Servico.Servicos.Interface;

namespace Teste_Vize.Controllers;

[BasicAuthorization]
[Route("api/[controller]")]
[ApiController]
public class ProdutosController : ControllerBase
{
    private readonly IProdutoServico _produtoServico;

    public ProdutosController(IProdutoServico produtoServico)
    {
        _produtoServico = produtoServico;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Produto>> ListarTodos()
    {
        var produtos = _produtoServico.ListarTodos();
        return Ok(produtos);
    }

    [HttpGet("{id}")]
    public IActionResult ListarPorId(int id)
    {
        try
        {
            var resultado = _produtoServico.ListarPorId(id);
            if (resultado.Sucesso)
            {
                return Ok(new { mensagem = resultado.Mensagem, dados = resultado.Dados });
            }
            else
            {
                return NotFound(resultado.Mensagem);
            }
        }
        catch (Exception)
        {
            return StatusCode(500, MensagensDeErro.ErroInterno);
        }
    }

    [HttpPost]
    public IActionResult AdicionarProduto([FromBody] Produto produto)
    {
        try
        {
            var resultado = _produtoServico.AdicionarProduto(produto);
            if (resultado.Sucesso)
            {
                return Ok(new { mensagem = resultado.Mensagem, dados = resultado.Dados });
            }
            else
            {
                return BadRequest(resultado.Mensagem);
            }
        }
        catch (Exception)
        {
            return StatusCode(500, MensagensDeErro.ErroInterno);
        }
    }

    [HttpPut("{id}")]
    public IActionResult AtualizarProduto([FromBody] Produto produto)
    {
        try
        {
            var resultado = _produtoServico.AtualizarProduto(produto);
            if (resultado.Sucesso)
            {
                return Ok(new { mensagem = resultado.Mensagem, dados = resultado.Dados });
            }
            else
            {
                return BadRequest(resultado.Mensagem);
            }
        }
        catch (Exception)
        {
            return StatusCode(500, MensagensDeErro.ErroInterno);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult DeletarProduto(Produto produto)
    {
        try
        {
            var resultado = _produtoServico.DeletarProduto(produto);
            if (resultado.Sucesso)
            {
                return Ok(new { mensagem = resultado.Mensagem, dados = resultado.Dados });
            }
            else
            {
                return BadRequest(resultado.Mensagem);
            }
        }
        catch (Exception)
        {
            return StatusCode(500, MensagensDeErro.ErroInterno);
        }
    }

    [HttpGet("dashboard")]
    public IActionResult ExibirDashboard()
    {
        var resultado = _produtoServico.ExibirDashboard();
        return Ok(resultado);
    }
}