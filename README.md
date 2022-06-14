# fwChallenge
Essa é uma solução SPA com Angular 13 e .NET 6. Com os principios da Arquitetura Clean Code.

Pré-requisitos
- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0);

#### Banco de Dados:
  - Bando de dados utilizado: SQL Server;
  - Está utilizando a ferramenta de migração automática. 
  - Existe uma flag no src/WebUI/appsettings.json "UseInMemoryDatabase", para utilizar o banco em memória. Por padrão está como true. Caso precise criar o banco é só configurar a connectionString e mudar essa mesma flag para false;

#### Executar Projeto: 
  - Entre na pasta `src/WebUI` e execute o comando `dotnet run` a aplicação;
  - Console exibirá o endereço do projeto. Navegue até https://localhost:5001/

#### Hangfire
 - Hangfire para agendar, enfileirar e executar tarefas em background; 
 - Está disponível um dashboard no seguinte caminho: https://localhost:5001/hangfire

#### Testes
 - NUnit e Moq;
 
#### Demais Tecnologias
  - CQRS com MediatR;
  - Validações com FluentValidation;
  - Mapeamento com AutoMapper;
  - ORM: Entity Framework Core;
  - Web API ASP.NET Core;
  - Front-end Angular 13;
  - Open API NSwag;

![Captura de tela 2022-06-14 115047 - Copia](https://user-images.githubusercontent.com/19472422/173638571-309f2351-93bf-4947-90b9-6c4af5811a38.png)

![Captura de tela 2022-06-14 114951 - Copia](https://user-images.githubusercontent.com/19472422/173638691-aa95c182-892a-4baf-bd42-fd0702bf511f.png)

![Captura de tela 2022-06-14 115023 - Copia](https://user-images.githubusercontent.com/19472422/173638716-59d62879-3ac3-405d-9614-b513ea7ed45b.png)

![Captura de tela 2022-06-14 115133 - Copia](https://user-images.githubusercontent.com/19472422/173638737-ead98438-8229-4958-a4bd-e84ed653bae7.png)




