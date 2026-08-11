# Resumo da Implementação: Program.cs (Entrypoint / CLI)

## Modificações Realizadas
- O arquivo [Program.cs](file:///c:/xampp/htdocs/BigDataCorp_DesafioBatch/BigDataCorp_DesafioBatch/Program.cs) foi completamente reescrito para adotar **top-level statements** (recurso C# 9+), eliminando a declaração explícita do namespace e da estrutura clássica do `static void Main`.
- Foram introduzidas defesas de fluxo para CLI:
  - Verificação de Argumentos (`args.Length < 1`): Imprime sintaxe de uso correta e corta a execução prematuramente (`return`).
  - Validação de Arquivo Fonte (`File.Exists`): Bloqueia processamentos cegos caso o arquivo de entrada (`.jsonl`) referenciado não seja localizado no sistema.
- Definição estruturada de caminhos absolutos para persistência de dados:
  - Destinos (`clubs.csv` e `players.csv`) foram acoplados dinamicamente ao `Directory.GetCurrentDirectory()` garantindo controle total sobre onde os artefatos finais serão renderizados.
- A orquestração (chamada da classe `DataProcessor`) foi protegida globalmente dentro de um grande `try-catch`, imprimindo uma log detalhada (incluindo erro e `StackTrace`) a fim de que qualquer anomalia indesejável (ex. estouro de memória não previsto) não "quebre" a aplicação em silêncio.
- O ciclo de vida ganhou logs verbosos via `Console.WriteLine`, indicando tanto o arranque, a finalização com êxito e os locais exatos onde os outputs foram descarregados.

## Verificação
- O motor de compilação C# confirmou a sanidade (`dotnet build`), atestando a exatidão estrutural do script top-level.
