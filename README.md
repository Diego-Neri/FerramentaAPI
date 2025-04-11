# FerramentaAPI

**FerramentaAPI** é uma API RESTful desenvolvida em C# com .NET 8, projetada para gerenciar o cadastro de ferramentas conforme os requisitos do teste para o cargo de Desenvolvedor Júnior. A API implementa operações CRUD (Create, Read, Update, Delete) para ferramentas, com validações específicas e suporte a diferentes tipos de ferramentas (`VBit` e `TopoRaso`), utilizando uma abordagem baseada em Clean Architecture.

## Funcionalidades

- **CRUD de Ferramentas**:
  - Criar, listar, obter por ID, atualizar e excluir ferramentas.
  - Propriedades obrigatórias:
    - `Endereco`: String (1 a 50 caracteres).
    - `Descricao`: String (mínimo 3 caracteres).
    - `Diametro`: Double (maior que 0 e menor que 100).
    - `Altura`: Double (maior que 0 e menor que 100).
    - `Tipo`: Enum (`VBit` ou `TopoRaso`).
  - Método `Path()`: Retorna um código específico para cada tipo de ferramenta:
    - `VBit`: "subir nos cantos".
    - `TopoRaso`: "caminho tradicional".

- **Validações**: Implementadas no domínio para garantir que os dados atendam aos requisitos.
- **Armazenamento**: Repositório em memória (conforme permitido pelo teste).
- **Testes Unitários**: Cobertura para o domínio, aplicação e infraestrutura.
- **Tratamento de Erros**: Respostas JSON claras com mensagens de erro específicas (ex.: "Diâmetro deve ser maior que zero e menor que 100.").

## Tecnologias Utilizadas

- **.NET 8**: Framework principal.
- **C#**: Linguagem de programação.
- **ASP.NET Core**: Para construção da API REST.
- **xUnit**: Framework de testes unitários.
- **Moq**: Biblioteca para mocking em testes.
- **Swagger**: Documentação interativa da API.
- **Clean Architecture**: Organização em camadas (Domain, Application, Infrastructure, Presentation).

## Arquitetura

O projeto segue os princípios da **Clean Architecture**, dividindo as responsabilidades em camadas:

- **Domain**:
  - Contém entidades (`Ferramenta`, `VBit`, `TopoRaso`), enums (`TipoFerramenta`), value objects (`EnderecoFerramenta`, `Descricao`) e interfaces (`IFerramentaRepository`).
  - Implementa regras de negócio e validações.
  - Independente de outras camadas.

- **Application**:
  - Contém DTOs (`FerramentaDTO`, `FerramentaCreateDTO`), serviços (`FerramentaService`) e interfaces (`IFerramentaService`).
  - Coordena a lógica de aplicação e mapeia dados entre camadas.

- **Infrastructure**:
  - Implementa o repositório em memória (`InMemoryFerramentaRepository`).
  - Depende do `Domain`.

- **Presentation**:
  - Contém controllers (`FerramentaController`) e configuração da API (`Program.cs`).
  - Usa um handler global de exceções (`GlobalExceptionHandler`) para respostas limpas.

- **Tests**:
  - Projetos de teste (`Domain.Tests`, `Application.Tests`, `Infrastructure.Tests`) com cobertura para validações, comportamento polimórfico e operações CRUD.
