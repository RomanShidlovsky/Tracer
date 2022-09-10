using System.Text.Json.Serialization;

namespace Tracer.Serialization.Json.Dtos
{
    [Serializable]
    public class TraceResultJsonDto
    {
        [JsonPropertyName("threads")]
        public List<ThreadInfoJsonDto> Threads { get; set; }

        public TraceResultJsonDto(List<ThreadInfoJsonDto> threads)
        {
            Threads = threads;
        }
    }
}
