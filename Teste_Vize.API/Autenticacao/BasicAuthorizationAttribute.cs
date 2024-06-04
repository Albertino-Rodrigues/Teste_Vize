using Microsoft.AspNetCore.Authorization;

namespace Teste_Vize.API.Autenticacao;

public class BasicAuthorizationAttribute : AuthorizeAttribute
{
    public BasicAuthorizationAttribute()
    {
        AuthenticationSchemes = BasicAuthenticationDefaults.AuthenticationScheme;
    }
}