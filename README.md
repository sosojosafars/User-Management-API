# UserManagementAPI

Projeto desenvolvido para a disciplina de Construção de APIs, contendo as atividades 1 e 2.

---

## 📌 Atividade 1: Análise do Cenário

### Problemas identificados
- **[Validação ausente](ca://s?q=Adicionar_validacao_Model_ASP.NET_Core)**: Usuários eram adicionados sem checagem de dados obrigatórios.
- **[Busca inexistente](ca://s?q=Tratar_usuario_inexistente_ASP.NET_Core)**: Erros ao tentar recuperar usuários que não existem.
- **[Exceções não tratadas](ca://s?q=Tratar_excecoes_ASP.NET_Core)**: Falhas ocasionais por falta de tratamento global de erros.
- **Persistência em memória**: Dados armazenados apenas em lista estática, sem banco de dados real.
- **Mensagens de erro genéricas**: Respostas inconsistentes dificultavam o consumo da API.

---

## 📌 Atividade 2: Correções Aplicadas

### 1. Validação de dados
- Implementação de `DataAnnotations` no modelo `User`:
  - `[Required]` para campos obrigatórios.
  - `[EmailAddress]` para validar formato de email.
  - `[StringLength]` para limitar tamanho de strings.

### 2. Tratamento de exceções
- Inclusão de blocos `try-catch` em todos os endpoints do `UsersController`.
- Criação de **ErrorController** para capturar exceções globais via `app.UseExceptionHandler("/error")`.

### 3. Otimização da lógica
- Uso de `Any()` antes de `Max()` para evitar erros em listas vazias.
- Substituição de `Where().FirstOrDefault()` por `FirstOrDefault()` para reduzir operações desnecessárias.
- Padronização das mensagens de erro (`BadRequest`, `NotFound`, `StatusCode(500)`).

---

## 🚀 Testes Realizados

- **[Entrada inválida](ca://s?q=Testar_validacao_Model_ASP.NET_Core)**: POST com email inválido retorna `400 Bad Request`.
- **[IDs inexistentes](ca://s?q=Testar_usuario_inexistente_ASP.NET_Core)**

/atsrsf