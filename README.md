
# SampleEFCore

Esse projeto tem como objetivo demonstrar a utilização do EntityFramework em um projeto ASP.NET Blazor Server-Side.

# Sobre o Projeto
O projeto consiste de um sistema de gerenciamento de cinema, onde é possível cadastrar pessoas e filmes com seu gênero. Permitindo também cadastrar quais filmes foram vistos por pessoas.

## Demonstração

Insira um gif ou um link de alguma demonstração


## Funcionalidades

- Gerenciar Pessoas
- Gerenciar Filmes
- Gerenciar Gêneros de Filmes
- Definir Filme Visto por Pessoa


## Rodando localmente

**AVISO: Certifique-se de ter o MySQL instalado**

Clone o projeto

```bash
  git clone https://github.com/VictorSantos09/SampleEFCore.git
```

Execute SampleEFCoreApp.sln

Vá para "Ferramentas" (Tools) no menu superior.

Selecione "Gerenciador de Pacotes" (NuGet Package Manager).

Na lista suspensa, escolha "Console do Gerenciador de Pacotes" (Package Manager Console).

Abra o terminal do Gerenciador de Pacotes.

Execute o comando:
```bash
  update-database
```

Execute o projeto 'View'


## Stack utilizada

**Front-end:** Blazor, MudBlazor

**Back-end:** C# ASP.NET, EntityFrameworkCore, MySQL

