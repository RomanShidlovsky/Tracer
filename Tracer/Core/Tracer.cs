using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Tracer.Core
{
    public class Tracer : ITracer
    {
        private class ThreadResource
        {
            public Stopwatch stopwatch;
            public ThreadInfo threadInfo;
            public ThreadResource(Stopwatch stopwatch, ThreadInfo threadInfo)
            {
                this.stopwatch = stopwatch;
                this.threadInfo = threadInfo;
            }
        }
        
        private ConcurrentDictionary<int, ThreadResource> _resources = new ConcurrentDictionary<int, ThreadResource>();
        public void StartTrace()
        {
            var threadId = Thread.CurrentThread.ManagedThreadId;
            if (!_resources.ContainsKey(threadId))
            {
                var sw = Stopwatch.StartNew();
                var threadInfo = new ThreadInfo(threadId);
                var threadResource = new ThreadResource(sw, threadInfo);
                _resources.TryAdd(threadId, threadResource);
            }
            else
            {
                var sw = _resources[threadId].stopwatch;
                sw.Reset();
                sw.Start();
            }
        }

        public void StopTrace()
        {
            var threadId = Thread.CurrentThread.ManagedThreadId;
            
            var sw = _resources[threadId].stopwatch;
            sw.Stop();

            _resources[threadId].threadInfo.Time += sw.ElapsedMilliseconds;

            var stackTrace = new StackTrace();
            var stackFrame = stackTrace.GetFrame(1);
            var method = stackFrame.GetMethod();

            var info = new MethodInfo(method.Name, method.DeclaringType.Name, sw.ElapsedMilliseconds);
            AddToTree(info);
        }

        public TraceResult GetTraceResult()
        {
            var threadList = new List<ThreadInfo>();
            foreach (var resource in _resources)
            {
                threadList.Add(resource.Value.threadInfo);
            }
            return new TraceResult(threadList);
        }


    }
}
