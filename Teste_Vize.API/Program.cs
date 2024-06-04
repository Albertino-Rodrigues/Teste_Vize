using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Teste_Vize.API.Autenticacao;
using Teste_Vize.Infraestrutura.Data;
using Teste_Vize.Infraestrutura.Repositorios;
using Teste_Vize.Infraestrutura.Repositorios.Interfaces;
using Teste_Vize.Repositorios;
using Teste_Vize.Repositorios.Interfaces;
using Teste_Vize.Servico.Servicos;
using Teste_Vize.Servico.Servicos.Interface;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.InvalidModelStateResponseFactory = context =>
        {
            var erros = context.ModelState.Values.SelectMany(v => v.Errors)
                                                  .Select(e => e.ErrorMessage)
                                                  .ToList();
            return new BadRequestObjectResult(new { Errors = erros });
        };
    });

builder.Services.AddAuthentication()
    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>(BasicAuthenticationDefaults.AuthenticationScheme, null);

builder.Services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();
builder.Services.AddScoped<IProdutoServico, ProdutoServico>();
builder.Services.AddScoped<IAutenticacaoRepositorio, AutenticacaoRepositorio>();
builder.Services.AddScoped<IAutenticacaoServico, AutenticacaoServico>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition(BasicAuthenticationDefaults.AuthenticationScheme,
        new OpenApiSecurityScheme()
        {
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            Scheme = BasicAuthenticationDefaults.AuthenticationScheme,
            In = ParameterLocation.Header,
            Description = "Basic authorization header"
        });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = BasicAuthenticationDefaults.AuthenticationScheme
                }
            },
            new String[] { "Basic" }
        }
    });
});
builder.Services.AddDbContext<DbContexto>(opcao =>
        opcao.UseNpgsql(builder.Configuration.GetConnectionString("ConexaoPrincipal")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();