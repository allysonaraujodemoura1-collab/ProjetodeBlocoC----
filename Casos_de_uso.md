# VidaPet — Especificação dos Casos de Uso

## 01 — Cadastrar animal

**Ator:** Recepcionista  
**Objetivo:** Registrar um animal para utilizar nas consultas.  
**Pré-condição:** A recepcionista deve estar no menu de cadastro.

**Fluxo principal:**

1. A recepcionista seleciona a opção "Cadastrar animal".
2. O sistema solicita os dados do animal e do tutor.
3. A recepcionista informa os dados.
4. O sistema verifica a validade das informações.
5. O sistema registra o animal e confirma o cadastro.

**Fluxo alternativo:** Caso os dados sejam inválidos ou exista um cadastro duplicado, o sistema informa o problema e não registra o novo animal.

**Pós-condição:** O animal cadastrado fica disponível para futuros agendamentos.

## 02 — Agendar consulta

**Ator:** Recepcionista  
**Objetivo:** Registrar uma consulta veterinária.  
**Pré-condição:** O animal e o veterinário já estão cadastrados.

**Fluxo principal:**

1. A recepcionista seleciona "Agendar consulta".
2. O sistema solicita o animal e o veterinário.
3. A recepcionista informa a data e o horário.
4. O sistema verifica as regras de agendamento.
5. O sistema registra a consulta com situação "Agendada".
6. O sistema confirma o agendamento.

**Fluxo alternativo:** Se o horário estiver ocupado, fora do expediente ou no passado, o sistema rejeita o agendamento e informa o motivo. (OBS:com no passado me refriro a demissões e tambem pretendo implementar um caso Férias)

**Pós-condição:** A consulta fica registrada na agenda do veterinário.

## 03 — Realizar consulta

**Ator:** Veterinário  
**Objetivo:** Registrar a conclusão de um atendimento.  
**Pré-condição:** A consulta está agendada e pertence ao veterinário responsável.

**Fluxo principal:**

1. O veterinário acessa sua agenda.
2. Seleciona uma consulta agendada.
3. Registra as observações do atendimento.
4. Marca a consulta como realizada.
5. O sistema atualiza a situação e confirma a operação.

**Fluxo alternativo:** Se a consulta estiver cancelada, já realizada ou não pertencer ao veterinário responsável, o sistema não permite a conclusão.

**Pós-condição:** A consulta passa a ter situação "Realizada", mantendo as observações registradas.
