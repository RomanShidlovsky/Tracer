using Tracer.Core.Models;

namespace Tracer.Serialization.Abstractions
{
    public interface ITraceResultSerializer
    {
        string Extension { get; }
        void Serialize(TraceResult traceResult, Stream to);
    }
}
