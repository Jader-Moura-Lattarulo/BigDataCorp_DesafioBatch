using System.Globalization;

namespace BigDataCorp_DesafioBatch.Utils;

public static class Formatter
{
    public static string EscapeCsvField(string? field)
    {
        if (string.IsNullOrEmpty(field))
        {
            return "";
        }

        if (field.Contains(',') || field.Contains('"') || field.Contains('\n') || field.Contains('\r'))
        {
            return $"\"{field.Replace("\"", "\"\"")}\"";
        }

        return field;
    }

    public static string FormatColors(List<string>? colors)
    {
        if (colors == null || colors.Count == 0)
        {
            return "";
        }

        return string.Join("|", colors);
    }

    public static string FormatDate(string? dateString)
    {
        if (string.IsNullOrEmpty(dateString))
        {
            return "";
        }

        if (DateTime.TryParseExact(dateString, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
        {
            return dateString;
        }

        return "";
    }
}
