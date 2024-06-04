using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Text;
using Teste_Vize.Servico.Servicos.Interface;

namespace Teste_Vize.API.Autenticacao;

public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    private readonly IAutenticacaoServico _autenticacaoServico;


    public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock, IAutenticacaoServico autenticacaoServico) : base(options, logger, encoder, clock)
    {
        _autenticacaoServico = autenticacaoServico;
    }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        if (!Request.Headers.ContainsKey("Authorization"))
        {
            return await Task.FromResult(AuthenticateResult.Fail("Missing Authorization header"));
        }

        var authorizationHeader = Request.Headers["Authorization"].ToString();

        if (!authorizationHeader.StartsWith("Basic ", StringComparison.OrdinalIgnoreCase))
        {
            return await Task.FromResult(AuthenticateResult.Fail("Authorization header does not start with 'Basic'"));
        }

        var authBase64Decoded = Encoding.UTF8.GetString(Convert.FromBase64String(authorizationHeader.Replace("Basic ", "", StringComparison.OrdinalIgnoreCase)));
        var authSplit = authBase64Decoded.Split(new[] { ':' }, 2);

        if (authSplit.Length != 2)
        {
            return await Task.FromResult(AuthenticateResult.Fail("Invalid Authorization header format"));
        }


        var login = authSplit[0];
        var senha = authSplit[1];


        var isValid = await _autenticacaoServico.ValidarCredenciaisAsync(login, senha);
        if (!isValid)
        {
            return await Task.FromResult(AuthenticateResult.Fail(string.Format("The secret is incorrect for the client '{0}'", login)));
        }

        var client = new BasicAuthenticationClient
        {
            AuthenticationType = BasicAuthenticationDefaults.AuthenticationScheme,
            IsAuthenticated = true,
            Name = login
        };

        var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(client, new[]
        {
                new Claim(ClaimTypes.Name, login)
            }));

        return await Task.FromResult(AuthenticateResult.Success(new AuthenticationTicket(claimsPrincipal, Scheme.Name)));
    }
}
