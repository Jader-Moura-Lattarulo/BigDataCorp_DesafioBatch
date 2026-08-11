# Estruturação da Classe Formatter (Utils/Formatter.cs)

Este plano detalha a criação da classe utilitária `Formatter` responsável por preparar e higienizar os dados antes da exportação para o formato CSV.

## User Review Required

> [!IMPORTANT]
> Verifique a lógica proposta para o escape de caracteres no padrão RFC 4180 e a formatação de datas. Aprove o plano para iniciarmos a codificação.

## Proposed Changes

### 1. Criação do Arquivo e Classe Base
#### [NEW] [Formatter.cs](file:///c:/xampp/htdocs/BigDataCorp_DesafioBatch/BigDataCorp_DesafioBatch/Utils/Formatter.cs)
- Criar a classe `public static class Formatter`.
- Definir o namespace `BigDataCorp_DesafioBatch.Utils`.

### 2. Método `EscapeCsvField`
- **Assinatura**: `public static string EscapeCsvField(string? field)`
- **Regras**:
  - Se `field` for nulo ou vazio (`string.IsNullOrEmpty`), retorna `""`.
  - Verifica se o campo contém os caracteres que exigem escape: vírgula (`,`), aspas duplas (`"`), `\n` ou `\r`.
  - Se contiver algum desses, substitui as aspas duplas internas por duas aspas (`""`) e envolve o campo inteiro com aspas duplas adicionais no início e no fim.
  - Se não contiver caracteres sensíveis, retorna a string original de forma limpa.

### 3. Método `FormatColors`
- **Assinatura**: `public static string FormatColors(List<string>? colors)`
- **Regras**:
  - Se a lista for nula ou não contiver elementos (`colors == null || colors.Count == 0`), retorna `""`.
  - Caso contrário, utiliza `string.Join("|", colors)` para unir os elementos com o caractere pipe (`|`).

### 4. Método `FormatDate`
- **Assinatura**: `public static string FormatDate(string? dateString)`
- **Regras**:
  - Se `dateString` for nulo ou vazio, retorna `""`.
  - Executa o parse com `DateTime.TryParseExact(dateString, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out _)`.
  - Se a operação retornar `true` (data válida de acordo com o formato e calendário), retorna a `dateString` original.
  - Se retornar `false` (incompatível ou corrompida), descarta retornando `""`.

## Verification Plan

### Manual Verification
- Ao aprovar o plano, escreveremos a classe `Formatter`.
- Em seguida, acionaremos `dotnet build` para certificar que os imports necessários (ex: `System.Globalization`) estão declarados e o código compila perfeitamente sem warnings.
