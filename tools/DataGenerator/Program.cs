using System.Text.Json;

Console.WriteLine("Iniciando geração de dados massivos...");
var outputFilePath = "base_massiva.jsonl";

var rnd = new Random();
var campeonatos = new[] { "SERIE A", "SERIE B", "SERIE C", "SERIE D", "SEM CAMPEONATO" };
var coresBase = new[] { "vermelho", "preto", "branco", "azul", "verde", "amarelo" };

using (var writer = new StreamWriter(outputFilePath))
{
    // Gera 100.000 linhas de clubes
    for (int i = 1; i <= 100000; i++)
    {
        var numJogadores = rnd.Next(15, 35); // 15 a 34 jogadores por time
        var players = new List<object>();

        for (int j = 1; j <= numJogadores; j++)
        {
            players.Add(new
            {
                player_id = $"P-{i}-{j}",
                name = $"Jogador Teste {j} do Clube {i}",
                age = rnd.Next(16, 40),
                goals = rnd.Next(0, 50),
                debut_date = rnd.Next(0, 10) > 1 ? $"202{rnd.Next(0, 4)}-0{rnd.Next(1, 9)}-1{rnd.Next(0, 9)}" : "data-invalida",
                position = "Posição Genérica",
                shirt_number = rnd.Next(1, 99),
                nationality = "Brasil",
                market_value = rnd.Next(100000, 50000000)
            });
        }

        var numCores = rnd.Next(0, 4);
        var coresClube = new List<string>();
        for (int c = 0; c < numCores; c++)
        {
            coresClube.Add(coresBase[rnd.Next(coresBase.Length)]);
        }

        var clube = new
        {
            club_id = $"C-{i}",
            name = $"Clube de Futebol {i}",
            championship = campeonatos[rnd.Next(campeonatos.Length)],
            founding_date = rnd.Next(0, 10) > 1 ? $"19{rnd.Next(10, 99)}-0{rnd.Next(1, 9)}-1{rnd.Next(0, 9)}" : "invalida",
            city = "Cidade Genérica",
            state = "UF",
            country = "Brasil",
            stadium = rnd.Next(0, 2) == 0 ? "Estádio Genérico" : "Estádio com \"Aspas\" e, Vírgulas",
            president = rnd.Next(0, 2) == 0 ? $"Presidente {i}" : $"Presidente, Vírgula {i}",
            nickname = rnd.Next(0, 2) == 0 ? $"Apelido {i}" : null,
            colors = coresClube,
            titles = rnd.Next(0, 50),
            players = players
        };

        var jsonLine = JsonSerializer.Serialize(clube);
        writer.WriteLine(jsonLine);
    }
}

Console.WriteLine($"Geração concluída! Arquivo criado em: {Path.GetFullPath(outputFilePath)}");