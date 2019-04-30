## Technologies Implemented:
- ASP.NET Core 2.2 (with .NET Core 2.2)
- ASP.NET MVC Core 2.2
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
- Integration Tests

## Used Software
* Microsft Windows 10 Pro
* Microsoft Visual Studio Professional 2019 (vers�o 16.0.2)
* Docker Desktop Community Version 2.0.0.3 (31259) - Channel: stable - Build: 8858db3
* Microsoft SQL Server 2017 (RTM-CU13) (KB4466404) - 14.0.3048.4 (X64) Developer Edition 
* SQL Server Management Studio v17.4

## Sobre o Desafio:
O desafio proposto pela Stone Payments pode ser acessado aqui -> https://github.com/stone-payments/microtef-hire-me

Basicamente o desafio consiste na implementa��o de um sistema que simule o processo de uma transa��o financeira.

Para simular um sistema de transa��o financeira foi implementado:
1. **Cliente WPF**
2. **Servidor de comunica��es**

## Sobre as Regras de Neg�cio do Desafio Proposto pela Stone
1. **Cliente WPF (AmonRa)**
	
	* Deve haver 4 telas principais:
		* **Tela de transa��o**: input dos dados da transa��o e envio da transa��o para o servidor
		* **Tela de consulta das transa��es efetuadas**: lista das transa��es efetuadas
		* **Sondagem das transa��es**: listagem de todas as opera��es realizadas referente a um �nico cart�o
		* **Cadastro de clientes**: dever� ser capaz de cadastrar clientes que possam passar transa��es
	
	* Cat�logo de cart�es virtuais com o n�mero razo�vel de cart�es para testar diferentes cen�rios
		* **Propriedades b�sicas**
			* A senha de cada cart�o do cat�logo deve estar criptografada de algum jeito
			* Com esse cat�logo, a verifica��o da senha do cart�o deve ser feita apenas pelo servidor

2. **Servidor Comunica��es (Karnak)**
	* O servidor ir� simular justamente o que a Stone �, uma **adquirente**
	* Tipos de cart�o aceitos: **cr�dito** e **d�bito**
	* Bandeiras: **Visa**, **MasterCard**, **American Express**
	* O servidor deve esperar por uma transa��o

3. **Limite de Cr�dito**
	* O limite de cr�dito para cada cliente deve ser considerado

4. **Comunica��o entre cliente e servidor**
	* A comunica��o pode acontecer em JSON ou XML

## Como o desafio foi resolvido

### Sobre a Senha
Como em qualquer transa��o do Mundo real, na solu��o do desafio proposta n�o foi diferente. 

Senha sempre � uma quest�o delicada, para n�o termos nenhum problema as senhas **sempre s�o transmitidas de forma criptografada**.

As senhas enviadas do cliente WPF (AmonRa) para o servidor de comunica��es (Karnak) s�o transmitidas de forma criptografada utilizando criptografia de 256 bits.

A verifica��o da senha fica a cargo do servidor de comunica��es (Karnak), o qual verifica se a senha informada � a mesma armazenada no banco de dados.

Todas as senhas armazenadas no banco de dados s�o criptografadas utilizando criptografia de 256 bits.

Veja abaixo as senhas criptografadas no banco de dados.
![AmonRa - Banco de dados - Senhas Criptografadas](image/senhas_criptografadas_armazenadas_bd.png)

**Os cart�es armazenados no banco de dados possuem senha 985471**

### Sobre o Docker
O banco de dados **Microsoft SQL Server** foi instalado dentro de um container Docker

Os procedimentos de instala��o do Microsoft SQL Server dentro de um container Docker podem ser visualizadas aqui -> https://medium.com/@renato.groffe/net-sql-server-2017-parte-1-executando-o-sql-server-em-um-container-docker-83abbed8eb7e

Os dados utilizados para instala��o:
1. Nome do servidor: localhost, 11433
2. Autentica��o:		
	* Usuario: sa
	* Senha: DockerSql2017!
3. O scrit sql para gera��o dos objetos est� aqui -> https://github.com/silvastefan/microtef-hire-me/blob/master/Desafio_Stone/KarnakCore/sql/GenerateDataBase.sql
4. O backup do banco de dados pode ser encontado aqui -> https://github.com/silvastefan/microtef-hire-me/blob/master/Desafio_Stone/KarnakCore/sql/KarnakStoneV13.bak

