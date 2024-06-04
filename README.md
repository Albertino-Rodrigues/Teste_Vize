# Teste_Vize

## Desafio proposto

"Precisamos criar uma API de Produto que uma outra aplicação client irá utilizar.
Podemos ter somente o ID, Nome, Tipo e Preço Unitário.
Os possíveis tipos poderão ser “Material” ou “Serviço”."

## Requisitos realizados no teste:

- A api deve realizar o CRUD.
- Dashboard com a quantidade e o preço unitário médio separado por tipo (Material ou Serviço).
- Seguir os padroões REST.
- Utilização do protocolo BASIC para autenticação.
- Constar pelo menos 2 princípios SOLID.
- Usar o banco de dados PostgreSQL para gravar as informações.


## Descrição do projeto

A aplicação foi construída com .NET 6. Para executar será necessário ter essa versão instalada. Segue link para download: https://dotnet.microsoft.com/pt-br/download/dotnet/6.0.
Como proposto no desafio, é necessário ter o PostgreSQL instalado. Você pode baixar o arquivo para instalação aqui: https://www.postgresql.org/download.
A aplicação está dividida em quatro camadas:
- API: possui as rotas de manipulação dos produtos e autenticação para a API, essa é a camada que deve ser executada.
- Dominio: possui as entidades que a aplicação necessita.
- Infraestrutura: possui a parametrização para criação das tabelas no banco de dados, comunicação entre o banco e a api e também realiza a inserção dos dados iniciais no banco.
- Serviço: possui os serviços que implementam as regras de negócio da aplicação e também a comunicação com os dados que estão salvos no banco.


## Orientações para execução

1. Baixe ou repositório.
2. Abra a solução do projeto que está na pasta.
3. Configure o projeto "API" para inicialização.
4. Configure a string de conexão com o banco no arquivo 'appsettings.json' que se encontra no projeto "API", por exemplo: "Server=127.0.0.1;Port=5432;Database=NomeDoBanco;User Id=UsuarioDoBanco;Password=SenhaParaAcesso".
5. Abra o terminal de pacotes NuGet, que se encontra em "Ferramentas > Gerenciador de pacotes NuGet".
6. Execute o comando 'update-database' para criar o banco (caso não tenha criado manualmente) e gerar a carga inicial informada na classe context.
7. Execute a aplicação.
8. Para utilizar os endpoints da API, é necessário autenticar com o usuário criado na carga inicial (Login = admin, Senha = admin).
9. Execute as rotas.
