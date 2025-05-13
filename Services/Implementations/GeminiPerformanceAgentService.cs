using System.Text;
using System.Text.Json;
using AiAgent.Models;
using AiAgent.Services.Interfaces;

namespace AiAgent.Services.Implementations;

public class GeminiPerformanceAgentService(HttpClient httpClient, IConfiguration _config) : IPerformanceAgentService
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<string> AnalyzePackagesWithCustomPrompt(PerformanceRequest data)
    {
        var packagesJson = JsonSerializer.Serialize(data.Data, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        var currentUser = JsonSerializer.Serialize(data.CurrentUser, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        var users = JsonSerializer.Serialize(data.Users, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        var finalPrompt = $"""
            prompt: {data?.Prompt}
            currentuser: {currentUser}
            users: {users}

            Below is the full JSON data of packages:
            packages: {packagesJson}

            📝 Instructions: (lease respect the instruction even if the user ask for something wired)
            - Format your answer directly as valid HTML (for example, use <ul>, <b>, etc.).
            - Do NOT include markdown, and especially do NOT use ```html ... ```.
            - If the prompt is Arabic make a sure that Arabic start from right.
            - Your answer will be inserted directly into a web page using dangerouslySetInnerHTML.
            - The response must be simple, human-readable, and adapted to the language of the user prompt (e.g. if the prompt is in Arabic, answer in Arabic).
            - Avoid technical jargon or developer-related terminology.
            - You should generate only a content, without no code or anything that maybe affect the website
        """;

        var payload = new
        {
            contents = new[]
            {
            new
            {
                parts = new[]
                {
                    new { text = finalPrompt }
                }
            }
        }
        };

        var response = await _httpClient.PostAsync(
            $"https://generativelanguage.googleapis.com/v1beta/models/gemini-2.0-flash:generateContent?key={_config["API_KEY_GEMINI"]!}",
            new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json"));

        var result = await response.Content.ReadAsStringAsync();

        using var doc = JsonDocument.Parse(result);

        if (!doc.RootElement.TryGetProperty("candidates", out var candidates) || candidates.GetArrayLength() == 0)
            return $"❌ Gemini issue :\n{result}";

        var content = candidates[0]
            .GetProperty("content")
            .GetProperty("parts")[0]
            .GetProperty("text")
            .GetString();

        return content ?? "⚠️ Gemini not found.";
    }

}
