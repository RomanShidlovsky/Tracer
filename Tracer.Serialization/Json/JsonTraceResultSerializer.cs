using System.Text.Json;
using System.Text;
using Tracer.Serialization.Abstractions;
using Tracer.Core.Models;

namespace Json
{
    public class JsonTraceResultSerializer : ITraceResultSerializer
    {
        public string Extension { get; } = "json";

        public void Serialize(TraceResult traceResult, Stream to)
        {
            var dto = traceResult.ToDto();
            var options = new JsonSerializerOptions { WriteIndented = true };
            var res = JsonSerializer.Serialize(dto, options);
            
            to.Write(Encoding.Default.GetBytes(res));
        }
    }
}
