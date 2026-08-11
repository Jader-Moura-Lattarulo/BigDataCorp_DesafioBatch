using System;
using System.IO;
using BigDataCorp_DesafioBatch.Services;

if (args.Length < 1)
{
    Console.WriteLine("Erro: Caminho do arquivo não fornecido. Uso correto: dotnet run -- <caminho_do_arquivo.jsonl>");
    return;
}

string inputFilePath = args[0];

if (!File.Exists(inputFilePath))
{
    Console.WriteLine($"Erro: Arquivo não encontrado em: {inputFilePath}");
    return;
}

string basePath = Directory.GetCurrentDirectory();
string outputClubsPath = Path.Combine(basePath, "clubs.csv");
string outputPlayersPath = Path.Combine(basePath, "players.csv");

try
{
    Console.WriteLine("Iniciando processamento...");
    
    var processor = new DataProcessor();
    processor.Process(inputFilePath, outputClubsPath, outputPlayersPath);
    
    Console.WriteLine("Processamento concluído com sucesso!");
    Console.WriteLine($"Arquivos gerados em:\n - {outputClubsPath}\n - {outputPlayersPath}");
}
catch (Exception ex)
{
    Console.WriteLine($"Erro crítico durante a execução: {ex.Message}");
    Console.WriteLine(ex.StackTrace);
}
