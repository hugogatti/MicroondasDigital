# Convenção de Commits

| Prefixo  | Descrição               | Significado                                                                 |
|----------|-------------------------|-----------------------------------------------------------------------------|
| `feat`   | Features                | Uma nova funcionalidade                                                     |
| `fix`    | Correções de Erros      | Uma correção de bug                                                         |
| `docs`   | Documentação            | Apenas mudanças na documentação                                             |
| `style`  | Estilos                 | Mudanças em relação à estilização                                           |
| `refactor` | Refatoração de Código   | Uma alteração de código que não corrige um bug nem adiciona uma funcionalidade |
| `perf`   | Melhorias de Performance | Uma alteração de código que melhora o desempenho                            |
| `test`   | Testes                  | Adição de testes em falta ou correção de testes existentes                  |
| `build`  | Builds                  | Mudanças que afetam o sistema de build ou dependências externas             |
| `ci`     | Integrações Contínuas   | Alterações em nossos arquivos e scripts de configuração de CI              |
| `chore`  | Tarefas                 | Outras mudanças que não modificam arquivos de código-fonte ou de teste      |
| `revert` | Reverter                | Reverte um commit anterior      

## Microondas Digital

Estrutura do Projeto
A solução é composta pelas seguintes camadas:

1. MicroondasDigital.Web (Blazor Server - UI)

- Responsável pela interface do usuário e interação com o backend.
- Utiliza o Blazor para criar páginas dinâmicas.
- Contém as páginas principais, como Index.razor e Configuracao.razor.

2. MicroondasDigital.Business (Lógica de Negócio)

- Contém a lógica que simula o funcionamento do micro-ondas.
- Define os serviços de negócio e interfaces, como o serviço IMicroondasService e a classe MicroondasService.

3. MicroondasDigital.Infra (Infraestrutura - Persistência)

- Responsável pela persistência de dados (ainda não implementada nesta fase).
- Contém classes como MicroondasDbContext e MicroondasRepository para futuras interações com o banco de dados.

4. MicroondasDigital.Tests (Testes Unitários)

- Contém testes unitários para a lógica de negócio.
- Utiliza o MSTest para garantir que os serviços e funcionalidades funcionem corretamente.

# Tecnologias Utilizadas
- .NET 6.0: Framework de desenvolvimento para construção de aplicativos robustos e de alto desempenho.
- Blazor: Framework de UI para criar interfaces ricas e interativas no navegador utilizando C# ao invés de JavaScript.
- MSTest: Framework de teste para garantir a qualidade do código com testes unitários.
- C#: Linguagem de programação utilizada para a implementação de toda a lógica de negócio e backend.

## Como Rodar o Projeto
Certifique-se de ter o Visual Studio e o .NET 6.0 SDK instalados.
Passos para rodar o projeto:
Abra o projeto no Visual Studio 2022.
Compile o projeto clicando em Build → Build Solution.
Rode a aplicação pressionando F5 ou clicando em Debug → Start Debugging.
A aplicação será aberta no navegador. O redirecionamento para a página de configuração (/configuracao) acontecerá automaticamente, como configurado.