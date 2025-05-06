using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace FerramentaAPI.Infra.Logs
{
    public class DiscordLogs
    {
        private readonly string _webhookUrl;
        private static readonly HttpClient _httpClient = new HttpClient();

        public DiscordLogs(string webhookUrl)
        {
            _webhookUrl = webhookUrl;
        }

        public async Task LogsAsync(string message, string level = "INFO")
        {
            var payload = new {
                content = $"**[{level}]** {message}"
            };

            string json = JsonSerializer.Serialize(payload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(_webhookUrl, content);

            if (!response.IsSuccessStatusCode) {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Falha ao enviar log para o Discord: {errorContent}");
            }
        }
    }
}
