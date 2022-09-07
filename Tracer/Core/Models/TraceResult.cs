using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer.Core.Models
{
    public class TraceResult
    {
        public IReadOnlyList<ReadOnlyThreadInfo> Threads { get; }

        public TraceResult(List<ReadOnlyThreadInfo> threads)
        {
            Threads = threads;
        }
    }
}
