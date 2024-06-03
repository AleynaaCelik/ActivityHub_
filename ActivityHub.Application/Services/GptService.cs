using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ActivityHub.Application.Services
{
    public class GptService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public GptService()
        {
            _httpClient = new HttpClient();
            _apiKey = "-";
        }
        public async Task<string> GenerateQuestionsForPromptAsync(string promptRequest)
        {
            var requestContent = new StringContent(
                JsonSerializer.Serialize(new
                {
                    model = "gpt-3.5-turbo",
                    messages = new[]
                    {
                        
                        new { role = "user", content = $"{promptRequest}" }
                    },
                    max_tokens = 150
                }),
                Encoding.UTF8,
                "application/json");

            string key = _apiKey;

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", key);

            var response = await _httpClient.PostAsync("https://api.openai.com/v1/chat/completions", requestContent);

            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }
    }
}
