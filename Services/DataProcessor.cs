using System;
using System.IO;
using System.Text.Json;
using BigDataCorp_DesafioBatch.Models;
using BigDataCorp_DesafioBatch.Utils;

namespace BigDataCorp_DesafioBatch.Services;

public class DataProcessor
{
    public void Process(string inputFilePath, string outputClubsPath, string outputPlayersPath)
    {
        using var reader = new StreamReader(inputFilePath);
        using var clubsWriter = new StreamWriter(outputClubsPath);
        using var playersWriter = new StreamWriter(outputPlayersPath);

        clubsWriter.WriteLine("Id do Clube,Nome,Campeonato,Data de Fundação,Cidade,Estado,País,Estádio,Presidente,Apelido,Cores");
        playersWriter.WriteLine("Id do Clube,Id do Jogador,Nome,Idade,Gols,Data de Estreia,Posição,Número da Camisa");

        string? line;
        while ((line = reader.ReadLine()) != null)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }

            try
            {
                var club = JsonSerializer.Deserialize<ClubDto>(line);
                if (club == null) continue;

                if (club.Championship != "SERIE A" && club.Championship != "SERIE B")
                {
                    continue;
                }

                var clubId = Formatter.EscapeCsvField(club.ClubId);
                var name = Formatter.EscapeCsvField(club.Name);
                var championship = Formatter.EscapeCsvField(club.Championship);
                var foundingDate = Formatter.EscapeCsvField(Formatter.FormatDate(club.FoundingDate));
                var city = Formatter.EscapeCsvField(club.City);
                var state = Formatter.EscapeCsvField(club.State);
                var country = Formatter.EscapeCsvField(club.Country);
                var stadium = Formatter.EscapeCsvField(club.Stadium);
                var president = Formatter.EscapeCsvField(club.President);
                var nickname = Formatter.EscapeCsvField(club.Nickname);
                var colors = Formatter.EscapeCsvField(Formatter.FormatColors(club.Colors));

                clubsWriter.WriteLine($"{clubId},{name},{championship},{foundingDate},{city},{state},{country},{stadium},{president},{nickname},{colors}");

                if (club.Players != null)
                {
                    foreach (var player in club.Players)
                    {
                        var playerId = Formatter.EscapeCsvField(player.PlayerId);
                        var playerName = Formatter.EscapeCsvField(player.Name);
                        var age = player.Age.ToString();
                        var goals = player.Goals.ToString();
                        var debutDate = Formatter.EscapeCsvField(Formatter.FormatDate(player.DebutDate));
                        var position = Formatter.EscapeCsvField(player.Position);
                        var shirtNumber = player.ShirtNumber.ToString();

                        playersWriter.WriteLine($"{clubId},{playerId},{playerName},{age},{goals},{debutDate},{position},{shirtNumber}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao processar linha: {ex.Message}");
                continue;
            }
        }
    }
}
