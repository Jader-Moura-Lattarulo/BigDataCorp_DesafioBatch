# Estruturação do Entrypoint (Program.cs)

Este plano define a arquitetura do arquivo principal (`Program.cs`) utilizando top-level statements do .NET 10, atuando como o ponto de entrada e CLI (Command Line Interface) do processador em lote.

## User Review Required

> [!IMPORTANT]
> Avalie se as validações de argumentos, manipulação dos diretórios via `Directory.GetCurrentDirectory()` e os logs propostos atendem ao seu escopo. Aprove para prosseguirmos com a edição do código.

## Proposed Changes

### 1. Reescrita do Arquivo Base
#### [MODIFY] [Program.cs](file:///c:/xampp/htdocs/BigDataCorp_DesafioBatch/BigDataCorp_DesafioBatch/Program.cs)
- O arquivo será reescrito aproveitando a sintaxe do C# moderno (**top-level statements**). Todo código ficará na raiz, sem declarações explícitas de `class Program` e `static void Main`.

### 2. Validação da CLI (Argumentos)
- Será checado se `args.Length < 1`. Em caso afirmativo, o sistema vai abortar a execução (`return;`) após apresentar um texto de orientação claro, por exemplo: `Erro: Caminho do arquivo não fornecido. Uso correto: dotnet run -- <caminho_do_arquivo.jsonl>`.

### 3. Validação do Arquivo Fonte
- O código atribuirá `args[0]` a `inputFilePath` e executará `File.Exists(inputFilePath)`. Se falso, aborta a execução (`return;`) informando que o arquivo não existe ou é inacessível.

### 4. Definição de Rotas de Saída
- Determinação do diretório alvo por intermédio de `Directory.GetCurrentDirectory()`.
- Criação das variáveis `outputClubsPath` e `outputPlayersPath` empregando `Path.Combine()` com os nomes de arquivos estipulados: `clubs.csv` e `players.csv`.

### 5. Invocação do Motor e Blindagem (Global Try-Catch)
- Emitirá o log: `"Iniciando processamento..."`.
- Envolverá toda a operação que consome disco/memória dentro de um `try-catch (Exception ex)` genérico para evitar fechamentos abruptos por exceções imprevistas não cobertas pelo serviço `DataProcessor`.
- Instanciará `BigDataCorp_DesafioBatch.Services.DataProcessor` e chamará `.Process(...)`.

### 6. Relatório Final Amigável
- Ao término do bloco do motor, emitirá o log: `"Processamento concluído com sucesso!"`.
- Imprimirá os diretórios absolutos onde os arquivos foram criados, garantindo rastreabilidade do processo no Console.

## Verification Plan

### Manual Verification
- O arquivo `Program.cs` será alterado e em seguida o comando `dotnet build` será invocado para assegurar integridade compilacional de toda a aplicação em relação ao método de top-level statements e injeção do DataProcessor.
