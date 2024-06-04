using Microsoft.AspNetCore.Mvc;
using Teste_Vize.API.Autenticacao;
using Teste_Vize.Dominio.MensagensConstantes;
using Teste_Vize.Dominio.Modelos;
using Teste_Vize.Servico.Servicos;
using Teste_Vize.Servico.Servicos.Interface;

namespace Teste_Vize.API.Controllers;

[BasicAuthorization]
[ApiController]
[Route("api/[controller]")]
public class AcessoAPIController : ControllerBase
{
    private readonly IAutenticacaoServico _autenticacaoServico;

    public AcessoAPIController(IAutenticacaoServico autenticacaoServico)
    {
        _autenticacaoServico = autenticacaoServico;
    }

    [HttpPost("registrar")]
    public IActionResult RegistrarAcesso([FromHeader] string login, [FromHeader] string senha)
    {
        try
        {
            var acessoAPI = new AcessoAPI { Login = login, Senha = senha };
            var resultado = _autenticacaoServico.RegistrarAcesso(acessoAPI);
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
}