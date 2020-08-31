# CursoOnline

Este Projeto foi criado para atender um desafio OnLine detalhes dos requisitos e da solução:

# Sobre o projeto desafio lançado:

#### Resumo
   > Precisamos que você nos mostre que sabe trabalhar com a stack .Net e Angular. 
   > Basicamente a ideia consiste na criação uma API escrita com Asp.Net Core Web API, além de uma camada Web escrita com 
   > Angular na versão mais recente, utilizando a técnica de monorepo, ou seja, o frontend e o backend estarão no mesmo 
   > repositório.
   
#### Requisitos \ Cenário
 1.  O estudante poderá realizar o seu cadastro na plataforma.
 2.  O estudante poderá cadastrar um cartão de crédito vinculado a sua conta.
 3.  A plataforma deve oferecer uma lista de cursos onde o estudante poderá se matricular, porém, a matrícula só é possível 
 se o estudante tiver realizado pelo menos um pagamento.
 4. A plataforma deve enviar um email se a operação de matrícula for realizada com sucesso.

 * OBS 1: Você deve deduzir quais são as entidades do domínio necessárias para completar a atividade, tal como os > relacionamentos, etc
 * OBS 2: **Não será avaliado** o uso do serviço de envio de email externo como por exemplo Sendgrid. Está etapa pode ser mockada.
 * OBS 3: **Não será avaliado** o uso de banco de dados, então, você poderar escolher armazenar em memória ou usar qualquer 
outra forma de armazenamento. Está etapa pode ser mockada.

   
-----------------------------------------------


# Proposta de Solução

### Arquitetura e padrões
  - Usando os conceitos de DDD
  - Segregação em entidades, Handles (Ação), Queries(obtenção) e Commands
  - Padroniozação usando contratos
  - Testes de unidade na camada de domínio 
  - Testes de unidade na camada de infraestrutura 
  - Tests de unidade na camada API 
  - SOLID e Clean 
  - Camada de domínio independente bem como de infraestrutura (Single Responsability Principle, desacoplamento e possibilidade de testar em separado)
  - Injeção de dependência
  - Conceitos de Testes e padronização de Retorno de Commands (Fail testes first)
  - EF core com Code-Firs e mapeamento de criação de tabelas
  - Banco de dados EntityFramework em memória e SQL Server
  - Autenticação JWT utilizando Google Firebase
  - Documentação da API via Swagger
  - Fluent API e Migrations
  
# Observações

  1. Apesar do projeto ter 5 entidades (Aluno, Cartao, Pagamento, Curso e Matrícula) alguns testes foram feitos apenas em 2 entidades pois a ideia é montar a arquitetura , contudo possibilitando de serem implementados os testes para as entidades restantes no futuro;
  2. Front End - sendo construído em Vue
  3. SQL sob docker


