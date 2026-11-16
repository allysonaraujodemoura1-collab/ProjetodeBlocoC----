# VidaPet — TP1: Análise e Modelagem de Requisitos

**Projeto:** Sistema de Agendamento da Clínica Veterinária VidaPet  
**Trilha escolhida:** C#

## 1. Objetivo

O sistema VidaPet tem como objetivo organizar o cadastro de animais, veterinários e consultas de uma clínica que atende somente cães e gatos no momento, substituindo o controle manual de agendamentos afim de reduzir os problemas como conflitos de horários e consultas esquecidas.

## 2. Entidades

- **Animal:** nome, espécie, idade, nome e telefone do tutor.
- **Veterinário:** nome e CRMV.
- **Consulta:** animal, veterinário, data e horário, situação e observações.

## 3. Requisitos funcionais

| Código  | Requisito                                                                             |
| ------- | ------------------------------------------------------------------------------------- |
| RF01 ✔️ | Permitir que a recepcionista cadastre animais.                                        |
| RF02 ✔️ | Permitir que a recepcionista cadastre veterinários.                                   |
| RF03    | Permitir agendar consultas vinculando um animal a um veterinário.                     |
| RF04    | Permitir cancelar consultas agendadas.                                                |
| RF05    | Permitir que o veterinário consulte sua agenda do dia.                                |
| RF06    | Permitir que o veterinário marque suas consultas agendadas como realizadas.           |
| RF07    | Permitir registrar observações do atendimento.                                        |
| RF08 ✔️ | Informar quando uma operação não puder ser realizada por violar uma regra de negócio. |

## 4. Requisitos não funcionais

| Código   | Requisito                                                                                     |
| -------- | --------------------------------------------------------------------------------------------- |
| RNF01 ✔️ | O sistema deve apresentar menus e mensagens compreensíveis ao usuário.                        |
| RNF02 ✔️ | A versão inicial deve funcionar localmente como programa standalone.                          |
| RNF03 ✔️ | O desenvolvimento deve utilizar C# e a plataforma .NET.                                       |
| RNF04 ✔️ | A implementação deve ser organizada para permitir futuras evoluções, como persistência e API. |

## 5. Regras de negócio

| Código | Regra                                                                                   |
| ------ | --------------------------------------------------------------------------------------- |
| RN01   | As consultas possuem duração de 30 minutos.                                             |
| RN02   | Consultas podem ser agendadas somente de segunda a sexta-feira.                         |
| RN03   | O horário de funcionamento é das 08h às 18h, com término da última consulta até as 18h. |
| RN04   | Um veterinário não pode ter consultas agendadas com horários sobrepostos.               |
| RN05   | Não é permitido agendar consultas em datas ou horários passados.                        |
| RN06   | Somente consultas com situação "Agendada" podem ser canceladas.                         |
| RN07   | Somente consultas agendadas podem ser marcadas como realizadas.                         |
| RN08   | Apenas o veterinário responsável pode marcar sua consulta como realizada.               |
| RN09   | A clínica realiza atendimentos somente de cães e gatos.                                 |

## 6. Atores

**Recepcionista:** responsável pelo cadastro de animais e veterinários, agendamento e cancelamento de consultas.

**Veterinário:** responsável por consultar sua agenda e registrar a realização das consultas e suas observações.

## 7. Escopo do TP1

O TP1 tem como foco o levantamento e a classificação dos requisitos, a modelagem dos casos de uso, a configuração do ambiente e a criação de um programa inicial executável.

O protótipo desenvolvido durante os estudos também inclui classes, listas, cadastros e algumas validações, antecipando conteúdos previstos para etapas futuras.

Nesta entrega, não se pretende concluir a implementação de toda a agenda, das regras de conflito de horários, da persistência de dados, da autenticação nem da API web. Essas funcionalidades deverão ser desenvolvidas progressivamente nas próximas etapas do projeto.

## 8. Premissas e decisões adotadas até o momento

- A clínica atende exclusivamente cães e gatos. ✔️
- Cada animal recebe um identificador numérico único de nove dígitos no protótipo. ✔️
- O CRMV, acompanhado da UF, identifica o veterinário no sistema. ✔️
- A aplicação inicial utiliza listas em memória, sem armazenamento permanente. ✔️
- As informações cadastradas são perdidas quando o processo é encerrado. ✔️
- A recepcionista e o veterinário são representados inicialmente por opções de menu, sem autenticação real. ✔️
- O limite de idade adotado no protótipo é de 0 a 50 anos. ✔️
- O número do CRMV recebe uma validação simplificada de formato, sem consulta ao registro profissional oficial. ✔️

## 9. Evolução prevista

Nas próximas etapas, o sistema poderá evoluir para uma aplicação orientada a objetos mais completa, incorporar as regras de agendamento e, posteriormente, utilizar banco de dados, autenticação e API web com ASP.NET Core.

## 10. Verificação do ambiente e da entrega

Para conferir a versão instalada do .NET SDK:

```powershell
dotnet --version (10.0.403)
dotnet --list-sdks (10.0.403 [C:\Program Files\dotnet\sdk])
```

Para verificar se o programa compila e executa:

```powershell
dotnet build
dotnet run
```
