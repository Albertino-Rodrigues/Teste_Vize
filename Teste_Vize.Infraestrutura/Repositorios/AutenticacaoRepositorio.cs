using Microsoft.EntityFrameworkCore;
using Teste_Vize.Dominio.MensagensConstantes;
using Teste_Vize.Dominio.Modelos;
using Teste_Vize.Infraestrutura.Data;
using Teste_Vize.Infraestrutura.Repositorios.Interfaces;

namespace Teste_Vize.Infraestrutura.Repositorios;

public class AutenticacaoRepositorio : IAutenticacaoRepositorio
{
    private readonly DbContexto _contexto;

    public AutenticacaoRepositorio(DbContexto contexto)
    {
        _contexto = contexto;
    }

    public RespostasDeRetorno<AcessoAPI> RegistrarAcesso(AcessoAPI acessoAPI)
    {
        var acessoRegistrado = _contexto.AcessoAPI
            .Any(a => a.Login.Trim().ToUpper() == acessoAPI.Login.Trim().ToUpper());
        try
        {
            if (!acessoRegistrado)
            {
                _contexto.Add(acessoAPI);
                _contexto.SaveChanges();

                return RespostasDeRetorno<AcessoAPI>.SucessoNoRetorno(acessoAPI, MensagensDeSucesso.AcessoRegistrado);
            }
            else
            {
                return RespostasDeRetorno<AcessoAPI>.FalhaNoRetorno(MensagensDeErro.LoginJaCadastrado);
            }

        }
        catch (Exception)
        {
            return RespostasDeRetorno<AcessoAPI>.FalhaNoRetorno(MensagensDeErro.ErroInterno);
        }
    } 

    public async Task<bool> ValidarCredenciaisAsync(string login, string senha)
    {
        var acessoRegistrado = await _contexto.AcessoAPI
            .SingleOrDefaultAsync(a => a.Login == login && a.Senha == senha);

        return acessoRegistrado != null;
    }

}