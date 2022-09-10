using System.Text.Json.Serialization;

namespace Tracer.Serialization.Json.Dtos
{
    [Serializable]
    public class ThreadInfoJsonDto
    {
        [JsonPropertyName("id")]
        public int ThreadId { get; set; }
        [JsonPropertyName("time")]
        public long Time { get; set; }
        [JsonPropertyName("methods")]
        public List<MethodInfoJsonDto> Methods { get; set; }
    }
}
