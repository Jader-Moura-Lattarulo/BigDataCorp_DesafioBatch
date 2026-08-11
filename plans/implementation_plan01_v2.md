# Estruturação dos Modelos de Dados (ClubData.cs)

Este plano detalha a criação das classes C# (DTOs) necessárias para desserializar os dados de clubes e jogadores a partir de um arquivo JSONL, utilizando `System.Text.Json` no .NET 10.

## User Review Required

> [!IMPORTANT]
> Verifique se as alterações em datas, nulabilidade de listas e exclusão de propriedades não utilizadas atendem aos requisitos. Aprove o plano para prosseguirmos com a codificação do arquivo.

## Proposed Changes

### Modelos de Dados (DTOs)

Serão criadas duas classes principais dentro do arquivo `ClubData.cs`: `ClubData` e `PlayerData`. 

> [!TIP]
> Propriedades do JSON original como `market_value`, `nationality` e `titles` foram omitidas intencionalmente do mapeamento. O `System.Text.Json` ignorará essas chaves por padrão, reduzindo o consumo de memória no processamento em lote.

#### 1. Classe `PlayerData`

Representa cada jogador na lista `players`.

**Lista de Propriedades, Tipos e Mapeamento:**

| Chave JSON | Propriedade C# | Tipo C# | Anulável? | Inicialização / Notas |
| :--- | :--- | :--- | :--- | :--- |
| `player_id` | `PlayerId` | `string` | Não | `= string.Empty;` |
| `name` | `Name` | `string` | Não | `= string.Empty;` |
| `age` | `Age` | `int` | Não | |
| `goals` | `Goals` | `int` | Não | |
| `debut_date` | `DebutDate` | `string?` | Sim | Valor padrão `null`. Alterado para `string?` para evitar exceções de desserialização caso a data venha malformada. |
| `position` | `Position` | `string` | Não | `= string.Empty;` |
| `shirt_number` | `ShirtNumber` | `int` | Não | |

> **Nota:** Usaremos o atributo `[JsonPropertyName("chave_json")]` em cada propriedade para o mapeamento snake_case (JSON) -> PascalCase (C#).

#### 2. Classe `ClubData`

Representa o objeto raiz do clube.

**Lista de Propriedades, Tipos e Mapeamento:**

| Chave JSON | Propriedade C# | Tipo C# | Anulável? | Inicialização / Notas |
| :--- | :--- | :--- | :--- | :--- |
| `club_id` | `ClubId` | `string` | Não | `= string.Empty;` |
| `name` | `Name` | `string` | Não | `= string.Empty;` |
| `championship` | `Championship` | `string` | Não | `= string.Empty;` |
| `founding_date` | `FoundingDate` | `string?` | Sim | Valor padrão `null`. Alterado para `string?` para evitar exceções na desserialização de datas malformadas. |
| `city` | `City` | `string` | Não | `= string.Empty;` |
| `state` | `State` | `string` | Não | `= string.Empty;` |
| `country` | `Country` | `string` | Não | `= string.Empty;` |
| `stadium` | `Stadium` | `string` | Não | `= string.Empty;` |
| `president` | `President` | `string` | Não | `= string.Empty;` |
| `nickname` | `Nickname` | `string?` | Sim | Valor padrão `null`. A chave no JSON pode vir com valor nulo. |
| `colors` | `Colors` | `List<string>?` | Sim | Valor padrão `null`. Sem inicialização para suportar chaves omitidas ou explícitas como null. |
| `players` | `Players` | `List<PlayerData>?`| Sim | Valor padrão `null`. Sem inicialização para suportar chaves omitidas ou explícitas como null. |

### Estratégia de Nulabilidade e Inicialização

*   **Tipos de Valor:** Inteiros (`int`) não necessitam de inicialização explícita.
*   **Strings não-nulas:** Propriedades `string` obrigatórias recebem `= string.Empty;` para evitar avisos CS8618 de Non-Nullable Reference Types.
*   **Strings e Datas anuláveis:** `Nickname`, `FoundingDate` e `DebutDate` são tipadas como `string?`, suportando nulo/ausência, validando regras de negócio em utilitários posteriores.
*   **Coleções (`colors`, `players`):** Declaradas como anuláveis (`List<T>?`) e sem inicialização automática (mantêm estado nulo caso a chave não exista no JSON ou venha como `null`).

## Verification Plan

### Manual Verification
- Ao aprovar o plano, gravaremos a estrutura em `c:\xampp\htdocs\BigDataCorp_DesafioBatch\BigDataCorp_DesafioBatch\Models\ClubData.cs`.
- Avaliaremos o código para garantir que o compilador não gere warnings indesejados.
