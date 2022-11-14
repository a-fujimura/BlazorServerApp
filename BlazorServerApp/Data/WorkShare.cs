using System.Text.Json.Serialization;
namespace BlazorServerApp.Data
{
    public class WorkShare
    {
        [JsonPropertyName("id")]
        public int Id { get; set; } = -1;
        [JsonPropertyName("content")]
        public string Content { get; set; } = string.Empty;
    }
}
