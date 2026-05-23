using System.Text.Json;
using Microsoft.JSInterop;
using LogTailBlazor.Models;

namespace LogTailBlazor.Services
{
    public class SettingsService
    {
        private readonly IJSRuntime _js;
        private const string Key = "logtail_settings";

        private static readonly JsonSerializerOptions JsonOpts = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = false
        };

        public SettingsService(IJSRuntime js) => _js = js;

        public async Task<AppSettings> LoadAsync()
        {
            try
            {
                var json = await _js.InvokeAsync<string?>("localStorage.getItem", Key);
                if (!string.IsNullOrEmpty(json))
                    return JsonSerializer.Deserialize<AppSettings>(json, JsonOpts) ?? new AppSettings();
            }
            catch { }
            return new AppSettings();
        }

        public async Task SaveAsync(AppSettings settings)
        {
            try
            {
                var json = JsonSerializer.Serialize(settings, JsonOpts);
                await _js.InvokeVoidAsync("localStorage.setItem", Key, json);
            }
            catch { }
        }
    }
}
