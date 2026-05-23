using LogTailBlazor.Models;

namespace LogTailBlazor.Services
{
    public class LogParserService
    {
        /// <summary>
        /// Parse une liste de lignes brutes et applique les règles de coloration.
        /// </summary>
        public List<LogLine> ParseLines(IEnumerable<string> rawLines, AppSettings settings)
        {
            var result  = new List<LogLine>();
            var sep     = settings.UseSeparator ? settings.ColumnSeparator : string.Empty;
            var counter = 0;

            foreach (var raw in rawLines)
            {
                if (string.IsNullOrEmpty(raw)) continue;

                var line = LogLine.Parse(++counter, raw, sep);
                ApplyHighlighting(line, raw, settings);
                result.Add(line);
            }
            return result;
        }

        /// <summary>
        /// Applique les couleurs CSS d'une règle qui correspond.
        /// </summary>
        public void ApplyHighlighting(LogLine line, string rawText, AppSettings settings)
        {
            foreach (var rule in settings.HighlightRules.OrderBy(r => r.Order))
            {
                var cmp = rule.IgnoreCase
                    ? StringComparison.OrdinalIgnoreCase
                    : StringComparison.Ordinal;

                if (!rawText.Contains(rule.Keyword, cmp)) continue;

                line.FgColor    = rule.TextColor;
                line.BgColor    = rule.BackgroundColor;
                line.FontWeight = rule.IsBold ? "bold" : "normal";
                return;
            }

            // Pas de règle → couleurs par défaut
            line.FgColor    = "#CCCCCC";
            line.BgColor    = "transparent";
            line.FontWeight = "normal";
        }
    }
}
