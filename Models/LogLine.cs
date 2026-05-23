namespace LogTailBlazor.Models
{
    public class LogLine
    {
        public int    Id          { get; set; }
        public string RawText     { get; set; } = string.Empty;

        // Colonnes parsées
        public string Timestamp   { get; set; } = string.Empty;
        public string Machine     { get; set; } = string.Empty;
        public string Application { get; set; } = string.Empty;
        public string Level       { get; set; } = string.Empty;
        public string Category    { get; set; } = string.Empty;
        public string EventType   { get; set; } = string.Empty;
        public string EventCode   { get; set; } = string.Empty;
        public string Message     { get; set; } = string.Empty;

        // Couleurs CSS calculées
        public string FgColor     { get; set; } = "#FFFFFF";
        public string BgColor     { get; set; } = "transparent";
        public string FontWeight  { get; set; } = "normal";

        public static LogLine Parse(int id, string raw, string separator)
        {
            var line = new LogLine { Id = id, RawText = raw };

            if (!string.IsNullOrEmpty(separator) && raw.Contains(separator))
            {
                var parts = raw.Split(separator);
                line.Timestamp   = parts.ElementAtOrDefault(0)?.Trim() ?? raw;
                line.Machine     = parts.ElementAtOrDefault(1)?.Trim() ?? string.Empty;
                line.Application = parts.ElementAtOrDefault(2)?.Trim() ?? string.Empty;
                line.Level       = parts.ElementAtOrDefault(3)?.Trim() ?? string.Empty;
                line.Category    = parts.ElementAtOrDefault(4)?.Trim() ?? string.Empty;
                line.EventType   = parts.ElementAtOrDefault(5)?.Trim() ?? string.Empty;
                line.EventCode   = parts.ElementAtOrDefault(6)?.Trim() ?? string.Empty;
                line.Message     = parts.Length > 7
                    ? string.Join(separator, parts.Skip(7)).Trim()
                    : string.Empty;
            }
            else
            {
                line.Message = raw;
            }

            return line;
        }
    }
}
