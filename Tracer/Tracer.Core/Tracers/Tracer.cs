using System.Collections.Concurrent;
using Tracer.Core.Models;
using Tracer.Core;

namespace Tracer.Core.Tracers
{
    public class Tracer : ITracer<TraceResult>
    {
        private ConcurrentDictionary<int, ThreadTracer> _threads = new ConcurrentDictionary<int, ThreadTracer>();

        public void StartTrace()
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            if (!_threads.ContainsKey(threadId))
            {
                ThreadTracer threadTracer = new ThreadTracer();
                _threads.TryAdd(threadId, threadTracer);
                threadTracer.StartTrace();
            }
            else
            {
                _threads[threadId].StartTrace();
            }
        }

        public void StopTrace()
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            if (_threads.ContainsKey(threadId))
            {
                _threads[threadId].StopTrace();
            }
        }

        public TraceResult GetTraceResult()
        {
            List<ThreadInfo> threads = new();
            
            foreach (var thread in _threads)
            {
                threads.Add(thread.Value.GetTraceResult());
            }

            return new TraceResult(threads);
        }
    }
}
