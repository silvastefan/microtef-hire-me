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

## Used Software
* Microsoft Visual Studio Professional 2019 (vers�o 16.0.2)
* Microsoft SQL Server 2017 (RTM-CU13) (KB4466404) - 14.0.3048.4 (X64) Developer Edition 

## Sobre o desafio:

O desafio proposto pela Stone Payments pode ser acessado aqui -> https://github.com/stone-payments/microtef-hire-me

Para resolver o desafio foi necess�rio criar 4 projetos distintos:
1. **AmonRa - cliente WPF**
2. **EFCoreMapStone - entity framework, cria o banco de dados, as tabelas, PK�s e FK�s**
3. **UnitTesteKarnakStone - respons�vel por realizar os testes unit�rios e de integra��o**
4. **KarnakCore - o cora��o do projeto, respons�vel por tudo, � o cara!**

# O projeto AmonRa - Cliente WPF

O nome AmonRa foi escolhido por se tratar do pai dos Deuses, o senhor da verdade, no antigo egito.

Para atender aos requisitos do desafio, foram criadas telas adicionais:

![AmonRa - Cliente WPF - Tela Transa��es](image/amonra_cliente_wpf_tela_transacoes.jpg)
Cliente WPF - Tela Transa��es

![AmonRa - Cliente WPF - Tela Tipo Transa��o](image/amonra_cliente_wpf_tela_tipo_transacao.jpg)
Cliente WPF - Tela Tipo Transa��es

![AmonRa - Cliente WPF - Tela Status Transa��o](image/amonra_cliente_wpf_tela_status_transacao.jpg)
Cliente WPF - Tela Tipo Transa��es

![AmonRa - Cliente WPF - Tela Bandeira Cart�o](image/amonra_cliente_wpf_tela_bandeira_cartao.jpg)
Cliente WPF - Tela Bandeira Cartao

![AmonRa - Cliente WPF - Tela Tipo Cart�o](image/amonra_cliente_wpf_tela_tipo_cartao.jpg)
Cliente WPF - Tela Tipo Cart�o

![AmonRa - Cliente WPF - Tela Clientes](image/amonra_cliente_wpf_tela_cliente.jpg)
Cliente WPF - Tela Clientes

![AmonRa - Cliente WPF - Tela Cart�es](image/amonra_cliente_wpf_tela_cartoes.jpg)
Cliente WPF - Tela Cart�es

![AmonRa - Cliente WPF - Tela Listagem Transa��es](image/amonra_cliente_wpf_tela_listagem_transacoes.jpg)
Cliente WPF - Tela Listagem Transacoes

![AmonRa - Cliente WPF - Tela Sondagem das Transa��es](image/amonra_cliente_wpf_tela_sondagem_das_transacoes.jpg)
Cliente WPF - Tela Sondagem das Transacoes

![AmonRa - Cliente WPF - Tela Cadastro de Clientes](image/amonra_cliente_wpf_tela_cadastro_cliente.jpg)
Cliente WPF - Tela Cadastro Cliente

O projeto est� estruturado da seguinte forma:
1. **Pasta Common**: classes comuns ao projeto
	* Classe StringCipher.cs: respons�vel por realizar a criptografia e descriptografia da senha
2. **Pasta Core**: respons�vel por efetuar transa��es
	* Classe TransactionServer.cs: enviar transa��es para o servidor Karnak  
3. **Pasta Model**: os modelos de dados		  
	* S�o as classes que ajudam na realiza��o dos parser�s dos dados que s�o enviados para o servidor ou que chegam do mesmo
4. **Pasta SendRequestToServer**: enviar requisi��es para o servidor Karnak 
	* S�o as classes que realizam conex�o diretamente com o api rest do servidor Karnak
5. **Pasta Services**: s�o os servi�os que chamam as classes do passo 4
	* As telas WPF chamam as classes de servi�os, que por sua vez chamam as classes do passo 4

### Cat�logo de Cart�es Virtuais
S�o os cart�es cadastrados no banco de dados, as informa��es dos cart�es s�o:
1. N�mero do cart�o (cardnumber)
2. Senha do cart�o (password), a senha ser� exigida somente para cart�es com chip
3. Valor da transa��o (amount)
4. Tipo da transa��o (cr�dito ou d�bito)
5. Pacelas, quantidade de parcelas exibida somente para compras do tipo cr�dito
6. Validade do cart�o
7. Bandeira do cart�o (visa, master, amex)

### Sondagem das Transa��es
Para ver as transa��es realizads por algum cart�o, � necess�rio escolher um cart�o na tela da **Listagem Transa��es**.

### Listagem Transa��es
S�o todas as transa��es realizadas pelo servidor. 
� poss�vel acompanhar o hist�rico das transa��es de um determinado cart�o.
Todas as transa��es possuem status de **aprovada** ou **negada**.

## Fun��es dispon�veis por tela:
1. **Tipo Transa��o**
	* Incluir
	* Alterar
	* Excluir
	* Consultar
		* Por nome
		* Por id
	* Listagem
	* Historico
2. **Status Transa��o**
	* Incluir
	* Alterar
	* Excluir
	* Consultar
		* Por nome
		* Por id
	* Listagem
	* Historico
