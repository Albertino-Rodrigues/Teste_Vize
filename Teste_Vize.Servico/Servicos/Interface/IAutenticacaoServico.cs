using Teste_Vize.Dominio.Modelos;

namespace Teste_Vize.Servico.Servicos.Interface;

public interface IAutenticacaoServico
{
    Task<bool> ValidarCredenciaisAsync(string login, string senha);
    RespostasDeRetorno<AcessoAPI> RegistrarAcesso(AcessoAPI acessoAPI);
}