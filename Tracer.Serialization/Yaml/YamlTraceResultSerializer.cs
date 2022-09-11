using System.Text;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using Tracer.Core.Models;
using Tracer.Serialization.Abstractions;


namespace Yaml
{
    public class YamlTraceResultSerializer : ITraceResultSerializer
    {
        public string Extension { get; } = "yaml";

        public void Serialize(TraceResult traceResult, Stream to)
        {
            var dto = traceResult.ToDto();

            var serializer = new SerializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();

            var res = serializer.Serialize(dto);
            to.Write(Encoding.Default.GetBytes(res));
        }
    }
}