3. **Bandeira Cart�o**
	* Incluir
	* Alterar
	* Excluir
	* Consultar
		* Por nome
		* Por id
	* Listagem
	* Historico
4. **Tipo Cart�o**
	* Incluir
	* Alterar
	* Excluir
	* Consultar
		* Por nome
		* Por id
	* Listagem
	* Historico
5. **Clientes**
	* Incluir
	* Alterar
	* Excluir
	* Consultar
		* Por nome
		* Por id
	* Listagem
	* Historico
6. **Cart�es**
	* Incluir
	* Alterar
	* Excluir
	* Consultar
		* Por nome
		* Por id
	* Listagem
	* Historico
7. **Transa��es**
	* Incluir
	* Consultar
		* Por id
	* Sondagem das transa��es
	* Listagem somente das transa��es
	* Listagem das transa��es com relacionamento de dados

## Sobre CQRS

CQRS significa Command Query Responsibility Segregation. Como o nome j� diz, � sobre separar a responsabilidade de escrita e leitura de seus dados.

CQRS � um pattern, um padr�o arquitetural assim como Event Sourcing, Transaction Script e etc. 

O CQRS n�o � um estilo arquitetural como desenvolvimento em camadas, modelo client-server, REST e etc.

## Onde posso aplicar CQRS

Atualmente as aplica��es n�o s�o mais para atender 10 usu�rios simult�neos, a maioria das novas aplica��es nascem com
premisas de escalabilidade, performance e disponibilidade, fazer uma aplica��o funcionar bem para cargas de trabalho 
de forma el�stica � uma tarefa extremamente complexa.

O CQRS prega a divis�o de responsabilidade de grava��o e escrita de forma conceitual e f�sica. 

Isto significa que al�m de ter meios separados para gravar e obter um dado os bancos de dados tamb�m s�o diferentes. 

As consultas s�o feitas de forma s�ncrona em uma base desnormalizada separada e as grava��es de forma ass�ncrona em um banco normalizado.

![Rela��o cliente-servidor com sonda](image/CQRS_FluxoSimples.jpg)

# Segregar as responsabilidades em QueryStack e CommandStack

A ideia b�sica � segregar as responsabilidades da aplica��o em:

* Command � Opera��es que modificam o estado dos dados na aplica��o.
* Query � Opera��es que recuperam informa��es dos dados na aplica��o.

**Para resolver o desafio foi utilizado uma arquitetura de N camadas, separarando as responsabilidades em CommandStack e QueryStack.**

## QueryStack

A QueryStack � uma camada s�ncrona que recupera os dados de um banco de leitura desnormalizado.

## CommandStack

O CommandStack por sua vez � potencialmente ass�ncrono. 

O CommandStack segue uma abordagem behavior-centric onde toda inten��o de neg�cio � inicialmente disparada pela UI como um caso de uso. 

Utilizamos o conceito de Commands para representar uma inten��o de neg�cio. 

Os Commands s�o declarados de forma imperativa (ex. Transaction) e s�o disparados assincronamente no formato de eventos, 
s�o interpretados pelos CommandHandlers e retornam um evento de sucesso ou falha.

Toda vez que um Command � disparado e altera o estado de uma entidade no banco de grava��o um processo tem que ser disparado para 
os agentes que ir�o atualizar os dados necess�rios no banco de leitura.

![Rela��o cliente-servidor com sonda](image/CQRS_BUS.jpg)


## Vantagens de utilizar CQRS

A implementa��o do CQRS quebra o conceito monol�tico cl�ssico de uma implementa��o de arquitetura em N camadas onde todo o processo 
de escrita e leitura passa pelas mesma camadas e concorre entre si no processamento de regras de neg�cio e uso de banco de dados.

Este tipo de abordagem aumenta a disponibilidade e escalabilidade da aplica��o e a melhoria na performance surge principalmente pelos aspectos:
* Todos comandos s�o ass�ncronos e processados em fila, assim diminui-se o tempo de espera.
* Os processos que envolvem regras de neg�cio existem apenas no sentido da inclus�o ou altera��o do estado das informa��es.
* As consultas na QueryStack s�o feitas de forma separada e independente e n�o dependem do processamento da CommandStack.
* � poss�vel escalar separadamente os processos da CommandStack e da QueryStack.
 
Uma outra vantagem de utilizar o CQRS � que toda representa��o do seu dom�nio ser� mais expressiva e refor�ar� a utiliza��o da linguagem ub�qua 
nas inten��es de neg�cio.

Toda a implementa��o do CQRS pattern pode ser feito manualmente, sendo necess�rio escrever diversos tipos de classes para cada aspecto, por�m 
� poss�vel encontrar alguns frameworks de CQRS que v�o facilitar um pouco a implementa��o e reduzir o tempo de codifica��o.

Apesar da minha prefer�ncia ser sempre codificar tudo por conta pr�pria eu encontrei alguns frameworks bem interessantes que servem inclusive 
para estudo e melhoria do entendimento no assunto.




## Swagger

- See the list of APIs: URL: https://localhost:44338/swagger/index.html

## Generation Database

- Run the scrit /sql/GenerateDataBase.sql


