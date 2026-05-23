namespace LogTailBlazor.Models
{
    public class AppSettings
    {
        public string ColumnSeparator { get; set; } = "|";
        public bool   UseSeparator   { get; set; } = true;
        public bool   AutoScroll     { get; set; } = true;
        public int    FontSize       { get; set; } = 12;

        public List<HighlightRule> HighlightRules { get; set; } = new()
        {
            new() { Keyword = "ERROR", TextColor = "#FFFFFF", BackgroundColor = "#DC3545", IgnoreCase = true,  IsBold = true,  Order = 0 },
            new() { Keyword = "WARN",  TextColor = "#000000", BackgroundColor = "#FFC107", IgnoreCase = true,  IsBold = false, Order = 1 },
            new() { Keyword = "INFO",  TextColor = "#FFFFFF", BackgroundColor = "#17A2B8", IgnoreCase = true,  IsBold = false, Order = 2 },
            new() { Keyword = "DEBUG", TextColor = "#FFFFFF", BackgroundColor = "#6C757D", IgnoreCase = true,  IsBold = false, Order = 3 },
        };
    }
}
