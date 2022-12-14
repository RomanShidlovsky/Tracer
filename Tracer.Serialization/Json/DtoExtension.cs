using System.Linq;
using Tracer.Serialization.Json.Dtos;
using Tracer.Core.Models;

namespace Json
{
    internal static class DtoExtension
    {
        public static MethodInfoJsonDto ToDto(this MethodInfo methodInfo)
        {
            return new MethodInfoJsonDto()
            {
                Name = methodInfo.Name,
                ClassName = methodInfo.ClassName,
                Time = $"{methodInfo.Time}ms"
            };
        }

        public static ThreadInfoJsonDto ToDto(this ThreadInfo threadInfo)
        {
            var methodDto = new MethodInfoJsonDto();
            var methodsRoot = new MethodInfo((List<MethodInfo>)threadInfo.Methods);
            CopyMethods(methodsRoot, methodDto);

            return new ThreadInfoJsonDto()
            {
                ThreadId = $"{threadInfo.ThreadId}",
                Time = $"{threadInfo.Time}ms",
                Methods = methodDto.Methods
            };
        
        }

        public static TraceResultJsonDto ToDto(this TraceResult traceResult)
        {
            return new TraceResultJsonDto(traceResult.Threads.Select(x => x.ToDto()).ToList());
        }

        public static void CopyMethods(MethodInfo methodInfo, MethodInfoJsonDto dto)
        {
            dto.Methods = methodInfo.Methods.Select(x => x.ToDto()).ToList();

            for(var i = 0; i < dto.Methods.Count; i++)
            {
                CopyMethods(methodInfo.Methods[i], dto.Methods[i]);
            }
        }
    }
}
