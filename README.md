# LibraryAPI

API RESTful para gerenciamento de livros em uma biblioteca, construída com ASP.NET Core, Entity Framework Core e SQLite.

---

## Funcionalidades

- Listar todos os livros
- Consultar livro por ID
- Criar novo livro
- Atualizar livro existente
- Excluir livro
- Validação de dados com FluentValidation
- Filtros personalizados para logs, tratamento de exceções e tempo de resposta
- Documentação Swagger integrada
- Logging com ILogger

---

## Tecnologias usadas

- [.NET 9.0](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
- ASP.NET Core Web API
- Entity Framework Core (SQLite)
- AutoMapper
- FluentValidation
- Swagger (Swashbuckle)
- xUnit (para testes)

---

## Como executar o projeto

### Pré-requisitos

- [.NET SDK 9.0](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
- Git instalado

### Passos para rodar localmente

1. Clone o repositório:
```bash
git clone https://github.com/Turgho/LibraryAPI.git
cd LibraryAPI
```

2. Restaure as dependências:
```bash
dotnet restore
```

3. Aplique as migrações e crie o banco de dados:
```bash
dotnet ef database update
```

4. Execute a aplicação:
```bash
dotnet run
```

5. Abra o navegador e acesse:
```bash
https://localhost:5291/swagger
```

### Como rodar testes
```bash
dotnet test BibliotecaAPI.Tests/BibliotecaAPI.Tests
```

---

## Configurações
- O arquivo `appsettings.json` contém a string de conexão para o banco SQLite.
- Logs são gerados na pasta `/logs`.

---

## Licença
Este projeto está licenciado sob a MIT License - veja o arquivo [LICENSE](LICENSE) para detalhes.