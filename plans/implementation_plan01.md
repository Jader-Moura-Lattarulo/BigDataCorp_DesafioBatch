# Estruturação dos Modelos de Dados (ClubData.cs)

Este plano detalha a criação das classes C# (DTOs) necessárias para desserializar os dados de clubes e jogadores a partir de um arquivo JSONL, utilizando `System.Text.Json` no .NET 10.

## User Review Required

> [!IMPORTANT]
> Verifique se as escolhas de tipos de dados (como `DateOnly` para datas e `decimal` para valor de mercado) atendem aos requisitos. Aprove o plano para prosseguirmos com a codificação do arquivo.

## Open Questions

> [!NOTE]
> 1. Você prefere utilizar `DateOnly` ou `DateTime` para as propriedades `founding_date` e `debut_date`? O plano adota `DateOnly` pelo formato "YYYY-MM-DD".
> 2. O tipo numérico escolhido para `market_value` é `decimal`. Está de acordo?

## Proposed Changes

### Modelos de Dados (DTOs)

Serão criadas duas classes principais dentro do arquivo `ClubData.cs`: `ClubData` e `PlayerData`.

#### 1. Classe `PlayerData`

Representa cada jogador na lista `players`.

**Lista de Propriedades, Tipos e Mapeamento:**

| Chave JSON | Propriedade C# | Tipo C# | Anulável? | Inicialização / Notas |
| :--- | :--- | :--- | :--- | :--- |
| `player_id` | `PlayerId` | `string` | Não | `= string.Empty;` |
| `name` | `Name` | `string` | Não | `= string.Empty;` |
| `age` | `Age` | `int` | Não | |
| `goals` | `Goals` | `int` | Não | |
| `debut_date` | `DebutDate` | `DateOnly` | Não | |
| `position` | `Position` | `string` | Não | `= string.Empty;` |
| `shirt_number` | `ShirtNumber` | `int` | Não | |
| `nationality` | `Nationality` | `string` | Não | `= string.Empty;` |
| `market_value` | `MarketValue` | `decimal` | Não | |

> **Nota:** Usaremos o atributo `[JsonPropertyName("chave_json")]` em cada propriedade para o mapeamento snake_case (JSON) -> PascalCase (C#).

#### 2. Classe `ClubData`

Representa o objeto raiz do clube.

**Lista de Propriedades, Tipos e Mapeamento:**

| Chave JSON | Propriedade C# | Tipo C# | Anulável? | Inicialização / Notas |
| :--- | :--- | :--- | :--- | :--- |
| `club_id` | `ClubId` | `string` | Não | `= string.Empty;` |
| `name` | `Name` | `string` | Não | `= string.Empty;` |
| `championship` | `Championship` | `string` | Não | `= string.Empty;` |
| `founding_date` | `FoundingDate` | `DateOnly` | Não | |
| `city` | `City` | `string` | Não | `= string.Empty;` |
| `state` | `State` | `string` | Não | `= string.Empty;` |
| `country` | `Country` | `string` | Não | `= string.Empty;` |
| `stadium` | `Stadium` | `string` | Não | `= string.Empty;` |
| `president` | `President` | `string` | Não | `= string.Empty;` |
| `nickname` | `Nickname` | `string?` | Sim | Valor padrão `null`. A chave no JSON pode vir com valor nulo. |
| `colors` | `Colors` | `List<string>` | Não | `= [];`. Lista garantida, mas vazia se ausente no JSON. |
| `titles` | `Titles` | `int` | Não | |
| `players` | `Players` | `List<PlayerData>`| Não | `= [];`. Lista garantida, mas vazia se ausente no JSON. |

### Estratégia de Nulabilidade e Inicialização

*   **Tipos de Valor:** Inteiros (`int`), decimais (`decimal`) e datas (`DateOnly`) não necessitam de inicialização explícita.
*   **Strings não-nulas:** Propriedades `string` obrigatórias recebem `= string.Empty;` para evitar avisos CS8618 de Non-Nullable Reference Types.
*   **Strings anuláveis:** `Nickname` é `string?`, suportando adequadamente a ausência ou nulo, sem precisar de inicialização (`null` por padrão).
*   **Coleções (`colors`, `players`):** Inicializadas como listas vazias (`= [];`) para garantir que o código consumindo esses dados não encontre exceções de referência nula (`NullReferenceException`) mesmo que as chaves não venham no JSON.

## Verification Plan

### Manual Verification
- Ao aprovar o plano, gravaremos a estrutura em `c:\xampp\htdocs\BigDataCorp_DesafioBatch\BigDataCorp_DesafioBatch\Models\ClubData.cs`.
- Avaliaremos o código para garantir zero *warnings* de nulabilidade.
