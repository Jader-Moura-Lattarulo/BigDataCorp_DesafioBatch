# Resumo da Implementação: Classe Formatter (Utils)

## Modificações Realizadas
- O arquivo [Formatter.cs](file:///c:/xampp/htdocs/BigDataCorp_DesafioBatch/BigDataCorp_DesafioBatch/Utils/Formatter.cs) foi implementado contendo a classe estática `Formatter`.
- Foram implementados 3 métodos estáticos para higienização e formatação de dados antes da conversão para CSV:
  - **`EscapeCsvField`**: Garante compatibilidade com o padrão CSV RFC 4180. Se o campo contiver vírgulas, quebras de linha (`\n`, `\r`) ou aspas duplas, as aspas são escapadas e a string inteira é protegida dentro de aspas duplas adicionais. Entradas nulas retornam string vazia.
  - **`FormatColors`**: Recebe uma lista nula ou preenchida e junta os elementos através do separador pipe (`|`), assegurando que a lista seja formatada em uma única string, ou vazia quando ausente.
  - **`FormatDate`**: Checa e valida se o campo textual de data segue perfeitamente o formato estrito `"yyyy-MM-dd"`. Em caso afirmativo, devolve a própria string; do contrário (string vazia ou inválida), retorna string vazia.

## Verificação
- O projeto foi compilado com o `dotnet build`, reportando **Êxito (zero erros ou warnings)**, provando que todos os pacotes (como `System.Globalization`) e retornos de nulo foram tratados estritamente como exigido pelo recurso de Nullable Reference Types do .NET.
