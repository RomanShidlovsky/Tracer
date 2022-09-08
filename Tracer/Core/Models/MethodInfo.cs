using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer.Core.Models
{
    public class MethodInfo
    {
        public string Name { get; set; }
        public string ClassName { get; set; }
        public long Time { get; set; }
        public List<MethodInfo> Methods { get; set; }
        
        public MethodInfo(string name="", string className="", long time=0)
        {
            Name = name;
            ClassName = className;
            Time = time;
            Methods = new List<MethodInfo>();
        }
    }
}
