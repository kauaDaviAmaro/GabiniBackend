# Gabini-Backend

**Gabini-Backend** é uma aplicação de e-commerce desenvolvida com .NET 8, implementada como uma Web API. O projeto adota uma arquitetura em camadas, facilitando a manutenção e o desenvolvimento.

## Estrutura do Projeto

A estrutura do projeto é organizada em várias camadas, cada uma com responsabilidades bem definidas:

- **Application**: Contém a lógica de negócios e serviços.
- **Core**: Inclui as entidades de domínio, DTOs (Data Transfer Objects) e interfaces de repositórios.
- **Infrastructure**: Gerencia a camada de dados, incluindo a configuração do Entity Framework Core, o contexto do banco de dados e as migrações.
- **Presentation**: Contém a API Web, controladores e configurações da aplicação.

## Requisitos

Para executar o projeto, você precisará dos seguintes requisitos:

- .NET SDK 8.0
- MySQL
- Ferramenta de linha de comando `dotnet format` e `dotnet ef`

## Configuração do Ambiente de Desenvolvimento

### 1. Clonar o Repositório

Clone o repositório para sua máquina local:

```bash
git clone https://github.com/kauaDaviAmaro/GabiniBackend.git
cd gabini-backend
```

### 2. Restaurar as Dependências do Projeto

Restaure as dependências do projeto com o seguinte comando:

```bash
dotnet restore
```

### 3. Instalar Ferramentas de Desenvolvimento

O projeto utiliza ferramentas de formatação para garantir a consistência do código. Para instalar essas ferramentas, execute:

```bash
dotnet tool restore
```

### 4. Configurar o Banco de Dados

Atualize as configurações de conexão com o banco de dados/jwt_secret no arquivo `appsettings.json` localizado na pasta **Presentation**. Em seguida, aplique as migrações para configurar o banco de dados:

```bash
cd Infrastructure
 dotnet ef database update -s ..\Presentation\
 ```

### 5. Executar a Aplicação

Inicie a aplicação com o comando:

```bash
cd Presentation
dotnet run
```

## Estrutura do Código

### Application

- **Serviços de Aplicação**: Implementações dos serviços que coordenam a lógica de negócios.
- **Exemplos de Serviços**: `UserService.cs`, `AddressService.cs`.

### Core

- **Models**: Modelos de dados do domínio, como `User.cs` e `Address.cs`.
- **DTOs**: Objetos de Transferência de Dados usados para comunicação entre camadas.
- **Repositórios**: Interfaces para acesso a dados, como `IUserRepository.cs`.

### Infrastructure

- **Contexto de Dados**: Configuração do Entity Framework Core.
- **Repositórios**: Implementações concretas dos repositórios.
- **Migrações**: Histórico de mudanças na estrutura do banco de dados.

### Presentation

- **Controladores**: Controladores API que lidam com as solicitações HTTP.
- **Configurações**: Arquivos de configuração, como `appsettings.json`.
