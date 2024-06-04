using Teste_Vize.Dominio.Modelos;
using Teste_Vize.Infraestrutura.Repositorios.Interfaces;
using Teste_Vize.Servico.Servicos.Interface;

namespace Teste_Vize.Servico.Servicos;

public class AutenticacaoServico : IAutenticacaoServico
{
    private readonly IAutenticacaoRepositorio _autenticacaoRepositorio;

    public AutenticacaoServico(IAutenticacaoRepositorio autenticacaoRepositorio)
    {
        _autenticacaoRepositorio = autenticacaoRepositorio;
    }

    public RespostasDeRetorno<AcessoAPI> RegistrarAcesso(AcessoAPI acessoAPI)
    {
        var acessoRegistrado = _autenticacaoRepositorio.RegistrarAcesso(acessoAPI);

        if(acessoRegistrado.Sucesso)
        {
            return RespostasDeRetorno<AcessoAPI>.SucessoNoRetorno(acessoRegistrado.Dados, acessoRegistrado.Mensagem);
        }
        else
        {
            return RespostasDeRetorno<AcessoAPI>.FalhaNoRetorno(acessoRegistrado.Mensagem);
        }
    }

    public async Task<bool> ValidarCredenciaisAsync(string login, string senha)
    {
        return await _autenticacaoRepositorio.ValidarCredenciaisAsync(login, senha);
    }
}