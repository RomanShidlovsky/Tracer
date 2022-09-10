using System.Text.Json.Serialization;


namespace Tracer.Serialization.Json.Dtos
{
    [Serializable]
    public class MethodInfoJsonDto
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("class")]
        public string ClassName { get; set; }
        [JsonPropertyName("time")]
        public long Time { get; set; }
        [JsonPropertyName("methods")]
        public List<MethodInfoJsonDto> Methods { get; set; }
    }
}
