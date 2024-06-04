using System.Security.Principal;

namespace Teste_Vize.API.Autenticacao;

public class BasicAuthenticationClient : IIdentity
{
    public string? AuthenticationType { get; set; }

    public bool IsAuthenticated { get; set; }

    public string? Name { get; set; }
}