### Sobre o Microsoft SQL Server
Os dados s�o armazenados no banco de dados Microsoft SQL Server.

A estrutura do banco de dados:

![AmonRa - Banco de dados - Estrutura](image/sql_server_estrutura_tabelas.png)

### Biblioteca de Terceiros
Para realizar a criptografia e descriptografia da senha foi utilizado a classe **StringCipher**.

### Mapemanento ORM
Para atender ao desafio proposto pela Stone foi estruturado um banco de dados com algumas tabelas b�sicas para a opera��o do sistema.

O sistema � composto por sete tabelas, abaixo suas estruturas e seus relacionamentos.

![AmonRa - Banco de dados - Mapeamento ORM](image/banco_de_dados_relacionamentos.png)
Banco de dados - Mapeamento ORM

### Poss�veis Retornos do Servidor
1. Senha inv�lida
2. Cart�o bloqueado
3. M�nimo de 10 centavos
4. Registro n�o encontrado
5. Senha Incorreta
6. Aprovado
7. Valor inv�lido
8. Transa��o aprovada
9. Saldo insuficiente
10. Senha entre 4 e 6 d�tigos
11. Transa��o negada
12. Erro no tamanho da senha
13. Cart�o vencido

### Sobre Event Sourcing
Por se tratar de um desafio, no qual s�o realizadas transa��es com cart�es, visando uma maior seguran�a e rastreabilidade
optou-se por implmentar o **Event Sourcing**.

A finalidade do Event Sourcing � armazenar no banco de dados hist�rico de todas as opera��es recebidas ou enviadas 
pelo servidor de comunica��es (Karnak).

### Fun��es Dispon�veis por Tipo de Opera��o:
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
	* Sondagem das transa��es efetuadas
	* Listagem somente das transa��es efetuadas
	* Listagem das transa��es com os relacionamentos de dados

### Para resolver o desafio foi necess�rio criar 4 projetos distintos:
1. **AmonRa** - cliente WPF
2. **EFCoreMapStone** - entity framework, cria o banco de dados, as tabelas, PK�s e FK�s
3. **UnitTesteKarnakStone** - respons�vel por realizar os testes unit�rios e de integra��o
4. **KarnakCore** - o cora��o do projeto, respons�vel por tudo, **� o cara!**

# 1 - O Projeto AmonRa - Cliente WPF
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

![AmonRa - Cliente WPF - Estutura Pastas](image/amonra_estutura_pastas.png)

O projeto est� estruturado da seguinte forma:
1. **Pasta Common**: classes comuns ao projeto
	* Classe StringCipher.cs: respons�vel por realizar a criptografia e descriptografia da senha
2. **Pasta Core**: respons�vel por efetuar transa��es
	* Classe TransactionServer.cs: enviar transa��es para o servidor Karnak  
3. **Pasta Models**: os modelos de dados		  
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

### Realizando uma transa��o 
Passos para realizar uma transa��o:
1. Informar o valor
2. Escolher um cart�o do cat�logo
	* Se o cart�o escolhido for do tipo **CHIP** o campo de senha **SER�** exibido
	* Se o cart�o escolhido for do tipo **TARJA** o campo de senha **N�O SER�** exibido
3. Escolher cr�dito ou d�bito
	* Se a op��o escolhida for **CR�DITO** a op��o parcelamento **SER�** exibida
	* Se a op��o escolhida for **D�BITO** a op��o parcelamento **N�O SER�** exibida
4. Confirmar a transa��o pressionando o bot�o
	* Se ao pressionar o bot�o **CONFIRMAR** estiver faltando alguma informa��o obrigat�ria, um alerta ser� exibido
5. Pressionou o bot�o e todas as informa��es preenchidas
	* Ser� enviada para o servidor de comunica��es (Karnak) uma requisi��o para realizar uma transa��o
	* O servidor ir� validar as informa��es enviadas, caso ocorra alguma restri��o, um ou mais erros podem ser retornados:
6. Diversas valida��es s�o realizadas pelo servidor de comunica��es, caso alguma n�o seja satisfat�ria o mesmo ir� retornar com erro. Os poss�veis retornos podem ser vistos no item **Poss�veis Retornos do Servidor**

