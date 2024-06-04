using Teste_Vize.Dominio.Modelos;

namespace Teste_Vize.Infraestrutura.Repositorios.Interfaces;

public interface IAutenticacaoRepositorio
{
    Task<bool> ValidarCredenciaisAsync(string login, string senha);
    RespostasDeRetorno<AcessoAPI> RegistrarAcesso(AcessoAPI acessoAPI);
}
