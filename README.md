# Web API Fornecedores

Este é um projeto de API RESTful para gerenciar fornecedores, desenvolvido com um CRUD completo (Create, Read, Update e Delete) utilizando Entity Framework com abordagem Code-First.

## Tecnologias Utilizadas

- **ASP.NET Core** para criação da API
- **Entity Framework Core** com abordagem Code-First
- **MySQL** como banco de dados
- **Data Annotations** para validações e configurações das entidades.


## Conexão com o Banco de Dados
A conexão com o banco de dados MySQL foi configurada no arquivo `appsettings.json`. A string de conexão está localizada na seção `ConnectionStrings`.

Exemplo de configuração no `appsettings.json`:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=seu_servidor;Database=sua_base_de_dados;Uid=seu_usuario;Pwd=sua_senha;"
  }
}