### Cadastro de Cliente e Cart�o
Passos para realizar o cadastro de um cliente e cart�o
1. Informar o nome
2. Informar o e-mail
3. Informar data de anivers�rio
4. Escolher tipo do cart�o
	* Se cart�o escolhido for **CHIP** a op��o para informar senha do cart�o ser� exibida
5. Escolher a bandeira do cart�o
6. Informar o n�mero do cart�o
7. Data de expira��o do cart�o
8. Limite do cart�o
9. Pressionar Salvar
	* **Em caso de falha**
		* Todas as informa��es ser�o validatas, caso alguma n�o satisfa�a alguma condi��o, um ou mais erros podem retornar
		* Valida��es diferentes s�o realizadas para cart�o e cliente
		* Caso o servidor de comunica��es retorne erro(s) os mesmos ser�o exibidos na tela
		* Diversas valida��es s�o realizadas pelo servidor de comunica��es, caso alguma n�o seja satisfat�ria o mesmo ir� retornar com erro. Os poss�veis retornos podem ser vistos no item **Poss�veis Retornos do Servidor**
	* **Em caso de sucesso**
		* Uma mensagem de **SUCESSO** ser� exibida para o cadastro do cliente e do cart�o 

### App.config
O arquivo App.config possu� a **KEY** de configura��o de conex�o com o servidor de comunica��es (Karnak).

Caso seja necess�rio realizar a troca da url, o arquivo est� aqui -> https://github.com/silvastefan/microtef-hire-me/blob/master/Desafio_Stone/AmonRa/AmonRa/App.config

# 2 - Sobre o Entity Framework Core
Ap�s criar as tabelas necess�rias e realizar os devidos relacionamentos, configurar o arquivo KarnakContext.cs

Pesquisar no arquivo pelo termo "optionsBuilder.UseSqlServer" e realizar os ajustes necess�rios.

**Seguir os passos**:
1. dotnet ef migrations add mig1 -p EFCoreMapStoneV13
2. verificar se na lista de migracoes disponiveis esta a nova migracao 'mig1'
3. dotnet ef migrations list -p EFCoreMapStoneV13
4. Wooouuuu, tudo pronto! Agora vamos criar o banco de dados e as tabelas.
5. dotnet ef database -v update -v -p EFCoreMapStoneV13
6. se tudo correu bem, os scripts devem come�ar a serem exibidos

# 3 - Sobre os Testes Unit�rios
Testes unit�rios foram realizados em todas as api�s rest.

Abaixo a lista de todos os testes efetuados.

1. Bandeira Cart�o
	* Post_CardBrand_The_Name_Is_Required
	* Delete_ByIdCardBrand_Valido
	* Get_ByNameCardBrand
	* Delete_ByIdCardBrand_Registro_nao_encontrado
	* Post_CardBrand_Valido
	* Put_CardBrand_The_Name_must_have_between_2_and_30_characters
	* Put_CardBrand_The_Guid_is_invalid_and_contains_00000000
	* Post_CardBrand_The_card_brand_id_has_already_been_taken_Run_2_Times
	* Post_CardBrand_The_Guid_is_empty
	* Put_CardBrand_Valido
	* Post_CardBrand_The_Guid_is_invalid_and_contains_00000000
	* Put_CardBrand_The_Name_is_Required
	* Post_CardBrand_The_card_brand_name_has_already_been_taken_Run
	* Delete_ByIdCardBrand_The_Guid_is_empty
	* Get_AllCardBrand
	* Put_CardBrand_The_card_brand_name_has_already_been_taken
	* Get_HistorycByIdCardBrand
	* Get_ByIdCardBrand
	* Put_CardBrand_The_Guid_is_empty
	* Post_CardBrand_The_Name_must_have_between_2_and_30_characters
	* Delete_ByIdCardBrand_The_Guid_is_invalid_and_contains_00000000
