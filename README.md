## Technologies implemented:

- ASP.NET Core 2.2 (with .NET Core 2.2)
 - ASP.NET MVC Core 2.
 - ASP.NET WebApi Core 2.2
 - ASP.NET Identity Core 2.2
- Entity Framework Core 2.2
- .NET Core Native DI
- AutoMapper
- FluentValidator
- MediatR
- Swagger UI

## Architecture:

- Full architecture with responsibility separation concerns, SOLID and Clean Code
- Domain Model Pattern, CQRS and ES concepts
- Domain Driven Design (Layers and Domain Model Pattern)
- Domain Events
- Domain Notification
- CQRS - Command Query Responsibility Segregation
- Event Sourcing
- Unit of Work
- Repository and Generic Repository
- ASP.NET Identity working throught WebAPI services
- Different ways to read and write data
- Unit Tests

## Sobre o desafio:

O desafio proposto pela Stone Payments pode ser acessado aqui -> https://github.com/stone-payments/microtef-hire-me

## Sobre CQRS
CQRS significa Command Query Responsibility Segregation. Como o nome j� diz, � sobre separar a responsabilidade de escrita e leitura de seus dados.

CQRS � um pattern, um padr�o arquitetural assim como Event Sourcing, Transaction Script e etc. 

O CQRS n�o � um estilo arquitetural como desenvolvimento em camadas, modelo client-server, REST e etc.

## Onde posso aplicar CQRS
Atualmente as aplica��es n�o s�o mais para atender 10 usu�rios simult�neos, a maioria das novas aplica��es nascem com
premisas de escalabilidade, performance e disponibilidade, fazer uma aplica��o funcionar bem para cargas de trabalho 
de forma el�stica � uma tarefa extremamente complexa.

O CQRS prega a divis�o de responsabilidade de grava��o e escrita de forma conceitual e f�sica. Isto significa que al�m 
de ter meios separados para gravar e obter um dado os bancos de dados tamb�m s�o diferentes. 

As consultas s�o feitas de 
forma s�ncrona em uma base desnormalizada separada e as grava��es de forma ass�ncrona em um banco normalizado.

![Rela��o cliente-servidor com sonda](image/CQRS_FluxoSimples.jpg)

# Segregar as responsabilidades em QueryStack e CommandStack
A ideia b�sica � segregar as responsabilidades da aplica��o em:

* Command � Opera��es que modificam o estado dos dados na aplica��o.
* Query � Opera��es que recuperam informa��es dos dados na aplica��o.

**Numa arquitetura de N camadas poder�amos pensar em separar as responsabilidades em CommandStack e QueryStack.**

## Swagger

- See the list of APIs: URL: https://localhost:44338/swagger/index.html

## Generation Database

- Run the scrit /sql/GenerateDataBase.sql


![Rela��o cliente-servidor com sonda](image/CQRS_BUS.jpg)