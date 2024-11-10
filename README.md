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


## Validações
O projeto utiliza Data Annotations para aplicar algumas validações e configurações diretamente nas entidades. Além disso, existem atributos personalizados para validações específicas, criados na pasta Validations. Essas regras foram definidas para garantir a integridade dos dados de acordo com as necessidades e especificações do projeto.

## Estrutura do Projeto
- Controllers Controlador da API
- **Models** Definição da entidade
- **Validations** Atributos personalizados para validações específicas
- **Context** Configurações do contexto do Entity Framework
- **Repositories** Camada intermediária entre o banco de dados e o restante da aplicação

