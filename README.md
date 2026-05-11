# FamilyStoryApi

API desenvolvida em **C#/.NET** para gerenciamento de histórias familiares, usuários, permissões e vínculos familiares.

O projeto está em desenvolvimento e tem como objetivo aplicar boas práticas de backend, organização de camadas, autenticação, validações, persistência de dados e padronização de respostas em APIs REST.

---

## Objetivo do projeto

O **FamilyStoryApi** foi criado como um projeto pessoal de estudo e evolução técnica em desenvolvimento backend com .NET.

A proposta é construir uma API capaz de registrar histórias familiares, usuários e parentes, mantendo uma estrutura organizada, escalável e de fácil manutenção.

Além da implementação das funcionalidades, o projeto também serve como prática de conceitos importantes de engenharia de software, como:

- Separação de responsabilidades;
- Arquitetura em camadas;
- CQRS;
- Repository Pattern;
- Validações de entrada;
- Autenticação com JWT;
- Padronização de respostas;
- Boas práticas de organização de código.

---

## Tecnologias utilizadas

- C#
- .NET Web API
- Entity Framework Core
- SQL Server
- JWT
- Swagger
- CQRS
- Repository Pattern
- Clean Code

---

## Funcionalidades

### Autenticação e usuários

- Login com geração de token JWT;
- Cadastro e gerenciamento de usuários;
- Controle de permissões por grupo;
- Validação de credenciais e claims.

### Histórias

- Criação de histórias familiares;
- Estruturação de comandos e handlers;
- Padronização do retorno das operações;
- Organização das regras de negócio na camada de aplicação.

### Parentes e vínculos familiares

- Cadastro de parentes;
- Relacionamento entre usuários, parentes e histórias;
- Estrutura de entidades voltada para representar vínculos familiares.

### Infraestrutura e dados

- Persistência com Entity Framework Core;
- Repositório genérico para operações CRUD;
- Organização da camada de infraestrutura;
- Mapeamento de entidades para banco de dados relacional.

---

## Arquitetura

O projeto busca seguir uma organização em camadas, separando responsabilidades entre domínio, aplicação, infraestrutura e API.

Estrutura conceitual:

```text
src/
  Domain/
    Entities/
    ValueObjects/
    Notifications/

  Application/
    Commands/
    Queries/
    Handlers/
    Results/

  Infrastructure/
    Data/
    Repositories/

  WebApi/
    Controllers/
    Middlewares/
    Configurations/
```

Essa separação permite que as regras de negócio fiquem mais organizadas e facilita futuras evoluções, testes e manutenção.

---

## Padrões e práticas aplicadas

- **CQRS:** separação entre comandos e consultas;
- **Repository Pattern:** abstração do acesso a dados;
- **Notifiable Pattern:** centralização de notificações e validações;
- **Result Pattern:** padronização dos retornos da API;
- **Dependency Injection:** organização das dependências da aplicação;
- **Clean Code:** foco em clareza, responsabilidade e legibilidade.

---

## Status do projeto

🚧 Projeto em desenvolvimento.

Algumas funcionalidades já foram estruturadas, enquanto outras ainda estão sendo evoluídas e refinadas.

---

## Próximos passos

- Melhorar cobertura de testes automatizados;
- Refinar validações de entrada;
- Evoluir o tratamento global de erros;
- Melhorar a documentação dos endpoints;
- Adicionar novos fluxos relacionados a histórias e parentes;
- Revisar a estrutura de permissões;
- Evoluir a organização da arquitetura.

---

## Como executar o projeto

Clone o repositório:

```bash
git clone https://github.com/CEduardoBS/FamilyStoryApi.git
```

Acesse a pasta do projeto:

```bash
cd FamilyStoryApi
```

Restaure as dependências:

```bash
dotnet restore
```

Compile a aplicação:

```bash
dotnet build
```

Execute o projeto:

```bash
dotnet run
```

Acesse a documentação Swagger no navegador, conforme a URL exibida no terminal.

---

## Observação

Este é um projeto pessoal, criado para estudo e prática de desenvolvimento backend com .NET.

O foco principal é evoluir conceitos de engenharia de software, arquitetura, organização de código e construção de APIs REST para sistemas corporativos.
