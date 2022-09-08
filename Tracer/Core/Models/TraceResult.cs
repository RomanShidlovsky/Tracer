using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