2. Tipo Cart�o
	* Put_CardType_The_card_type_name_has_already_been_taken
	* Get_AllCardType
	* Post_CardType_Valido
	* Delete_ByIdCardType_The_Guid_is_invalid_and_contains_00000000
	* Delete_ByIdCardType_Registro_nao_encontrado
	* Post_CardType_The_card_type_id_has_already_been_taken_Run_2_Times
	* Get_HistorycByIdCardType
	* Post_CardType_The_Guid_is_empty
	* Post_CardType_The_Name_must_have_between_2_and_30_characters
	* Get_ByIdCardType
	* Put_CardType_The_Name_must_have_between_2_and_30_characters
	* Post_CardType_The_Name_Is_Required
	* Put_CardType_The_Name_is_Required
	* Put_CardType_Valido
	* Post_CardType_The_card_type_name_has_already_been_taken_Run
	* Get_ByNameCardType
	* Post_CardType_The_Guid_is_invalid_and_contains_00000000
	* Put_CardType_The_Guid_is_invalid_and_contains_00000000
	* Delete_ByIdCardType_The_Guid_is_empty
	* Delete_ByIdCardType_Valido
	* Put_CardType_The_Guid_is_empty
3. Cart�o
	* Get_ByCardNumber
	* Get_HistorycByIdCard
	* Get_ByIdCard
	* Delete_ByIdCard_Valido
	* Post_Card_Valido
	* Get_AllCard
4. Cliente
	* Post_Customer_The_Name_must_have_between_2_and_30_characters
	* Post_Customer_Valido
	* Put_Customer_The_Name_must_have_between_2_and_100_characters
	* Put_Customer_Valido
	* Put_Customer_The_Guid_is_invalid_and_contains_00000000
	* Post_Customer_The_Guid_is_empty
	* Put_Customer_The_customer_name_has_already_been_taken
	* Post_Customer_The_customer_e_mail_has_already_been_taken_Run_2_Times
	* Put_Customer_The_Name_is_Required
	* Delete_ByIdCustomer_The_Guid_is_empty
	* Delete_ByIdCustomer_The_Guid_is_invalid_and_contains_00000000
	* Put_Customer_The_Guid_is_empty
	* Post_Customer_The_customer_id_has_already_been_taken_Run
	* Post_Customer_The_Name_Is_Required
	* Post_Customer_The_Guid_is_invalid_and_contains_00000000
	* Delete_ByIdCustomer_Valido
	* Delete_ByIdCustomer_Registro_nao_encontrado
	* Get_AllCustomer
	* Get_ByIdCustomer
	* Get_HistorycByIdCustomer
	* Get_ByNameCustomer
5. Senha
	* PasswordDecryptFail
	* PasswordDecryptSuccess
	* PasswordEncrypt
6. Transa��o Status
	* Get_ByIdTransactionStatus
	* Put_TransactionStatus_The_Guid_is_empty
	* Put_TransactionStatus_The_Name_must_have_between_2_and_30_characters
	* Delete_ByIdTransactionStatus_Valido
	* Delete_ByIdTransactionStatus_The_Guid_is_invalid_and_contains_00000000
	* Get_HistorycByIdTransactionStatus
	* Delete_ByIdTransactionStatus_Registro_nao_encontrado
	* Post_TransactionStatus_The_Name_must_have_between_2_and_30_characters
	* Post_TransactionStatus_The_Guid_is_invalid_and_contains_00000000
	* Get_AllTransactionStatus
	* Put_TransactionStatus_The_transaction_status_name_has_already_been_taken
	* Get_ByNameTransactionStatus
	* Put_TransactionStatus_Valido
	* Put_TransactionStatus_The_Name_is_Required
	* Post_TransactionStatus_The_transaction_status_id_has_already_been_taken_Run_2_Times
	* Post_TransactionStatus_The_Guid_is_empty
	* Post_TransactionStatus_Valido
	* Delete_ByIdTransactionStatus_The_Guid_is_empty
	* Put_TransactionStatus_The_Guid_is_invalid_and_contains_00000000
	* Post_TransactionStatus_The_Name_Is_Required
	* Post_TransactionStatus_The_transaction_status_name_has_already_been_taken
