namespace LogTailBlazor.Models
{
    public class HighlightRule
    {
        public string Keyword         { get; set; } = string.Empty;
        public string TextColor       { get; set; } = "#FFFFFF";
        public string BackgroundColor { get; set; } = "#000000";
        public bool   IgnoreCase      { get; set; } = true;
        public bool   IsBold          { get; set; } = false;
        public int    Order           { get; set; }

        public HighlightRule Clone() => new()
        {
            Keyword = Keyword, TextColor = TextColor, BackgroundColor = BackgroundColor,
            IgnoreCase = IgnoreCase, IsBold = IsBold, Order = Order
        };
    }
}
