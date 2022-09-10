namespace Tracer.Core.Models
{
    public class TraceResult
    {
        public IReadOnlyList<ThreadInfo> Threads { get; }

        public TraceResult(List<ThreadInfo> threads)
        {
            Threads = threads;
        }
    }
}
