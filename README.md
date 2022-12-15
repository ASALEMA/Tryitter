# TryitterAPI

Este é um projeto de uma API, simulando o processo de criação de conta em uma rede social e postagens de um usuário, sendo implementado um CRUD de usuários e posts, com autenticação e autorização.

### Como rodar o projeto

#### Pré-requisitos

* **Docker**
* **Docker Compose**
* **SDK .NET Core 7.0**

#### Rodando o projeto
* Clone o repositório
* Entre na pasta do projeto
* Suba o banco de dados com o comando `docker-compose up -d`
* Faça o build do projeto com o comando` dotnet build`
* Rode as migrations para o banco de dados com o comando `dotnet ef database update`
* Inicialize o projeto com o comando `dotnet run`
* Acesse o link https://localhost:7140/swagger/index.html no seu navegador

