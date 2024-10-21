# Gabini-Backend

**Gabini-Backend** é uma aplicação de e-commerce desenvolvida utilizando .NET 8, implementada como uma Web API. O projeto é organizado em uma arquitetura de camadas para facilitar a manutenção e o desenvolvimento.

## Estrutura do Projeto

A estrutura do projeto está organizada em várias camadas, cada uma com responsabilidades claras:

- **Application**: Contém a lógica de negócios e serviços.
- **Core**: Inclui as entidades de domínio, DTOs e interfaces de repositórios.
- **Infrastructure**: Gerencia a camada de dados, incluindo a configuração do Entity Framework Core, contexto do banco de dados e as migrações.
- **Presentation**: Contém a API Web, controladores e configurações da aplicação.

## Requisitos

- [.NET SDK 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)
- MySQL
- Ferramenta de linha de comando dotnet format

## Configuração do Ambiente de Desenvolvimento

### 1. Clonar o Repositório

```bash
cd gabini-backend
```

### 2. Restaurar as Dependências do Projeto

```bash
dotnet restore
```

### 3. Instalar Ferramentas de Desenvolvimento

O projeto utiliza ferramentas de formatação para garantir a consistência do código. Para instalar essas ferramentas, execute:

```bash
dotnet tool restore
```

### 4. Configurar o Banco de Dados

Atualize as configurações de conexão com o banco de dados no arquivo `appsettings.json` na pasta **Presentation**. Em seguida, aplique as migrações para configurar o banco de dados:

```bash
dotnet ef database update --project Infrastructure
```

### 5. Executar a Aplicação

Inicie a aplicação com o comando:

```bash
dotnet run --project Presentation
```

## Estrutura do Código

### Application

- **Serviços de Aplicação**: Implementações dos serviços que coordenam a lógica de negócios.
- **Serviços**: Exemplo: `UserService.cs`, `AddressService.cs`.

### Core

- **Models**: Modelos de dados do domínio, como `User.cs` e `Address.cs`.
- **DTOs**: Objetos de Transferência de Dados usados para comunicações entre camadas.
- **Repositórios**: Interfaces para acesso a dados, como `IUserRepository.cs`.

### Infrastructure

- **Contexto de Dados**: Configuração do Entity Framework Core.
- **Repositórios**: Implementações concretas dos repositórios.
- **Migrações**: Histórico de mudanças na estrutura do banco de dados.

### Presentation

- **Controladores**: Controladores API que lidam com as solicitações HTTP.
- **Configurações**: Arquivos de configuração como `appsettings.json`.
