namespace Tracer.Core.Models
{
    public class ThreadInfo
    {
        public int ThreadId { get; }
        public long Time { get; }
        public IReadOnlyList<MethodInfo> Methods { get; }

        public ThreadInfo(int threadId, long time, List<MethodInfo> methods)
        {
            ThreadId = threadId;
            Time = time;
            Methods = methods;
        }
    }
}
