using System.Text.Json.Serialization;

namespace BigDataCorp_DesafioBatch.Models;

public class ClubDto
{
    [JsonPropertyName("club_id")]
    public string ClubId { get; set; } = string.Empty;

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("championship")]
    public string Championship { get; set; } = string.Empty;

    [JsonPropertyName("founding_date")]
    public string? FoundingDate { get; set; }

    [JsonPropertyName("city")]
    public string City { get; set; } = string.Empty;

    [JsonPropertyName("state")]
    public string State { get; set; } = string.Empty;

    [JsonPropertyName("country")]
    public string Country { get; set; } = string.Empty;

    [JsonPropertyName("stadium")]
    public string Stadium { get; set; } = string.Empty;

    [JsonPropertyName("president")]
    public string President { get; set; } = string.Empty;

    [JsonPropertyName("nickname")]
    public string? Nickname { get; set; }

    [JsonPropertyName("colors")]
    public List<string>? Colors { get; set; }

    [JsonPropertyName("players")]
    public List<PlayerDto>? Players { get; set; }
}

public class PlayerDto
{
    [JsonPropertyName("player_id")]
    public string PlayerId { get; set; } = string.Empty;

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("age")]
    public int Age { get; set; }

    [JsonPropertyName("goals")]
    public int Goals { get; set; }

    [JsonPropertyName("debut_date")]
    public string? DebutDate { get; set; }

    [JsonPropertyName("position")]
    public string Position { get; set; } = string.Empty;

    [JsonPropertyName("shirt_number")]
    public int ShirtNumber { get; set; }
}
