using System.Text.Json.Serialization;

namespace Tracer.Serialization.Json.Dtos
{
    [Serializable]
    public class ThreadInfoJsonDto
    {
        [JsonPropertyName("id")]
        public string ThreadId { get; set; }
        [JsonPropertyName("time")]
        public string Time { get; set; }
        [JsonPropertyName("methods")]
        public List<MethodInfoJsonDto> Methods { get; set; }
    }
}
