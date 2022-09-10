using System.Diagnostics;
using Tracer.Core.Models;

namespace Tracer.Core.Tracers
{
    public class ThreadTracer : ITracer <ThreadInfo>
    {
        private class MethodResource
        {
            public MethodInfo MethodInfo { get; set; }
            public MethodTracer MethodTracer { get; set; }

            public MethodResource(MethodInfo methodInfo)
            {
                MethodInfo = methodInfo;
                MethodTracer = new MethodTracer();
            }
        }

        private readonly int _frameNumber = 3;
        private Stack<MethodResource> _resources = new();
        private List<MethodInfo> _rootMethods = new();

        public void StartTrace()
        {    
            MethodInfo info = GetMethodInfo();
            MethodResource methodResource = new(info);
            _resources.Push(methodResource);
            methodResource.MethodTracer.StartTrace();
        }

        public void StopTrace()
        {
            if(_resources.TryPop(out MethodResource? child))
            {
                MethodInfo info = child.MethodInfo;
                
                child!.MethodInfo.SetTime(child.MethodTracer.GetTraceResult());
                if(_resources.TryPeek(out MethodResource? parent))
                {
                    parent.MethodInfo.AddMethod(child.MethodInfo);
                }
                else
                {
                    _rootMethods.Add(child.MethodInfo);
                }
            }
        }

        public ThreadInfo GetTraceResult()
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            long time = 0;
            foreach (var method in _rootMethods)
            {
                time += method.Time;
            }

            return new ThreadInfo(threadId, time, _rootMethods);
        }

        private MethodInfo GetMethodInfo()
        {
            StackTrace stackTrace = new();
            StackFrame? stackFrame = stackTrace.GetFrame(_frameNumber);

            if (stackFrame != null)
            {
                var method = stackFrame.GetMethod();
                return new MethodInfo(method!.Name, method!.DeclaringType!.Name);
            }
            return new MethodInfo();
        }
    }
}