7. Transa��o Tipo
	* Post_TransactionType_The_Name_Is_Required
	* Delete_ByIdTransactionType_The_Guid_is_empty
	* Get_HistorycByIdTransactionType
	* Post_TransactionType_The_Guid_is_invalid_and_contains_00000000
	* Post_TransactionType_The_transaction_type_name_has_already_been_taken
	* Get_ByIdTransactionType
	* Post_TransactionType_The_Name_must_have_between_2_and_30_characters
	* Delete_ByIdTransactionType_Valido
	* Get_AllTransactionType
	* Put_TransactionType_The_Name_is_Required
	* Put_TransactionType_The_transaction_type_name_has_already_been_taken
	* Delete_ByIdTransactionType_The_Guid_is_invalid_and_contains_00000000
	* Get_ByNameTransactionType
	* Post_TransactionType_Valido
	* Put_TransactionType_The_Guid_is_empty
	* Put_TransactionType_The_Name_must_have_between_2_and_30_characters
	* Post_TransactionType_The_Guid_is_empty
	* Delete_ByIdTransactionType_Registro_nao_encontrado
	* Put_TransactionType_Valido
	* Put_TransactionType_The_Guid_is_invalid_and_contains_00000000
	* Post_TransactionType_The_transaction_type_id_has_already_been_taken_Run_2_Times
8. Transa��o
	* Post_Transaction_CHIP
	* Delete_ByIdTransaction_Valido
	* Post_Transaction_TARJA
	* Get_HistorycByIdTransaction
	* Get_ByIdTransaction
	* Post_Transaction_Cartao_Vencido
	* Get_AllTransaction
	* Get_ByNameTransaction

# 4 - Sobre o KarnakCore - Servidor de Comunica��es

O servidor de comunica��es � o projeto respons�vel por fazer tudo funcionar, **ele � o cara!**

Por que o nome **Karnak**:

Templo de Carnaque, ou simplesmente Carnaque, � um templo dedicado ao deus Amom-R�. 

Tem esse nome devido a uma aldeia vizinha chamada Carnaque, mas no tempo dos antigos fara�s a aldeia 
era conhecida como Ipet-sut.

Maiores informa��es sobre o templo de Karnak aqui -> https://www.penaestrada.blog.br/luxor-o-templo-de-karnak/


## Sobre CQRS
CQRS significa Command Query Responsibility Segregation. Como o nome j� diz, � sobre separar a responsabilidade de escrita e leitura de seus dados.

CQRS � um pattern, um padr�o arquitetural assim como Event Sourcing, Transaction Script e etc. 

O CQRS n�o � um estilo arquitetural como desenvolvimento em camadas, modelo client-server, REST e etc.

Atualmente as aplica��es n�o s�o mais para atender dez usu�rios simult�neos, a maioria das novas aplica��es nascem com
premisas de escalabilidade, performance e disponibilidade, fazer uma aplica��o funcionar bem para cargas de trabalho 
de forma el�stica � uma tarefa extremamente complexa.

O CQRS prega a divis�o de responsabilidade de grava��o e escrita de forma conceitual e f�sica. 

Isto significa que al�m de ter meios separados para gravar e obter um dado os bancos de dados tamb�m s�o diferentes. 

As consultas s�o feitas de forma s�ncrona em uma base desnormalizada separada e as grava��es de forma ass�ncrona em um banco normalizado.

![Rela��o cliente-servidor com sonda](image/CQRS_FluxoSimples.jpg)

## Segregar as responsabilidades em QueryStack e CommandStack
A ideia b�sica � segregar as responsabilidades da aplica��o em:

* Command
	* Opera��es que modificam o estado dos dados na aplica��o.
* Query 
	* Opera��es que recuperam informa��es dos dados na aplica��o.

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

## Arquitetura comparativa
A imagem do lado esquerdo representa uma aplica��o padr�o.

A imagem do lado direito representa uma aplica��o CQRS.

![Arquitetura comparativa](image/arquitetura_comparativa.png)

## Arquitetura utilizada na resolu��o do desafio Stone

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

## Arquitetura Sugerida
Abaixo arquitetura sugerida para resolu��o do desafio de uma forma mais escal�vel. 

Essa arquitetura trabalha diretamente com microservi�os, fila e event-driven.

![Arquitetura Sugerida](image/arquitetura_sugerida.png)

![Arquitetura Sugerida Detalhada](image/arquitetura_sugerida_detalhada.png)

## Swagger
Todas as api�s rest podem ser utilizadas com Swagger ou atrav�s do projeto de testes unit�rios.

![Api�s Rest Swagger](image/swagger.png)


## Gerar Banco de Dados
* Executar script -> https://github.com/silvastefan/microtef-hire-me/blob/master/Desafio_Stone/KarnakCore/sql/GenerateDataBase.sql


